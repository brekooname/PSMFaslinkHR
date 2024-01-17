using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using iHRM.Win.Frm.LogAction;
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

namespace iHRM.Win.Frm.Employee
{
    public partial class ImportPhepNamNamCu : frmBase
    {
        dcDatabaseDataContext db;

        DataTable LstData;

        List<DevExpress.XtraGrid.Columns.GridColumn> LstCol;
        List<ActionClass> _lActionClass = new List<ActionClass>();

        i_Import.FixImporter importer = null;

        public ImportPhepNamNamCu()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
           
           
            LoadGrvLayout(bandedGridView1);

            #region phân quyền
            toolStripButton4.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);

            btnImport.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Import);

            btnSave.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Save);

            btnFind.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Find);
            #endregion

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            btnFind.Enabled = false;

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();

            dw_it.Caption = "Đang tải dữ liệu nhân viên...";

            dw_it.OnDoing = (s, ev) =>
            {
               

                if (!string.IsNullOrEmpty(chonPhongBan1.SelectedValue))
                {
                    LstData = Provider.ExecuteDataTableReader("p_GetPhepNam",           
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue));
                }
                else
                    LstData = Provider.ExecuteDataTableReader("p_GetPhepNam");



                dw_it.bw.ReportProgress(1, LstData);

             
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState; btnFind.Enabled = true;
                }
                
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(bandedGridView1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (LstData.GetChanges(DataRowState.Modified) == null || LstData.GetChanges(DataRowState.Modified).Rows.Count <= 0)
                {
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);

                    return;
                }

                foreach (DataRow r in LstData.GetChanges(DataRowState.Modified).Rows)
                {

                    _lActionClass.Add(new ActionClass("Cập nhập ngày phép", r["EmployeeID"].ToString(), "", "Dữ liệu ngày phép năm cũ của NV " + r["EmployeeID"].ToString() + " với ngày phép năm còn " + r["AnnualLeave_OldYear"].ToString() + " hết hạn vào ngày " + r["AnnualLeave_ExpireDate"].ToString(), "tblEmployee"));
                    LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();

                   Provider.ExecNoneQuery("p_UpdatePhepNam",
                       new SqlParameter("EmployeeID", DbHelper.DrGet(r, "EmployeeID")),
                       new SqlParameter("SoNgay", DbHelper.DrGet(r, "AnnualLeave_OldYear")),
                       new SqlParameter("NgayHetHan", DbHelper.DrGet(r, "AnnualLeave_ExpireDate"))
                       );
                }


                btnFind_Click(null, null);

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (importer == null)
            {
                importer = new i_Import.FixImporter();

                importer.OnDownLoadFileTemplate += importer_OnDownLoadFileTemplate;

                importer.OnImportData += Importer_OnImportData;
            }

            importer.ShowDialog();
        }
        private void importer_OnDownLoadFileTemplate(string fPath)
        {
            //lấy file mẫu
            ExcelExtend ex = new ExcelExtend();

            ex.OpenFile(Path.Combine(win_globall.apppath, @"ExcelTemplate\Employee\impNgayPhep.xlsx"));

            //In thông tin cột có sử dụng
            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            //in dữ liệu có sẵn
            var ret = Provider.ExecuteDataTableReader("p_GetPhepNam",               
                new SqlParameter("phongban_id", chonPhongBan1.SelectedValue)
            );

            for (int j = 0; j < ret.Rows.Count; j++)
            {
                var r = ret.Rows[j];

                ex.WriteToCell(2 + j, 0, DbHelper.DrGet(r, "EmployeeID"));

                ex.WriteToCell(2 + j, 1, DbHelper.DrGet(r, "EmployeeName"));

                ex.WriteToCell(2 + j, 2, DbHelper.DrGet(r, "AppliedDate"));

                ex.WriteToCell(2 + j, 3, DbHelper.DrGet(r, "PosName"));

                ex.WriteToCell(2 + j, 4, DbHelper.DrGet(r, "DepName_Final"));

                ex.WriteToCell(2 + j, 5, DbHelper.DrGet(r, "AnnualLeave_OldYear"));

                ex.WriteToCell(2 + j, 6, DbHelper.DrGet(r, "AnnualLeave_ExpireDate"));
              
            }

            //lưu file vào vị trí download
            ex.Save(fPath);
        }
        private void Importer_OnImportData(DataTable obj)
        {
            try
            {
                if (importer.dtDataExcelImported.Rows.Count > 0)

                    importer.dtDataExcelImported.Rows.RemoveAt(0);

                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("EmployeeID", typeof(string)));

                dt.Columns.Add(new DataColumn("AnnualLeave_OldYear", typeof(float)));
                dt.Columns.Add(new DataColumn("AnnualLeave_ExpireDate", typeof(DateTime)));

                foreach (DataRow it in importer.dtDataExcelImported.Rows)
                {
                    var dr = dt.NewRow();

                    dr["EmployeeID"] = DbHelper.DrGet(it, "EmployeeID");
                    dr["AnnualLeave_OldYear"] = DbHelper.DrGet(it, "AnnualLeave_OldYear");
                    dr["AnnualLeave_ExpireDate"] = DbHelper.DrGet(it, "AnnualLeave_ExpireDate"); 

                    dt.Rows.Add(dr);
                }
                foreach (DataRow r in dt.Rows)
                {
                    if (r["EmployeeID"].ToString().Trim() != "")
                    {
                        DataTable dtcheck = Provider.ExecuteDataTable("p_GetPhepNamByEmpID", new SqlParameter("EmployeeID", r["EmployeeID"].ToString().Trim()));
                        if (dtcheck.Rows.Count > 0)
                        {
                            if (dtcheck.Rows[0]["AnnualLeave_OldYear"].ToString() == "" || dtcheck.Rows[0]["AnnualLeave_OldYear"].ToString() == "0")
                            {
                                _lActionClass.Add(new ActionClass("Cập nhập ngày phép", r["EmployeeID"].ToString(), "", "Dữ liệu phép năm cũ của NV " + r["EmployeeID"].ToString() + " với ngày phép năm còn " + r["AnnualLeave_OldYear"].ToString() + " hết hạn vào ngày " + r["AnnualLeave_ExpireDate"].ToString(), "tblEmployee"));
                            }
                            else
                            {
                                _lActionClass.Add(new ActionClass("Xóa dữ liệu cũ", dtcheck.Rows[0]["EmployeeID"].ToString(), "", "Phép năm cũ bị xóa của NV " + dtcheck.Rows[0]["EmployeeID"].ToString() + " với ngày phép năm còn " + dtcheck.Rows[0]["AnnualLeave_OldYear"].ToString() + " hết hạn vào ngày " + dtcheck.Rows[0]["AnnualLeave_ExpireDate"].ToString(), "tblEmployee"));
                                _lActionClass.Add(new ActionClass("Cập nhập ngày phép", r["EmployeeID"].ToString(), "", "Dữ liệu phép năm cũ của NV " + r["EmployeeID"].ToString() + " với ngày phép năm còn " + r["AnnualLeave_OldYear"].ToString() + " hết hạn vào ngày " + r["AnnualLeave_ExpireDate"].ToString(), "tblEmployee"));
                            }
                        }
                        else
                        {
                            _lActionClass.Add(new ActionClass("Cập nhập ngày phép", r["EmployeeID"].ToString(), "", "Dữ liệu phép năm cũ của NV " + r["EmployeeID"].ToString() + " với ngày phép năm còn " + r["AnnualLeave_OldYear"].ToString() + " hết hạn vào ngày " + r["AnnualLeave_ExpireDate"].ToString(), "tblEmployee"));
                        }
                    }
                }
                LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();
                var ret = Provider.ExecNoneQuery("p_NgayPhepNam_UpdateMulti",
                    new SqlParameter("data", SqlDbType.Structured) { TypeName = "LST_nhapNgayPhep", Value = dt }
                );
                
                importer.OutLog_DuringImport("Nhập liệu hoàn tất (" + dt.Rows.Count + ")");

                this.Invoke(new Action(() => { GUIHelper.Notifications("Nhập liệu hoàn tất (" + dt.Rows.Count + ")", "", GUIHelper.NotifiType.tick); }));
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
            btnFind_Click(null, null);
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {

                var dg = MessageBox.Show("Dữ liệu của nhóm đang chọn trong năm sẽ được xóa đi và khởi tạo lại!\r\nBạn chắc chắn chứ?"
                    , "Xóa tất cả các yêu cầu đang chọn"
                    , MessageBoxButtons.OKCancel);

                if (dg == DialogResult.OK)
                {
                    var dg2 = MessageBox.Show("Sẽ không khôi phục dữ liệu khi xóa!", "Cảnh báo", MessageBoxButtons.OKCancel);

                    if (dg2 == DialogResult.OK)
                    {


                        Provider.ExecNoneQuery("p_DeletePhepNam",
                            new SqlParameter("phongban_id", chonPhongBan1.SelectedValue)
                        );

                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);

                      DataTable dtlog=((DataTable)grd.DataSource).Copy();
                        foreach(DataRow dr in dtlog.Rows)
                        {

                            _lActionClass.Add(new ActionClass("Xóa", dr["EmployeeID"].ToString(), "", "Xóa dữ liệu phép năm cũ của NV " + dr["EmployeeID"].ToString() + " với ngày phép năm còn " + dr["AnnualLeave_OldYear"].ToString() + " hết hạn vào ngày " + dr["AnnualLeave_ExpireDate"].ToString(), "tblEmployee"));
                        
                        }

                        LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                if (globall.indebug)

                    GUIHelper.MessageBox(ex.Message);
            }
            btnFind_Click(null, null);
        }

        private void bandedGridView1_KeyDown(object sender, KeyEventArgs e)
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
