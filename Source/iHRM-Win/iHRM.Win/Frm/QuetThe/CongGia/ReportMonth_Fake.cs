using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Win.Frm.XtraReportTemplate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using iHRM.Win.ExtClass;
using iHRM.Common.Code;
using DevExpress.XtraGrid;
using System.Data;
using System.Reflection;
using iHRM.Win.DungChung;
using iHRM.Win.Cls;

namespace iHRM.Win.Frm.QuetThe.CongGia
{
    public partial class ReportMonth_Fake : frmBase
    {
        Core.Controller.QuetThe.ReportMonth controller = new Core.Controller.QuetThe.ReportMonth();

        dlgReportMonth_Fake dlgEditor = new dlgReportMonth_Fake();
        dsXuLyQuetThe ds;

        DataTable dt = new DataTable();

        public bool Chitietbangcong = false;
        public ReportMonth_Fake()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            //toolStripButton3.Visible = BitHelper.Has(iRule.customRules ?? 0, 1);//bảng tính công
            //toolStripButton1.Enabled = Chitietbangcong = BitHelper.Has(iRule.customRules ?? 0, 2);//chi tiết bảng công
            //toolStripButton2.Enabled = BitHelper.Has(iRule.customRules ?? 0, 4);//Xuất Excel

            //toolStripPrint.Enabled = BitHelper.Has(iRule.customRules ?? 0, 8);//In bảng công tất cả trên lưới
            ////toolStripPrint.Enabled = BitHelper.Has(iRule.customRules ?? 0, 16);//In bảng công tất cả trên lưới
            dlgEditor.Owner = this;
            LoadGrvLayout(grv);
            TranslateForm();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s, ev) =>
            {

                dt = controller.GetData_Fake(ucChonDoiTuong_DS1.GetValue(),
                    chonKyLuong1.TuNgay,
                    chonKyLuong1.DenNgay,
                    true,
                    ucChonDoiTuong_DS1.getKhoiPBvalue()
                );
                dw_it.bw.ReportProgress(1, dt);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = data.UserState; btnFind.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            SaveFileDialog sd = new SaveFileDialog(); // Tạo dialog Save
            sd.Filter = "Excel 2007|*.xls";
            if (sd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))
                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, this.Text);
                return;
            }
            //---------------- Tạo 1 genexcel. tạo 1 luồng mới---------------------

            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel(); // Tạo 1 genexcel. tạo 1 luồng mới
            ge.OnDoing += (bw) =>
            {
                bw.ReportProgress(-1, "Xuất excel bảng công chi tiết"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (dt == null || dt.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu
                    return;
                }


                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description.

                ExcelExportHelper ex = new ExcelExportHelper("Report/ReportBangCongChiTiet.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("A2", "BẢNG CHẤM CÔNG THÁNG " + chonKyLuong1.TuNgay.Date.ToString("MM") + " NĂM " + chonKyLuong1.DenNgay.Date.ToString("yyyy"));
                ex.WriteToCell("H5", chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy"));
                ex.WriteToCell("AI10", "Đông Hưng, ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.ToString("MM") + " năm " + DateTime.Now.ToString("yyyy"));
                ex.WriteToCell("AJ15", LoginHelper.user.caption);
                ex.FillDataTable(dt); // Fill BC_FillData
                ex.RendAndFlush("ReportBangCongChiTiet" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
                bw.ReportProgress(2);
                #endregion
            };

            ge.OnReport += (ps, obj) =>
            {
                if (ps == 1)
                {
                    GUIHelper.Notifications("Không có dữ liệu"); // Thông báo k có dữ liệu.
                }
                else if (ps == 2)
                {// Tạo khung nằm góc trái bên dưới. Bấm vào để mở file.
                    var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);
                    c.AlertClick += (s1, e1) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sd.FileName,
                            UseShellExecute = true
                        });
                    };
                }
            };

            ge.Show(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //if (!Chitietbangcong)
            //    return;
            var r = grv.GetFocusedDataRow();
            if (r != null)
            {
                dlgEditor.empID = DbHelper.DrGetString(r, "EmployeeID");
                dlgEditor.empName = DbHelper.DrGetString(r, "tenNV");
                dlgEditor.tuNgay = chonKyLuong1.TuNgay;
                dlgEditor.denNgay = chonKyLuong1.DenNgay;

                dlgEditor.Show();
                dlgEditor.LoadData();
            }
        }

        private void grv_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column != colTotal && e.Column != colDepName_Final && e.Column != colLineName && e.Column != colTeamName
                && e.Column != colNgayVaoLam && e.Column != colEmployeeName && e.Column != colEmployeeID
                && e.Column != colNghiCoLuong && e.Column != colNghiKhongLuong && e.Column != colNghiCheDo
                && e.Column != colNghiKhongPhep && e.Column != colPosName && e.Column != colTotal_LamThem
                && e.Column != colNormalOT && e.Column != colNightOT && e.Column != colTotalOT
                && e.Column != colNghiPhepNam && e.Column != colTCDemLT && e.Column != colTCNgayLT && e.Column != colTotal_TCLamThem
                && e.Column != colSoLanDTVS5 && e.Column != colSoLanDTVS510 && e.Column != colSoLanDTVS10 && e.Column != colLeftdate
                )
            {
                int ngay = Convert.ToInt16(e.Column.GetCaption());
                if (ngay >= chonKyLuong1.TuNgay.Day)
                {
                    if (DateTime.DaysInMonth(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month) < ngay)
                    {
                        return;
                    }
                    DateTime a = new DateTime(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month, ngay);
                    if (a.DayOfWeek == DayOfWeek.Sunday)
                    {
                        e.Appearance.BackColor = Color.Lavender;
                    }
                }
                else
                {
                    if (DateTime.DaysInMonth(chonKyLuong1.DenNgay.Year, chonKyLuong1.DenNgay.Month) < ngay)
                    {
                        return;
                    }
                    DateTime a = new DateTime(chonKyLuong1.DenNgay.Year, chonKyLuong1.DenNgay.Month, ngay);
                    if (a.DayOfWeek == DayOfWeek.Sunday)
                    {
                        e.Appearance.BackColor = Color.Lavender;
                    }
                }
            }
        }

        private void toolStripPrint_Click(object sender, EventArgs e)
        {
            List<String> _lstr = new List<String>();

            foreach (DataRow _row in (grd.DataSource as DataTable).Rows)
            {
                _lstr.Add(_row["EmployeeID"].ToString());
            }

            Ham.report_ChamCongThang_ChiTiet_Fake(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay, _lstr);
            //// GHI CHÚ: SỬA Ở ĐÂY THÌ PHẢI SỬA CẢ Ở dlgReportMonth.
            //DateTime tuNgay = chonKyLuong1.TuNgay;
            //DateTime denNgay = chonKyLuong1.DenNgay;
            //ds = new dsXuLyQuetThe();
            //List<string> _lNV = new List<string>();
            //Provider.LoadData(ds, ds.tbCaLamViec.TableName);
            //Provider.LoadData(ds, ds.tbLoaiNgayLamThem.TableName);
            //Provider.LoadData(ds, ds.tbNgayNghiPhepNam.TableName);
            //Provider.LoadData(ds, ds.tblRef_LeaveType.TableName);
            //Provider.LoadDataByProc(ds, ds.tblEmployee.TableName, "p_getAlltblEmployee_ByList", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS1.GetValue()));
            //Provider.LoadDataByProc(ds, ds.tblEmpDayOff.TableName, "p_getAllDangKyVangMat_ByList", Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS1.GetValue()));

            //Provider.LoadDataByProc(ds, ds.tblEmp7hours.TableName, "p_GetAllEmp7hours_ByList", Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS1.GetValue()));
            //Provider.LoadDataByProc(ds, ds.tbKetQuaQuetThe_Fake.TableName, "p_duLieuQuetThe_GetAllKetQuaQuetThe_Fake_TinhCong_ByList", new SqlParameter("tuNgay", tuNgay), new SqlParameter("denNgay", denNgay), Provider.CreateParameter_StringList("dtEmpID", ucChonDoiTuong_DS1.GetValue()));
            //var rs = ds.tbKetQuaQuetThe_Fake;

            //List<KQQT> _lKQQT = new List<KQQT>();
            //List<Emp_KQ> _lEmp_KQ = new List<Emp_KQ>();
            //foreach (var i_Emp in ds.tblEmployee)
            //{
            //    Emp_KQ newEmpKQ = new Emp_KQ();
            //    newEmpKQ.EmployeeID = i_Emp.EmployeeID;
            //    newEmpKQ.EmployeeName = i_Emp.EmployeeName;
            //    newEmpKQ.DepName_Final = i_Emp.DepName_Final;
            //    double SoGio = 0, Cong = 0, TangCa = 0, SoLanTre = 0, SoLanSom = 0, VangKP = 0, SoPhutTre = 0, SoPhutSom = 0, TangCaNgayLe = 0, VangCP = 0;

            //    _lKQQT = new List<KQQT>();
            //    for (DateTime i = tuNgay; i <= denNgay; i = i.AddDays(1)) // Để hiện thị cả ngày chủ nhật nếu không đăng ký ca làm.
            //    {
            //        KQQT new_KQQT = new KQQT();
            //        new_KQQT.ngay = i;
            //        _lKQQT.Add(new_KQQT);
            //    }
            //    foreach (var i_kqqt in _lKQQT)
            //    {
            //        var _lDr = ds.tbKetQuaQuetThe_Fake.Where(p => p.EmployeeID == i_Emp.EmployeeID && p.ngay == i_kqqt.ngay);
            //        if (_lDr.Count() == 0)
            //        {
            //            continue;
            //        }
            //        var dr = _lDr.FirstOrDefault();
            //        i_kqqt.caLam = ds.tbCaLamViec.Where(p => p.id == DbHelper.DrGetGuid(dr, "idCaLam")).FirstOrDefault().ten;

            //        SoGio += DbHelper.DrGetDouble(dr, "kqNgayCong") *  DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");

            //        if (dr["dkLamThem"] == DBNull.Value) // không làm thêm
            //        {
            //            Cong += DbHelper.DrGetDouble(dr, "kqNgayCong");

            //            SoPhutTre += DbHelper.DrGetDouble(dr, "tgDiMuon") > 0 ? DbHelper.DrGetDouble(dr, "tgDiMuon") : 0;
            //            if (DbHelper.DrGetDouble(dr, "tgDiMuon") > 0)
            //            {
            //                SoLanTre++;
            //            }
            //            SoPhutSom += DbHelper.DrGetDouble(dr, "tgVeSom") > 0 ? DbHelper.DrGetDouble(dr, "tgVeSom") : 0;
            //            if (DbHelper.DrGetDouble(dr, "tgVeSom") > 0)
            //            {
            //                SoLanSom++;
            //            }

            //            TangCa += DbHelper.DrGetDouble(dr, "tgTinhTangCa");
            //        }
            //        else // làm thêm
            //        {
            //            TangCa += DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");
            //        }


            //        if (DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") == "KP")
            //        {
            //            VangKP++;
            //        }
            //        string leaveID = DbHelper.DrGetString(dr, "LeaveID");
            //        var leaveType = ds.tblRef_LeaveType.Where(p => p.LeaveID == leaveID).FirstOrDefault();
            //        if (leaveType != null && !leaveType.isTinhCong)
            //        {
            //            if (DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") != "" && DbHelper.DrGetString(dr, "tt_nghiPhep_Alias") != "KP")
            //            {
            //                int PerTimeID = DbHelper.DrGetInt(dr, "PerTimeID");
            //                if (PerTimeID != 0)
            //                {
            //                    VangCP += PerTimeID == 3 ? 1 : 0.5;
            //                }
            //            }
            //        }
            //        if (dr["dkLamThem"] != DBNull.Value)
            //        {
            //            try
            //            {
            //                int dkLT = Convert.ToInt16(dr["dkLamThem"]);
            //                string tenLoaiLT = ds.tbLoaiNgayLamThem.Where(p => p.id == dkLT).FirstOrDefault().tenLoai;
            //                i_kqqt.caLam = i_kqqt.caLam + " - " + tenLoaiLT;
            //            }
            //            catch (Exception)
            //            {
            //            }
            //            if (DbHelper.DrGetBoolean(dr, "tt_leTet") == true && DbHelper.DrGetDouble(dr, "kqNgayCong") > 0)// A trọng sửa từ dklamthem = 3 sang tt_leTet = true 26/02/2018
            //            {
            //                TangCaNgayLe += DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");
            //            }
            //        }
            //        i_kqqt.ngay = DbHelper.DrGetDateTime(dr, "ngay");
            //        i_kqqt.tgQuetDen = DbHelper.DrGetTimeSpan(dr, "tgQuetDen");
            //        i_kqqt.tgDiMuon = DbHelper.DrGetDouble(dr, "tgDiMuon") > 0 ? DbHelper.DrGetDouble(dr, "tgDiMuon") : 0;
            //        i_kqqt.tgQuetVe = DbHelper.DrGetTimeSpan(dr, "tgQuetVe");
            //        i_kqqt.tgVeSom = DbHelper.DrGetDouble(dr, "tgVeSom") > 0 ? DbHelper.DrGetDouble(dr, "tgVeSom") : 0;
            //        if (dr["dkLamThem"] == DBNull.Value) // không làm thêm
            //        {
            //            i_kqqt.OT = DbHelper.DrGetDouble(dr, "tgTinhTangCa");
            //        }
            //        else // làm thêm
            //        {
            //            i_kqqt.OT = DbHelper.DrGetDouble(dr, "kqNgayCong") * DbHelper.DrGetDouble(dr, "SoTiengTinhCa") + DbHelper.DrGetDouble(dr, "tgTinhTangCa");
            //        }
            //        i_kqqt.lyDoNghi = DbHelper.DrGetString(dr, "tt_nghiPhep_Alias");
            //    }
            //    newEmpKQ._lKQQT = _lKQQT;
            //    newEmpKQ.SoGio = SoGio;
            //    newEmpKQ.Cong = Cong;
            //    newEmpKQ.TangCa = TangCa;
            //    newEmpKQ.SoLanTre = SoLanTre;
            //    newEmpKQ.SoLanSom = SoLanSom;
            //    newEmpKQ.VangKP = VangKP;
            //    newEmpKQ.SoPhutTre = SoPhutTre;
            //    newEmpKQ.SoPhutSom = SoPhutSom;
            //    newEmpKQ.TangCaNgayLe = TangCaNgayLe;
            //    newEmpKQ.VangCP = VangCP;
            //    _lEmp_KQ.Add(newEmpKQ);
            //}
            //var rp = new rep_BangCongChiTiet();
            //rp.paramTieuDe.Value = string.Format("BẢNG CHI TIẾT CHẤM CÔNG THÁNG {0}", chonKyLuong1.DenNgay.Month);
            //rp.paramTuNgay.Value = string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}", chonKyLuong1.TuNgay, chonKyLuong1.DenNgay);
            //rp.BindData(_lEmp_KQ);
            //ReportViewer rv = new ReportViewer();
            //rv.ViewReport(rp);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            PhanTichBangCong_Fake frm = new PhanTichBangCong_Fake();
            frm.Show();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            ExportGrid(grd);
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
        private IEnumerable<DevExpress.XtraEditors.CheckEdit> EnumerateCheckEdit()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.CheckEdit).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.CheckEdit)field.GetValue(this)
                   where component != null
                   select component;
        }
        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new System.Data.SqlClient.SqlParameter("CtrName", nameCrt),

                           new System.Data.SqlClient.SqlParameter("FormName", this.Name.ToString()));
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
            string formText = SelectTranslate(this.Name, langTrans);
            if (formText != "")
            {
                this.Text = formText;
            }
            #region Khai báo list loai control trong form
            var _GridColumn = EnumerateGridColumn();
            var _ToolStripButton = EnumerateToolStripButton();
            var _LableControl = EnumerateLabelControl();
            var _SimpleButton = EnumerateSimpleButton();
            var _CheckEdit = EnumerateCheckEdit();
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
            foreach (DevExpress.XtraEditors.CheckEdit s in _CheckEdit)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            myData.Add(this.Name, this.Text);
            listCtr.Add(this.Name);


            #endregion
        }

        #endregion

        private void ReportMonth_Fake_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frmDangKyCaLam_Load(null, null);
            }
        }
    }
}
