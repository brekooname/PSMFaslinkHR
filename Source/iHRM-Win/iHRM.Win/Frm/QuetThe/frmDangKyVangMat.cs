using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using iHRM.Win.Frm.LogAction;
using iHRM.Win.Frm.XtraReportTemplate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class frmDangKyVangMat : frmBase
    {
        private int coHuongLuong = 1;

        public string CoHuongLuong { get { return coHuongLuong.ToString(); } set { coHuongLuong = int.Parse(value); } }

        string[] col_XinNghi_Data = new string[4];

        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();

        List<ActionClass> _lActionClass = new List<ActionClass>();

        DataTable dt = new DataTable();

        dlgDangKyVangMat dlgDKVM;
        dlgDangKyVangMatEdit dlgDKVMEdit;

        public frmDangKyVangMat()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            col_XinNghi_Data[0] = "-";
            col_XinNghi_Data[1] = SelectTranslate("DangKyVangMat_sang", LoginHelper.langTrans);
            col_XinNghi_Data[2] = SelectTranslate("DangKyVangMat_chieu", LoginHelper.langTrans);
            col_XinNghi_Data[3] = SelectTranslate("DangKyVangMat_cangay", LoginHelper.langTrans);
            this.Text = SelectTranslate("frmDangKyVangMat", LoginHelper.langTrans) + (coHuongLuong == 0 ? SelectTranslate("frmDangKyVangMat_khongluong", LoginHelper.langTrans) : SelectTranslate("frmDangKyVangMat_coluong", LoginHelper.langTrans));

            this.toolStripAddNew.Text = SelectTranslate("frmDangKyVangMat", LoginHelper.langTrans)  + (coHuongLuong == 0 ? SelectTranslate("frmDangKyVangMat_khongluong", LoginHelper.langTrans) : SelectTranslate("frmDangKyVangMat_coluong", LoginHelper.langTrans));
         
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

                //toolStripButton_KhoaHan.Visible = true;
            }
            else
            {
                toolStripAccept_DA.Visible = false;

                toolStripNotAccept_DA.Visible = false;

                toolStripGoDuyetChotCong.Visible = false;

                rdAccept.Visible = false;

                //toolStripButton_KhoaHan.Visible = false;
            }

            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

            repQLDuyet.DataSource = db.w5sysUsers;

            if (coHuongLuong == 1)

                repositoryItemLookUpEdit1.DataSource = db.tblRef_LeaveTypes.Where(p => p.SalaryRate > 0);

            if (coHuongLuong == 0)

                repositoryItemLookUpEdit1.DataSource = db.tblRef_LeaveTypes.Where(p => p.SalaryRate == 0 || p.SalaryRate == null);

            _lActionClass.Clear();

            LoadGrvLayout(grv, CoHuongLuong);
            TranslateForm();
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

            dw_it.Caption = "Đang tải dữ liệu đăng ký vắng mặt...";

            dw_it.OnDoing = (s, ev) =>
            {
                dt = logic.GetDataDangKyVangMat(
                            ucChonDoiTuong_DS2.GetValue(),
                            chonKyLuong1.TuNgay,
                            chonKyLuong1.DenNgay,
                            isAccept,
                            coHuongLuong
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
            SaveGrvLayout(grv, CoHuongLuong);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            grv.OptionsPrint.UsePrintStyles = false;

            ShowPreview(grd);
            //ExportGrid(grd);
        }

        //private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        //{
        //    var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả các đăng ký vắng mặt đang chọn?", "Xóa tất cả các đăng ký vắng mặt đang chọn", MessageBoxButtons.OKCancel);
        //    if (dg == DialogResult.OK)
        //    {
        //        foreach (int rowhandler in grv.GetSelectedRows())
        //        {
        //            var r = grv.GetDataRow(rowhandler);
        //            if (r != null)
        //            {
        //                var isOK = true;
        //                if (r["isAccept"] != DBNull.Value)
        //                {
        //                    isOK = false;
        //                }
        //                if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
        //                {
        //                    isOK = false;
        //                }
        //                if (!isOK)
        //                {
        //                    GUIHelper.Notifications("Không thể xóa vì bản ghi này đã được duyệt hoặc không thuộc phòng ban của bạn.", "Xóa tất cả các yêu cầu đang chọn", GUIHelper.NotifiType.error);
        //                }
        //                else
        //                {
        //                    grv.DeleteRow(rowhandler);
        //                }
        //            }
        //        }
        //    }
        //}
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả đăng ký vắng mặt đang chọn?"
                                        , "Xóa tất cả đăng ký vắng mặt đang chọn"
                                        , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                int[] rc = grv.GetSelectedRows();

                for (int i = rc.Count(); i > 0; i--)
                {
                    var r = grv.GetDataRow(rc[i - 1]);

                    if (r != null)
                    {

                        var isOK = true;

                        if (IsLock.IsLock.Check_IsLock("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString())))
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
                            continue;
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
                            GUIHelper.Notifications("Không thể xóa vì bản ghi này đã được duyệt hoặc không thuộc phòng ban của bạn."
                                                        , "Xóa tất cả các yêu cầu đang chọn"
                                                        , GUIHelper.NotifiType.error);
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

                if (e.Column == colXinNghi)
                {
                    e.Value = col_XinNghi_Data[DbHelper.DrGetInt(r.Row, "PertimeID")];
                }
                if (e.Column == colHuongLuong)
                {
                    e.Value = DbHelper.DrGetDouble(r.Row, "SalaryRate") > 0 ? "Có" : "Không";
                }
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

            //MessageBox.Show(coHuongLuong.ToString());
            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }

            dcDatabaseFilesDataContext dbFile = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);

            var count = dt.GetChanges().Rows.Count;

            string mnv = string.Empty;

            List<tblEmpDayOff> lst = new List<tblEmpDayOff>();

            DateTime FromDate = DateTime.Now;

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
                        if (dr["isAcceptBP"] != DBNull.Value && dr["isAccept"] == DBNull.Value)
                        {
                            tblEmpDayOff vm = new tblEmpDayOff();

                            vm.EmployeeID = dr["EmployeeID"].ToString();

                            vm.FromDate = Convert.ToDateTime(dr["FromDate"]);

                            if ((bool)dr["isAcceptBP"])
                            {
                                vm.ghiChuAccept="1";
                            }
                            else
                            {
                                vm.ghiChuAccept = "0";
                            }

                            lst.Add(vm);
                        }
                        #endregion
                    }
                    else
                    {
                        var empID = (string)dr["EmployeeID", DataRowVersion.Original];

                        _lActionClass.Add(new ActionClass("Xóa dữ liệu", empID, "", "Xóa dữ liệu đăng ký vắng mặt", "tblEmpDayOff"));
                    }
                }

                Provider.UpdateData(dt, "tblEmpDayOff");

                LogAction.LogAction.PushLog(_lActionClass); _lActionClass.Clear();

                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
        }

        private void toolStripAccept_Click(object sender, EventArgs e)
        {

            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các đăng ký vắng mặt đang chọn?"
                                        , "Duyệt đăng ký vắng mặt"
                                        , MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);

                frm.ShowDialog();

                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");

                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()), 3))
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
                        //if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        //{
                        //    continue;
                        //}
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }

                        r["isAcceptBP"] = true;

                        r["userAcceptBP"] = LoginHelper.user.id;

                        r["ngayAcceptBP"] = DateTime.Now;

                        r["ghiChuAcceptBP"] = frm.reason;

                        _lActionClass.Add(new ActionClass("Duyệt"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Duyệt " + this.Text
                                                            , "tblEmpDayOff"));
                    }
                }
            }
        }

        private void toolStripAcceptAll_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt tất cả các đăng ký vắng mặt?"
                                        , "Duyệt đăng ký vắng mặt"
                                        , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);
                frm.ShowDialog();
                for (int i = 0; i < grv.DataRowCount; i++)
                {
                    var r = grv.GetDataRow(i);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");

                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()), 3))
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
                        //if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        //{
                        //    continue;
                        //}
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }
                        if (r["isAcceptBP"] == DBNull.Value)
                        {
                            r["isAcceptBP"] = true;

                            r["userAcceptBP"] = LoginHelper.user.id;

                            r["ngayAcceptBP"] = DateTime.Now;

                            r["ghiChuAcceptBP"] = frm.reason;

                            _lActionClass.Add(new ActionClass("Duyệt tất cả"
                                                                , r["EmployeeID"].ToString()
                                                                , ""
                                                                , "Duyệt tất cả " + this.Text
                                                                , "tblEmpDayOff"));
                        }
                    }
                }

            }
        }

        private void toolStripNotAccept_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các đăng ký vắng mặt đang chọn?"
                                        , "Không duyệt đăng ký vắng mặt"
                                        , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(false);

                frm.ShowDialog();

                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");

                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");

                            continue;
                        }

                        if (LoginHelper.user.idKhoiPB != null 
                            && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            continue;
                        }
                        if (r["isAccept"] != DBNull.Value)
                        {
                            continue;
                        }
                        //if (Convert.ToInt32(r["idUserRequest"]) == LoginHelper.user.id && !LoginHelper.user.isAdmin)
                        //{
                        //    continue;
                        //}
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }

                        r["isAcceptBP"] = false;

                        r["userAcceptBP"] = LoginHelper.user.id;

                        r["ngayAcceptBP"] = DateTime.Now;

                        r["ghiChuAcceptBP"] = frm.reason;

                        _lActionClass.Add(new ActionClass("Không duyệt"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Không duyệt " + this.Text
                                                            , "tblEmpDayOff"));
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
            //if (e.RowHandle >= 0 
            //    && grv.GetRowCellValue(e.RowHandle, "FromDate") != null 
            //    && string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isAcceptBP").ToString()) 
            //    && string.IsNullOrEmpty(grv.GetRowCellValue(e.RowHandle, "isHetHan").ToString()))
            //{
            //    TimeSpan date = Convert.ToDateTime(DateTime.Now) - Convert.ToDateTime(grv.GetRowCellValue(e.RowHandle, "FromDate").ToString());

            //    //if (date.Days >= 5 && (LoginHelper.user.isAcceptable == true || LoginHelper.user.isAdmin))
            //    //{
            //    //    e.Appearance.ForeColor = Color.MediumBlue;
            //    //}
            //}
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dlgDKVM != null)
            {
                dlgDKVM.coHuongLuong = coHuongLuong;

                dlgDKVM.ShowDialog();
            }
            else
            {
                dlgDKVM = new dlgDangKyVangMat();

                dlgDKVM.coHuongLuong = coHuongLuong;

                dlgDKVM.ShowDialog();
            }
        }

        private void toolStripAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn duyệt đăng ký vắng mặt đang chọn?"
                                        , "Duyệt đăng ký vắng mặt"
                                        , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(true);

                frm.ShowDialog();

                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);

                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()),1))
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
                        if (r["isHetHan"] != DBNull.Value)
                        {
                            continue;
                        }

                        r["isAccept"] = true;

                        r["userAccept"] = LoginHelper.user.id;

                        r["ngayAccept"] = DateTime.Now;

                        r["ghiChuAccept"] = frm.reason;

                        _lActionClass.Add(new ActionClass("Duyệt chốt công"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Duyệt chốt công " + this.Text
                                                            , "tblEmpDayOff"));
                    }
                }
            }
        }

        private void toolStripNotAccept_DA_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn không duyệt tất cả các đăng ký vắng mặt đang chọn?"
                                        , "Không duyệt đăng ký vắng mặt"
                                        , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                dlgLyDoDuyet frm = new dlgLyDoDuyet(false);

                frm.ShowDialog();

                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");

                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null 
                            && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
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

                        _lActionClass.Add(new ActionClass("Không duyệt chốt công"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Không duyệt chốt công " + this.Text
                                                            , "tblEmpDayOff"));
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
            var dg = MessageBox.Show("Bạn có chắc chắn muốn khóa đăng ký công tác đang chọn?"
                                        , "Khóa đăng ký công tác"
                                        , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);

                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");

                            continue;
                        }
                        if (LoginHelper.user.idKhoiPB != null 
                            && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
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

                        _lActionClass.Add(new ActionClass("Khóa hạn"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Khóa hạn " +this.Text
                                                            , "tblEmpDayOff"));
                    }
                }
            }
        }

        private void toolStripGoDuyet_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ bỏ đăng ký đang chọn?"
                                        , "Khóa đăng ký"
                                        , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);

                    if (r != null)
                    {
                        //if (IsLock.IsLock.Check_IsLock("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString())))
                        //{
                        //    GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                        //    continue;
                        //}
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()),1))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");

                            continue;
                        }
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()), 3))
                        {
                            GUIHelper.MessageBox("Dữ liệu đã chốt quản lý duyệt khổng thể thao tác!");

                            continue;
                        }

                        if (LoginHelper.user.idKhoiPB != null 
                            && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
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

                        _lActionClass.Add(new ActionClass("Gỡ duyệt"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Gỡ duyệt " + this.Text
                                                            , "tblEmpDayOff"));
                    }
                }
            }
        }

        private void toolStripGoDuyetChotCong_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn gỡ duyệt chốt công đăng ký đang chọn?"
                                        , "Gỡ duyệt chốt công đăng ký"
                                        , MessageBoxButtons.OKCancel);

            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);

                    if (r != null)
                    {
                        if (IsLock.IsLock.Check_IsLock_Type("tblEmpDayOff", Convert.ToDateTime(r["FromDate"].ToString()), 1))
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

                        _lActionClass.Add(new ActionClass("Gỡ duyệt"
                                                            , r["EmployeeID"].ToString()
                                                            , ""
                                                            , "Gỡ duyệt chốt công " + this.Text
                                                            , "tblEmpDayOff"));
                    }
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetDataRow(i));


            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                return;
            }

            try
            {
                foreach (var item in drs)
                {
                    var a = Provider.ExecuteDataTableReader("p_export_DonXinNghiPhep"
                                                            , new System.Data.SqlClient.SqlParameter("@empID", item["EmployeeID"].ToString())
                                                            , new System.Data.SqlClient.SqlParameter("@tuNgay", DateTime.Parse(item["FromDate"].ToString()))
                                                            , new System.Data.SqlClient.SqlParameter("@denNgay", DateTime.Parse(item["ToDate"].ToString()))
                                                            , new System.Data.SqlClient.SqlParameter("@loaiPhep", int.Parse(CoHuongLuong)));


                    var rp = new rep_DonXinNghiPhep();

                    rp.DataBindings(a);

                    ReportViewer rv = new ReportViewer();

                    rv.ViewReport(rp);
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
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
       
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            if (grv.GetSelectedRows().Count() != 1) //Xét điều kiện không chọn nhiều hơn một dòng.
            {
                return;
            }

            int[] rc = grv.GetSelectedRows(); //Lấy dữ liệu trong lưới

            for (int i = rc.Count(); i > 0; i--)
            {
                var r = grv.GetDataRow(rc[i - 1]);

                if (r != null)
                {
                    if (r["isAccept"] != DBNull.Value || r["isAcceptBP"] != DBNull.Value) return; //Không sửa đơn đã duyệt hoặc chốt

                    if (grv.FocusedRowHandle != -1)
                    {
                        string manv = (string)r["EmployeeID"];

                        DateTime ngaydk = (DateTime)r["FromDate"];

                        dlgDKVMEdit = new dlgDangKyVangMatEdit();

                        dlgDKVMEdit.coHuongLuong = coHuongLuong;

                        dlgDKVMEdit.manv = manv;

                        dlgDKVMEdit.ngaydk = ngaydk.Date;

                        if (r["idFile"] != DBNull.Value)
                        {
                            dlgDKVMEdit._idFiles = (Guid)r["idFile"];
                        }

                        dlgDKVMEdit.ShowDialog();
                        
                    }
                }
            }
        }


        #region Translate language
        public static List<string> listCtr = new List<string>();
        public static Dictionary<string, string> myData = new Dictionary<string, string>();

        private IEnumerable<DevExpress.XtraGrid.Columns.GridColumn> EnumerateGridColumn()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraGrid.Columns.GridColumn).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraGrid.Columns.GridColumn)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<DevExpress.XtraEditors.SimpleButton> EnumerateSimpleButton()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.SimpleButton).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.SimpleButton)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<ToolStripButton> EnumerateToolStripButton()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(ToolStripButton).IsAssignableFrom(field.FieldType)
                   let component = (ToolStripButton)field.GetValue(this)
                   where component != null
                   select component;
        }

        private IEnumerable<DevExpress.XtraEditors.LabelControl> EnumerateLabelControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.LabelControl).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.LabelControl)field.GetValue(this)
                   where component != null
                   select component;
        }

        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new System.Data.SqlClient.SqlParameter("CtrName", nameCrt),

                           new System.Data.SqlClient.SqlParameter("FormName", this.Name.ToString() + (coHuongLuong == 0 ? "_khongluong" : "_coluong")));
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
        public void TranslateForm()
        {
            myData.Clear();
            listCtr.Clear();
            string langTrans = LoginHelper.langTrans;
            //string formText = SelectTranslate(this.Name + (coHuongLuong == 0 ? "_khongluong" : "_coluong"), langTrans);
            //if (formText != "")
            //{
            //    this.Text = formText;
            //}
            #region Khai báo list loai control trong form
            var _GridColumn = EnumerateGridColumn();
            var _ToolStripButton = EnumerateToolStripButton();
            var _LableControl = EnumerateLabelControl();
            var _SimpleButton = EnumerateSimpleButton();
            #endregion

            #region Dịch form
            foreach (DevExpress.XtraGrid.Columns.GridColumn s in _GridColumn)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Caption);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Caption = trans;
                }
            }
            foreach (ToolStripButton s in _ToolStripButton)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.SimpleButton s in _SimpleButton)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.LabelControl s in _LableControl)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            this.Text = SelectTranslate("frmDangKyVangMat", langTrans) +" "+ SelectTranslate("frmDangKyVangMat" + (coHuongLuong == 0 ? "_khongluong" : "_coluong"), langTrans);
            myData.Add(this.Name + (coHuongLuong == 0?"_khongluong":"_coluong"), this.Text);
            listCtr.Add(this.Name + (coHuongLuong == 0 ? "_khongluong" : "_coluong"));
            // dịch radiogrop duyệt 
            rdAccept.Properties.Items[0].Description = SelectTranslate("rdAcceptTatca", langTrans);
            rdAccept.Properties.Items[1].Description = SelectTranslate("rdAcceptDaDuyet", langTrans);
            rdAccept.Properties.Items[2].Description = SelectTranslate("rdAcceptKhongDuyet", langTrans);
           
            #endregion
        }

        #endregion

        private void frmDangKyVangMat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name+(coHuongLuong == 0 ? "_khongluong" : "_coluong");
                frm.ShowDialog();
                frmDangKyCaLam_Load(null, null);
            }
        }

        private void frmDangKyVangMat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                return;
            }
            else
            {
                var dg = MessageBox.Show("Bạn có muốn lưu dữ liệu đã thao tác!", "Lưu tất cả các yêu cầu", MessageBoxButtons.YesNoCancel);

                if (dg == DialogResult.Yes)
                {
                    toolStripLuu_Click(null, null);
                }
                else if (dg == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
       

    }
}
