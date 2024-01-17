using iHRM.Core.Business;
using iHRM.Core.Business.Logic.Luong;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using DevExpress.XtraEditors.Controls;
using iHRM.Win.Cls;

namespace iHRM.Win.Frm.Luong
{
    public partial class dlgCongThucTinhLuong : dlgCustomBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);
        public tbBangLuongCalc myValue = null;
        public int? ID
        {
            get
            {
                return myValue == null ? null : (int?)myValue.id;
            }
            set
            {
                myValue = db.tbBangLuongCalcs.SingleOrDefault(i => i.id == value);
                txtCaption.Text = myValue.caption;

                var checkedItem = myValue.tbBangLuongCalc_EmpGroups.ToList();
                for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                {
                    var idd = (int)checkedListBoxControl1.GetItemValue(i);
                    checkedListBoxControl1.SetItemChecked(i, checkedItem.Count(j => j.idEmpGroup == idd) > 0);
                }
            }
        }

        public dlgCongThucTinhLuong()
        {
            InitializeComponent();

            checkedListBoxControl1.DataSource = db.tblEmp_Group2s.ToList();
        }

        private void dlgReportMonth_Load(object sender, EventArgs e)
        {
        }
        
        private void dlgReportMonth_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void dlgReportMonth_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID == null)
                {
                    using (var ts = new System.Transactions.TransactionScope())
                    {
                        myValue = new tbBangLuongCalc();
                        myValue.caption = txtCaption.Text;
                        db.tbBangLuongCalcs.InsertOnSubmit(myValue);
                        db.SubmitChanges();

                        if (checkedListBoxControl1.CheckedItemsCount > 0)
                        {
                            foreach (tblEmp_Group2 it in checkedListBoxControl1.CheckedItems)
                            {
                                var ii = new tbBangLuongCalc_EmpGroup();
                                ii.id = Guid.NewGuid();
                                ii.idEmpGroup = it.id;
                                ii.idCalc = myValue.id;
                                db.tbBangLuongCalc_EmpGroups.InsertOnSubmit(ii);
                            }
                            db.SubmitChanges();
                        }

                        ts.Complete();
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    }
                }
                else
                {
                    using (var ts = new System.Transactions.TransactionScope())
                    {
                        myValue.caption = txtCaption.Text;
                        db.SubmitChanges();

                        db.tbBangLuongCalc_EmpGroups.DeleteAllOnSubmit(myValue.tbBangLuongCalc_EmpGroups);
                        db.SubmitChanges();

                        if (checkedListBoxControl1.CheckedItemsCount > 0)
                        {
                            foreach (tblEmp_Group2 it in checkedListBoxControl1.CheckedItems)
                            {
                                var ii = new tbBangLuongCalc_EmpGroup();
                                ii.id = Guid.NewGuid();
                                ii.idEmpGroup = it.id;
                                ii.idCalc = myValue.id;
                                db.tbBangLuongCalc_EmpGroups.InsertOnSubmit(ii);
                            }
                            db.SubmitChanges();
                        }

                        ts.Complete();
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }
    }
}
