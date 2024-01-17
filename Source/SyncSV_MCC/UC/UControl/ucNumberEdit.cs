using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SyncSV.UC.UControl
{
    public partial class ucNumberEdit : ucBaseEdit
    {
        public enum ucNumberEdit_ReturnType { Int, Double, Decimal }

        private ucNumberEdit_ReturnType _returnType = ucNumberEdit_ReturnType.Decimal;
        public ucNumberEdit_ReturnType ucReturnType
        {
            get
            {
                return _returnType;
            }
            set
            {
                _returnType = value;
                edit1.Properties.DisplayFormat.FormatString =
                edit1.Properties.EditFormat.FormatString = (_returnType == ucNumberEdit_ReturnType.Double ? "#,0.00" : "#,0");
            }
        }

        public ucNumberEdit()
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
            edit1.EditValue = value;
        }
        protected override object getValue()
        {
            if (_returnType == ucNumberEdit_ReturnType.Decimal)
                return (decimal?)edit1.Value;
            else if (_returnType == ucNumberEdit_ReturnType.Int)
                return (int?)Convert.ToInt32(edit1.Value);
            else
                return (double?)Convert.ToDouble(edit1.Value);
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
