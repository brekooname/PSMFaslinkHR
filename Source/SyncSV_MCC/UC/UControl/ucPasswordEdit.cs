using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SyncSV.UC.UControl
{
    public partial class ucPasswordEdit : ucBaseEdit
    {
        public char ucPasswordChar
        {
            get { return edit1.Properties.PasswordChar; }
            set { edit1.Properties.PasswordChar = edit2.Properties.PasswordChar = value; }
        }

        public ucPasswordEdit()
        {
            InitializeComponent();

            edit1.GotFocus += textEdit1_GotFocus;
            edit1.LostFocus += textEdit1_LostFocus;
            edit2.GotFocus += textEdit1_GotFocus;
            edit2.LostFocus += textEdit1_LostFocus;
        }

        void textEdit1_LostFocus(object sender, EventArgs e)
        {
            edit1.BackColor = edit2.BackColor = NomalColor;
        }
        void textEdit1_GotFocus(object sender, EventArgs e)
        {
            edit1.BackColor = edit2.BackColor = FocusColor;
        }

        protected override void setValue(object value)
        {
            edit1.Text = edit2.Text = (string)(value == DBNull.Value ? null : value);
        }
        protected override void setValue2(object value)
        {
            edit2.Text = (string)(value == DBNull.Value ? null : value);
        }
        protected override object getValue()
        {
            return edit1.Text;
        }
        protected override object getValue2()
        {
            return edit2.Text;
        }
        protected override bool getLocked()
        {
            return edit1.Properties.ReadOnly;
        }
        protected override void setLocked(bool value)
        {
            edit1.Properties.ReadOnly = edit2.Properties.ReadOnly = value;
        }

        public override bool checkVailable()
        {
            if (edit1.Text != edit2.Text)
            {
                edit2.BackColor = LabelErrorColor;
                return false;
            }
            else
            {
                edit2.BackColor = NomalColor;
            }

            return base.checkVailable();
        }

        private void edit1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            edit1.Properties.PasswordChar = '\0';
        }
        private void edit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            edit1.Properties.PasswordChar = edit2.Properties.PasswordChar;
        }

        private void edit1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
