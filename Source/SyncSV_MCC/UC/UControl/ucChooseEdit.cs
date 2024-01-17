using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV.UC.UControl
{
    public partial class ucChooseEdit : ucBaseEdit
    {
        public event EventHandler OnUcValueChanged;

        [AttributeProvider(typeof(IListSource))]
        public object ucDataSource
        {
            get
            {
                return edit1.Properties.DataSource;
            }
            set
            {
                edit1.Properties.DataSource = value;
            }
        }

        public string ucDisplayMember
        {
            get { return edit1.Properties.DisplayMember; }
            set { edit1.Properties.DisplayMember = value; }
        }

        public string ucValueMember
        {
            get { return edit1.Properties.ValueMember; }
            set { edit1.Properties.ValueMember = value; }
        }
        public DevExpress.XtraEditors.Controls.LookUpColumnInfo[] ucColumns { get; set; }

        /// <summary>
        /// có hiện cột id hay hok ?
        /// </summary>
        public bool ucIdVisible
        {
            get { return text1.Visible; }
            set { text1.Visible = value; }
        }

        public ucChooseEdit()
        {
            InitializeComponent();

            edit1.GotFocus += textEdit1_GotFocus;
            edit1.LostFocus += textEdit1_LostFocus;
            text1.GotFocus += textEdit1_GotFocus;
            text1.LostFocus += textEdit1_LostFocus;
        }
        private void ucChooseEdit_Load(object sender, EventArgs e)
        {
            searchLookUpEdit1View.Columns.Clear();
            if (ucColumns != null)
                searchLookUpEdit1View.Columns.AddRange(ucColumns.Select(i =>
                    new DevExpress.XtraGrid.Columns.GridColumn(){ 
                        Caption = i.Caption,
                        FieldName = i.FieldName,
                        Visible = true
                    }
                ).ToArray());
        }

        void textEdit1_LostFocus(object sender, EventArgs e)
        {
            if (sender == text1)
            {
                long l;
                if (long.TryParse(text1.Text, out l))
                    edit1.EditValue = l;
                else
                    text1.EditValue = edit1.EditValue;
            }
            edit1.BackColor = text1.BackColor = NomalColor;
        }
        void textEdit1_GotFocus(object sender, EventArgs e)
        {
            edit1.BackColor = text1.BackColor = FocusColor;
        }

        protected override void setValue(object value)
        {
            edit1.EditValue = text1.EditValue = value;
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
            edit1.Properties.ReadOnly = text1.Properties.ReadOnly = value;
        }

        private void text1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textEdit1_LostFocus(sender, null);
            else if (e.KeyCode == Keys.Escape)
                text1.EditValue = edit1.EditValue;
        }

        private void edit1_EditValueChanged(object sender, EventArgs e)
        {
            text1.EditValue = edit1.EditValue;
            if (OnUcValueChanged != null)
                OnUcValueChanged(this, e);
        }

    }
}
