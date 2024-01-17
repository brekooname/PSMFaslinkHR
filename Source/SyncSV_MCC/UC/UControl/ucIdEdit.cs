using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SyncSV.UC.UControl
{
    public partial class ucIdEdit : ucBaseEdit
    {
        private string tableCheck = "";
        public string ucTableCheck
        {
            get { return tableCheck; }
            set { tableCheck = value; }
        }

        private string oldValue = "";
        //public string ucOldValue
        //{
        //    get { return oldValue; }
        //    set { oldValue = value; }
        //}

        private bool daKiemTraRoi = true;

        public ucIdEdit()
        {
            InitializeComponent();
            ucRequied = true;

            edit1.GotFocus += textEdit1_GotFocus;
            edit1.LostFocus += textEdit1_LostFocus;

            if (string.IsNullOrWhiteSpace(tableCheck))
            {
                edit1.Text = "tableCheck is not set";
            }
        }

        void textEdit1_LostFocus(object sender, EventArgs e)
        {
            if (checkAvailableId())
                edit1.BackColor = LabelValidColor;
            else
                edit1.BackColor = LabelErrorColor;
        }
        void textEdit1_GotFocus(object sender, EventArgs e)
        {
            edit1.BackColor = FocusColor;
        }

        protected override void setValue(object value)
        {
            oldValue = edit1.Text = (string)(value == DBNull.Value ? null : value);
            daKiemTraRoi = true;
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

        public override bool checkVailable()
        {
            if (!checkAvailableId())
                return false;

            return base.checkVailable();
        }

        private bool checkAvailableId()
        {
            if (daKiemTraRoi)
                return true;

            daKiemTraRoi = Business.AllLogic.checkID(tableCheck, ucFieldName, edit1.Text, oldValue);
            return daKiemTraRoi;
        }

        private void textEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.OK)
            {
                if (checkAvailableId())
                    Cls.GUIHelper.MessageBox("Id vailable");
            }
        }

        private void edit1_TextChanged(object sender, EventArgs e)
        {
            daKiemTraRoi = false;
        }

        public void AutoGenId(string prefix = "", bool includeDate = true)
        {
            if (includeDate)
                prefix += DateTime.Now.ToString("ddMMyy");
            try
            {
                string mid = Business.AllLogic.getMaxID(tableCheck, ucFieldName, prefix);
                if (string.IsNullOrWhiteSpace(mid))
                    mid = "0";
                else
                    mid = mid.Substring(prefix.Length + 1);
                ucValue = prefix + (Convert.ToInt32(mid) + 1).ToString("0000");
            }
            catch { }
        }
    }
}
