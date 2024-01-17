using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SyncSV.UC.UControl
{
    public partial class ucEnumEdit : ucBaseEdit
    {
        private DataTable dt = new DataTable();

        public bool ucViewIdColumn
        {
            get { return edit1.Properties.Columns["id"].Visible; }
            set { edit1.Properties.Columns["id"].Visible = value; }
        }

        public ucEnumEdit()
        {
            InitializeComponent();

            edit1.GotFocus += textEdit1_GotFocus;
            edit1.LostFocus += textEdit1_LostFocus;

            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("text", typeof(string));
            edit1.Properties.DataSource = dt;
        }

        public void setEnum(Type enumType)
        {
            dt.Rows.Clear();
            foreach (var e in Enum.GetValues(enumType))
            {
                DataRow dr = dt.NewRow();
                dr["id"] = (int)e;
                dr["text"] = e.ToString();
                dt.Rows.Add(dr);
            }
        }
        public void setEnum<enumType>(IDictionary<enumType, string> dic)
        {
            dt.Rows.Clear();
            foreach (var e in dic)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = Convert.ToInt32(e.Key);
                dr["text"] = e.Value;
                dt.Rows.Add(dr);
            }
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
            edit1.EditValue = (int?)(value == DBNull.Value ? null : value);
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
