using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV.UC.UControl
{
    public partial class ucDate2DataEdit : ucBaseEdit
    {
        public ucDate2DataEdit()
        {
            InitializeComponent();

            edit1.GotFocus += dateEdit1_GotFocus;
            edit1.LostFocus += dateEdit1_LostFocus;

            edit2.GotFocus += edit2_GotFocus;
            edit2.LostFocus += edit2_LostFocus;
        }

        void edit2_LostFocus(object sender, EventArgs e)
        {
            edit2.BackColor = NomalColor;
        }

        void edit2_GotFocus(object sender, EventArgs e)
        {
            edit2.BackColor = FocusColor;
        }

        void dateEdit1_LostFocus(object sender, EventArgs e)
        {
            edit1.BackColor = NomalColor;
        }
        void dateEdit1_GotFocus(object sender, EventArgs e)
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
        protected override void setValue2(object value)
        {
            edit2.EditValue = value;
        }
        protected override object getValue2()
        {
            return edit2.EditValue;
        }
        protected override bool getLocked()
        {
            return edit1.Properties.ReadOnly;
        }
        protected override void setLocked(bool value)
        {
            edit1.Properties.ReadOnly = edit2.Properties.ReadOnly = value;
        }
    }
}
