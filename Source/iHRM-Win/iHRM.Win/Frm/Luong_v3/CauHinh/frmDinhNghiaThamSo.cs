using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class frmDinhNghiaThamSo : frmBase
    {
        dcLuongv3DataContext db;
        List<tbLuong_DinhNghiaThamSo> LstData;

        dlgDinhNghiaThamSo dlgEditor = new dlgDinhNghiaThamSo();
        private class KieuDuLieu
        {
            public string Ten { get; set; }
            public int kieuDuLieu { get; set; }
        }
        public frmDinhNghiaThamSo()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            List<KieuDuLieu> arrKDL = new List<KieuDuLieu>();
            arrKDL.Add(new KieuDuLieu { Ten = "Nhập tay", kieuDuLieu = 1 });
            arrKDL.Add(new KieuDuLieu { Ten = "Tự động từ module khác", kieuDuLieu = 2 });
            arrKDL.Add(new KieuDuLieu { Ten = "Được tính toán", kieuDuLieu = 3 });
            repositoryItemLookUpEdit1.DataSource = arrKDL;
            repositoryItemLookUpEdit1.DisplayMember = "Ten";
            repositoryItemLookUpEdit1.ValueMember = "kieuDuLieu";

            btnFind_Click(null, null);
            LoadGrvLayout(grv);
            TranslateForm();
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu tham số tính lương...";
            dw_it.OnDoing = (s,ev) => 
            {
                if (string.IsNullOrWhiteSpace(txtSearchKey.Text))
                    LstData = db.tbLuong_DinhNghiaThamSos.ToList();
                else
                    LstData = db.tbLuong_DinhNghiaThamSos.Where(i => i.ten.IndexOf(txtSearchKey.Text.Trim()) >= 0).ToList();
                dw_it.bw.ReportProgress(1, LstData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = new BindingList<tbLuong_DinhNghiaThamSo>(LstData);
                btnFind.Enabled = true;
                dlgEditor.LstThamSo = LstData;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetRow(i) as tbLuong_DinhNghiaThamSo);
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            if (!GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa các bản ghi đã chọn?"))
                return;

            try
            {
                db.tbLuong_DinhNghiaThamSos.DeleteAllOnSubmit(drs);
                db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                grv.DeleteSelectedRows();
                dlgEditor.LstThamSo = LstData;

                var log = Log2.CreateLog(Log2.Log2Action.xoa, "Xóa " + drs.Count() + " bản ghi tham số lương", "tbLuong_DinhNghiaThamSo");
                log.tbLog2_details.AddRange(drs.Select(i => new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "id",
                    target2 = "ten",
                    value1 = i.id.ToString(),
                    value2 = i.ten
                }).ToArray());
                Log2.PushLog(log);

            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var r = grv.GetFocusedRow() as tbLuong_DinhNghiaThamSo;
            if (r != null)
                show_edit(r);
        }
        void show_edit(tbLuong_DinhNghiaThamSo r)
        {
            dlgEditor.MyValue = r;
            dlgEditor.AttackMode = "edit";
            if (dlgEditor.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
                    dlgEditor.LstThamSo = LstData;

                    var log = Log2.CreateLog(Log2.Log2Action.sua, "Sửa tham số lương " + r.ten, "tbLuong_DinhNghiaThamSo");
                    Log2.AddLogDetail(log, new string[] {"id",
                        "ma",
                        "ten",
                        "tsIdx",
                        "laCoDinh",
                        "ghiChu",
                        "kieuDuLieu",
                        "kieuNhap",
                        "kieuMapping",
                        "congthuc_id",
                        "moduleDef_id",
                        "giatri_macdinh",
                        "macdinh_theothangtruoc",
                        "lvTinhToan",
                        "hienTrenBangLuong",
                        "nhom",
                        "hienTrenPhieuLuong",
                        "stt"
                    }, r);
                    Log2.PushLog(log);

                }
                catch (Exception ex)
                {
                    GUIHelper.MessageError(ex.Message);
                }
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dlgEditor.MyValue = new tbLuong_DinhNghiaThamSo();
            dlgEditor.AttackMode = "add";
            if (dlgEditor.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(dlgEditor.MyValue.tsIdx))
                    {
                        int i;
                        string ts_Pre = "ts";
                        if (dlgEditor.MyValue.kieuDuLieu == 2)
                            ts_Pre = "tss";
                        for (i = 1; i < 199; i++)
                            if (db.tbLuong_DinhNghiaThamSos.Count(j => j.tsIdx == ts_Pre + i) == 0)
                                break;
                        if (i >= 199)
                        {
                            GUIHelper.MessageBox("Đã hết tham số (Xin vui lòng liên hệ quản trị viên để tiếp tục)");
                            return;
                        }
                        dlgEditor.MyValue.tsIdx = ts_Pre + i;
                    }

                    db.tbLuong_DinhNghiaThamSos.InsertOnSubmit(dlgEditor.MyValue);
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

                    LstData.Add(dlgEditor.MyValue);
                    grd.DataSource = new BindingList<tbLuong_DinhNghiaThamSo>(LstData);
                    dlgEditor.LstThamSo = LstData;

                    //bật lại form sửa
                    show_edit(dlgEditor.MyValue);

                    var log = Log2.CreateLog(Log2.Log2Action.them, "Thêm tham số lương " + dlgEditor.MyValue.ten, "tbLuong_DinhNghiaThamSo");
                    Log2.AddLogDetail(log, new string[] {"id",
                        "ma",
                        "ten",
                        "tsIdx",
                        "laCoDinh",
                        "ghiChu",
                        "kieuDuLieu",
                        "kieuNhap",
                        "kieuMapping",
                        "congthuc_id",
                        "moduleDef_id",
                        "giatri_macdinh",
                        "macdinh_theothangtruoc",
                        "lvTinhToan",
                        "hienTrenBangLuong",
                        "nhom",
                        "hienTrenPhieuLuong",
                        "stt"
                    }, dlgEditor.MyValue);
                    Log2.PushLog(log);

                }
                catch (Exception ex)
                {
                    GUIHelper.MessageError(ex.Message);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var r = grv.GetFocusedRow() as tbLuong_DinhNghiaThamSo;
            if (r != null)
            {
                viewThamSoCongThuc v = new viewThamSoCongThuc();
                v.MyId = r.congthuc_id;
                v.Show();
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

        private void frmDinhNghiaThamSo_KeyDown(object sender, KeyEventArgs e)
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
