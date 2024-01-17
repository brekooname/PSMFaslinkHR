using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV
{
    public partial class frmConnect : Form
    {
        public zkemkeeper.CZKEMClass axCZKEM1 = null;

        public frmConnect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Frm.Common.frmConnectFingerPrint();
            this.Hide();
            try
            {
                frm.ShowDialog();
            }
            finally
            {
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frm = new Frm.Common.frmCauHinh();
            this.Hide();
            try
            {
                frm.ShowDialog();
            }
            finally
            {
                this.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new Frm.frmcauhinhsomay();
            this.Hide();
            try
            {
                frm.ShowDialog();
            }
            finally
            {
                this.Show();
            }
        }
    }
}
