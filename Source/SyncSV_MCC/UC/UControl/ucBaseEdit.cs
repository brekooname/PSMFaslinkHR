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
    public partial class ucBaseEdit : UserControl
    {
        protected static Color NomalColor = Color.White;
        protected static Color FocusColor = Color.FromArgb(255, 255, 128);
        protected static Color LabelNomalColor = Color.FromArgb(192, 192, 255);
        protected static Color LabelErrorColor = Color.Red;
        protected static Color LabelValidColor = Color.Green;

        public int ucLabelWidth
        {
            get { return labelControl1.Width; }
            set { labelControl1.Width = value; }
        }
        private bool _ucLabelAutoWidth = false;
        public bool ucLabelAutoWidth
        {
            get { return _ucLabelAutoWidth; }
            set { _ucLabelAutoWidth = value; labelControl1_TextChanged(null, null); }
        }

        public bool ucLabelVisible
        {
            get { return labelControl1.Visible; }
            set { labelControl1.Visible = value; }
        }

        public bool ucLocked
        {
            get { return getLocked(); }
            set { setLocked(value); }
        }

        public bool Vailable
        {
            get { return checkVailable(); }
        }

        private bool requied = false;
        public bool ucRequied
        {
            get { return requied; }
            set { requied = value; showCaption(); }
        }

        private string caption = "";
        public string ucCaption
        {
            get { return caption; }
            set { caption = value; showCaption(); }
        }

        private string fieldName = "";
        public string ucFieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        public object ucValue
        {
            get { return getValue(); }
            set { setValue(value); }
        }
        public object ucValue2
        {
            get { return getValue2(); }
            set { setValue2(value); }
        }

        public ucBaseEdit()
        {
            InitializeComponent();
        }

        #region mothod
        private void showCaption()
        {
            labelControl1.Text = caption + (requied ? string.Format(" <b><color=red>*</color></b>") : "");
        }

        protected virtual void setValue(object value)
        {
        }
        protected virtual object getValue()
        {
            return null;
        }
        protected virtual void setValue2(object value)
        {
        }
        protected virtual object getValue2()
        {
            return null;
        }
        protected virtual void setLocked(bool value)
        {
        }
        protected virtual bool getLocked()
        {
            return false;
        }

        public virtual bool checkVailable()
        {
            if (requied)
                return checkRequied();
            return true;
        }

        public bool checkRequied()
        {
            object v = getValue();
            if (((v is string) && string.IsNullOrWhiteSpace((string)v)) ||
                v == null)
            {
                labelControl1.BackColor = LabelErrorColor;
                return false;
            }

            labelControl1.BackColor = LabelNomalColor;
            return true;
        }
        #endregion

        private void labelControl1_TextChanged(object sender, EventArgs e)
        {
            if (_ucLabelAutoWidth)
                labelControl1.Width = labelControl1.CalcBestSize().Width + labelControl1.Padding.Left + labelControl1.Padding.Right;
        }
    }
}
