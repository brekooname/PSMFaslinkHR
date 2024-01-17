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
    public partial class frmDinhNghiaThamSo_ModuleSelect_Fake : frmBase
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);

        public Guid? MyId
        {
            get { return txtModule.EditValue as Guid?; }
            set { txtModule.EditValue = value; }
        }

        public frmDinhNghiaThamSo_ModuleSelect_Fake()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            txtModule.Properties.DataSource = db.tbLuongTS_ModuleDef_Fakes.ToList();
        }
        
        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        
    }
}
