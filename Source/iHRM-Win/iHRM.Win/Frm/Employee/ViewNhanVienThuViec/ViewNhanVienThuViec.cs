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
using iHRM.Win.DungChung;
using System.IO;
using iHRM.Win.Frm.XtraReportTemplate;
using iHRM.Win.Frm.TuyenDung;
using iHRM.Win.Frm.Employee;
using iHRM.Common.Code;


namespace iHRM.Win.Frm.Employee.ViewNhanVienThuViec
{
    public partial class ViewNhanVienThuViec : frmBase
    {
        global::iHRM.Core.Business.Logic.Employee.tblEmployee_TV_TuDanhGia logic = new global::iHRM.Core.Business.Logic.Employee.tblEmployee_TV_TuDanhGia();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        iHRM.Core.Controller.Report.GetData controller = new Core.Controller.Report.GetData();
        DataTable dtData = new DataTable();
        DataRow CRow;
        frmNhanVienTuDanhGia dlgEditorNhanVienTuDanhGia;
        List<PhamVi> arrSex = new List<PhamVi>();
        frmQLDanhGia dlgEditorfrmQLDanhGia;
        public static string strFunction = "";
        public class PhamVi
        {
            string _MaPhamVi;

            public string MaPhamVi
            {
                get { return _MaPhamVi; }
                set { _MaPhamVi = value; }
            }
            string _TenPhamVi;

