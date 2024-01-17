﻿using DevExpress.XtraEditors;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe.CongGia
{
    public partial class frmLayDuLieu : XtraForm
    {
        public frmLayDuLieu()
        {
            InitializeComponent();
        }

        private void btnLayDuLieuThat_Click(object sender, EventArgs e)
        {
            if (IsLock.IsLock.Check_IsLock("tbKetQuaQuetThe_Fake", chonKyLuong1.TuNgay) || IsLock.IsLock.Check_IsLock("tbKetQuaQuetThe_Fake", chonKyLuong1.DenNgay))
            {
                GUIHelper.MessageBox(string.Format("Dữ liệu đã chốt công từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy} khổng thể thao tác!", chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                return;
            }
            if (chonPhongBan1.SelectedValue == null)
            {
                GUIHelper.MessageBox("Vui lòng chon phòng ban!");
                return;
            }
            var a = Provider.ExecNoneQuery("p_GetDuLieuGia",
                new System.Data.SqlClient.SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                new System.Data.SqlClient.SqlParameter("denNgay", chonKyLuong1.DenNgay),
                new System.Data.SqlClient.SqlParameter("phongban", chonPhongBan1.SelectedValue));
            if (a >= 0)
            {
                LogAction.LogAction.PushLog("Analyze", "", "", string.Format("Lấy dữ liệu công BH từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", chonKyLuong1.TuNgay, chonKyLuong1.DenNgay), "tbKetQuaQuetThe_Fake");
                GUIHelper.Notifications("Lấy dữ liệu thành công", "Lấy dữ liệu", GUIHelper.NotifiType.tick);
            }
        }
        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new System.Data.SqlClient.SqlParameter("CtrName", nameCrt),

                           new System.Data.SqlClient.SqlParameter("FormName", this.Name.ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                //có dữ liệu cho dùng chung
                if (ds.Tables[1].Rows.Count == 0)
                {
                    //không dùng riêng
                    return ds.Tables[0].Rows[0][lang].ToString().Trim();

                }
                else
                {
                    // có dùng riêng 
                    return ds.Tables[1].Rows[0][lang].ToString().Trim();
                }
            }
            else
            {
                return "";
            }

        }
        private void frmLayDuLieu_Load(object sender, EventArgs e)
        {
            this.Text = SelectTranslate("frmLayDuLieuFake_title", LoginHelper.langTrans);
            btnLayDuLieuThat.Text = SelectTranslate("frmLayDuLieuFake_nut", LoginHelper.langTrans);
        }
    }
}