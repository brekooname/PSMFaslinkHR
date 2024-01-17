using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;

namespace iHRM.Win.Frm.Category
{
    public partial class AllCategory_New : frmBase
    {
        Core.Business.Logic.Category.CatDefine logic = new Core.Business.Logic.Category.CatDefine();

        public AllCategory_New()
        {
            InitializeComponent();
        }

        private void AllCategory_Load(object sender, EventArgs e)
        {
            var dt = logic.GetAllCatDefine();

            grvBoDanhMuc.DataSource = (DataTable)dt;
        }

        private void btnFormLst_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var dr = e.ClickedItem.Tag as DataRow;

            Guid id = (Guid)dr["id"];

            foreach(CategoryDetail frm in this.MdiChildren)
            {
                if (frm.ID_CatCatDefine == id)
                {
                    frm.Activate();

                    return;
                }
            }

            CategoryDetail frm1 = new CategoryDetail();

            frm1.ID_CatCatDefine = id;

            frm1.TopLevel = false;

            frm1.MdiParent = this;

            frm1.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ///
        }

        private Guid id;

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.pan.Controls.Clear();

            CategoryDetail frm = new CategoryDetail();

            id = new Guid(gridView1.GetFocusedRowCellValue("id").ToString());

            frm.ID_CatCatDefine = id;

            frm.TopLevel = false;

            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            //frm.MdiParent = this;

            //FrmEmployeeInfo frmChild = new FrmEmployeeInfo();

            // Gắn vào panel
            this.pan.Controls.Add(frm);

            // Hiển thị form
            frm.Show();
        }

        private void grvBoDanhMuc_Click(object sender, EventArgs e)
        {

        }
        
    }
}
