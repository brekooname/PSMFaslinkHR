using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SyncSV.UC.UControl
{
    public partial class ucPictureEdit : ucBaseEdit
    {
        public ucPictureEdit()
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
            if (value == DBNull.Value)
                edit1.EditValue = null;
            else if (value is System.Data.Linq.Binary)
                edit1.EditValue = (value as System.Data.Linq.Binary).ToArray();
            else
                edit1.EditValue = value;
        }
        protected override object getValue()
        {
            if (edit1.EditValue is byte[])
                return new System.Data.Linq.Binary(edit1.EditValue as byte[]);
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

        private void edit1_DoubleClick(object sender, EventArgs e)
        {
            if (ucLocked)
                return;

            edit1.LoadImage();
        }
    }
}
