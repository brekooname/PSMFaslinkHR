using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Employee.ViewNhanVienThuViec
{
    public partial class frmQLDanhGia : dlgBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public string duoiFile = "";
        public byte[] dataFile;
        public bool isChangedFile = false;
        public bool isTuyenDung = false;
        public int _PhamVi;
        public DataTable dt_congViecChinh = null;
        public bool isTruongPhong = false;
        public frmQLDanhGia()
        {
            InitializeComponent();
            AddControlBinding();
        }
        protected override void FormGetData()
        {
            base.FormGetData();

            this.MyValue["tenFile"] = btnFile.Text;


            this.MyValue["QLDeNghi"] = radHopDong.SelectedIndex != -1 ? radHopDong.EditValue : DBNull.Value;
            dt_congViecChinh = grv.DataSource as DataTable;

        }
        protected override void FormSetData()
        {
            base.FormSetData();
            //thông tin hợp đồng
            radHopDong.SelectedIndex = this.MyValue["QLDeNghi"] != DBNull.Value ? Convert.ToInt32(this.MyValue["QLDeNghi"].ToString()) : -1;

            #region phân quyền
        
           
            #endregion
            //mn:
            #region thông tin phiếu đánh giá thử việc
            //thông tin kĩ năng và kiến thức
            radKienThucChuyenMon.SelectedIndex = this.MyValue["KienThucChuyenMon"] != DBNull.Value ? Convert.ToInt32(this.MyValue["KienThucChuyenMon"].ToString()) : -1;
            radkinhNghiemLamViec.SelectedIndex = this.MyValue["KienThucLamViec"] != DBNull.Value ? Convert.ToInt32(this.MyValue["KienThucLamViec"].ToString()) : -1;
            radKhaNang.SelectedIndex = this.MyValue["KiNangTiepThu"] != DBNull.Value ? Convert.ToInt32(this.MyValue["KiNangTiepThu"].ToString()) : -1;
            radHieuQuaCongViec.SelectedIndex = this.MyValue["KiNangHieuQuaCV"] != DBNull.Value ? Convert.ToInt32(this.MyValue["KiNangHieuQuaCV"].ToString()) : -1;

            radTuLapKeHoach.SelectedIndex = this.MyValue["KiNangTuLapKeHoach"] != DBNull.Value ? Convert.ToInt32(this.MyValue["KiNangTuLapKeHoach"].ToString()) : -1;
            radKhaNangGiaoTiep.SelectedIndex = this.MyValue["KiNangGiaoTiep"] != DBNull.Value ? Convert.ToInt32(this.MyValue["KiNangGiaoTiep"].ToString()) : -1;
            radSangTaoCV.SelectedIndex = this.MyValue["KiNangSangTao"] != DBNull.Value ? Convert.ToInt32(this.MyValue["KiNangSangTao"].ToString()) : -1;
            //thông tin thái độ
            radTinhThanTuGiac.SelectedIndex = this.MyValue["ThaiDoTuGiac"] != DBNull.Value ? Convert.ToInt32(this.MyValue["ThaiDoTuGiac"].ToString()) : -1;
            radTinhTrungThuc.SelectedIndex = this.MyValue["ThaiDoTrungThuc"] != DBNull.Value ? Convert.ToInt32(this.MyValue["ThaiDoTrungThuc"].ToString()) : -1;
            radCoTrachNhiem.SelectedIndex = this.MyValue["ThaiDoTrachNhiem"] != DBNull.Value ? Convert.ToInt32(this.MyValue["ThaiDoTrachNhiem"].ToString()) : -1;
            radCoNhungDeXuat.SelectedIndex = this.MyValue["ThaiDoDongGop"] != DBNull.Value ? Convert.ToInt32(this.MyValue["ThaiDoDongGop"].ToString()) : -1;
            radHoTroDongNghiep.SelectedIndex = this.MyValue["ThaiDoHoTro"] != DBNull.Value ? Convert.ToInt32(this.MyValue["ThaiDoHoTro"].ToString()) : -1;
            radTinhThanHocHoi.SelectedIndex = this.MyValue["ThaiDoHocHoi"] != DBNull.Value ? Convert.ToInt32(this.MyValue["ThaiDoHocHoi"].ToString()) : -1;

            //thông tin công việc đã làm của nhân viên
            //var id_tam=(db.tblEmployee_TV_TuDanhGias.Where(k=>k.idUV == this.MyValue["MaNhanVien"] as string)).FirstOrDefault().id;
            //grv.DataSource = db.tblEmployee_TV_TuDanhGia_TrachNhiems.Where(p => p.idTDG == id_tam);
            #endregion
            //Display file
            if (this.MyValue["duoiFile"] != DBNull.Value)
            {
                lbDuoiFile.Text = this.MyValue["duoiFile"] as string;
            }
            if (this.MyValue["tenFile"] != DBNull.Value)
            {
                btnFile.Text = this.MyValue["tenFile"] as string;
            }
            else
            {
                btnFile.Text = "";
            }
            #region load công việc đã thực hiện
            DataSet dsDM = Provider.ExecuteDataSetReader("p_tblEmployee_TV_TuDanhGia_GetTN_QH", new System.Data.SqlClient.SqlParameter("EmployeeID", this.MyValue["MaNhanVien"].ToString()));
            grv.DataSource = dsDM.Tables[0];
            #endregion



        }
        public void AddControlBinding()
        {
            //thông tin nhân viên
            dlgData.CB.Add(new ControlBinding("MaNhanVien", txtMaNhanVien, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("HoTen", txtTenNhanVien, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("ChucDanh", txtChucVu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BoPhan", txtBoPhan, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("BangCap", txtBangCap, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("NgayVaoLam", dateNgayNhanViec, ControlBinding_DataType.DateTime));
            //thông tin quản lý
            dlgData.CB.Add(new ControlBinding("MaQuanLy", cboNguoiQuanLy, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("HDTuNgay", dateTuNgay1, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("ThoiViecTuNgay", dateTuNgay2, ControlBinding_DataType.DateTime));

            dlgData.CB.Add(new ControlBinding("TBPNgayPD", date_TBPNgayPD, ControlBinding_DataType.DateTime));
            dlgData.CB.Add(new ControlBinding("idTBP", cboTruongPhong, ControlBinding_DataType.String));

            //xác nhận của quản lý,trưởng bộ phận và giám đốc
            dlgData.CB.Add(new ControlBinding("QLXacNhan", chkQLXN, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("TBPXN", chkTBPXN, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("GDXN", chkGDXN, ControlBinding_DataType.Bool));
            dlgData.CB.Add(new ControlBinding("GDPhanHoi", txtGDPhanHoi, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding("GDNgay", date_GDNgay, ControlBinding_DataType.DateTime));


            dlgData.CB.Add(new ControlBinding("KienThucChuyenMon", radKienThucChuyenMon, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("KienThucLamViec", radkinhNghiemLamViec, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("KiNangTiepThu", radKhaNang, ControlBinding_DataType.Int));

            dlgData.CB.Add(new ControlBinding("KiNangHieuQuaCV", radHieuQuaCongViec, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("KiNangTuLapKeHoach", radTuLapKeHoach, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("KiNangGiaoTiep", radKhaNangGiaoTiep, ControlBinding_DataType.Int));

            dlgData.CB.Add(new ControlBinding("KiNangSangTao", radSangTaoCV, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("ThaiDoTuGiac", radTinhThanTuGiac, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("ThaiDoTrungThuc", radTinhTrungThuc, ControlBinding_DataType.Int));

            dlgData.CB.Add(new ControlBinding("ThaiDoTrachNhiem", radCoTrachNhiem, ControlBinding_DataType.Int));

            dlgData.CB.Add(new ControlBinding("capBac", cboCapBac, ControlBinding_DataType.String));

            dlgData.CB.Add(new ControlBinding("ThaiDoDongGop", radCoNhungDeXuat, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("ThaiDoHoTro", radHoTroDongNghiep, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("ThaiDoHocHoi", radTinhThanHocHoi, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("QLDeNghi", radHopDong, ControlBinding_DataType.Int));

            dlgData.CB.Add(new ControlBinding("TBPLuongThuViec", txtLuongThuViec, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("TBPLuongChinhThuc", txtLuongDeNghi, ControlBinding_DataType.Int));
            //dlgData.CB.Add(new ControlBinding("TBPLuongDeNghi", txtLuongDeNghi, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("TBPLuongCoBan", txtLuongCoBan, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("TBPLuongBHXH", LuongThamGiaBHXH, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("soChungTu", txtSoChungTu, ControlBinding_DataType.String));


            dlgData.CB.Add(new ControlBinding("KienThucChuyenMonKhac", txtKienThucChuyenMonKhac, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("KinhNghiemLamViecKhac", txtKinhNghiemLamViecKhac, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("KhaNangTiepThuKhac", txtKhaNangTiepThu, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("HieuQuaCongViecKhac", txtHieuQuaCongViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("KhaNangGiaoTiepKhac", txtKhaNangGiaoTiep, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("SangTaoTrongCongViecKhac", txtSangTaoTrongCongViec, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("TuLapKeHoachKhac", txtTuLapKeHoach, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("TinhThanTuGiacKhac", txtThaiDoTuGiac, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("TinhTrungThucKhac", txtThaiDoTrungThuc, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("TinhThanHocHoiKhac", txtThaiDoHocHoi, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("CoTrachNhiemKhac", txtThaiDoTrachNhiem, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("CoNhungDeXuat", txtThaiDoDeXuat, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("HoTroDongNghiepKhac", txtThaiDoHoTro, ControlBinding_DataType.String));

        }
        private void GetAllDataInTaBle_ByEmpID(string EmpID, string TableName, GridControl grc, string addStrWhere = "")
        {
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

            buttonPanel1.enableButtonSave = false;

            cboCapBac.Properties.DataSource = db.tblRef_Positions;
            DataTable dt = Provider.ExecuteDataTable("p_tblEmployee_getNV_PB",
                    new System.Data.SqlClient.SqlParameter("idPB", LoginHelper.user.idKhoiPB));
            cboNguoiQuanLy.Properties.DataSource = dt;
            cboTruongPhong.Properties.DataSource = dt;
        }
        public void PhanQuyen(string value)
        {
            switch (value)
            {
                case "Quản lý":
                    {
                        groupControl12.Enabled = false;
                        groupControl3.Enabled = false;
                        cboNguoiQuanLy.Enabled = groupControl13.Enabled = false;
                        groupControl7.Enabled = false;
                        groupControl1.Enabled = false;
                        groupControl2.Enabled = false;
                        groupControl4.Enabled = false;
                    } break;
                case "Trưởng Phòng":
                    {
                        groupControl12.Enabled = false;
                        groupControl3.Enabled = false;
                        cboNguoiQuanLy.Enabled = groupControl13.Enabled = false;
                        groupControl7.Enabled = false;
                        groupControl1.Enabled = false;
                        groupControl2.Enabled = false;
                        groupControl4.Enabled = false;

                        cboTruongPhong.Enabled = groupControl5.Enabled = false;


                    } break;
                case "Tuyển dụng":
                    {
                        groupControl12.Enabled = false;
                        groupControl3.Enabled = false;
                        cboNguoiQuanLy.Enabled = groupControl13.Enabled = false;
                        groupControl7.Enabled = false;
                        groupControl1.Enabled = false;
                        groupControl2.Enabled = false;
                        groupControl4.Enabled = false;

                        cboTruongPhong.Enabled = groupControl5.Enabled = false;
                    } break;

            }
        }

        private void cboNguoiQuanLy_EditValueChanged(object sender, EventArgs e)
        {
            var Name = db.tblEmployees.Where(k => k.EmployeeID == cboNguoiQuanLy.EditValue).FirstOrDefault();
            if (Name != null)
                txtChucVuQL.Text = (Name.EmpTypeName);
        }

        private void radHopDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radHopDong.SelectedIndex == 0)
            {
                penKiHD.Visible = true;
                penThoiViec.Visible = false;
                if (dateTuNgay1.EditValue == null)
                    dateTuNgay1.EditValue = DateTime.Now;
                dateTuNgay2.EditValue = null;
                chkQLXN.Visible = true;
            }
            if (radHopDong.SelectedIndex == 2)
            {
                penKiHD.Visible = false;
                penThoiViec.Visible = true;
                if (dateTuNgay2.EditValue == null)
                    dateTuNgay2.EditValue = DateTime.Now;
                dateTuNgay1.EditValue = null;
                chkQLXN.Visible = true;
            }
            if (radHopDong.SelectedIndex == 1)
            {
                penKiHD.Visible = false;
                penThoiViec.Visible = false;
                chkQLXN.Visible = false;
            }
        }

        private void btnFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) //Chọn file
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
                    if (this.MyValue["idFile"] == DBNull.Value)
                    {
                        this.MyValue["idFile"] = Guid.NewGuid();
                    }
                    try
                    {
                        this.MyValue["dataFile"] = System.IO.File.ReadAllBytes(od.FileNames[0]);
                        btnFile.Text = od.FileNames[0];
                    }
                    catch (Exception)
                    {
                        isChangedFile = false;
                        throw;
                    }
                    duoiFile = Path.GetExtension(btnFile.Text);
                    lbDuoiFile.Text = duoiFile;
                    this.MyValue["duoiFile"] = duoiFile;
                    isChangedFile = true;
                }
            }
            else //Hủy file
            {
                btnFile.Text = "";
                lbDuoiFile.Text = "";
                this.MyValue["dataFile"] = DBNull.Value;
                this.MyValue["duoiFile"] = DBNull.Value;
                isChangedFile = true;
            }
        }

        private void lbXemFile_MouseClick(object sender, MouseEventArgs e)
        {
            FileStorageHelper fh = new FileStorageHelper();
            if (this.MyValue["dataFile"] != DBNull.Value && this.MyValue["duoiFile"] != DBNull.Value)
            {
                fh.DownLoadAndShowFILE(this.MyValue["dataFile"] as byte[], this.MyValue["duoiFile"].ToString());
            }
            else
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
        }

        private void radKienThucChuyenMon_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void radKienThucChuyenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKienThucChuyenMonKhac.Enabled = radKienThucChuyenMon.SelectedIndex == 3 ? false : false;
            txtKienThucChuyenMonKhac.Text = radKienThucChuyenMon.SelectedIndex == 3 ? txtKienThucChuyenMonKhac.Text : string.Empty;
        }

        private void radkinhNghiemLamViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKinhNghiemLamViecKhac.Enabled = radkinhNghiemLamViec.SelectedIndex == 3 ? false : false;
            txtKinhNghiemLamViecKhac.Text = radkinhNghiemLamViec.SelectedIndex == 3 ? txtKinhNghiemLamViecKhac.Text : string.Empty;
        }

        private void radKhaNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKhaNangTiepThu.Enabled = radKhaNang.SelectedIndex == 2 ? false : false;
            txtKhaNangTiepThu.Text = radKhaNang.SelectedIndex == 2 ? txtKhaNangTiepThu.Text : string.Empty;
        }

        private void radHieuQuaCongViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHieuQuaCongViec.Enabled = radHieuQuaCongViec.SelectedIndex == 2 ? false : false;
            txtHieuQuaCongViec.Text = radHieuQuaCongViec.SelectedIndex == 2 ? txtHieuQuaCongViec.Text : string.Empty;
        }

        private void radTuLapKeHoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTuLapKeHoach.Enabled = radTuLapKeHoach.SelectedIndex == 2 ? false : false;
            txtTuLapKeHoach.Text = radTuLapKeHoach.SelectedIndex == 2 ? txtTuLapKeHoach.Text : string.Empty;
        }

        private void radKhaNangGiaoTiep_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKhaNangGiaoTiep.Enabled = radKhaNangGiaoTiep.SelectedIndex == 2 ? false : false;
            txtKhaNangGiaoTiep.Text = radKhaNangGiaoTiep.SelectedIndex == 2 ? txtKhaNangGiaoTiep.Text : string.Empty;
        }

        private void radSangTaoCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSangTaoTrongCongViec.Enabled = radSangTaoCV.SelectedIndex == 2 ? false : false;
            txtSangTaoTrongCongViec.Text = radSangTaoCV.SelectedIndex == 2 ? txtSangTaoTrongCongViec.Text : string.Empty;
        }

        private void radTinhThanTuGiac_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThaiDoTuGiac.Enabled = radTinhThanTuGiac.SelectedIndex == 3 ? false : false;
            txtThaiDoTuGiac.Text = radTinhThanTuGiac.SelectedIndex == 3 ? txtThaiDoTuGiac.Text : string.Empty;
        }

        private void radTinhTrungThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThaiDoTrungThuc.Enabled = radTinhTrungThuc.SelectedIndex == 3 ? false : false;
            txtThaiDoTrungThuc.Text = radTinhTrungThuc.SelectedIndex == 3 ? txtThaiDoTrungThuc.Text : string.Empty;
        }

        private void radTinhThanHocHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThaiDoHocHoi.Enabled = radTinhThanHocHoi.SelectedIndex == 3 ? false : false;
            txtThaiDoHocHoi.Text = radTinhThanHocHoi.SelectedIndex == 3 ? txtThaiDoHocHoi.Text : string.Empty;
        }

        private void radCoTrachNhiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThaiDoTrachNhiem.Enabled = radCoTrachNhiem.SelectedIndex == 3 ? false : false;
            txtThaiDoTrachNhiem.Text = radCoTrachNhiem.SelectedIndex == 3 ? txtThaiDoTrachNhiem.Text : string.Empty;
        }

        private void radCoNhungDeXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThaiDoDeXuat.Enabled = radCoNhungDeXuat.SelectedIndex == 3 ? false : false;
            txtThaiDoDeXuat.Text = radCoNhungDeXuat.SelectedIndex == 3 ? txtThaiDoDeXuat.Text : string.Empty;
        }

        private void radHoTroDongNghiep_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtThaiDoHoTro.Enabled = radHoTroDongNghiep.SelectedIndex == 3 ? false : false;
            txtThaiDoHoTro.Text = radHoTroDongNghiep.SelectedIndex == 3 ? txtThaiDoHoTro.Text : string.Empty;
        }

        private void grv_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                deleteRecord(gridView2);
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


    }
}
