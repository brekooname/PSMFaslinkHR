using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.AccessRight
{
    public partial class dlgCustomRule : DevExpress.XtraEditors.XtraForm
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        private long _myRule = 0;
        public long myRule
        {
            set
            {
                _myRule = value;
                gridView1.ClearSelection();
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    if (BitHelper.Has(_myRule, (gridView1.GetRow(i) as w5sysFunctionCustomRight).rightValue ?? 0))
                        gridView1.SelectRow(i);
                }
            }
            get
            {
                _myRule = gridView1.GetSelectedRows().Sum(i => (gridView1.GetRow(i) as w5sysFunctionCustomRight).rightValue ?? 0);
                return _myRule;
            }
        }

        public dlgCustomRule()
        {
            InitializeComponent();
        }

        private void dlgCustomRule_Load(object sender, EventArgs e)
        {

        }

        public void setDataSource(long funcID)
        {
            gridControl1.DataSource = db.w5sysFunctionCustomRights.Where(i => i.idFunction == funcID).ToList();
        }

        private void buttonPanel1_OnSave(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
