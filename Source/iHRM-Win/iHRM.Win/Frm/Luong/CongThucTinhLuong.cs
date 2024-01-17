using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
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

namespace iHRM.Win.Frm.Luong
{
    public partial class CongThucTinhLuong : frmBase
    {
        List<tbBangLuongCalc> Data;
        MathEvaluator.EvaluatorEditor dlgCalcEditor = null;

        public CongThucTinhLuong()
        {
            InitializeComponent();
        }
        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadGrvLayout(grv);
        }
        private void LoadData()
        {
            dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
            Data = db.tbBangLuongCalcs.ToList();
            grd.DataSource = new BindingList<tbBangLuongCalc>(Data);
        }
        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            var r = grv.GetFocusedRow() as tbBangLuongCalc;
            if (r == null)
                return;

            if (dlgCalcEditor == null)
            {
                dlgCalcEditor = new MathEvaluator.EvaluatorEditor();
                MathEvaluator.EvaluatorEditor.lstPara.Clear();
                MathEvaluator.EvaluatorEditor.lstPara.AddRange(new MathEvaluator.EvaluatorEditor.lstItem[] {
                    new MathEvaluator.EvaluatorEditor.lstItem(){Name = "LuongTG", Description = "Lương thời gian"},
                    new MathEvaluator.EvaluatorEditor.lstItem(){Name = "ChuyenCan", Description = "Chuyên cần"},
                    new MathEvaluator.EvaluatorEditor.lstItem(){Name = "ConTho", Description = "Con thơ"},
                    new MathEvaluator.EvaluatorEditor.lstItem(){Name = "XangXe", Description = "Xăng xe"}
                });

                dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
                var lst = db.tblRef_Allowances.ToList();
                MathEvaluator.EvaluatorEditor.lstPara.AddRange(lst.Select(i => new MathEvaluator.EvaluatorEditor.lstItem() { Name = i.AllowanceID, Description = i.AllowanceName }));
            }
            dlgCalcEditor.CalcText = r.expression;
            if (dlgCalcEditor.ShowDialog() == DialogResult.OK)
                r.expression = dlgCalcEditor.CalcText;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            dlgCongThucTinhLuong dlg = new dlgCongThucTinhLuong();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Data.Add(dlg.myValue);
                grd.RefreshDataSource();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var it = grv.GetFocusedRow() as tbBangLuongCalc;
            if (it != null)
            {
                dlgCongThucTinhLuong dlg = new dlgCongThucTinhLuong();
                dlg.ID = it.id;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    it.caption = dlg.myValue.caption;
                    grd.RefreshDataSource();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa?"))
            {
                try
                {
                    var it = grv.GetFocusedRow() as tbBangLuongCalc;
                    if (it == null)
                        return;

                    using (var ts = new System.Transactions.TransactionScope())
                    {
                        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
                        var it1 = db.tbBangLuongCalcs.SingleOrDefault(i => i.id == it.id);
                        db.tbBangLuongCalc_EmpGroups.DeleteAllOnSubmit(it1.tbBangLuongCalc_EmpGroups);
                        db.SubmitChanges();

                        db.tbBangLuongCalcs.DeleteOnSubmit(it1);
                        db.SubmitChanges();

                        ts.Complete();
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                        grv.DeleteSelectedRows();
                    }
                }
                catch(Exception ex)
                {
                    GUIHelper.MessageError(ex.Message);
                }
            }
        }
    }
    
}
