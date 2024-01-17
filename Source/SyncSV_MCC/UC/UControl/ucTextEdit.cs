using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SyncSV.UC.UControl
{
    public partial class ucTextEdit : ucBaseEdit
    {
        public event EventHandler OnKeyEnter;

        public char ucPasswordChar
        {
            get { return edit1.Properties.PasswordChar; }
            set { edit1.Properties.PasswordChar = value; }
        }

        public ucTextEdit()
        {
            InitializeComponent();

            edit1.GotFocus += textEdit1_GotFocus;
            edit1.LostFocus += textEdit1_LostFocus;
        }

        void textEdit1_LostFocus(object sender, EventArgs e)
        {
            edit1.BackColor = NomalColor;
        }
        void textEdit1_GotFocus(object sender, EventArgs e)
        {
            edit1.BackColor = FocusColor;
        }

        protected override void setValue(object value)
        {
            edit1.Text = (string)(value == DBNull.Value ? null : value);
        }
        protected override object getValue()
        {
            return edit1.Text;
        }
        protected override bool getLocked()
        {
            return edit1.Properties.ReadOnly;
        }
        protected override void setLocked(bool value)
        {
            edit1.Properties.ReadOnly = value;
        }

        private void edit1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (OnKeyEnter != null)
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                    OnKeyEnter(this, null);
            }
        }
    }
}
