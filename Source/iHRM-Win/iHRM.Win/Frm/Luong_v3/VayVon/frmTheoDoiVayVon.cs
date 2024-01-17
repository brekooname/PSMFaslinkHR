using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3.VayVon
{
    public partial class frmTheoDoiVayVon : frmBase
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
        List<tbVayVon_lichSuTra> LstData;
        
        public frmTheoDoiVayVon()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            txtThangBatDau.EditValue = DateTime.Today;

            btnFind_Click(null, null);
            LoadGrvLayout(grv);

            toolStripButton2.Enabled = BitHelper.Has(iRule.customRules ?? 0, 1);
            btnAdd.Enabled = BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu tham số tính lương...";
            dw_it.OnDoing = (s,ev) => 
            {
                var thang = new DateTime(txtThangBatDau.DateTime.Year, txtThangBatDau.DateTime.Month, 1);
                var qry = db.tbVayVon_lichSuTras.Where(i => i.ngayThanhToan == thang);
                
                LstData = qry.ToList();
                dw_it.bw.ReportProgress(1, LstData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = new BindingList<tbVayVon_lichSuTra>(LstData);
                btnFind.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var thang = new DateTime(txtThangBatDau.DateTime.Year, txtThangBatDau.DateTime.Month, 1);
                Provider.ExecNoneQuery("p_vayvon_taoTheoDoiThang", new SqlParameter("thang", thang));
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
                btnFind_Click(null, null);

                var log = Log2.CreateLog(Log2.Log2Action.them, string.Format("Khởi tạo dữ liệu vay vốn tháng {0:MM/yyyy}", thang), "Theo dõi Vay Vốn");
                log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "thang",
                    value1 = string.Format("{0:MM/yyyy}", thang)
                });
                Log2.PushLog(log);


            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }
        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa?"))
                return;

            try
            {
                var lst = grv.GetSelectedRows().Select(i => grv.GetRow(i) as tbVayVon_lichSuTra);
                db.tbVayVon_lichSuTras.DeleteAllOnSubmit(lst);
                db.SubmitChanges();

                grv.DeleteSelectedRows();
                //grd.RefreshDataSource();
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);

                var log = Log2.CreateLog(Log2.Log2Action.xoa, "Xóa " + lst.Count() + " bản ghi", "Theo doi Vay Vốn");
                log.tbLog2_details.AddRange(lst.Select(i => new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "id",
                    target2 = "ten",
                    value1 = i.id.ToString(),
                    value2 = i.tenNV
                }).ToArray());
                Log2.PushLog(log);

            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }

        private void grv_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == gridColumn6)
                {
                    var r = e.Row as tbVayVon_lichSuTra;
                    if (r != null && Enums.eTTVayVon_Alias.ContainsKey(r.status))
                        e.Value = Enums.eTTVayVon_Alias[r.status];
                }
            }
        }
        
    }
}
