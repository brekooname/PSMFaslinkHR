using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong
{
    public partial class frmCachTinhThueTNCN : frmBase
    {
        public frmCachTinhThueTNCN()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grvSoNgPT);
            toolStripButton1_Click(null, null);
        }
        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grvSoNgPT);
        }

        private void toolstripSave_Click(object sender, EventArgs e)
        {
            try
            {
                Provider.UpdateData((grcSoNgPT.DataSource as DataTable), "tbCachTinhThueTNCN");
                (grcSoNgPT.DataSource as DataTable).AcceptChanges();
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
            }
            catch (Exception)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditFalse);
            }
        }
        private void grvDK7h_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        private void grvDK7h_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colMaNV)
            {
                if (grvSoNgPT.GetRowCellValue(e.RowHandle, colMaNV) != null)
                {
                    string empID = grvSoNgPT.GetRowCellValue(e.RowHandle, colMaNV).ToString();
                    dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
                    var emp = db.tblEmployees.Where(p => p.EmployeeID == empID).FirstOrDefault();
                    if (emp != null)
                    {
                        grvSoNgPT.SetRowCellValue(e.RowHandle, colTenNV, emp.EmployeeName);
                    }
                }
            }
        }

        private void grvDK7h_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column == colXoa)
            {
                grvSoNgPT.DeleteSelectedRows();
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải công thức tính thuế thu nhật cá nhân";
            dw_it.OnDoing = (s, ev) =>
            {
                var data = Provider.ExecuteDataTableReader_SQL("SELECT * FROM tbCachTinhThueTNCN order by SoTienBatDau");
                dw_it.bw.ReportProgress(1, data);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grcSoNgPT.DataSource = data.UserState;
                    (grcSoNgPT.DataSource as DataTable).AcceptChanges();
                }
            };
            dw_it.OnCompleting = (s, a) =>
            {
                toolStripButton1.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }
    }
}
