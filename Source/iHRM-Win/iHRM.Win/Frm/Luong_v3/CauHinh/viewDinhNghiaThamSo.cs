using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class viewDinhNghiaThamSo : frmBase
    {
        DataTable dtData;
        dlgDinhNghiaThamSo dlgEditor = new dlgDinhNghiaThamSo();
        private class KieuDuLieu
        {
            public string Ten { get; set; }
            public int kieuDuLieu { get; set; }
        }
        public viewDinhNghiaThamSo()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            List<KieuDuLieu> arrKDL = new List<KieuDuLieu>();
            arrKDL.Add(new KieuDuLieu { Ten = "Nhập tay", kieuDuLieu = 1 });
            arrKDL.Add(new KieuDuLieu { Ten = "Tự động từ module khác", kieuDuLieu = 2 });
            arrKDL.Add(new KieuDuLieu { Ten = "Được tính toán", kieuDuLieu = 3 });
            repositoryItemLookUpEdit1.DataSource = arrKDL;
            List<KieuDuLieu> arrKDL2 = new List<KieuDuLieu>();
            arrKDL2.Add(new KieuDuLieu { Ten = "Số", kieuDuLieu = 1 });
            arrKDL2.Add(new KieuDuLieu { Ten = "Chữ", kieuDuLieu = 2 });
            repositoryItemLookUpEdit2.DataSource = arrKDL2;

            btnFind_Click(null, null);
            LoadGrvLayout(grv);
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu tham số tính lương...";
            dw_it.OnDoing = (s,ev) => 
            {
                dtData = Provider.ExecuteDataTableReader("p_ThamSo_viewTs");
                dw_it.bw.ReportProgress(1);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = dtData;
                btnFind.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void grv_DoubleClick(object sender, EventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            grv.OptionsView.ShowPreview = checkEdit1.Checked;
        }
    }
}
