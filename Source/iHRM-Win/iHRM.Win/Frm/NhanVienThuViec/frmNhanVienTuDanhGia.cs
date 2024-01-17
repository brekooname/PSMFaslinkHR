using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
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

namespace iHRM.Win.Frm.NhanVienThuViec
{
    public partial class frmNhanVienTuDanhGia : dlgBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public frmNhanVienTuDanhGia()
        {
            InitializeComponent();
            AddControlBinding();
            
        }
        protected override void FormGetData()
        {
            base.FormGetData();
            #region Validate
            if(cboNguoiQuanLy.Text == string.Empty)
            {
                GUIHelper.MessageBox("Chưa chọn người quản lý.");
                cboNguoiQuanLy.Focus();
                return;
            }
            if(radQTThucHienViecChung.SelectedIndex == -1)
            {
                GUIHelper.MessageBox("Chưa tự đánh giá quy trình thực hiện công việc chung.");
                return;
            }
            if(radQTThucHienCVTaiPB.SelectedIndex == -1)
            {
                GUIHelper.MessageBox("Chưa tự đánh giá quy trình thực hiện công việc tại phòng ban.");
                return;
            }
            if (radMoiTruongLamViecChung.SelectedIndex == -1)
            {
                GUIHelper.MessageBox("Chưa tự đánh giá môi trường làm việc chung.");
                return;
            }
            if (radMoiTruongLamViecTaiPB.SelectedIndex == -1)
            {
                GUIHelper.MessageBox("Chưa tự đánh giá môi trường làm việc tại phòng ban.");
                return;
            }
            if (radQD_QT_CS.SelectedIndex == -1)
            {
                GUIHelper.MessageBox("Chưa tự đánh giá quy định/quy trình và chính sách tại công ty.");
                return;
            }
            if (radHD.SelectedIndex == -1)
            {
                GUIHelper.MessageBox("Chưa chọn có ký hợp đồng hay không.");
                return;
            }
            if (this.MyValue["isDongY"] == DBNull.Value)
            {
                GUIHelper.MessageBox("Chưa xác nhận.");
                return;
            }
            else
            {
                if(!(bool)this.MyValue["isDongY"])
                {
                    GUIHelper.MessageBox("Chưa đồng ý xác nhận.");
                    return;
                }
            }
            #endregion
            int chk = 0;
            if (chkHD.Checked)
                chk = 1;
            //thực hiện lưa trong này
            DataTable dt_nv = Provider.ExecuteDataTable("p_InsertNV_TuDanhGia",
                    new System.Data.SqlClient.SqlParameter("idUV", txtMaNhanVien.Text),
                    new System.Data.SqlClient.SqlParameter("idQL", cboNguoiQuanLy.EditValue.ToString()),
                    new System.Data.SqlClient.SqlParameter("ThucHienQuyDinh", int.Parse(radQD_QT_CS.SelectedIndex.ToString())),
                    new System.Data.SqlClient.SqlParameter("LydoThucHienQuyDinh", txtLyDoQD_QT_CS.Enabled ? txtLyDoQD_QT_CS.Text : null),
                    new System.Data.SqlClient.SqlParameter("MTLamViecChung", int.Parse(radMoiTruongLamViecChung.SelectedIndex+"")),
                    new System.Data.SqlClient.SqlParameter("LyDoMTLamViecChung", txtMoiTruongLamViecChung.Enabled ? txtMoiTruongLamViecChung.Text : null),
                    new System.Data.SqlClient.SqlParameter("MTLamViecTaiPB", int.Parse(radMoiTruongLamViecTaiPB.SelectedIndex+"")),
                    new System.Data.SqlClient.SqlParameter("LyDoMTLamViecTaiPB", txtMoiTruongLamViecTaiPB.Enabled?txtMoiTruongLamViecTaiPB.Text:null),
                    new System.Data.SqlClient.SqlParameter("QTCongViecChung", int.Parse(radQTThucHienViecChung.SelectedIndex+"")),
                    new System.Data.SqlClient.SqlParameter("LyDoQTCongViecChung", txtLyDoQTThucHienCVChung.Enabled?txtLyDoQTThucHienCVChung.Text:null),
                    new System.Data.SqlClient.SqlParameter("QTCongViecChungPB", int.Parse(radQTThucHienCVTaiPB.SelectedIndex+"")),
                    new System.Data.SqlClient.SqlParameter("LyDoQTCongViecChungPB", txtLyDoQTThucHienCVTaiPB.Enabled?txtLyDoQTThucHienCVTaiPB.Text:null),
                    new System.Data.SqlClient.SqlParameter("DeXuat", txtNDDeXuat.Enabled?txtNDDeXuat.Text:null),
                    new System.Data.SqlClient.SqlParameter("DongYKyHD", int.Parse(radHD.SelectedIndex+"")),
                    new System.Data.SqlClient.SqlParameter("LyDoDongYKyHD", txtHD.Text != string.Empty?txtHD.Text:null),
                    new System.Data.SqlClient.SqlParameter("soChungTu", txtSoChungTu.Text),
                    new System.Data.SqlClient.SqlParameter("isDongY", chk));

            try
            {
                if (int.Parse(dt_nv.Rows[0][0].ToString()) == 0)
                {
                    GUIHelper.MessageBox("Chỉnh sửa thành công.");
                }
                if (int.Parse(dt_nv.Rows[0][0].ToString()) == 1)
                {
                    GUIHelper.MessageBox("Thêm mới thành công.");
                }
            }
            catch { return; }
            //THỰC HIỆN XÓA DỮ LIỆU TRONG BẢNG TRÁCH NHIỆM VÀ QUYỀN HẠN
            Provider.ExecuteDataTable("p_tblEmployee_TV_TuDanhGia_DELETETN_QH",new System.Data.SqlClient.SqlParameter("EmployeeID", txtMaNhanVien.Text));

            //Thêm trách nhiệm trong công việc
            DataTable dt_TNCV = grvTNCV.DataSource as DataTable;
            foreach (DataRow r in dt_TNCV.Rows)
            {
                if (r.RowState == DataRowState.Deleted)
                    continue;
                Provider.ExecuteDataTable("p_InsertTV_TuDanhGia_TrachNhiem",
                    new System.Data.SqlClient.SqlParameter("idUV", txtMaNhanVien.Text),
                    new System.Data.SqlClient.SqlParameter("CongViecChinh", r["CongViecChinh"] as string),
                    new System.Data.SqlClient.SqlParameter("TrachNhiemVu", r["TrachNhiemVu"] as string));
            }
            ////Thêm quyền hạn trong công việc
            DataTable dt_QHCV = grvQHCV.DataSource as DataTable;
            foreach (DataRow r in dt_QHCV.Rows)
            {
                if (r.RowState == DataRowState.Deleted)
                    continue;
                Provider.ExecuteDataTable("p_InsertTV_TuDanhGia_QuyenHan",
                    new System.Data.SqlClient.SqlParameter("idUV", txtMaNhanVien.Text),
                    new System.Data.SqlClient.SqlParameter("TrongGioiHanChoPhep", r["TrongGioiHanChoPhep"] as string),
                    new System.Data.SqlClient.SqlParameter("NgoaiKhaNang", r["NgoaiKhaNang"] as string));
            }


        }
        protected override void FormSetData()
        {
            base.FormSetData();
            //thông tin kĩ năng và kiến thức
            radQD_QT_CS.SelectedIndex = this.MyValue["ThucHienQuyDinh"] != DBNull.Value ? Convert.ToInt32(this.MyValue["ThucHienQuyDinh"].ToString()) : -1;
            radMoiTruongLamViecChung.SelectedIndex = this.MyValue["MTLamViecChung"] != DBNull.Value ? Convert.ToInt32(this.MyValue["MTLamViecChung"].ToString()) : -1;
            radMoiTruongLamViecTaiPB.SelectedIndex = this.MyValue["MTLamViecTaiPB"] != DBNull.Value ? Convert.ToInt32(this.MyValue["MTLamViecTaiPB"].ToString()) : -1;
            radQTThucHienViecChung.SelectedIndex = this.MyValue["QTCongViecChung"] != DBNull.Value ? Convert.ToInt32(this.MyValue["QTCongViecChung"].ToString()) : -1;
            radQTThucHienCVTaiPB.SelectedIndex = this.MyValue["QTCongViecChungPB"] != DBNull.Value ? Convert.ToInt32(this.MyValue["QTCongViecChungPB"].ToString()) : -1;
            cboNguoiQuanLy.EditValue = this.MyValue["idQL"] != DBNull.Value ? this.MyValue["idQL"] : DBNull.Value;
            radHD.SelectedIndex = this.MyValue["DongYKyHD"] != DBNull.Value ? Convert.ToInt32(this.MyValue["DongYKyHD"].ToString()) : -1;
            DataSet dsDM = Provider.ExecuteDataSetReader("p_tblEmployee_TV_TuDanhGia_GetTN_QH", new System.Data.SqlClient.SqlParameter("EmployeeID", this.MyValue["MaNhanVien"].ToString()));
            grvTNCV.DataSource = dsDM.Tables[0];
            grvQHCV.DataSource = dsDM.Tables[1];
        }
        public void AddControlBinding()
        {
            //thông tin nhân viên
            dlgData.CB.Add(new ControlBinding("MaNhanVien", txtMaNhanVien, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("soChungTu", txtSoChungTu, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding("HoTen", txtTenNhanVien, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ChucDanh", txtChucVu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BoPhan", txtBoPhan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BangCap", txtBangCap, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("NgayVaoLam", dateNgayNhanViec, ControlBinding_DataType.DateTime));
            //thông tin quản lý
            //dlgData.CB.Add(new ControlBinding("idQL", cboNguoiQuanLy, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ThucHienQuyDinh", radQD_QT_CS, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("LydoThucHienQuyDinh", txtLyDoQD_QT_CS, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("MTLamViecChung", radMoiTruongLamViecChung, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("LyDoMTLamViecChung", txtMoiTruongLamViecChung, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("MTLamViecTaiPB", radMoiTruongLamViecTaiPB, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("LyDoMTLamViecTaiPB", txtMoiTruongLamViecTaiPB, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("QTCongViecChung", radQTThucHienViecChung, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("LyDoQTCongViecChung", txtLyDoQTThucHienCVChung, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("QTCongViecChungPB", radQTThucHienCVTaiPB, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("LyDoQTCongViecChungPB", txtLyDoQTThucHienCVTaiPB, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("DeXuat", txtNDDeXuat, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("DongYKyHD", radHD, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("isDongY", chkHD, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("LyDoDongYKyHD", txtHD, ControlBinding_DataType.String));

        }
        private void GetAllDataInTaBle_ByEmpID(string EmpID, string TableName, GridControl grc, string addStrWhere = "")
        {
            //grc.DataSource = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM {0} WHERE idUV = '{1}' {2} ORDER BY idx", TableName, EmpID, addStrWhere));
            //(grc.DataSource as DataTable).AcceptChanges();
        }
        private void groupControl12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuRefresh_GDPT_Click(object sender, EventArgs e)
        {
            //GetAllDataInTaBle_ByEmpID(txt, "tblUV_QuanHeGiaDinh", grcQHGD);
        }

        private void frmNhanVienTuDanhGia_Load(object sender, EventArgs e)
        {
            DataTable dt = Provider.ExecuteDataTable("p_tblEmployee_getNV_PB",
                    new System.Data.SqlClient.SqlParameter("idPB", LoginHelper.user.idKhoiPB));
            cboNguoiQuanLy.Properties.DataSource = dt;
            
        }

        private void cboNguoiQuanLy_EditValueChanged(object sender, EventArgs e)
        {
            var Name=db.tblEmployees.Where(k => k.EmployeeID == cboNguoiQuanLy.EditValue.ToString()).FirstOrDefault();
            if(Name != null)
                txtChucVuQL.Text = (Name.EmpTypeName);
        }

        private void radQTThucHienViecChung_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLyDoQTThucHienCVChung.Enabled = radQTThucHienViecChung.SelectedIndex == 1 ? true : false;
            txtLyDoQTThucHienCVChung.Text = radQTThucHienViecChung.SelectedIndex == 1 ? txtLyDoQTThucHienCVChung.Text : string.Empty;
        }

        private void radQTThucHienCVTaiPB_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLyDoQTThucHienCVTaiPB.Enabled = radQTThucHienCVTaiPB.SelectedIndex == 1 ? true : false;
            txtLyDoQTThucHienCVTaiPB.Text = radQTThucHienCVTaiPB.SelectedIndex == 1 ? txtLyDoQTThucHienCVTaiPB.Text : string.Empty;
        }

        private void radMoiTruongLamViecChung_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtMoiTruongLamViecChung.Enabled = radMoiTruongLamViecChung.SelectedIndex == 1 ? true : false;
            txtMoiTruongLamViecChung.Text = radMoiTruongLamViecChung.SelectedIndex == 1 ? txtMoiTruongLamViecChung.Text : string.Empty;

        }

        private void radMoiTruongLamViecTaiPB_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMoiTruongLamViecTaiPB.Enabled = radMoiTruongLamViecTaiPB.SelectedIndex == 1 ? true : false;
            txtMoiTruongLamViecTaiPB.Text = radMoiTruongLamViecTaiPB.SelectedIndex == 1 ? txtMoiTruongLamViecTaiPB.Text : string.Empty;
        }

