using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3.VayVon
{
    public partial class dlgVayVon_LyDo : dlgCustomBase
    {
        public string myLyDo
        {
            get { return txtLyDo.Text; }
            set { txtLyDo.Text = value; }
        }
        public bool myReadOnly
        {
            get { return !btnSave.Visible; }
            set { btnSave.Visible = !value; }
        }

        public dlgVayVon_LyDo()
        {
            InitializeComponent();
        }
        private void dlgDinhNghiaThamSo_Load(object sender, EventArgs e)
        {
        }
        
        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        
    }
}
