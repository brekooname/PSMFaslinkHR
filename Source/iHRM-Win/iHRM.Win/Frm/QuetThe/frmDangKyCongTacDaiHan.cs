using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using iHRM.Win.Frm.LogAction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class frmDangKyCongTacDaiHan : frmBase
    {
        DataTable dt = new DataTable();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        dlgDangKyCongTacDaiHan dlgDKCTDH;
        List<ActionClass> _lActionClass = new List<ActionClass>();
        public frmDangKyCongTacDaiHan()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            if (LoginHelper.user.isAcceptBP == true || LoginHelper.user.isAdmin)
            {
                toolStripAccept.Visible = true;
                toolStripNotAccept.Visible = true;
                toolStripAcceptAll.Visible = true;
                toolStripGoDuyet.Visible = true;
                rdAccept.Visible = false;
            }
            else
            {
                toolStripAccept.Visible = false;
                toolStripNotAccept.Visible = false;
                toolStripAcceptAll.Visible = false;
                toolStripGoDuyet.Visible = false;
                rdAccept.Visible = true;
            }
            if (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin)
            {
                toolStripAccept_DA.Visible = true;
                toolStripNotAccept_DA.Visible = true;
                toolStripGoDuyetChotCong.Visible = true;
                rdAccept.Visible = true;
                toolStripButton_KhoaHan.Visible = true;
            }
            else
            {
                toolStripAccept_DA.Visible = false;
                toolStripGoDuyetChotCong.Visible = false;
                toolStripNotAccept_DA.Visible = false;
                rdAccept.Visible = false;
                toolStripButton_KhoaHan.Visible = false;
            }
            repQLDuyet.DataSource = db.w5sysUsers;
            LoadGrvLayout(grv);
            _lActionClass.Clear();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            dt = new DataTable();
            bool? isAccept = null;
            if (rdAccept.SelectedIndex == 1)
            {
                isAccept = true;
            }
            if (rdAccept.SelectedIndex == 2)
            {
                isAccept = false;
            }

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu đăng ký công tác...";
            dw_it.OnDoing = (s, ev) =>
            {
                dt = Provider.ExecuteDataTable(
                    "p_chamcong_GetData_DangKyCongTacDaiHan",
                    Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS2.GetValue()),
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                    new SqlParameter("isAccept", isAccept)
                );

                dw_it.bw.ReportProgress(1, dt);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = data.UserState;
                dt.AcceptChanges();
                btnFind.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it);
            _lActionClass.Clear();
        }

        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            grv.OptionsPrint.UsePrintStyles = false;
            ShowPreview(grd);
            //ExportGrid(grd);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả đăng ký công tác đang chọn?", "Xóa tất cả đăng ký công tác đang chọn", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();
                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        var isOK = true;
                        if (IsLock.IsLock.Check_IsLock("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString())))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            isOK = false;
                            continue;
                        }
                        if (r["isAcceptBP"] != DBNull.Value)
                        {
                            isOK = false;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            isOK = false;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            isOK = false;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            isOK = false;
                        }
                        if (!isOK)
                        {
                            GUIHelper.Notifications("Không thể xóa vì bản ghi này đã được duyệt hoặc không thuộc phòng ban của bạn.", "Xóa tất cả các yêu cầu đang chọn", GUIHelper.NotifiType.error);
                        }
                        else
                        {
                            grv.DeleteRow(rc[i - 1]);
                        }
                    }
                }
            }
        }
        private void grv_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var r = e.Row as DataRowView;
                if (r == null)
                    return;
            }
        }


        private void grv_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column == colXemFile)
            {
                FileStorageHelper fh = new FileStorageHelper();

                var a = grv.GetFocusedRowCellValue(colFile);
                var duoiFile = grv.GetFocusedRowCellValue(colDuoiFile).ToString();
                if (a != null && a.ToString() != "")
                {
                    Binary dataFile = new Binary(a as byte[]);
                    fh.DownLoadAndShowFILE(a as byte[], duoiFile);
                }
                else
                {
                    GUIHelper.Notifications("Không tìm thấy file.", "Xem file", GUIHelper.NotifiType.error);
                }
            }
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }
            dcDatabaseFilesDataContext dbFile = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);
            var count = dt.GetChanges().Rows.Count;
            string mnv = string.Empty;
            List<tblDangKyCongTacDaiHan> lst = new List<tblDangKyCongTacDaiHan>();
            try
            {
                foreach (DataRow dr in dt.GetChanges().Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        if (dr["idFile"] != DBNull.Value)
                        {
                            var a = dbFile.tbFiles.Where(p => p.id == Guid.Parse(dr["idFile"].ToString())).FirstOrDefault();
                            if (a == null)
                            {
                                a = new tbFile();
                                a.id = Guid.Parse(dr["idFile"].ToString());
                                dbFile.tbFiles.InsertOnSubmit(a);
                            }
                            if (dr["duoiFile"] == DBNull.Value)
                            {
                                a.duoiFile = null;
                            }
                            else
                                a.duoiFile = dr["duoiFile"].ToString();
                            if (dr["dataFile"] == DBNull.Value)
                            {
                                a.dataFile = null;
                            }
                            else
                                a.dataFile = dr["dataFile"] as byte[];
                            dbFile.SubmitChanges();
                        }
                        #region get data send mail
                       try
                       {
                           if (dr["isAcceptBP"] != DBNull.Value && dr["isAccept"] == DBNull.Value)
                           {
                               tblDangKyCongTacDaiHan ct = new tblDangKyCongTacDaiHan();
                               ct.EmployeeID = dr["EmployeeID"].ToString();
                               ct.id = Guid.Parse(dr["id"].ToString());
                               if ((bool)dr["isAcceptBP"])
                               {
                                   ct.ghiChuAccept = "1";
                               }
                               else
                               {
                                   ct.ghiChuAccept = "0";
                               }
                               lst.Add(ct);
                           }
                       }
                       catch { }
                        #endregion
                        if (dr.RowState == DataRowState.Added)
                        {
                            _lActionClass.Add(new ActionClass("Thêm dữ liệu", dr["EmployeeID"].ToString(), "", "Thêm dữ liệu đăng ký công tác dài hạn", "tblDangKyCongTacDaiHan"));
                        }
                    }
                    else
                    {
                        var empID = (string)dr["EmployeeID", DataRowVersion.Original];
                        _lActionClass.Add(new ActionClass("Xóa dữ liệu", empID, "", "Xóa dữ liệu đăng ký công tác dài hạn", "tblDangKyCongTacDaiHan"));
                    }
                }
                Provider.UpdateData(dt, "tblDangKyCongTacDaiHan");
                LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();
                #region gởi mail
                try
                {
                    foreach(tblDangKyCongTacDaiHan ct in lst)
                    {
                        tblDangKyCongTacDaiHan dcctdh = db.tblDangKyCongTacDaiHans.Where(p => p.EmployeeID == ct.EmployeeID && p.id == ct.id).FirstOrDefault();
                        if (dcctdh == null)
                            continue;
                        w5sysUser u = db.w5sysUsers.Where(p => p.id == dcctdh.idUserRequest).FirstOrDefault();
                        string NoiDung = string.Empty;
                        string TieuDe = "[THUANHAI - iHRM] - Đăng kí công tác - ";
                        tblEmployee employee = db.tblEmployees.Where(p => p.EmployeeID == dcctdh.EmployeeID).FirstOrDefault();
                        if (employee != null)
                        {
                            //tblEmployee employee = db.tblEmployees.First(p => p.EmployeeID == dcctdh.EmployeeID);
                            TieuDe += employee.EmployeeName + ",";
                            NoiDung += "==========//==========" + "\n";
                            NoiDung += "Mã Nhân viên: " + employee.EmployeeID + "\n";
                            NoiDung += "Tên nhân viên: " + employee.EmployeeName + "\n";
                            NoiDung += "Chức vụ: " + employee.EmpTypeName + "\n";
                            NoiDung += "Phòng ban: " + employee.DepName_Final + "\n";
                            NoiDung += "Nội dung: Đăng ký công tác" + "\n";
                            if (int.Parse(ct.ghiChuAccept) == 1)
                            {
                                NoiDung += "Trạng thái: Đã duyệt" + "\n";
                            }
                            if (int.Parse(ct.ghiChuAccept) == 0)
                            {
                                NoiDung += "Trạng thái: Không duyệt" + "\n";
                            }
                            NoiDung += "Thời gian: Từ ngày " + string.Format("{0: dd/MM/yyyy}", dcctdh.FromDate) + " Đến ngày " + string.Format("{0: dd/MM/yyyy}", dcctdh.ToDate) + "\n";
                            NoiDung += "iHRM - PSM Toàn Cầu" + "\n";
                            NoiDung += "==========//==========" + "\n";
                            TieuDe += ")";
                            TieuDe = TieuDe.Replace(",)", "");
                            if (u != null)
                            {
                                iHRM.Win.DungChung.Ham.SendMail(TieuDe, NoiDung, u.loginID);
                            }
                        }
                    }
                }
                catch
                { }
                #endregion

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception ex)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void toolStripAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các đăng ký công tác đang chọn?", "Duyệt đăng ký công tác", MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);
                frm.ShowDialog();

                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        {
                            continue;
                        }

                        r["isAcceptBP"] = true;
                        r["userAcceptBP"] = LoginHelper.user.id;
                        r["ngayAcceptBP"] = DateTime.Now;
                        r["ghiChuAcceptBP"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Duyệt", r["EmployeeID"].ToString(), "", "Duyệt đăng ký công tác dài hạn", "tblDangKyCongTacDaiHan"));
                    }
                }
            }
        }

        private void toolStripAcceptAll_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các đăng ký công tác?", "Duyệt đăng ký công tác", MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);
                frm.ShowDialog();

                for (int i = 0; i < grv.DataRowCount; i++)
                {
                    var r = grv.GetDataRow(i);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        {
                            continue;
                        }
                        if (r["isAcceptBP"] == DBNull.Value)
                        {

                            r["isAcceptBP"] = true;
                            r["userAcceptBP"] = LoginHelper.user.id;
                            r["ngayAcceptBP"] = DateTime.Now;
                            r["ghiChuAcceptBP"] = frm.reason;
                            _lActionClass.Add(new ActionClass("Duyệt tất cả", r["EmployeeID"].ToString(), "", "Duyệt tất cả đăng ký công tác dài hạn", "tblDangKyCongTacDaiHan"));
                        }

                    }
                }

            }
        }

        private void toolStripNotAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các đăng ký công tác đang chọn?", "Không duyệt đăng ký công tác", MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(false);
                frm.ShowDialog();

                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");
                            continue;
                        }

                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        {
                            continue;
                        }

                        r["isAcceptBP"] = false;
                        r["userAcceptBP"] = LoginHelper.user.id;
                        r["ngayAcceptBP"] = DateTime.Now;
                        r["ghiChuAcceptBP"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Không duyệt", r["EmployeeID"].ToString(), "", "Không duyệt đăng ký công tác dài hạn", "tblDangKyCongTacDaiHan"));
                    }
                }
            }
        }
        private void grv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && grv.GetRowCellValue(e.RowHandle, "isAcceptBP") != null && !string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString()))
            {
                if (grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString() == "True")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else if (grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString() == "False")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
            if (e.RowHandle >= 0 && grv.GetRowCellValue(e.RowHandle, "FromDate") != null && string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString()) && string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isHetHan").ToString()))
            {
                TimeSpan date = Convert.ToDateTime(DateTime.Now) - Convert.ToDateTime(grv.GetRowCellValue(e.RowHandle, "FromDate").ToString());
                if (date.Days >= 5 && (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin))
                {
                    e.Appearance.ForeColor = Color.MediumBlue;
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dlgDKCTDH != null)
            {
                dlgDKCTDH.ShowDialog();
            }
            else
            {
                dlgDKCTDH = new dlgDangKyCongTacDaiHan();
                dlgDKCTDH.ShowDialog();
            }
        }

        private void toolStripAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt đăng ký công tác đang chọn?", "Duyệt đăng ký công tác", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);
                frm.ShowDialog();

                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}

                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if ((r["isAcceptBP"] as bool? != true))
                        {
                            continue;
                        }
                        if ((r["isAccept"] as bool? == true))
                        {
                            continue;
                        }
                        if ((r["isHetHan"] != DBNull.Value))
                        {
                            continue;
                        }

                        r["isAccept"] = true;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayAccept"] = DateTime.Now;
                        r["ghiChuAccept"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Duyệt chốt công", r["EmployeeID"].ToString(), "", "Duyệt chốt công đăng ký công tác dài hạn", "tblDangKyCongTacDaiHan"));
                    }
                }
            }
        }

        private void toolStripNotAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các đăng ký công tác đang chọn?", "Không duyệt đăng ký công tác", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(false);

                frm.ShowDialog();
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}

                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }

                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if ((r["isAcceptBP"] as bool? != true))
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }

                        r["isAccept"] = false;
                        r["userAccept"] = LoginHelper.user.id;
                        r["ngayAccept"] = DateTime.Now;
                        r["ghiChuAccept"] = frm.reason;
                        _lActionClass.Add(new ActionClass("Không duyệt chốt công", r["EmployeeID"].ToString(), "", "Không duyệt chốt công đăng ký công tác dài hạn", "tblDangKyCongTacDaiHan"));
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmDangKyCaLam_Load(null, null);
        }

        private void grv_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column == colAcceptDA && e.CellValue != null)
            {
                if (e.CellValue.ToString() == "Đã duyệt")
                {
                    e.Appearance.BackColor = Color.MediumSpringGreen;
                }
                else if (e.CellValue.ToString() == "Không duyệt")
                {
                    e.Appearance.BackColor = Color.NavajoWhite;
                }
            }
            if (e.Column == colisHetHan && e.CellValue != null)
            {
                if (e.CellValue.ToString() == "Hết hạn")
                {
                    e.Appearance.BackColor = Color.NavajoWhite;
                }
            }
        }

        private void toolStripButton_KhoaHan_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn khóa đăng ký công tác đang chọn?", "Khóa đăng ký công tác", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if ((r["isAccept"] != DBNull.Value))
                        {
                            continue;
                        }
                        if ((r["isAcceptBP"] != DBNull.Value))
                        {
                            continue;
                        }
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            r["isHetHan"] = DBNull.Value;
                            r["userHetHan"] = LoginHelper.user.id;
                            r["ngayHetHan"] = DateTime.Now;
                        }
                        else
                        {
                            r["isHetHan"] = true;
                            r["userHetHan"] = LoginHelper.user.id;
                            r["ngayHetHan"] = DateTime.Now;
                        }
                        _lActionClass.Add(new ActionClass("Khóa hạn", r["EmployeeID"].ToString(), "", "Khóa hạn đăng ký công tác dài hạn", "tblDangKyCongTacDaiHan"));
                    }
                }
            }
        }

        private void toolStripGoDuyet_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ bỏ đăng ký đang chọn?", "Gỡ bỏ đăng ký", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");
                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if ((r["isAccept"] != DBNull.Value))
                        {
                            continue;
                        }
                        if ((r["isHetHan"] != DBNull.Value))
                        {
                            //r["isHetHan"] = DBNull.Value;

                            //r["isGoBo"] = true;
                            //r["userGoBo"] = LoginHelper.user.id;
                            //r["ngayGoBo"] = DateTime.Now;
                            continue;
                        }
                        if ((r["isAcceptBP"] == DBNull.Value))
                        {
                            continue;
                        }
                        if ((Convert.ToDouble(r["userAcceptBP"].ToString()) != LoginHelper.user.id))
                        {
                            continue;
                        }
                        r["isAcceptBP"] = DBNull.Value;
                        r["userAcceptBP"] = DBNull.Value;
                        r["ngayAcceptBP"] = DBNull.Value;
                        r["ghiChuAcceptBP"] = DBNull.Value;

                        r["isGoBo"] = true;
                        r["userGoBo"] = LoginHelper.user.id;
                        r["ngayGoBo"] = DateTime.Now;
                        _lActionClass.Add(new ActionClass("Gỡ duyệt", r["EmployeeID"].ToString(), "", "Gỡ duyệt đăng ký công tác dài hạn", "tblDangKyCongTacDaiHan"));
                    }
                }
            }
        }

        private void toolStripGoDuyetChotCong_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ duyệt chốt công đăng ký đang chọn?", "Gỡ duyệt chốt công đăng ký", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {

                    var r = grv.GetDataRow(rc[i - 1]);
                    if (r != null)
                    {
                        if (IsLock.IsLock.Check_IsLock_Type("tblDangKyCongTacDaiHan", Convert.ToDateTime(r["FromDate"].ToString()), 1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                            continue;
                        }
                        if ((r["isAccept"] == DBNull.Value))
                        {
                            continue;
                        }
                        if ((r["isHetHan"] != DBNull.Value))
                        {
                            continue;
                        }
                        if ((Convert.ToDouble(r["userAccept"].ToString()) != LoginHelper.user.id))
                        {
                            continue;
                        }
                        r["isAccept"] = DBNull.Value;
                        r["userAccept"] = DBNull.Value;
                        r["ngayAccept"] = DBNull.Value;
                        r["ghiChuAccept"] = DBNull.Value;

                        _lActionClass.Add(new ActionClass("Gỡ duyệt", r["EmployeeID"].ToString(), "", "Gỡ duyệt chốt công đăng ký công tác dài hạn", "tblDangKyCongTacDaiHan"));
                    }
                }
            }
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
