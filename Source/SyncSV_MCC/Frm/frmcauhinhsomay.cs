using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV.Frm
{
    public partial class frmcauhinhsomay : Form
    {
        public frmcauhinhsomay()
        {
            InitializeComponent();
        }

        private void frmcauhinhsomay_Load(object sender, EventArgs e)
        {
            button2_Click(null, null);
            comboBox1.SelectedValue = Properties.Settings.Default.FP_soMay;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = Business.ADOController.ExeProcedure("p_mcc_getAll");
                comboBox1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.FP_soMay = comboBox1.SelectedValue.ToString();
                Properties.Settings.Default.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