        private void radQD_QT_CS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLyDoQD_QT_CS.Enabled = radQD_QT_CS.SelectedIndex == 1 ? true : false;
            txtLyDoQD_QT_CS.Text = radQD_QT_CS.SelectedIndex == 1 ? txtLyDoQD_QT_CS.Text : string.Empty;
        }

        private void radHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHD.Enabled = radHD.SelectedIndex == 1 ? true : false;
            txtHD.Text = radHD.SelectedIndex == 1 ? txtHD.Text : string.Empty;
        }


        private void grvTNCV_ProcessGridKey(object sender, KeyEventArgs e)
        {
           
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                deleteRecord(gridView3);
                e.Handled = true;
            }
        }
        private void deleteRecord(GridView grv)
        {
            //lay thong tin cac dong dc chon
            int[] idx = grv.GetSelectedRows();//GetSelectedRows tra lai index cua row dc chon
            if (idx.Length == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            var rows = idx.Select(i => grv.GetDataRow(i)); // GetDataRow tra lai dataarow cua datatable
            if (GUIHelper.ConfirmBox(string.Format("Bạn muốn xóa {0} bản ghi đã chọn?", rows.Count()), "Xác nhận lại"))
            {
                foreach (DataRow r in rows)
                    r.Delete();
                //r.Table.Rows.Remove(r);
            }
        }
        private void grvQHCV_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                deleteRecord(grd);
                e.Handled = true;
            }
        }
    }
}
