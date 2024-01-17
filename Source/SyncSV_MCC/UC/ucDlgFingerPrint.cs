using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV.UC
{
    public partial class ucDlgFingerPrint : Form
    {
        public ucDlgFingerPrint()
        {
            InitializeComponent();
            //main.axCZKEM1_OnFingerPrint += main_axCZKEM1_OnFingerPrint;
        }

        void main_axCZKEM1_OnFingerPrint(object sender, EventArgs e)
        {
            _myValue = sender.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private string _myValue = null;
        public string myValue
        {
            get { return _myValue; }
            set
            {
                _myValue = value; 
            }
        }

        private void ucDlgFingerPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            //main.axCZKEM1_OnFingerPrint -= main_axCZKEM1_OnFingerPrint;
        }


    }
}
