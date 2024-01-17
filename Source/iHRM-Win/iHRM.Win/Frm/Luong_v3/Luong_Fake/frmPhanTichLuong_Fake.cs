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

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class frmPhanTichLuong_Fake : frmBase
    {
        dcLuongv3DataContext db;

        public frmPhanTichLuong_Fake()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            txtSearchThang.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            TranslateForm();
        }
        
        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {
            btnExxecute.Enabled = checkPhanTichLuongOK.Checked;
        }

        private void btnExxecute_Click(object sender, EventArgs e)
        {
            if (chonPhongBan1.SelectedValue == null)
            {
                GUIHelper.MessageBox("Cần chọn phòng ban để thực hiện");
                return;
            }
            if (IsLock.IsLock.Check_IsLock("tbLuong_BangLuongThang_Fake", new DateTime(txtSearchThang.DateTime.Year, txtSearchThang.DateTime.Month, 1)))
            {
                GUIHelper.MessageBox("Dữ liệu đã chốt công khổng thể thao tác!");
                return;
            }


            if (backgroundWorker1.IsBusy)
                return;

            btnExxecute.Enabled = false;
            btnExxecute.Image = Properties.Resources.loading;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                backgroundWorker1.ReportProgress(0, "===== ===== LẤY DỮ LIỆU ===== =====");
                var ds = Provider.ExecuteDataSetReader("p_luong_layDuLieuTinhLuong_Fake",
                    new SqlParameter("thang", txtSearchThang.DateTime),
                    new SqlParameter("phongban_id", chonPhongBan1.SelectedValue)
                );
                backgroundWorker1.ReportProgress(0, string.Format("Tháng: {0:MM-yyyy}, phòng ban: {1}\r\n", txtSearchThang.DateTime, chonPhongBan1.SelectedRow == null ? "-" : chonPhongBan1.SelectedRow.DepName) +
                    "Tham số tính lương (" + ds.Tables[0].Rows.Count + ")\r\n" +
                    "Module tính lương (" + ds.Tables[1].Rows.Count + ")\r\n" +
                    "Công thức tính lương: " + ds.Tables[2].Rows[0][0] 
                );
                string sql = "";
                string where = " b.thang = @thang ";
                string congthuctinh;

                #region nhập tay
                if (chkDlNhapTay.Checked)
                {
                    try
                    {
                        backgroundWorker1.ReportProgress(0, "===== ===== THỰC HIỆN CÁC THAM SỐ NHẬP TAY ===== =====");
                        var lst = ds.Tables[0].Select("kieuNhap=1").Select(i => i["tsIdx"] as string).ToList();
                        sql = @"DECLARE @DepPath NVARCHAR(255) = (SELECT TOP 1 Path FROM dbo.tblRef_Department WHERE DepID='" + chonPhongBan1.SelectedValue + "') + '%' ";
                        sql += @"UPDATE dbo.tbLuong_BangLuongThang_Fake
                        SET " + string.Join(",", lst.Select(i => string.Format("[{0}]=n.[{0}]", i))) + @"
                        FROM dbo.tbLuong_BangLuongThang_Fake b  WITH (NOLOCK)
	                        INNER JOIN dbo.tbLuong_NhapDuLieu_Fake n WITH (NOLOCK) ON b.idNV = n.idNV AND b.thang = n.thang
	                        INNER JOIN dbo.tblEmployee nv WITH (NOLOCK) ON n.idNV=nv.EmployeeID 
                            INNER JOIN ( SELECT * FROM dbo.tblRef_Department d WITH (NOLOCK)  WHERE d.[Path] LIKE  @DepPath) d1 ON nv.DepID_Final = d1.DepID 
                        WHERE " + where;
                        Provider.ExecuteNonQuery_SQL(sql, new SqlParameter("thang", txtSearchThang.DateTime));
                        
                        backgroundWorker1.ReportProgress(0, "Thực hiện hoàn tất");
                    }
                    catch (Exception ex)
                    {
                        backgroundWorker1.ReportProgress(3, ex.Message + "");
                    }
                }
                #endregion

                #region hut dl tu module
                if (chkHutDuLieu.Checked)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        backgroundWorker1.ReportProgress(0, "===== ===== THỰC HIỆN HÚT DỮ LIỆU TỪ MODULE ===== =====");
                        foreach (DataRow r in ds.Tables[1].Rows)
                        {
                            try
                            {
                                string ten = DbHelper.DrGetString(r, "ten");
                                string chuoiKetNoi = DbHelper.DrGetString(r, "chuoiKetNoi");
                                string tenBang = DbHelper.DrGetString(r, "tenBang");
                                string tenCotGiaTri = DbHelper.DrGetString(r, "tenCotGiaTri");
                                string tenCotThang = DbHelper.DrGetString(r, "tenCotThang");
                                string tenCotNvId = DbHelper.DrGetString(r, "tenCotNvId");
                                string tsIdx = DbHelper.DrGetString(r, "tsIdx");

                                string tenCT = string.Empty;
                                tenCT = DbHelper.DrGetString(r, "ten");

                                backgroundWorker1.ReportProgress(0, "Tham số " + tenCT + " - Module: " + ten + "");
                                switch (DbHelper.DrGetString(r, "loai"))
                                {
                                    case "auto":
                                    case "":
                                    case null:
                                        if (string.IsNullOrWhiteSpace(chuoiKetNoi) || chuoiKetNoi.Trim() == ".") //cùng db
                                        {
                                            if (string.IsNullOrWhiteSpace(tenCotGiaTri))
                                            {
                                                backgroundWorker1.ReportProgress(0, "Chưa định nghĩa tên cột giá trị");
                                            }
                                            else
                                            {

                                                sql = @"DECLARE @DepPath NVARCHAR(255) = (SELECT TOP 1 Path FROM dbo.tblRef_Department WHERE DepID='" + chonPhongBan1.SelectedValue + "') + '%'";

                                                sql += @"UPDATE dbo.tbLuong_BangLuongThang_Fake
                                                    SET " + string.Format(" [{0}]={1} ", tsIdx, tenCotGiaTri) + @" 
                                                    FROM dbo.tbLuong_BangLuongThang_Fake b  WITH (NOLOCK)
	                                                    " + (string.IsNullOrWhiteSpace(tenBang) ? "" : (
                                                          "INNER JOIN [" + tenBang + @"] n WITH (NOLOCK) ON b.idNV = n.[" + tenCotNvId + @"] " + (string.IsNullOrWhiteSpace(tenCotThang) ? "" : (" AND b.thang = n.[" + tenCotThang + @"] "))
                                                        )) + @"
	                                                    INNER JOIN dbo.tblEmployee nv WITH (NOLOCK) ON b.idNV = nv.EmployeeID
                                                        INNER JOIN ( SELECT * FROM dbo.tblRef_Department d WITH (NOLOCK)  WHERE d.[Path] LIKE  @DepPath) d1 ON nv.DepID_Final = d1.DepID
                                                    WHERE " + where;

                                                //if (globall.indebug)
                                                //    backgroundWorker1.ReportProgress(0, "======= sql ======\r\n" + sql + "\r\n====================\r\n");

                                                Provider.ExecuteNonQuery_SQL(sql, new SqlParameter("thang", txtSearchThang.DateTime));
                                            }
                                        }
                                        else
                                        {
                                            backgroundWorker1.ReportProgress(0, "Chưa hỗ trợ hút từ db khác!");
                                        }
                                        break;
                                    case "phongban":
                                        sql = @"DECLARE @DepPath NVARCHAR(255) = (SELECT TOP 1 Path FROM dbo.tblRef_Department WHERE DepID='" + chonPhongBan1.SelectedValue + "') + '%'";

                                        sql += @"UPDATE dbo.tbLuong_BangLuongThang_Fake
                                        SET " + string.Format(" [{0}]=[{1}] ", tsIdx, "giatri") + @" 
                                        FROM dbo.tbLuong_BangLuongThang_Fake b  WITH (NOLOCK)
	                                        INNER JOIN [tbMod_values] n WITH (NOLOCK) ON b.idNV = n.[nhanvien_id] AND b.thang = n.[thang]
	                                        INNER JOIN dbo.tblEmployee nv WITH (NOLOCK) ON n.[nhanvien_id] = nv.EmployeeID
                                            INNER JOIN ( SELECT * FROM dbo.tblRef_Department d WITH (NOLOCK)  WHERE d.[Path] LIKE  @DepPath) d1 ON nv.DepID_Final = d1.DepID
                                        WHERE " + where;
                                        Provider.ExecuteNonQuery_SQL(sql, new SqlParameter("thang", txtSearchThang.DateTime));
                                        break;
                                    case "thang":
                                        sql = @"DECLARE @DepPath NVARCHAR(255) = (SELECT TOP 1 Path FROM dbo.tblRef_Department WHERE DepID='" + chonPhongBan1.SelectedValue + "') + '%'";

                                        sql += @"UPDATE dbo.tbLuong_BangLuongThang_Fake
                                            SET " + tsIdx + "=(SELECT TOP 1 giatri FROM tbMod_thang m WHERE m.moduleDef_id = '" + DbHelper.DrGet(r, "id") + "' AND m.thang = " + txtSearchThang.DateTime.Month
                                            + @" AND (ISNULL(m.nam,0)=0 OR m.nam=" + txtSearchThang.DateTime.Year + @"))
                                            FROM tbLuong_BangLuongThang_Fake b WITH (NOLOCK)
	                                            INNER JOIN dbo.tblEmployee nv WITH (NOLOCK) ON b.idNV=nv.EmployeeID
                                                INNER JOIN ( SELECT * FROM dbo.tblRef_Department d WITH (NOLOCK)  WHERE d.[Path] LIKE  @DepPath) d1 ON nv.DepID_Final = d1.DepID
                                            WHERE " + where;
                                        Provider.ExecuteNonQuery_SQL(sql, new SqlParameter("thang", txtSearchThang.DateTime));
                                        break;
                                }

                                backgroundWorker1.ReportProgress(0, "Thực hiện hoàn tất");
                            }
                            catch (Exception ex)
                            {
                                backgroundWorker1.ReportProgress(3, string.Format("Module {0} xảy ra lỗi: {1}", DbHelper.DrGetString(r, "ten"), ex.Message));
                            }
                        }
                    }
                }
                #endregion

                #region theo công thức (lv)
                if (chkPtCongThuc.Checked)
                {
                    backgroundWorker1.ReportProgress(0, "===== ===== THỰC HIỆN CÁC THAM SỐ TÍNH TOÁN ===== =====");
                    var lstLV = ds.Tables[0].Select("kieuNhap=3 OR kieuMapping=2").Select(i => (int)i["lvTinhToan"]).Distinct().ToList().OrderBy(i => i);
                    string tenCT = string.Empty;
                    foreach (var lv in lstLV)
                    {
                        var lst = ds.Tables[0].Select("(kieuNhap=3 OR kieuMapping=2) and lvTinhToan=" + lv);
                        foreach (DataRow r in lst)
                        {
                            try
                            {
                                tenCT = DbHelper.DrGetString(r, "ten");

                                if (DbHelper.DrGetInt(r, "kieuNhap") == 3)
                                {
                                    congthuctinh = DbHelper.DrGetString(r, "congthuctinh");
                                    if (string.IsNullOrWhiteSpace(congthuctinh))
                                    {
                                        backgroundWorker1.ReportProgress(2, string.Format("Tham số {0} chưa được định nghĩa công thức tính", DbHelper.DrGetString(r, "ten")));
                                        continue;
                                    }

                                    sql = @"DECLARE @DepPath NVARCHAR(255) = (SELECT TOP 1 Path FROM dbo.tblRef_Department WHERE DepID='" + chonPhongBan1.SelectedValue + "') + '%'";

                                    sql += @"UPDATE dbo.tbLuong_BangLuongThang_Fake
                                        SET [" + DbHelper.DrGetString(r, "tsIdx") + @"] = " + buildCongThuc(congthuctinh, ds.Tables[0]) + @"
                                        FROM dbo.tbLuong_BangLuongThang_Fake b WITH (NOLOCK)  
                                         INNER JOIN dbo.tblEmployee nv WITH (NOLOCK) ON b.idNV=nv.EmployeeID
                                        INNER JOIN ( SELECT * FROM dbo.tblRef_Department d WITH (NOLOCK)  WHERE d.[Path] LIKE  @DepPath) d1 ON nv.DepID_Final = d1.DepID
                                     WHERE " + where.Replace("n.thang", "b.thang");
                                    Provider.ExecuteNonQuery_SQL(sql, new SqlParameter("thang", txtSearchThang.DateTime));
                                }

                                if (DbHelper.DrGetInt(r, "kieuMapping") == 2) //được định nghĩa
                                {
                                    string ts_pre = "tuGiaTri";
                                    if (DbHelper.DrGetInt(r, "kieuDuLieu") == 2) //nhập chữ
                                        ts_pre = "tuGiaTris";

                                    if (DbHelper.DrGetInt(r, "kieuNhap") == 1) //nhập tay
                                    {

                                        if (ts_pre == "tuGiaTris") // Trong add lai nhap chuoi 21/08/2017
                                        {
                                            sql = @"DECLARE @DepPath NVARCHAR(255) = (SELECT TOP 1 Path FROM dbo.tblRef_Department WHERE DepID='" + chonPhongBan1.SelectedValue + "') + '%'";

                                             sql += @"UPDATE dbo.tbLuong_BangLuongThang_Fake
                                        SET [" + DbHelper.DrGetString(r, "tsIdx") + @"] = CAST( t.layGiaTri AS Decimal ) 

                                        FROM dbo.tbLuong_BangLuongThang_Fake b WITH (NOLOCK)
	                                        INNER JOIN dbo.tbLuong_NhapDuLieu_Fake nl WITH (NOLOCK) ON nl.idNV = b.idNV AND nl.thang = b.thang
	                                        INNER JOIN tbLuongTS_TruthDef_Fake t WITH (NOLOCK) ON nl.[" + DbHelper.DrGetString(r, "tsIdx") + @"] = t." + ts_pre + " AND t.luongTS_id = " + DbHelper.DrGetString(r, "id") + @"
	                                        INNER JOIN dbo.tblEmployee nv WITH (NOLOCK) ON nl.idNV=nv.EmployeeID
                                       INNER JOIN ( SELECT * FROM dbo.tblRef_Department d  WHERE d.[Path] LIKE  @DepPath) d1 ON nv.DepID_Final = d1.DepID
                                        WHERE " + where;
                                        }else
                                        {
                                            sql = @"DECLARE @DepPath NVARCHAR(255) = (SELECT TOP 1 Path FROM dbo.tblRef_Department WHERE DepID='" + chonPhongBan1.SelectedValue + "') + '%'";

                                               sql += @"UPDATE dbo.tbLuong_BangLuongThang_Fake
                                        SET [" + DbHelper.DrGetString(r, "tsIdx") + @"] = t.layGiaTri
                                        FROM dbo.tbLuong_BangLuongThang_Fake b WITH (NOLOCK)
	                                        INNER JOIN dbo.tbLuong_NhapDuLieu_Fake nl WITH (NOLOCK) ON nl.idNV = b.idNV AND nl.thang = b.thang
	                                        INNER JOIN tbLuongTS_TruthDef_Fake t WITH (NOLOCK) ON nl.[" + DbHelper.DrGetString(r, "tsIdx") + @"] = t." + ts_pre + " AND nl.[" + DbHelper.DrGetString(r, "tsIdx") + @"] < t.denGiaTri AND t.luongTS_id = " + DbHelper.DrGetString(r, "id") + @"
	                                        INNER JOIN dbo.tblEmployee nv WITH (NOLOCK) ON nl.idNV=nv.EmployeeID
                                        INNER JOIN ( SELECT * FROM dbo.tblRef_Department d  WHERE d.[Path] LIKE  @DepPath) d1 ON nv.DepID_Final = d1.DepID
                                        WHERE " + where;
                                        }
                                     
                                    }
                                    else //tính toán hoặc hút dl
                                    {
                                        if (ts_pre == "tuGiaTris") // Trong add lai nhap chuoi 21/08/2017
                                        {
                                            sql = @"DECLARE @DepPath NVARCHAR(255) = (SELECT TOP 1 Path FROM dbo.tblRef_Department WHERE DepID='" + chonPhongBan1.SelectedValue + "') + '%'";


                                            sql += @"UPDATE dbo.tbLuong_BangLuongThang_Fake
                                        SET [" + DbHelper.DrGetString(r, "tsIdx") + @"] = CAST( t.layGiaTri AS Decimal ) 
                                        FROM dbo.tbLuong_BangLuongThang_Fake b WITH (NOLOCK)
	                                        INNER JOIN tbLuongTS_TruthDef_Fake t WITH (NOLOCK) ON b.[" + DbHelper.DrGetString(r, "tsIdx") + @"] = t." + ts_pre + " AND t.luongTS_id = " + DbHelper.DrGetString(r, "id") + @"
	                                        INNER JOIN dbo.tblEmployee nv WITH (NOLOCK) ON b.idNV=nv.EmployeeID
                                       INNER JOIN ( SELECT * FROM dbo.tblRef_Department d WITH (NOLOCK) WHERE d.[Path] LIKE  @DepPath) d1 ON nv.DepID_Final = d1.DepID
                                        WHERE " + where;
                                        }
                                        else
                                        {
                                            sql = @"DECLARE @DepPath NVARCHAR(255) = (SELECT TOP 1 Path FROM dbo.tblRef_Department WHERE DepID='" + chonPhongBan1.SelectedValue + "') + '%'";

                                            sql += @"UPDATE dbo.tbLuong_BangLuongThang_Fake
                                        SET [" + DbHelper.DrGetString(r, "tsIdx") + @"] = t.layGiaTri
                                        FROM dbo.tbLuong_BangLuongThang_Fake b WITH (NOLOCK)
	                                        INNER JOIN tbLuongTS_TruthDef_Fake t WITH (NOLOCK) ON b.[" + DbHelper.DrGetString(r, "tsIdx") + @"] >= t." + ts_pre + " AND b.[" + DbHelper.DrGetString(r, "tsIdx") + @"] < t.denGiaTri AND t.luongTS_id = " + DbHelper.DrGetString(r, "id") + @"
	                                        INNER JOIN dbo.tblEmployee nv WITH (NOLOCK) ON b.idNV=nv.EmployeeID
                                        INNER JOIN ( SELECT * FROM dbo.tblRef_Department d  WHERE d.[Path] LIKE  @DepPath) d1 ON nv.DepID_Final = d1.DepID
                                        WHERE " + where;
                                        }

                                    }
                                    Provider.ExecuteNonQuery_SQL(sql, new SqlParameter("thang", txtSearchThang.DateTime));                           
                                }
                            }
                            catch (Exception ex)
                            {
                                string[] arrListStr = sql.Split('{');
                                if (arrListStr.Count() >  1)
                                {
                                    for (int i = 0; i < arrListStr.Count() - 1; i++)
                                    {
                                        string[] arrListStr1 = arrListStr[i + 1].Split('}');
                                        if (arrListStr1.Count() > 1)
                                        {
                                            backgroundWorker1.ReportProgress(3, "Công thức: " + tenCT + " thiếu/sai tham số {" + arrListStr1[0] + "}");
                                        }
                                    }
                                }
                                else
                                {
                                    backgroundWorker1.ReportProgress(3, tenCT + " - " + ex.Message + "");
                                }
                            }
                        }
                    }
                    backgroundWorker1.ReportProgress(0, "Thực hiện hoàn tất");
                }
                #endregion

                backgroundWorker1.ReportProgress(0, "Phân tích hoàn tất");

                var log = Log2.CreateLog(Log2.Log2Action.phantich, "Phân tích lương báo cáo tháng: " + string.Format("{0:MM/yyyy}", txtSearchThang.DateTime), "tbLuong_BangLuongThang_Fake");
                log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "thang",
                    value1 = string.Format("{0:MM/yyyy}", txtSearchThang.DateTime)
                });
           
                log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "phongban_id",
                    value1 = "" + chonPhongBan1.SelectedValue,
                });
                Log2.PushLog(log);
            }
            catch (Exception ex)
            {
                backgroundWorker1.ReportProgress(3, "Xảy ra lỗi ngoại lệ: " + ex.Message + "");
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage >= 0 && e.ProgressPercentage < 4)
            {
                logger1.OutLog(e.UserState.ToString(), (UC.Logger.LogType)e.ProgressPercentage);
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanTichLuong));
            btnExxecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExxecute.Image")));
            btnExxecute.Enabled = true;
        }
        
        string buildCongThuc(string temp, DataTable dtMapping)
        {
            foreach (DataRow r in dtMapping.Rows)
                temp = temp.Replace("{" + DbHelper.DrGet(r, "ma") + "}", "[" + DbHelper.DrGet(r, "tsIdx") + "]");
            return temp;
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

        private void frmPhanTichLuong_Fake_KeyDown(object sender, KeyEventArgs e)
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
