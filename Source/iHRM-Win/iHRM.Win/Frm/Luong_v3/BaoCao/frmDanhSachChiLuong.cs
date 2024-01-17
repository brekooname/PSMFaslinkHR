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
    public partial class frmDanhSachChiLuong : frmBase
    {
        dcLuongv3DataContext db1 = new dcLuongv3DataContext(Provider.ConnectionString);
        DataTable LstData;

        dlgDinhNghiaThamSo dlgEditor = new dlgDinhNghiaThamSo();

        public frmDanhSachChiLuong()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {

            if (LoginHelper.user.isAcceptBP == true || LoginHelper.user.isAdmin)
            {
                toolStripKhoiTaoDuLieuCL.Visible = true;

                toolStripXoaDuLieuCL.Visible = true;

                toolStripXuatExcel.Visible = true;

              
            }
            else
            {
                toolStripXuatExcel.Visible = false;

                toolStripXoaDuLieuCL.Visible = false;

                toolStripKhoiTaoDuLieuCL.Visible = false;

            }

            txtSearchThang.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            LoadGrvLayout(gridView1);
            cmbKyLuong.SelectedIndex = 0;
            checkEditNhanTienMat.Checked = true;
            TranslateForm();
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            var db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s,ev) => 
            {
            if (cmbKyLuong.SelectedIndex == 0)
            {
                LstData = Provider.ExecuteDataTableReader("p_BangLuong_GetDsChiLuong_Lan1", 
                    new SqlParameter("thang", new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1)),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue),
                    new SqlParameter("tukhoa", txtTuKhoaSearch.Text.Trim()),
                    new SqlParameter("hinhthuctraluong", checkEditNhanTienMat.Checked ? "0" : "1"));
            }
            else
            {
                LstData = Provider.ExecuteDataTableReader("p_BangLuong_GetDsChiLuong_Lan2",
                    new SqlParameter("thang", new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1)),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue),
                    new SqlParameter("tukhoa", txtTuKhoaSearch.Text.Trim()),
                    new SqlParameter("hinhthuctraluong", checkEditNhanTienMat.Checked ? "0" : "1"));
            }
                dw_it.bw.ReportProgress(1, LstData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                if (data.ProgressPercentage == 1)
                {
                    //bandedGridColumn3.SummaryItem.FieldName = bandedGridColumn3.FieldName = cmbKyLuong.SelectedIndex == 0 ? "ts36" : "ts36";
                    //LstData.Columns.Add("tongBP", typeof(double));
                    //var dic = new Dictionary<string, double>();
                    //foreach(var pb in LstData.Select().Select(i => i["nv_phongban"] as string).Distinct())
                    //    dic.Add(pb, Convert.ToDouble(LstData.Compute("SUM(" + (cmbKyLuong.SelectedIndex == 0 ? "ts36" : "ts36") + ")", "nv_phongban='" + pb + "'")));
                    //foreach (DataRow r in LstData.Rows)
                    //    r["tongBP"] = dic[r["nv_phongban"] as string];
                    grd.DataSource = LstData;
                    btnFind.Enabled = true;
                }
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(gridView1);
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //if (LstData == null || LstData.Rows.Count == 0)
            //{
            //    GUIHelper.MessageBox("Chưa có dữ liệu");
            //    return;
            //}
            //ExportGrid(grd);

            string temp = ""; 
            if (cmbKyLuong.SelectedIndex == 0)
            {
                temp = checkEditNhanTienMat.Checked ? "Luong\\chiLuongTM.xls" : "Luong\\chiLuongNH.xls";
            }
            else
            {
                temp = checkEditNhanTienMat.Checked ? "Luong\\chiLuongTM_2.xls" : "Luong\\chiLuongNH_2.xls";
            }

            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Excel 2007|*.xls";
            if (sd.ShowDialog() != DialogResult.OK)
                return;
            
            var ex = new ExcelExportHelper(temp);
            if (checkEditNhanTienMat.Checked)
            {
                ex.SetNamedRangeValue("thang", "Tháng " + string.Format("{0:MM-yyyy}", txtSearchThang.DateTime));
                ex.SetNamedRangeValue("ngay", string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", DateTime.Today));
            }
            else
            {
                ex.SetNamedRangeValue("thang", "Month " + string.Format("{0:MM-yyyy}", txtSearchThang.DateTime));

                ex.SetNamedRangeValue("ngay", string.Format("Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", DateTime.Today));
            } 

            ex.FillDataTable_DSNL(LstData);
            ex.RendAndFlush("DanhSachNhanLuong" + cmbKyLuong.Text, sd.FileName);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = sd.FileName,
                UseShellExecute = true
            });

            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

           // LogAction.LogAction.PushLog("Khởi tạo dữ liệu", "", "", string.Format("Xuất danh sách chi lương thành công!"), "tbLuong_BangLuongThang");

            var log = Log2.CreateLog(Log2.Log2Action.them, "Xuất file Excel danh sách chi lương: " + string.Format("{0:MM/yyyy}", txtSearchThang.DateTime), "tbLuong_BangChiLuongThang");

            log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
            {
                id = Guid.NewGuid(),
                log_id = log.id,
                target1 = "thang",
                value1 = string.Format("{0:MM/yyyy}", txtSearchThang.DateTime)
            });
            Log2.PushLog(log);            
        }
        
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            txtSearchThang.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            chonPhongBan1.SelectedValue = null;
            txtTuKhoaSearch.EditValue = null;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbKyLuong.SelectedIndex == 0)
                {
                    LstData = Provider.ExecuteDataTableReader("p_BangLuong_DsChiLuong_Lan1",
                        new SqlParameter("thang", new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1)),
                        new SqlParameter("phongban_id", chonPhongBan1.SelectedValue),
                        new SqlParameter("tukhoa", txtTuKhoaSearch.Text.Trim()),
                        new SqlParameter("hinhthuctraluong", checkEditNhanTienMat.Checked ? "0" : "1"));
                }
                else
                {
                    LstData = Provider.ExecuteDataTableReader("p_BangLuong_DsChiLuong_Lan2",
                        new SqlParameter("thang", new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1)),
                        new SqlParameter("phongban_id", chonPhongBan1.SelectedValue),
                        new SqlParameter("tukhoa", txtTuKhoaSearch.Text.Trim()),
                        new SqlParameter("hinhthuctraluong", checkEditNhanTienMat.Checked ? "0" : "1"));
                }
                GUIHelper.MessageBox("Khởi tạo danh sách chi lương theo điều kiện thành công");
                btnFind_Click(null, null);

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

                //LogAction.LogAction.PushLog("Khởi tạo dữ liệu", "", "", string.Format("Khởi tạo dữ liệu sách chi lương thành công!"), "tbLuong_BangLuongThang");


                var log = Log2.CreateLog(Log2.Log2Action.them, "Khởi tạo danh sách chi lương: " + string.Format("{0:MM/yyyy}", txtSearchThang.DateTime), "tbLuong_BangChiLuongThang");

                log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "thang",
                    value1 = string.Format("{0:MM/yyyy}", txtSearchThang.DateTime)
                });

                Log2.PushLog(log);
            }
           catch
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddFalse);
                GUIHelper.MessageBox("Khởi tạo danh sách chi lương theo điều kiện thất bại");
               // LogAction.LogAction.PushLog("Khởi tạo dữ liệu", "", "", string.Format("Khởi tạo dữ liệu sách chi lương thất bại!"), "tbLuong_BangLuongThang");

                var log = Log2.CreateLog(Log2.Log2Action.them, "Khởi tạo danh sách chi lương lỗi: " + string.Format("{0:MM/yyyy}", txtSearchThang.DateTime), "tbLuong_BangChiLuongThang");

                log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "thang",
                    value1 = string.Format("{0:MM/yyyy}", txtSearchThang.DateTime)
                });

                Log2.PushLog(log);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsLock.IsLock.Check_IsLock("tbLuong_BangChiLuongThang", new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1)))
                {
                    GUIHelper.MessageBox("Dữ liệu đã chốt khổng thể thao tác!");

                    return;
                }

                var dg = MessageBox.Show("Dữ liệu của nhóm đang chọn trong tháng sẽ được xóa đi và khởi tạo lại!\r\nBạn chắc chắn chứ?"
                    , "Xóa tất cả các yêu cầu đang chọn"
                    , MessageBoxButtons.OKCancel);

                if (dg == DialogResult.OK)
                {
                    var dg2 = MessageBox.Show("Sẽ không khôi phục dữ liệu khi xóa!", "Cảnh báo", MessageBoxButtons.OKCancel);

                    if (dg2 == DialogResult.OK)
                    {
                        var thang = new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1);

                        if (cmbKyLuong.SelectedIndex == 0)
                        {
                             Provider.ExecuteDataTableReader("p_BangLuong_DelDsChiLuong_Lan1",
                                new SqlParameter("thang", new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1)),
                                new SqlParameter("phongban_id", chonPhongBan1.SelectedValue),
                                new SqlParameter("tukhoa", txtTuKhoaSearch.Text.Trim()),
                                new SqlParameter("hinhthuctraluong", checkEditNhanTienMat.Checked ? "0" : "1"));
                        }
                        else
                        {
                             Provider.ExecuteDataTableReader("p_BangLuong_DelDsChiLuong_Lan2",
                                new SqlParameter("thang", new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1)),
                                new SqlParameter("phongban_id", chonPhongBan1.SelectedValue),
                                new SqlParameter("tukhoa", txtTuKhoaSearch.Text.Trim()),
                                new SqlParameter("hinhthuctraluong", checkEditNhanTienMat.Checked ? "0" : "1"));
                        }

                        btnFind_Click(null, null);
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);

                       // LogAction.LogAction.PushLog("Xóa dữ liệu", "", "", string.Format("Xóa Danh sách chi lương"), "tbLuong_BangLuongThang");

                        var log = Log2.CreateLog(Log2.Log2Action.xoa, "Xóa danh sách chi lương: " + string.Format("{0:MM/yyyy}", txtSearchThang.DateTime), "tbLuong_BangChiLuongThang");

                        log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
                        {
                            id = Guid.NewGuid(),
                            log_id = log.id,
                            target1 = "thang",
                            value1 = string.Format("{0:MM/yyyy}", txtSearchThang.DateTime)
                        });
                        Log2.PushLog(log);

                    }
                }
            }
            catch (Exception ex)
            {
                if (globall.indebug)

                    GUIHelper.MessageBox(ex.Message);
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
        private void frmDanhSachChiLuong_KeyDown(object sender, KeyEventArgs e)
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
