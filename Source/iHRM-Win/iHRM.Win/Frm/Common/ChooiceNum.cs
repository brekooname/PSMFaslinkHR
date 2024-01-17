using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Common
{
    public partial class ChooiceNum : DevExpress.XtraEditors.XtraForm
    {
        public object SelectedRow { get; private set; }
        public int SelectedIndex { get; private set; }

        public string Caption
        {
            get { return gridView1.ViewCaption; }
            set { gridView1.ViewCaption = value; }
        }

        public ChooiceNum()
        {
            InitializeComponent();
        }
        private void ChooiceNum_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(object data, string captionCol = "caption")
        {
            gridColumn2.FieldName = captionCol;
            gridControl1.DataSource = data;
            SelectedRow = null;
            SelectedIndex = -1;
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    gridView1_DoubleClick(null, null);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.D1: Select1(0); break;
                case Keys.D2: Select1(1); break;
                case Keys.D3: Select1(2); break;
                case Keys.D4: Select1(3); break;
                case Keys.D5: Select1(4); break;
                case Keys.D6: Select1(5); break;
                case Keys.D7: Select1(6); break;
                case Keys.D8: Select1(7); break;
                case Keys.D9: Select1(8); break;
            }
        }
        void Select1(int idx)
        {
            SelectedRow = gridView1.GetRow(idx);
            if (SelectedRow != null)
            {
                SelectedIndex = idx;
                this.DialogResult = DialogResult.OK;
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SelectedRow = gridView1.GetFocusedRow();
            if (SelectedRow != null)
            {
                SelectedIndex = gridView1.FocusedRowHandle;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == gridColumn1)
                e.Value = e.ListSourceRowIndex + 1;
        }
    }
}
