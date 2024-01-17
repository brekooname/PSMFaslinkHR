using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3.BaoCao
{
    public partial class frmBangTongHopLuong_CN : frmBase
    {
        dcLuongv3DataContext db1 = new dcLuongv3DataContext(Provider.ConnectionString);
        DataTable dtData = new DataTable();
        
        public frmBangTongHopLuong_CN()
        {
            InitializeComponent();

            dtData.Columns.AddRange(new DataColumn[] {
                new DataColumn("nhom"),
                new DataColumn("ten"),
                new DataColumn("tong", typeof(double)),
                new DataColumn("t1", typeof(double)),
                new DataColumn("t2", typeof(double)),
                new DataColumn("t3", typeof(double)),
                new DataColumn("t4", typeof(double)),
                new DataColumn("t5", typeof(double)),
                new DataColumn("t6", typeof(double)),
                new DataColumn("t7", typeof(double)),
                new DataColumn("t8", typeof(double)),
                new DataColumn("t9", typeof(double)),
                new DataColumn("t10", typeof(double)),
                new DataColumn("t11", typeof(double)),
                new DataColumn("t12", typeof(double))
            });
        }

        private void frm_Load(object sender, EventArgs e)
        {
            txtSearchNam.EditValue = new DateTime(DateTime.Today.Year, 1, 1);

            LoadGrvLayout(gridView1);
            TranslateForm();
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            var db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            grd.DataSource = null;
            dtData.Rows.Clear();
            dw_it.OnDoing = (s,ev) =>
            {
                var nv = db1.tblEmployees.FirstOrDefault(i => i.EmployeeID == txtTuKhoaSearch.Text);
                var lstTS = nv.tbNhanVien_NhomNVs.FirstOrDefault().tbDM_nhomNV.tbNhanVien_ThamSoLuongs.Select(i => i.tbLuong_DinhNghiaThamSo);
               
                var lstLuong = db.tbLuong_BangLuongThangs.Where(i => i.idNV == nv.EmployeeID && (i.thang ?? new DateTime(1970, 1, 1)).Year == txtSearchNam.DateTime.Year).ToList();

                foreach (var ts in lstTS.Where(p=>p.hienTrenBangLuong==true))
                {
                    var r = dtData.NewRow();
                    r["ten"] = ts.ten;
                    r["nhom"] = ts.nhom;
                    r["tong"] = 0;
                    //r["tong"] = lstLuong.Sum(i => i.tongLuong ?? 0);
                    for (int j = 1; j < 13; j++)
                    {
                        r["t" + j] = lstLuong.Where(i => i.thang == new DateTime(txtSearchNam.DateTime.Year, j, 1)).Sum(i => (PropertyExtension1.GetPropValue(i, ts.tsIdx) as double?) ?? 0);
                        r["tong"] =  Convert.ToDouble( r["tong"]) + lstLuong.Where(i => i.thang == new DateTime(txtSearchNam.DateTime.Year, j, 1)).Sum(i => (PropertyExtension1.GetPropValue(i, ts.tsIdx) as double?) ?? 0);
                    }
                        
                    dtData.Rows.Add(r);
                }
                dw_it.bw.ReportProgress(1);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = dtData;
                btnFind.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(gridView1);
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //ExportGrid(grd);
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
                bw.ReportProgress(-1, "Xuất excel bảng tổng hợp lương theo nhân viên"); // Set caption

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu..."); // Set description

                //Lấy dữ liệu

                if (dtData == null || dtData.Rows.Count == 0)
                {
                    bw.ReportProgress(1); // Nếu không có dữ liệu
                    return;
                }


                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel..."); // Set description.

                ExcelExportHelper ex = new ExcelExportHelper("Luong/BCTonghoptienluong_NV.xls"); // Tạo excel export helper + đường dẫn template
                ex.WriteToCell("D6", "Năm " + txtSearchNam.DateTime.Year);
                ex.WriteToCell("D7",  txtTuKhoaSearch.Text.ToUpper());
                ex.WriteToCell("D8", textEdit1.Text);
                ex.WriteToCell("C11", " Tổng cộng năm " + txtSearchNam.DateTime.Year);

                var x = db1.tblEmployees.Where(p=>p.EmployeeID==txtTuKhoaSearch.Text).Select(i=>i.DepName_Final).FirstOrDefault();

                if( x != null)
                {
                    ex.WriteToCell("D9",x);
                }
                ex.SetNamedRangeValue("Ngay", "Ngày tạo: " + DateTime.Now.ToString("dd/MM/yyyy"));
                ex.WriteToCell("D11", "Năm " + txtSearchNam.DateTime.Year);

                dtData.DefaultView.Sort = "nhom, ten ASC";
                dtData = dtData.DefaultView.ToTable();


                ex.FillDataTable(dtData);
                ex.RendAndFlush("BCTonghoptienluong_NV_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
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
        
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            txtSearchNam.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            txtTuKhoaSearch.EditValue = null;
            textEdit1.Text = "";
        }

        private void txtTuKhoaSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var nv = db1.tblEmployees.FirstOrDefault(i => i.EmployeeID == txtTuKhoaSearch.Text);
                if (nv == null)
                {
                    GUIHelper.MessageBox("Không tìm thấy thông tin!");
                    return;
                }
                textEdit1.Text = nv.EmployeeName;
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
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
        private void frmBangTongHopLuong_CN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                frm_Load(null, null);
            }
        }
    }
}
