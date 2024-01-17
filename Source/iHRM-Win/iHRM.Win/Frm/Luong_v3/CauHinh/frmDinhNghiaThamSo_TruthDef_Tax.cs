using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class frmDinhNghiaThamSo_TruthDef_Tax : frmBase
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
        IQueryable<tbLuongTS_TruthDef_Tax> LstData;

        tbLuong_DinhNghiaThamSo_Tax myTS = new tbLuong_DinhNghiaThamSo_Tax();

        private int? myId;
        public int? MyId
        {
            get { return myId; }
            set
            {
                myId = value;
                myTS = db.tbLuong_DinhNghiaThamSo_Taxes.SingleOrDefault(i => i.id == myId);
                LstData = db.tbLuongTS_TruthDef_Taxes.Where(i => i.luongTS_id == myId);
                grd.DataSource = LstData;
            }
        }

        public frmDinhNghiaThamSo_TruthDef_Tax()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            if (myTS != null)
            {
                if(myTS.kieuDuLieu == 1)
                {
                    gridColumn1.Visible = gridColumn2.Visible = gridColumn3.Visible = myTS.kieuDuLieu == 1;
                    gridColumn4.Visible = myTS.kieuDuLieu == 2;
                }
                else
                {
                    gridColumn1.Visible = gridColumn2.Visible = myTS.kieuDuLieu == 1;
                    gridColumn4.Visible = gridColumn3.Visible = myTS.kieuDuLieu == 2;
                }
                this.Text = "Định nghĩa giá trị cho " + myTS.ten;
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            grv.DeleteSelectedRows();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.GetChangeSet().Deletes.Count() > 0)
                {
                    var log = Log2.CreateLog(Log2.Log2Action.xoa, "Xóa " + db.GetChangeSet().Deletes.Count() + " bản ghi", "tbLuongTS_TruthDef_Tax");
                    log.tbLog2_details.AddRange(db.GetChangeSet().Deletes.Select(i => new Core.Business.DbObject.tbLog2_detail()
                    {
                        id = Guid.NewGuid(),
                        log_id = log.id,
                        target1 = "id",
                        value1 = (i as tbLuongTS_TruthDef_Tax).id.ToString()
                    }).ToArray());
                    Log2.PushLog(log);
                }

                if (db.GetChangeSet().Inserts.Count() > 0)
                {
                    foreach (tbLuongTS_TruthDef_Tax r in db.GetChangeSet().Inserts)
                    {
                        var log = Log2.CreateLog(Log2.Log2Action.them, "Thêm bản ghi " + r.id, "tbLuongTS_TruthDef_Tax");
                        Log2.AddLogDetail(log, new string[] {"id",
                            "luongTS_id",
                            "tuGiaTri",
                            "tuGiaTris",
                            "denGiaTri",
                            "layGiaTri"
                        }, r);
                        Log2.PushLog(log);
                    }
                }

                if (db.GetChangeSet().Updates.Count() > 0)
                {
                    foreach (tbLuongTS_TruthDef_Tax r in db.GetChangeSet().Updates)
                    {
                        var log = Log2.CreateLog(Log2.Log2Action.sua, "Sửa bản ghi " + r.id, "tbLuongTS_TruthDef_Tax");
                        Log2.AddLogDetail(log, new string[] {"id",
                            "luongTS_id",
                            "tuGiaTri",
                            "tuGiaTris",
                            "denGiaTri",
                            "layGiaTri"
                        }, r);
                        Log2.PushLog(log);
                    }
                }

                db.SubmitChanges();
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }

        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var r = grv.GetRow(e.RowHandle) as tbLuongTS_TruthDef_Tax;
            if (r != null)
            {
                r.id = Guid.NewGuid();
                r.luongTS_id = myId;
            }
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
    }
}
