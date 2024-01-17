using iHRM.Core.i_Report;
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
using iHRM.Win.Cls;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Reflection;

namespace iHRM.Win.Frm.Report
{
    public partial class BCCaLamTrongThang : frmBase
    {
        iHRM.Core.Business.DbObject.dcDatabaseDataContext db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
        iHRM.Core.Controller.Report.GetData controller = new Core.Controller.Report.GetData();
        DataTable data = new DataTable();
        public BCCaLamTrongThang()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            TranslateForm();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu ..."; //text hiện ở status
            dw_it.OnDoing = (s, ev) => //hàm lấy dữ liệu chạy ngầm
            {
                dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
                data = controller.GetDataReportCaLamMonth(ucChonDoiTuong_DS1.GetValue(), chonKyLuong1.TuNgay, chonKyLuong1.DenNgay, ucChonDoiTuong_DS1.getKhoiPBvalue());

                dw_it.bw.ReportProgress(1, data);

            };
            dw_it.OnProcessing = (ps, data) =>
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        grd.DataSource = data.UserState;
                        btnFind.Enabled = true;
                        break;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void btnExcel_Click(object sender, EventArgs e)
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
                bw.ReportProgress(-1, "Xuất excel ca làm trong tháng"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (data == null || data.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu
                    return;
                }


                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description.

                ExcelExportHelper ex = new ExcelExportHelper("Report/BCCaLamTrongThang.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("A4", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));
                ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                ex.WriteToCell("C1", LoginHelper.Company.CompanyName);
                ex.SetNamedRangeValue("Ngay", "Ngày tạo: " + DateTime.Now.ToString("dd/MM/yyyy"));
                ex.FillDataTable(data); // Fill BC_FillData
                ex.RendAndFlush("BCCaLamTrongThang_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
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

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void grv_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column != colEmployeeID && e.Column != colEmployeeName && e.Column != colPosName && e.Column != colDepName_Final && e.Column != colTongNgayDK)
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            grv.OptionsPrint.UsePrintStyles = false;
            ShowPreview(grd);
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
        //DevExpress.XtraGrid.Views.BandedGrid.GridBand
        private IEnumerable<DevExpress.XtraGrid.Views.BandedGrid.GridBand> EnumerateGridBand()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraGrid.Views.BandedGrid.GridBand).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraGrid.Views.BandedGrid.GridBand)field.GetValue(this)
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
            var _GridBand = EnumerateGridBand();
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
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand s in _GridBand)
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
        private void BCCaLamTrongThang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                Viewer_Load(null, null);
            }
        }

        //public ExcelExportHelper xuatexcel(DataTable dtData, string strFileExcel, int iStartRow, int iStartCol, DateTime TuNgay, DateTime DenNgay, BackgroundWorker bw)
        //{
        //    string tenPB = "";
        //    int _irow = 0;
        //    int _indexcol = 0;

        //    if (dtData.Rows.Count > 0)
        //    {
        //        ExcelExportHelper ex = new ExcelExportHelper(strFileExcel);

        //        //  ex.WriteToCell(7, 2, DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        //        //  ex.WriteToCell(8, 2, Convert.ToDateTime(dtangay.Value).Day + "/" + Convert.ToDateTime(dtangay.Value).Month + "/" + Convert.ToDateTime(dtangay.Value).Year + "  " + cboFromHour.SelectedItem.Value + ":" + cboFromPhut.SelectedItem.Value + ":00"; ;
        //        //  ex.WriteToCell(9, 2, Convert.ToDateTime(dtToDate.Value).Day + "/" + Convert.ToDateTime(dtToDate.Value).Month + "/" + Convert.ToDateTime(dtToDate.Value).Year + "  " + cbotoHour.SelectedItem.Value + ":" + cboToPhut.SelectedItem.Value + ":00";
        //        ex.WriteToCell(2, 0, "Từ ngày:" + TuNgay.ToString("dd/MM/yyyy") + " Đến ngày:" + DenNgay.ToString("dd/MM/yyyy"));
        //        ex.WriteToCell("Z5", "Tháng " + TuNgay.Month);
        //        ex.WriteToCell("J5", "Tháng " + DenNgay.Month);
        //        //ex.ClearPageBreak();
        //        //ex.setPageBreakPreview(true);
        //        try
        //        {
        //            int pageBreak = 0;
        //            int _index = 1;
        //            foreach (DataRow _dr in dtData.Rows)
        //            {
        //                if (_index % 10 == 0)
        //                    bw.ReportProgress(-1, string.Format("Đang chuẩn bị dữ liệu ({0}/{1})", _index, dtData.Rows.Count));

        //                if (_dr["DepName"].ToString() != "")
        //                {
        //                    tenPB = _dr["DepName"].ToString();
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 1, _dr["DepName"].ToString());
        //                    // ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 5, TypeHelper.ToDateTime(_dr["gps_create_date"].ToString());//ket thuc hanh trinh
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 8, tenPB);
        //                    ex.SetCellBorder(iStartRow + _irow, iStartCol + _indexcol + 1, iHRM.Common.Code.ExcelExtend.BorderPosition.Left);
        //                    ex.SetCellBorder(iStartRow + _irow, iStartCol + _indexcol + 1, iHRM.Common.Code.ExcelExtend.BorderPosition.Right);
        //                    for (int i = 0; i <= 49; i++)
        //                    {
        //                        //var cell = ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + i];
        //                        //var border = ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + i].Style.Border;
        //                        //var fill = cell.Style.Fill;
        //                        // fill.PatternType = ExcelFillStyle.Solid;
        //                        // fill.BackgroundColor.SetColor(System.Drawing.Color.YellowGreen);
        //                        //  fill.BackgroundColor.SetColor(
        //                        //border.Left.Style = border.Right.Style = border.Bottom.Style = ExcelBorderStyle.Thin;
        //                        ex.SetCellBorder(iStartRow + _irow, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Bottom);
        //                    }
        //                    if (pageBreak >= 1)
        //                    {
        //                        ex.setHorPageBreakAtCell("AY" + (iStartRow + _irow + 1));
        //                    }
        //                    pageBreak++;
        //                    _irow++;
        //                }
        //                else
        //                {
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol, _index);
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 3, _dr["tenNV"].ToString());
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 4, _dr["EmployeeID"].ToString());
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 5, _dr["PosName"].ToString());
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 6, _dr["AppliedDate"]);
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 7, _dr["IDCard"].ToString());
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 8, tenPB);
        //                    ex.WriteToCell(iStartRow + _irow + 1, iStartCol + _indexcol + 8, tenPB);
        //                    // ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 5, TypeHelper.ToDateTime(_dr["gps_create_date"].ToString());//ket thuc hanh trinh
        //                    for (int i = 1; i <= 31; i++)
        //                    {
        //                        //try
        //                        //{
        //                        //    ex.WriteToCell(iStartRow + _irow, (iStartCol + _indexcol + 8) + i, Convert.ToDouble(_dr["D" + i]).ToString());
        //                        //}
        //                        //catch (Exception)
        //                        //{
        //                        //    ex.WriteToCell(iStartRow + _irow + 1, (iStartCol + _indexcol + 8) + i, _dr["D" + i]);                                    
        //                        //}
        //                        //try
        //                        //{
        //                        //    ex.WriteToCell(iStartRow + _irow, (iStartCol + _indexcol + 8) + i, Convert.ToDouble(_dr["T" + i]).ToString());
        //                        //}
        //                        //catch (Exception)
        //                        //{
        //                        //    ex.WriteToCell(iStartRow + _irow + 1, (iStartCol + _indexcol + 8) + i, _dr["T" + i]);                      
        //                        //}

        //                        ex.WriteToCell(iStartRow + _irow, (iStartCol + _indexcol + 8) + i, _dr["D" + i].ToString());
        //                        ex.WriteToCell(iStartRow + _irow + 1, (iStartCol + _indexcol + 8) + i, _dr["T" + i].ToString());
        //                    }
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 40, Convert.ToDouble(_dr["DChuNhat"].ToString() != "" ? _dr["DChuNhat"].ToString() : "0"));
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 41, Convert.ToDouble(_dr["NghiLe"].ToString() != "" ? _dr["NghiLe"].ToString() : "0"));
        //                    // ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 41, _dr["DChuNhat"].ToString();
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 42, Convert.ToDouble(_dr["NghiKhongPhep"].ToString() != "" ? _dr["NghiKhongPhep"].ToString() : "0"));
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 43, Convert.ToDouble(_dr["NghiPhepNam"].ToString() != "" ? _dr["NghiPhepNam"].ToString() : "0"));
        //                    // ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 44, _dr["NghiOm"];
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 44, Convert.ToDouble(_dr["NghiKhongLuong"].ToString() != "" ? _dr["NghiKhongLuong"].ToString() : "0"));
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 45, Convert.ToDouble(_dr["NghiThaiSan"].ToString() != "" ? _dr["NghiThaiSan"].ToString() : "0"));

        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 46, Convert.ToDouble(_dr["NghiCheDo"].ToString() != "" ? _dr["NghiCheDo"].ToString() : "0"));
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 47, Convert.ToDouble(_dr["NghiKhac"].ToString() != "" ? _dr["NghiKhac"].ToString() : "0"));
        //                    ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 48, Convert.ToDouble(_dr["SoNgayCong"].ToString() != "" ? _dr["SoNgayCong"].ToString() : "0"));
        //                    ex.WriteToCell(iStartRow + _irow + 1, iStartCol + _indexcol + 48, Convert.ToDouble(_dr["TangCa"].ToString() != "" ? _dr["TangCa"].ToString() : "0"));
        //                    ex.WriteToCell(iStartRow + _irow + 1, iStartCol + _indexcol + 50, _dr["TeamName"].ToString());
        //                    ex.WriteToCell(iStartRow + _irow + 1, iStartCol + _indexcol + 51, _dr["LineName"].ToString());
        //                    for (int i = 0; i <= 51; i++)
        //                    {
        //                        //    var cells = ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol];
        //                        //var borders = ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + i].Style.Border;
        //                        //var borderschil = ex.WriteToCell(iStartRow + _irow + 1, iStartCol + _indexcol + i].Style.Border;
        //                        if ((iStartCol + _indexcol + i) < 2 || (iStartCol + _indexcol + i) > 3)
        //                        {
        //                            ex.SetCellBorder(iStartRow + _irow, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Left);
        //                            ex.SetCellBorder(iStartRow + _irow, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Right);
        //                            ex.SetCellBorder(iStartRow + _irow + 1, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Bottom);
        //                            ex.SetCellBorder(iStartRow + _irow + 1, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Left);
        //                            ex.SetCellBorder(iStartRow + _irow + 1, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Right);
        //                        }
        //                        else
        //                        {
        //                            ex.SetCellBorder(iStartRow + _irow + 1, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Bottom);
        //                            //borderschil.Top.Style = ExcelBorderStyle.Dotted;
        //                        }
        //                    }
        //                    _irow = _irow + 2;
        //                    _index++;
        //                }
        //            }
        //            ex.setHorPageBreakAtCell("AY" + (iStartRow + _irow + 1));
        //            ex.setVerPageBreakAtCell("AX" + (iStartRow + _irow + 1));
        //            //worksheet.View.PageLayoutView = false;
        //            //ex.ActiveSheet.worksheet.View.PageBreakView = true;
        //            //worksheet.Cells.AutoFitColumns();

        //            //xlPackage.SaveAs(stream);
        //            //Byte[] bytearray = stream.ToArray();
        //            //SaveFileDialog(fileTemp.Name, bytearray);
        //            //stream.Flush();
        //            //stream.Close();
        //            ex.ConvertStringToNumericValue();
        //            return ex;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }

        //    return null;
        //}
    }
}
