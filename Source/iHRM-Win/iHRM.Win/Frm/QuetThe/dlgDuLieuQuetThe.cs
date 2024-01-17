using System.Windows.Forms;
using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Frm.LogAction;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using iHRM.Core.FileDB;
using DevExpress.XtraGrid.Views.Grid;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgDuLieuQuetThe : frmBase
    {
        private dcDatabaseDataContext _db = new dcDatabaseDataContext(Provider.ConnectionString);

        private DataTable _dt;

        public List<String> _listEmp = new List<String>();

        public String _maNV = "";

        public DateTime _ngay = new DateTime();

        public dlgDuLieuQuetThe()
        {
            InitializeComponent();
        }

        private void dlgDuLieuQuetThe_Load(object sender, EventArgs e)
        {
            _dt = new DataTable();
            if(_maNV != "")
            {
                _dt = Provider.ExecuteDataTable("p_getDulieuQuetThe_byEmpID",
                                               new SqlParameter("@ngay", _ngay.ToString("yyyy-MM-dd")),
                                               new SqlParameter("@dtEmpID", _maNV)
               );

                grd.DataSource = _dt;

                return;
            }

            if (_listEmp.Count == 1)
            {
                _dt = Provider.ExecuteDataTable("p_getDulieuQuetThe_byEmpID",
                                                new SqlParameter("@ngay", _ngay.ToString("yyyy-MM-dd")),
                                                new SqlParameter("@dtEmpID", _listEmp[0].ToString())
                );

                grd.DataSource = _dt;
            }
            else
            {
                GUIHelper.MessageBox("Chỉ cho phép chọn một Nhân Viên");
            }
        }

        private void dlgDuLieuQuetThe_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            //this.Dispose();
        }

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grd.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }
    }
}