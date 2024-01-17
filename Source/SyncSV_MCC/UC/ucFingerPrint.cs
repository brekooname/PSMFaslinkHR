using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV.UC
{
    public partial class ucFingerPrint : UControl.ucBaseEdit
    {
        ucDlgFingerPrint editor = null;

        public ucFingerPrint()
        {
            InitializeComponent();
        }

        protected override object getValue()
        {
            return buttonEdit1.Text;
        }
        protected override void setValue(object value)
        {
            buttonEdit1.Text = value as string;
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            editor = new ucDlgFingerPrint();
            if (editor.ShowDialog() == DialogResult.OK)
            {
                buttonEdit1.Text = editor.myValue;
            }
        }
        protected override bool getLocked()
        {
            return buttonEdit1.Properties.ReadOnly;
        }
        protected override void setLocked(bool value)
        {
            buttonEdit1.Properties.ReadOnly = value;
        }
    }
}
