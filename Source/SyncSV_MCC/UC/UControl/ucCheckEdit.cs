using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SyncSV.UC.UControl
{
    public partial class ucCheckEdit : ucBaseEdit
    {
        public bool ucAllowNull
        {
            set
            {
                edit1.Properties.NullStyle = value ? DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked : DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            }
            get
            {
                return edit1.Properties.NullStyle == DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
            }
        }

        public ucCheckEdit()
        {
            InitializeComponent();

            edit1.GotFocus += edit1_GotFocus;
            edit1.LostFocus += edit1_LostFocus;
        }

        void edit1_LostFocus(object sender, EventArgs e)
        {
            edit1.BackColor = NomalColor;
        }
        void edit1_GotFocus(object sender, EventArgs e)
        {
            edit1.BackColor = FocusColor;
        }

        protected override void setValue(object value)
        {
            edit1.EditValue = (value == DBNull.Value ? null : value);
        }
        protected override object getValue()
        {
            if (!ucAllowNull)
                return edit1.EditValue ?? false;
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
