using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong
{
    public partial class frmTamUng : frmBase
    {
        Core.Business.Logic.Luong.TinhLuong logic = new Core.Business.Logic.Luong.TinhLuong();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        DataTable dt=new DataTable();
        public frmTamUng()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            #region phân quyền
            toolStripButton1.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);
            toolStripButton2.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Export);
            toolStripButton3.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Edit);
            toolstripSave.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Save);
            toolStripButtonThem.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
            btnFind.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Find);
            #endregion

            LoadGrvLayout(grv);
            grv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            //var dt = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));
            //thông tin nhân viên tạm ứng
            var dtnv = Provider.ExecuteDataTableReader("p_getEmpByDepID_Name", new System.Data.SqlClient.SqlParameter("depID", LoginHelper.user.idKhoiPB));
            repositoryItemSearchLookUpEditMaNV.DataSource = dtnv;
            repositoryItemSearchLookUpEditMaNV.DisplayMember = "EmployeeName";
            repositoryItemSearchLookUpEditMaNV.ValueMember = "EmployeeID";

            btnFind_Click(null, null);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu tạm ứng";
            dw_it.OnDoing = (s, ev) =>
            {
                dt = logic.getTamUng(ucChonDoiTuong_DS1.GetValue(), chonKyLuong1.TuNgay, chonKyLuong1.DenNgay);
                dw_it.bw.ReportProgress(1, dt);
            };
            dw_it.OnProcessing = (ps, dt) =>
            {
                if (dt.ProgressPercentage == 1)
                {
                    grd.DataSource = dt.UserState;
                    //(grcSoNgPT.DataSource as DataTable).AcceptChanges();
                }
            };
            dw_it.OnCompleting = (s, a) =>
            {
                btnFind.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }
        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        void  on_off_colum(bool values)
        {
            colNVname.OptionsColumn.AllowEdit = values;
            colNgayTamUng.OptionsColumn.AllowEdit = values;
            colSoChungTu.OptionsColumn.AllowEdit = values;
            colSoTien.OptionsColumn.AllowEdit = values;
            colGhiChu.OptionsColumn.AllowEdit = values;
        }
        private void toolstripSave_Click(object sender, EventArgs e)
        {
            //grv.OptionsBehavior.Editable = false;
            dcDatabaseFilesDataContext dbFile = new dcDatabaseFilesDataContext(Provider.ConnectionString_Files);
            on_off_colum(false);
            grv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            //MessageBox.Show(coHuongLuong.ToString());
            if (dt.GetChanges() == null || (dt.GetChanges() != null && dt.GetChanges().Rows.Count == 0))
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }
            var count = dt.GetChanges().Rows.Count;
            try
            {

                foreach (DataRow dr in dt.GetChanges().Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        if (dr["idFile"] == DBNull.Value)
                        {
                            if (dr["idFileDelete"] != DBNull.Value)
                            {
                                var a = dbFile.tbFiles.Where(p => p.id == Guid.Parse(dr["idFileDelete"].ToString())).FirstOrDefault();
                                if (a != null)
                                {
                                    dbFile.tbFiles.DeleteOnSubmit(a);
                                }
                            }
                        }
                        else
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
                        }
                        dbFile.SubmitChanges();
                    }
                }
                Provider.UpdateData(dt, "tbTamUng");
                GUIHelper.Notifications("Cập nhật thành công " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.tick);
            }
            catch (Exception ex)
            {
                GUIHelper.Notifications("Cập nhật lỗi " + count + " record.", "Lưu dữ liệu", GUIHelper.NotifiType.error);
            }
            

        }
        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dr = grv.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["idUserRequest"] = LoginHelper.user.id;
                dr["ngayRequest"] = DateTime.Now;
            } 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả các yêu cầu đang chọn?", "Xóa tất cả các yêu cầu đang chọn", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                foreach (int rowhandler in grv.GetSelectedRows())
                {
                    var r = grv.GetDataRow(rowhandler);
                    if (r != null)
                    {
                        var isOK = true;
                        if (LoginHelper.user.idKhoiPB != null && !AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB.Value))
                        {
                            isOK = false;
                        }
                        if (!isOK)
                        {
                            GUIHelper.Notifications("Không thể xóa vì bản ghi này không thuộc phòng ban của bạn.", "Xóa tất cả các yêu cầu đang chọn", GUIHelper.NotifiType.error);
                        }
                        else
                        {
                            grv.DeleteRow(rowhandler);
                        }
                    }
                }
            }
        }

        private void repositoryItemSearchLookUpEditNhanVien_EditValueChanged_1(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            this.grv.SetFocusedRowCellValue(colSoChungTu, searchEdit.Properties.View.GetFocusedRowCellValue("Birthday"));
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //grv.OptionsBehavior.Editable = true;
            grv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            on_off_colum(true);
            GUIHelper.Notifications("Bạn đã có thể sửa trực tiếp trên lưới danh sách.", "Sửa dữ liệu", GUIHelper.NotifiType.info);
        }

        private void repositoryItemSearchLookUpEditMaNV_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit searchEdit = sender as SearchLookUpEdit;
            this.grv.SetFocusedRowCellValue(colMaNV, searchEdit.Properties.View.GetFocusedRowCellValue("EmployeeID"));
            this.grv.SetFocusedRowCellValue(colChucVu, searchEdit.Properties.View.GetFocusedRowCellValue("PosName"));
            this.grv.SetFocusedRowCellValue(colPhongBan, searchEdit.Properties.View.GetFocusedRowCellValue("DepName_Final"));
        }

        private void grv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var r = grv.GetDataRow(e.RowHandle);
            if (r != null && r.RowState != DataRowState.Unchanged)
            {
                if (r["EmployeeID"] == DBNull.Value || r["EmployeeID"].ToString() == "")
                {
                    e.ErrorText = ("Bạn cần phải nhập mã nhân viên.\n");
                    e.Valid = false;
                    grv.FocusedColumn = grv.Columns[0];
                    return;
                }
                else
                {
                    if (!AllLogic.checkEmployeeIDInDep(r["EmployeeID"].ToString(), LoginHelper.user.idKhoiPB))
                    {
                        e.ErrorText = ("Mã nhân viên bạn nhập không nằm trong phòng ban của bạn.\n");
                        e.Valid = false;
                        grv.FocusedColumn = grv.Columns[0];
                        return;

                    }
                }
                if (r["NgayTU"] == DBNull.Value || r["NgayTU"].ToString() == "")
                {
                    e.ErrorText = ("Chưa nhập ngày tạm ứng.\n");
                    e.Valid = false;
                    grv.FocusedColumn = grv.Columns[5];
                    return;
                }
                if (r["SoTienTU"] == DBNull.Value || r["SoTienTU"].ToString() == "")
                {
                    e.ErrorText = ("Chưa nhập số tiền tạm ứng.\n");
                    e.Valid = false;
                    grv.FocusedColumn = grv.Columns[4];
                    return;
                }
                if (r["SoChungTu"] == DBNull.Value || r["SoChungTu"].ToString() == "")
                {
                    e.ErrorText = ("Chưa nhập số chứng từ.\n");
                    e.Valid = false;
                    grv.FocusedColumn = grv.Columns[6];
                    return;
                }
                
            }
        }

        private void repositoryItemButtonEditFileDinhKem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dr = grv.GetFocusedDataRow();
            if (e.Button.Index == 0)// Xem file
            {
                if (dr != null && dr["dataFile"] != DBNull.Value)
                {
                    FileStorageHelper fh = new FileStorageHelper();

                    var duoiFile = grv.GetFocusedRowCellValue(colDuoiFile).ToString();
                    Binary dataFile = new Binary(dr["dataFile"] as byte[]);
                    fh.DownLoadAndShowFILE(dataFile, dr["duoiFile"].ToString());
                }
                else
                {
                    GUIHelper.Notifications("Không có dữ liệu để xem", "Mở file", GUIHelper.NotifiType.error);
                }
            }
            else if (e.Button.Index == 1) // Chọn file mới
            {
                if(colNVname.OptionsColumn.AllowEdit)
                {
                    if (dr != null)
                    {

                        OpenFileDialog od = new OpenFileDialog();
                        string filterFile = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                        filterFile += "|Word files (*.doc, *.docx)|*.doc; *.docx; ";
                        filterFile += "|Pdf files (*.pdf)|*.pdf; ";
                        filterFile += "|All files (*.*)|*.*;";
                        od.Filter = filterFile;
                        od.Multiselect = false;
                        if (od.ShowDialog() == DialogResult.OK)
                        {
                            byte[] bytes = System.IO.File.ReadAllBytes(od.FileNames[0]);
                            dr["dataFile"] = bytes;
                            dr["duoiFile"] = Path.GetExtension(od.FileNames[0]);
                            if (dr["idFile"] == DBNull.Value)
                            {
                                dr["idFile"] = Guid.NewGuid();
                            }
                        }
                    }
                    else
                    {
                        GUIHelper.Notifications("Không có dữ liệu để chọn", "Mở file", GUIHelper.NotifiType.error);
                    }
                }
            }
            else if (e.Button.Index == 2) // Xóa file
            {
                if(colNVname.OptionsColumn.AllowEdit)
                {
                    if (dr != null)
                    {
                        dr["idFileDelete"] = dr["idFile"];
                        dr["dataFile"] = DBNull.Value;
                        dr["idFile"] = DBNull.Value;
                        dr["duoiFile"] = DBNull.Value;
                        GUIHelper.Notifications("Đã xóa file đính kèm. Bấm lưu lại để hoàn thành.", "Xóa file đính kèm", GUIHelper.NotifiType.info);
                    }
                    else
                    {
                        GUIHelper.Notifications("Không có dữ liệu để xóa", "Xóa file", GUIHelper.NotifiType.error);
                    }
                }
            }
        }

        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            grv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            on_off_colum(true);
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
