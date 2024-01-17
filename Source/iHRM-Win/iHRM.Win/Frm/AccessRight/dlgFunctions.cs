using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.AccessRight
{
    public partial class dlgFunctions : dlgBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        w5sysFunction f = null;

        public dlgFunctions()
        {
            InitializeComponent();

            dlgData.IdColumnName = "id";

            dlgData.CaptionColumnName = "caption";

            dlgData.FormCaption = "Chức năng";

            dlgData.CB.Add(new ControlBinding("id", txtTen, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("parentId", txtParentID, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("caption", textEdit1, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("caption_EN", textEdit2, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("order1", textEdit3, ControlBinding_DataType.Int));
            dlgData.CB.Add(new ControlBinding("asemblyPath", textEdit4, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("asemblyInherits", textEdit6, ControlBinding_DataType.String));
            dlgData.CB.Add(new ControlBinding("icon", pictureEditIcon, ControlBinding_DataType.Image));
            //dlgData.CB.Add(new ControlBinding("modal", checkEdit1, ControlBinding_DataType.Bool));
        }

        protected override void FormGetData()
        {
            base.FormGetData();

            myValue["modal"] = checkEdit1.Checked ? 1 : (checkEdit2.Checked ? 2 : (checkEdit2.Checked ? 3 : 0));

            myValue["status"] = checkEdit5.Checked ? 1 : 0;

            db.SubmitChanges();
        }
        protected override void FormSetData()
        {
            base.FormSetData();

            checkEdit1.Checked = (myValue["modal"] as int?) == 1;

            checkEdit2.Checked = (myValue["modal"] as int?) == 2;

            checkEdit3.Checked = (myValue["modal"] as int?) == 3;

            checkEdit4.Checked = (myValue["modal"] as int? ?? 0) == 0;

            checkEdit5.Checked = (myValue["status"] as long?) == 1;

            gridView1.PostEditor();

            txtTen.Focus();

            f = db.w5sysFunctions.SingleOrDefault(i => i.id == (long)myValue["id"]);

            if (f != null)

                gridControl1.DataSource = f.w5sysFunctionCustomRights;

            else

                gridControl1.DataSource = new List<object>();
        }

        private void dlgFunctions_Load(object sender, EventArgs e)
        {
            panel1.Left = textEdit3.Left;

            panel1.Top = checkEdit4.Top + checkEdit4.Height + 6;

            panel1.Enabled = this.myID != null;
        }

        #region:Grid Control
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var r = gridView1.GetRow(e.RowHandle) as w5sysFunctionCustomRight;

            if (r != null && f != null)
            {
                r.idFunction = f.id;

                r.rightValue = 1;

                while (f.w5sysFunctionCustomRights.Count(i => i.rightValue == r.rightValue) > 0)

                    r.rightValue <<= 1;
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnDelCusstomRight.PerformClick();
            }
        }

        #endregion

        #region: Button
        private void btnAddCusstomRight_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void btnDelCusstomRight_Click(object sender, EventArgs e)
        {
            if (GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa?"))

                gridView1.DeleteSelectedRows();
        }

        #endregion
    }
}
