using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace iHRM.Win.Frm.TuyenDung
{
    public partial class dlgThemUVVaoYCTD : frmBase
    {
        dcDatabaseDataContext db;

        public List<DataRow> MyValue
        {
            get {
                return grv.GetSelectedRows().Select(i => grv.GetDataRow(i) as DataRow).ToList(); }
        }

        public dlgThemUVVaoYCTD()
        {
            InitializeComponent();

            btnFind_Click(null, null);
        }

        private void frm_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(Provider.ConnectionString);

            var lst = Provider.ExecuteDataTableReader("p_tblUngVien_GetAllByTrangThaiAddToYCTD",

                        new SqlParameter("strSearch",txtSearchText.Text),

                        new SqlParameter("trangThai", "0")
                    );
            //db.tblUngViens.Where(p => (p.trangThai == null || p.trangThai == 0) 
            //                        && ((txtSearchText.Text != "" && (p.EmployeeName.Contains(txtSearchText.Text) || p.EmployeeID.Contains(txtSearchText.Text))) || txtSearchText.Text == ""));
            
            grd.DataSource = lst;
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        
    }
}
