using iHRM.Core.Business;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using iHRM.Common.Code;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class ThemUVVaoYCTD : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        public ThemUVVaoYCTD()
        {
            InitializeComponent();
        }

        private void AllCategory_Load(object sender, EventArgs e)
        {

            btnThemUV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);

            btnXoaUV.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);

            grcDotTuyenDung.DataSource = db.tbDotTuyenDungs.OrderByDescending(p=>p.BeginDate);
        }
        private void grvYCTD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = grvYCTD.GetFocusedDataRow();

            if (r != null)
            {
                grcUngVien.DataSource = Provider.ExecuteDataTableReader("p_tblYeuCauTD_UngVien_GetByIdYCTD",

                                                    new System.Data.SqlClient.SqlParameter("idYCTD", r["id"]));
            }
            else
            {
                grcUngVien.DataSource = null;
            }
        }

        private void grvYCTD_DataSourceChanged(object sender, EventArgs e)
        {
            grvYCTD_FocusedRowChanged(null, null);
        }

        private void grvDotTuyenDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var a = grvDotTuyenDung.GetFocusedRow() as tbDotTuyenDung;

            if (a != null)
            {
                grcYCTD.DataSource = Provider.ExecuteDataTableReader("p_tbYeuCauTuyenDung_GetAllByIdDotTD",

                                                    new System.Data.SqlClient.SqlParameter("idDotTD", a.id));
            }
            else
            {
                grcYCTD.DataSource = null;
            }
        }

        private void btnThemUV_Click(object sender, EventArgs e)
        {
            DataRow r = grvYCTD.GetFocusedDataRow();

            if (r != null)
            {
                dlgThemUVVaoYCTD dlgEditor = new dlgThemUVVaoYCTD();

                if (dlgEditor.ShowDialog() == DialogResult.OK)
                {
                    if (dlgEditor.MyValue.Count() == 0)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);

                        return;
                    }

                    try
                    {
                        var a = dlgEditor.MyValue.ToList();

                        grvDotTuyenDung_FocusedRowChanged(null, null);

                        if (r["isAccept"] != DBNull.Value)
                        {
                            if(!(bool)r["isAccept"])
                            {
                                GUIHelper.MessageError("Yêu cầu tuyển dụng này chưa được phê duyệt.", "Thêm ứng viên vào yêu cầu tuyển dụng");
                                
                                return;
                            }

                            Provider.ExecuteNonQuery_SQL("INSERT tblYeuCauTD_UngVien (idUV,idYCTD) VALUES " +
                                string.Join(",", dlgEditor.MyValue.Select(i => string.Format("('{0}','{1}')", i["EmployeeID"], r["id"])))
                            );

                            LogAction.LogAction.PushLog("Thêm dữ liệu"
                                                , string.Join(",", dlgEditor.MyValue.Select(i => string.Format("({0})", i["EmployeeID"])))
                                                , ""
                                                , string.Format("Thêm ứng viên vào yêu cầu tuyển dụng")
                                                , "tblYeuCauTD_UngVien");
                           
                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                           
                            grvDotTuyenDung_FocusedRowChanged(null, null);
                        }
                        else
                        {
                            GUIHelper.MessageError("Yêu cầu tuyển dụng này chưa được phê duyệt.", "Thêm ứng viên vào yêu cầu tuyển dụng");
                        }
                    }
                    catch (Exception ex)
                    {
                        win_globall.ExecCatch(ex);
                    }
                }
            }
            else
            {
                GUIHelper.MessageError("Bạn chưa chọn yêu cầu tuyển dụng.","Thêm ứng viên vào yêu cầu tuyển dụng");

                return;
            }
        }

        private void btnXoaUV_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả danh sách ứng viên trong yêu cầu tuyển dụng này?", "Xóa danh sách ứng viên", MessageBoxButtons.OKCancel);
            
            if (dg == DialogResult.OK)
            {
                DataRow r = grvYCTD.GetFocusedDataRow();

                string idxoa = string.Empty;

                if (r != null && r["id"] != DBNull.Value)
                {
                    var a = grvUngVien.GetSelectedRows();

                    if (a.Count() != 0)
                    {
                        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

                        foreach (var item in a)
                        {
                            var r2 = grvUngVien.GetDataRow(item);

                            if (r2 != null && r2["EmployeeID"] != DBNull.Value)
                            {
                                var uv = db.tblYeuCauTD_UngViens.FirstOrDefault(p => p.idUV == r2["EmployeeID"].ToString() && p.idYCTD.ToString() == r["id"].ToString());
                                
                                if (uv != null)
                                {
                                    idxoa += r2["EmployeeID"].ToString() + ",";

                                    db.tblYeuCauTD_UngViens.DeleteOnSubmit(uv);
                                }
                            }
                        }
                        try
                        {
                            db.SubmitChanges();

                            LogAction.LogAction.PushLog("Xóa dữ liệu", idxoa, "", string.Format("Xóa ứng viên khỏi yêu cầu tuyển dụng"), "tblYeuCauTD_UngVien");
                            
                            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                            
                            grvYCTD_FocusedRowChanged(null, null);
                        }
                        catch (Exception ex)
                        {
                            win_globall.ExecCatch(ex);
                        }
                    }
                    else
                    {
                        GUIHelper.MessageError("Bạn chưa chọn ứng viên.", "Xóa ứng viên khỏi yêu cầu tuyển dụng");
                        
                        return;
                    }
                }
                else
                {
                    GUIHelper.MessageError("Bạn chưa chọn yêu cầu tuyển dụng.", "Thêm ứng viên vào yêu cầu tuyển dụng");
                   
                    return;
                }
            }
        }
    }
}