            public string TenPhamVi
            {
                get { return _TenPhamVi; }
                set { _TenPhamVi = value; }
            }
        }
        public ViewNhanVienThuViec()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            LoadPhamVi();
        }
        private void LoadPhamVi()
        {
            ////chọn phạm vi đánh giá
            arrSex = new List<PhamVi>();
            arrSex.Add(new PhamVi { TenPhamVi = "Nhân Viên", MaPhamVi = "NV" });
            arrSex.Add(new PhamVi { TenPhamVi = "Quản lý", MaPhamVi = "QL" });
            arrSex.Add(new PhamVi { TenPhamVi = "Trưởng Phòng", MaPhamVi = "TP" });
            arrSex.Add(new PhamVi { TenPhamVi = "Tuyển dụng", MaPhamVi = "TD" });
            arrSex.Add(new PhamVi { TenPhamVi = "Đã đánh giá", MaPhamVi = "DD" });

            cboPhamViPV.DataSource = arrSex;
            cboPhamViPV.DisplayMember = "TenPhamVi";
            cboPhamViPV.ValueMember = "MaPhamVi";
            cboPhamViPV.SelectedIndex = 0;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().ToList();
            foreach (int rowhandler in grv.GetSelectedRows())
            {
                var r = grv.GetDataRow(rowhandler);
            }

            string Key = txtSearchKey.Text;
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu nhân viên...";
            dw_it.OnDoing = (s, ev) =>
            {
                logic.VirtualPaging.PageSize = pageNavigator1.PageSize;
                logic.VirtualPaging.Page = pageNavigator1.CurrentPage;
                //if(chkUngVienPV.Checked)
                //{
                //    dtData = controller.GetDataUngVienPVTrongNgay();
                //}
                //else
                //string phamvi = "NV";
                //switch(cboPhamViPV.SelectedText)
                //{
                //    case "Trưởng Phòng": phamvi = "TP"; break;
                //    case "Tuyển Dụng": phamvi = "TD"; break;
                //    case "Quản Lý": phamvi = "QL"; break;
                //}
                dtData = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", Key),
                                      new System.Data.SqlClient.SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                                      new System.Data.SqlClient.SqlParameter("denNgay", chonKyLuong1.DenNgay),
                                      new System.Data.SqlClient.SqlParameter("idPB", LoginHelper.user.idKhoiPB),
                                      new System.Data.SqlClient.SqlParameter("PhamVi", cboPhamViPV.SelectedValue),
                                      new System.Data.SqlClient.SqlParameter("isall", chkisall.Checked ? 1 : 0)
                                      );
                dw_it.bw.ReportProgress(1, dtData);
                dw_it.bw.ReportProgress(2, logic.VirtualPaging.RecordCount);

            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    grd.DataSource = data.UserState; btnFind.Enabled = true;
                }
                else if (data.ProgressPercentage == 2)
                {
                    pageNavigator1.RecordCount = (int)data.UserState;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

 
        public string get_id_string_nn(string text)
        {
            string[] ngoaingu = text.Trim().Split(',');
            string id_nn = string.Empty;
            //dr["LangID"] = GetID_ds(dsDM.Tables[2], "LangName", dr["NgoaiNguName"] as string, "LangID");
            foreach(string nn in ngoaingu)
            {
                DataTable dt = Provider.ExecuteDataTable("tblRef_Language_GetAll");
                id_nn += GetID_ds(dt, "LangName", nn, "LangID")+",";
            }
            id_nn += ")";
            return id_nn.Replace(",)","");
        }
        object GetID_ds(DataTable dt, string textColName, string textValue, string idColName)
        {
            if (!string.IsNullOrWhiteSpace(textValue))
            {
                var r = dt.Select("[" + textColName + "]='" + textValue.Trim() + "'").FirstOrDefault();
                if (r != null)
                    return r[idColName];
            }
            return DBNull.Value;
        }
        private class LoaiUngVien
        {
            public string LoaiUngVienName { get; set; }
            public string LoaiUngVienID { get; set; }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CRow = grv.GetFocusedDataRow();
            if (dlgEditorNhanVienTuDanhGia == null)
            {
                dlgEditorNhanVienTuDanhGia = new frmNhanVienTuDanhGia();
                dlgEditorNhanVienTuDanhGia.Owner = this;
            }
            dlgEditorNhanVienTuDanhGia.Show();
            dtData = Provider.ExecuteDataTable("p_tblEmployee_TV_TuDanhGia_GetAllInfoNV", new System.Data.SqlClient.SqlParameter("EmployeeID", CRow["EmployeeID"] as string));
            if(dtData.Rows[0]["soChungTu"] == DBNull.Value)
            {
                var count = db.tblEmployee_TV_TuDanhGias.Where(p => p.NgayDongY.Value.Year == DateTime.Now.Year).Count();
                dtData.Rows[0]["soChungTu"] = string.Format("TD/D.07/{0:00}/{1:0000}", DateTime.Now.Year.ToString().Substring(2, 2), count + 1);
            }
            dlgEditorNhanVienTuDanhGia.MyValue = dtData.Rows[0];
        }

        private void repositoryItemButtonEditPhieuTuDanhGia_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //xuất phiếu nhân viên tự đánh giá 
            CRow = grv.GetFocusedDataRow();

            //lấy được mã ứng viên
            DataSet dsDM = Provider.ExecuteDataSetReader("p_tblEmployee_TV_TuDanhGia_GetInfo", new System.Data.SqlClient.SqlParameter("EmployeeID", CRow["EmployeeID"] as string));
            if (dsDM.Tables[0].Rows.Count <= 0)
            {
                GUIHelper.MessageBox("Nhân viên thử việc này chưa tự đánh giá.");
                return;
            }
            WordUltil wd = new WordUltil(Path.Combine(win_globall.apppath, @"ExcelTemplate\TuyenDung\phieuNhanVienTuDanhGia.dotx"), true);
            #region THÔNG TIN ỨNG VIÊN
            Dictionary<string, string> dic = new Dictionary<string, string>();
            // Xuất các dữ liệu mình chuẩn bị ở Field (ở đây mình lọc lấy dữ liệu ở dạng linq)
            dic.Add("EmployeeIDNV", dsDM.Tables[0].Rows[0]["EmployeeIDNV"] as string);

            dic.Add("PDG", dsDM.Tables[0].Rows[0]["PDG"] as string);
            dic.Add("ThoiGianThuViec", dsDM.Tables[0].Rows[0]["ThoiGianThuViec"] as string);

            dic.Add("EmployeeIDHS", dsDM.Tables[0].Rows[0]["EmployeeIDHS"] as string);
            dic.Add("HoVaTen", dsDM.Tables[0].Rows[0]["HoVaTen"] as string);
            dic.Add("TrinhDo", dsDM.Tables[0].Rows[0]["TrinhDo"] as string);
            dic.Add("ChucDanh", dsDM.Tables[0].Rows[0]["ChucDanh"] as string);
            dic.Add("BoPhan", dsDM.Tables[0].Rows[0]["BoPhan"] as string);
            dic.Add("NgayNhanViec", dsDM.Tables[0].Rows[0]["NgayNhanViec"] as string);
            dic.Add("HoTenQL", dsDM.Tables[0].Rows[0]["HoTenQL"] as string);
            dic.Add("ChucVuQL", dsDM.Tables[0].Rows[0]["ChucVuQL"] as string);
            dic.Add("QDQT_CS_C", dsDM.Tables[0].Rows[0]["QDQT_CS_C"] as string);
            dic.Add("QDQT_CS_K", dsDM.Tables[0].Rows[0]["QDQT_CS_K"] as string);
            dic.Add("LydoThucHienQuyDinh", dsDM.Tables[0].Rows[0]["LydoThucHienQuyDinh"] as string);
            dic.Add("MTLV_C", dsDM.Tables[0].Rows[0]["MTLV_C"] as string);
            dic.Add("MTLV_K", dsDM.Tables[0].Rows[0]["MTLV_K"] as string);
            dic.Add("LyDoMTLamViecChung", dsDM.Tables[0].Rows[0]["LyDoMTLamViecChung"] as string);
            dic.Add("MTLV_T_PB_C", dsDM.Tables[0].Rows[0]["MTLV_T_PB_C"] as string);
            dic.Add("MTLV_T_PB_K", dsDM.Tables[0].Rows[0]["MTLV_T_PB_K"] as string);
            dic.Add("LyDoMTLamViecTaiPB", dsDM.Tables[0].Rows[0]["LyDoMTLamViecTaiPB"] as string);
            dic.Add("THCV_Chung_C", dsDM.Tables[0].Rows[0]["THCV_Chung_C"] as string);
            dic.Add("THCV_Chung_K", dsDM.Tables[0].Rows[0]["THCV_Chung_K"] as string);
            dic.Add("LyDoQTCongViecChung", dsDM.Tables[0].Rows[0]["LyDoQTCongViecChung"] as string);
            dic.Add("THCV_PB_C", dsDM.Tables[0].Rows[0]["THCV_PB_C"] as string);
            dic.Add("THCV_PB_K", dsDM.Tables[0].Rows[0]["THCV_PB_K"] as string);
            dic.Add("LyDoQTCongViecChungPB", dsDM.Tables[0].Rows[0]["LyDoQTCongViecChungPB"] as string);
            dic.Add("HDLD_C", dsDM.Tables[0].Rows[0]["HDLD_C"] as string);
            dic.Add("HDLD_K", dsDM.Tables[0].Rows[0]["HDLD_K"] as string);
            dic.Add("LyDoDongYKyHD", dsDM.Tables[0].Rows[0]["LyDoDongYKyHD"] as string);

            dic.Add("DeXuat", dsDM.Tables[0].Rows[0]["DeXuat"] as string);
            dic.Add("NgayDongY", dsDM.Tables[0].Rows[0]["NgayDongY"] as string);

            wd.WriteFields(dic);
            #endregion
            //THÔNG TIN trách nhiệm trong công việc
            wd.WriteTable(dsDM.Tables[1], 2);
            //THÔNG TIN quyền hạn trong công viêc
            wd.WriteTable(dsDM.Tables[2], 3); 
           


        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            CRow = grv.GetFocusedDataRow();
            if (dlgEditorfrmQLDanhGia == null)
            {
                dlgEditorfrmQLDanhGia = new frmQLDanhGia();
                dlgEditorfrmQLDanhGia.Owner = this;
                dlgEditorfrmQLDanhGia.isTruongPhong = BitHelper.Has(iRule.customRules ?? 0, 32);
            }
            
            
            try
            {
                if (!(cboPhamViPV.Text == "Nhân Viên"))
                {
                    dlgEditorfrmQLDanhGia.Show();
                    dtData = Provider.ExecuteDataTable("p_tblEmployee_TV_TuDanhGia_GetInfoQL", new System.Data.SqlClient.SqlParameter("EmployeeID", CRow["EmployeeID"] as string));
                    dlgEditorfrmQLDanhGia.MyValue = dtData.Rows[0];
                    dlgEditorfrmQLDanhGia.PhanQuyen(cboPhamViPV.Text);
                }
                else
                {
                    GUIHelper.MessageBox("Chọn phạm vi đánh giá không đúng.");
                }
            }
            catch { }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //xuất phiếu nhân viên tự đánh giá 
            CRow = grv.GetFocusedDataRow();

            //lấy được mã ứng viên
            DataSet dsDM = Provider.ExecuteDataSetReader("p_tblEmployee_TV_TuDanhGia_GetInfoPhieuDanhGia", new System.Data.SqlClient.SqlParameter("EmployeeID", CRow["EmployeeID"] as string));
            if (dsDM.Tables[0].Rows.Count <= 0)
            {
                GUIHelper.MessageBox("Nhân viên thử việc này chưa tự đánh giá.");
                return;
            }
            //if (dsDM.Tables[0].Rows[0]["GDXN"] == DBNull.Value)
            //{
            //    GUIHelper.MessageBox("Giám đốc duyệt mới được in phiếu đánh giá.");
            //    return;
            //}
            WordUltil wd = new WordUltil(Path.Combine(win_globall.apppath, @"ExcelTemplate\TuyenDung\phieuDanhGia.dotx"), true);
            #region THÔNG TIN ỨNG VIÊN
            Dictionary<string, string> dic = new Dictionary<string, string>();
            // Xuất các dữ liệu mình chuẩn bị ở Field (ở đây mình lọc lấy dữ liệu ở dạng linq)
            dic.Add("EmployeeIDNV", dsDM.Tables[0].Rows[0]["EmployeeIDNV"] as string);
            dic.Add("EmployeeIDHS", dsDM.Tables[0].Rows[0]["EmployeeIDHS"] as string);
            dic.Add("HoVaTen", dsDM.Tables[0].Rows[0]["HoVaTen"] as string);
            dic.Add("TrinhDo", dsDM.Tables[0].Rows[0]["TrinhDo"] as string);
            dic.Add("ChucDanh", dsDM.Tables[0].Rows[0]["ChucDanh"] as string);
            dic.Add("BoPhan", dsDM.Tables[0].Rows[0]["BoPhan"] as string);
            dic.Add("NgayNhanViec", dsDM.Tables[0].Rows[0]["NgayNhanViec"] as string);
            dic.Add("HoTenQL", dsDM.Tables[0].Rows[0]["HoTenQL"] as string);
            dic.Add("ChucVuQL", dsDM.Tables[0].Rows[0]["ChucVuQL"] as string);

            dic.Add("Ngay", dsDM.Tables[0].Rows[0]["Ngay"] as string);
            dic.Add("Thang", dsDM.Tables[0].Rows[0]["Thang"] as string);
            dic.Add("Nam", dsDM.Tables[0].Rows[0]["Nam"] as string);
            dic.Add("soChungTu", dsDM.Tables[0].Rows[0]["soChungTu"] as string);
            dic.Add("QLKetQua", dsDM.Tables[0].Rows[0]["QLKetQua"] as string);

            dic.Add("KetThucThuViec", dsDM.Tables[0].Rows[0]["KetThucThuViec"] as string);

            dic.Add("KienThucChuyenMon", dsDM.Tables[0].Rows[0]["KienThucChuyenMon"] as string);
            dic.Add("KienThucLamViec", dsDM.Tables[0].Rows[0]["KienThucLamViec"] as string);
            dic.Add("KiNangTiepThu", dsDM.Tables[0].Rows[0]["KiNangTiepThu"] as string);
            dic.Add("KiNangHieuQuaCV", dsDM.Tables[0].Rows[0]["KiNangHieuQuaCV"] as string);
            dic.Add("KiNangTuLapKeHoach", dsDM.Tables[0].Rows[0]["KiNangTuLapKeHoach"] as string);
            dic.Add("KiNangGiaoTiep", dsDM.Tables[0].Rows[0]["KiNangGiaoTiep"] as string);
            dic.Add("KiNangSangTao", dsDM.Tables[0].Rows[0]["KiNangSangTao"] as string);
            dic.Add("ThaiDoTuGiac", dsDM.Tables[0].Rows[0]["ThaiDoTuGiac"] as string);
            dic.Add("ThaiDoTrungThuc", dsDM.Tables[0].Rows[0]["ThaiDoTrungThuc"] as string);
            dic.Add("ThaiDoHocHoi", dsDM.Tables[0].Rows[0]["ThaiDoHocHoi"] as string);
            dic.Add("ThaiDoTrachNhiem", dsDM.Tables[0].Rows[0]["ThaiDoTrachNhiem"] as string);
            dic.Add("ThaiDoDongGop", dsDM.Tables[0].Rows[0]["ThaiDoDongGop"] as string);
            dic.Add("ThaiDoHoTro", dsDM.Tables[0].Rows[0]["ThaiDoHoTro"] as string);
            dic.Add("QLDeNghiNgay", dsDM.Tables[0].Rows[0]["QLDeNghiNgay"] as string);
            dic.Add("NgayDongY", dsDM.Tables[0].Rows[0]["NgayDongY"] as string);


            dic.Add("TBPNgayPD", dsDM.Tables[0].Rows[0]["TBPNgayPD"] as string);
            dic.Add("TBPLuongThuViec", dsDM.Tables[0].Rows[0]["TBPLuongThuViec"] as string);
            dic.Add("TBPLuongDeNghi", dsDM.Tables[0].Rows[0]["TBPLuongDeNghi"] as string);
            dic.Add("TBPLuongCoBan", dsDM.Tables[0].Rows[0]["TBPLuongCoBan"] as string);
            dic.Add("TBPLuongBHXH", dsDM.Tables[0].Rows[0]["TBPLuongBHXH"] as string);
            dic.Add("GDNgay", dsDM.Tables[0].Rows[0]["GDNgay"] as string);
            dic.Add("GDPhanHoi", dsDM.Tables[0].Rows[0]["GDPhanHoi"] as string);

            dic.Add("HoTenTBP", dsDM.Tables[0].Rows[0]["HoTenTBP"] as string);
            dic.Add("tenGiamDoc", dsDM.Tables[0].Rows[0]["tenGiamDoc"] as string);

            wd.WriteFields(dic);
            #endregion
            //THÔNG TIN trách nhiệm trong công việc
            wd.WriteTable(dsDM.Tables[1], 2);
        }
        private void grv_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["stype"]).ToString();
                if (category == "1")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                if (category == "2")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }
       

        private void pageNavigator1_OnPageChange(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
        }

        private void txtSearchKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(null, null);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void splitContainerControl1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
