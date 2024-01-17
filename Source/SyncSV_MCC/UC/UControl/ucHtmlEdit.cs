using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SyncSV.UC.UControl
{
    public partial class ucHtmlEdit : ucBaseEdit
    {
        public ucHtmlEdit()
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
            edit1.EditValue = (value == DBNull.Value ? null : value);
        }
        protected override object getValue()
        {
            return edit1.EditValue;
        }
        protected override bool getLocked()
        {
            return edit1.Properties.ReadOnly;
        }
        protected override void setLocked(bool value)
        {
            edit1.Properties.ReadOnly = value;
        }
    }
}
