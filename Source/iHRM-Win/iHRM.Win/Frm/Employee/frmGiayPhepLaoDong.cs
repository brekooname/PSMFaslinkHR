using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Helper;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Win.Frm.Report;
using iHRM.Win.Frm.QuetThe;
using DevExpress.Skins;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Win.ExtClass;
namespace iHRM.Win.Frm.Employee
{
    public partial class frmGiayPhepLaoDong : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        DataTable dtData = new DataTable();
        DataRow CRow;
        dlgGiayPhepLaoDong dlgEditor;
        public static string strFunction = "";
        public frmGiayPhepLaoDong()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s, ev) =>
            {
                dtData = Provider.ExecuteDataTable("p_tblGiayPhepLaoDong_GetAll", new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text), new System.Data.SqlClient.SqlParameter("tuNgay", chonKyLuong1.TuNgay), new System.Data.SqlClient.SqlParameter("denNgay", chonKyLuong1.DenNgay));

                dw_it.bw.ReportProgress(1, dtData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState;
                    btnFind.Enabled = true;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));
            //if (drs.Count() == 0)
            //{
            //    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
            //    return;
            //}
            //else
            //{
            //    if (GUIHelper.ConfirmBox("Bạn có chắc chắn muốn xóa nhân viên đã chọn " + drs.First()["hoTen"]))
            //    {
            //        db = new dcDatabaseDataContext(Provider.ConnectionString);
            //        var lst = db..Where(i => drs.Select(j => j[TableConst.tblEmployee.EmployeeID] as string).Contains(i.EmployeeID));

            //        if (lst == null || lst.Count() == 0)
            //        {
            //            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
            //            return;
            //        }
            //        try
            //        {
            //            db.tblUngViens.DeleteAllOnSubmit(lst);
            //            db.SubmitChanges();

            //            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
            //            grv.DeleteSelectedRows();
            //        }
            //        catch (Exception ex)
            //        {
            //            win_globall.ExecCatch(ex);
            //        }
            //    }
            //}
        }
        void ShowEditor()
        {
            if (dlgEditor == null)
            {
                dlgEditor = new dlgGiayPhepLaoDong();
                dlgEditor.Owner = this;
                dlgEditor.OnSave += dlgEditor_OnSave;
            }
            dlgEditor.Show();
        }

        void dlgEditor_OnSave(object sender, EventArgs e)
        {
            try
            {
                db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
                tblGiayPhepLaoDong gp;
                if (strFunction == "add")
                {
                    gp = new tblGiayPhepLaoDong();
                }
                else
                {
                    gp = db.tblGiayPhepLaoDongs.Where(p => p.id.ToString() == dlgEditor.myID.ToString()).Single();
                }
                // Thông tin chung:
                gp.hoTen =dlgEditor.MyValue["hoTen"] as string;
                gp.soGiayPhep = dlgEditor.MyValue["soGiayPhep"] as string;
                gp.EmployeeID = dlgEditor.MyValue["EmployeeID"] as string;
                gp.soHoChieu = dlgEditor.MyValue["soHoChieu"] as string;
                gp.toChucLamViec = dlgEditor.MyValue["toChucLamViec"] as string;
                gp.noiLamViec = dlgEditor.MyValue["noiLamViec"] as string;
                gp.viTriCongViec = dlgEditor.MyValue["viTriCongViec"] as string;
                gp.trinhDoChuyenMon = dlgEditor.MyValue["trinhDoChuyenMon"] as string;
                gp.gioiTinh = dlgEditor.MyValue["gioiTinh"] as string;

                gp.BeginDate = dlgEditor.MyValue["BeginDate"] as DateTime?;
                gp.EndDate = dlgEditor.MyValue["EndDate"] as DateTime?;
                gp.ngayKy = dlgEditor.MyValue["ngayKy"] as DateTime?;
                gp.noiKy = dlgEditor.MyValue["noiKy"] as string;
                gp.ngaySinh = dlgEditor.MyValue["ngaySinh"] as DateTime?;

                if (strFunction == "add")
                {
                    var aa = db.tblGiayPhepLaoDongs.Where(p => p.id.ToString() == dlgEditor.MyValue["id"].ToString()).ToList();
                    if (aa.Count == 0)
                    {
                        db.tblGiayPhepLaoDongs.InsertOnSubmit(gp);
                        db.SubmitChanges();
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    }
                    else
                    {
                        db.SubmitChanges();
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                    }
                }
                else
                {
                    // Sửa thì chuyển trạng thái thành edited
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
        private void btnThemNV_Click_Click(object sender, EventArgs e)
        {
            strFunction = "add";
            ShowEditor();
            var r = dtData.NewRow();
            dlgEditor.MyValue = r;
        }
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            if (grv.FocusedRowHandle != -1)
            {
                CRow = grv.GetFocusedDataRow();
                strFunction = "edit";
                ShowEditor();
                dlgEditor.MyValue = CRow;
            }
        }

        private void grd_DataSourceChanged(object sender, EventArgs e)
        {
            CRow = grv.GetFocusedDataRow();
        }

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
        }

        private void txtSearchKey_Leave(object sender, EventArgs e)
        {
            btnFind_Click(sender, e);
        }

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grd.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }
    }
}
