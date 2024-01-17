using iHRM.Core.i_Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
namespace iHRM.Win.Frm.Report
{
    public partial class BCTongNhanVienLamCa : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(iHRM.Core.Business.Provider.ConnectionString);
        DataTable dt = new DataTable();
        private DevExpress.Utils.WaitDialogForm Starting = null;
        public BCTongNhanVienLamCa()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            lookupCalam.Properties.DataSource = db.tbCaLamViecs;
            TranslateForm();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
            //Starting = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu...", "iHRM");
            dt = Core.Business.Provider.ExecuteDataTableReader("p_BaoCao_Tong_NhanVienLamCa",
                        Provider.CreateParameter_StringList("dtEmployeeID", ucChonDoiTuong_DS1.GetValue()),
                        new SqlParameter("idCaLam", lookupCalam.EditValue),
                        new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                        new SqlParameter("denNgay", chonKyLuong1.DenNgay)
                    );
            var dt_Emp = (from data in dt.AsEnumerable()
                     select new
                     {
                         EmployeeID = data["EmployeeID"],
                         EmployeeName = data["EmployeeName"],
                         PosName = data["PosName"],
                         IDCard = data["IDCard"],
                         AppliedDate = data["AppliedDate"],
                         LeftDate = data["LeftDate"],
                         DepName = data["DepName"]
                     }).ToList();
            DataTable dt_Reuslt = new DataTable();
            dt_Reuslt.Columns.Add("EmployeeID");
            dt_Reuslt.Columns.Add("EmployeeName");
            dt_Reuslt.Columns.Add("PosName");
            dt_Reuslt.Columns.Add("IDCard");
            dt_Reuslt.Columns.Add("AppliedDate");
            dt_Reuslt.Columns.Add("LeftDate");
            dt_Reuslt.Columns.Add("DepName");
            foreach (var item in dt_Emp)
            {
                if (dt_Reuslt.Select("EmployeeID='" + item.EmployeeID + "'").Count() == 0)
                {
                    DataRow row = dt_Reuslt.NewRow();
                    row["EmployeeID"] = item.EmployeeID;
                    row["EmployeeName"] = item.EmployeeName;
                    row["PosName"] = item.PosName;
                    row["IDCard"] = item.IDCard;
                    row["AppliedDate"] = item.AppliedDate;
                    row["LeftDate"] = item.LeftDate;
                    row["DepName"] = item.DepName;
                    dt_Reuslt.Rows.Add(row);
                }
            }
            var tb_Ca = db.tbCaLamViecs.ToList().OrderBy(p=>p.ten);

            int count = grv.Columns.Count;

            for (int i = 0; i <= count; i++)
            {
                if (grv.Columns.Count > 7 )
                {
                    grv.Columns.RemoveAt(7);
                }
            }
                foreach (var item in tb_Ca)
                {
                    dt_Reuslt.Columns.Add(item.id.ToString(), typeof(string));


                    #region Add Column ca làm
                    DevExpress.XtraGrid.Columns.GridColumn newCol = grv.Columns.Add();
                    newCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
                    newCol.AppearanceCell.Options.UseFont = true;
                    newCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
                    newCol.AppearanceHeader.Options.UseFont = true;
                    newCol.Visible = true;
                    newCol.FieldName = item.id.ToString();
                    newCol.Caption = item.ten;
                    grv.BestFitColumns(true);
                    #endregion

                }
            foreach (var item in dt_Emp)
            {
                foreach (var ca in tb_Ca)
                {
                    DataRow dr = dt_Reuslt.Select("EmployeeID = '" + item.EmployeeID +"'").First();
                    dr[ca.id.ToString()] = dt.Select("EmployeeID = '" + item.EmployeeID + "' AND idCaLam = '" + ca.id+"'").Count();
                }
            }
            
            grcNVLamCa.DataSource = dt;
                }
            catch { }
            finally
            {
                //Starting.Close();
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //ExportGrid(grcNVLamCa);
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
                bw.ReportProgress(-1, "Xuất excel thông tin nhân viên làm ca"); // Set caption

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

                ExcelExportHelper ex = new ExcelExportHelper("Report/BaoCaoNhanVienLamCa.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("AJ6", "Ngày tạo:  " + DateTime.Now.ToString("dd/MM/yyyy"));
                ex.InsertImage(0, 0, 1, 2, LoginHelper.Company.LogoCompany);
                ex.WriteToCell("C1", LoginHelper.Company.CompanyName);
                ex.WriteToCell("A4", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));
                ex.FillDataTable(dt); // Fill BC_FillData
                ex.RendAndFlush("BaoCaoNhanVienLamCa" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
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

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grcNVLamCa.FocusedView as GridView;
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
        private void BCTongNhanVienLamCa_KeyDown(object sender, KeyEventArgs e)
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
    }
}
