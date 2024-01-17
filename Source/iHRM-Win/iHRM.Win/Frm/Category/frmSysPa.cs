using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Category
{
    public partial class frmSysPa : frmBase
    {
        DataTable dtData;

        public frmSysPa()
        {
            InitializeComponent();
        }
        private void frmBaseList_grdEdit_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            buttonPanel1_OnFind(null, null);
            grd.DataSource = dtData;
        }

        private void buttonPanel1_OnFind(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            dtData = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM [w5sysParameter]"));
        }
        private void buttonPanel1_OnSave(object sender, EventArgs e)
        {
            try
            {
                Provider.UpdateData(dtData, "w5sysParameter");
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
        
        private void frmBaseList_grdEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
    }
}
