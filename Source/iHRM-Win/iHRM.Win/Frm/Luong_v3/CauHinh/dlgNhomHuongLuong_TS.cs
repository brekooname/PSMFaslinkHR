using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class dlgNhomHuongLuong_TS : frmBase
    {
        dcLuongv3DataContext db;
        List<tbLuong_DinhNghiaThamSo> LstData;

        public List<tbLuong_DinhNghiaThamSo> MyValue
        {
            get { return grv.GetSelectedRows().Select(i => grv.GetRow(i) as tbLuong_DinhNghiaThamSo).ToList(); }
            set
            {
                grv.ClearSelection();
                if (value != null && value.Count > 0)
                {
                    for (int i = 0; i < grv.DataRowCount; i++)
                    {
                        var id = (grv.GetRow(i) as tbLuong_DinhNghiaThamSo).id;
                        if (value.Count(j => j.id == id) > 0)
                            grv.SelectRow(i);
                    }
                }
            }
        }

        public dlgNhomHuongLuong_TS()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            btnFind_Click(null, null);
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s,ev) => 
            {
                LstData = db.tbLuong_DinhNghiaThamSos.ToList();
                dw_it.bw.ReportProgress(1, LstData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = new BindingList<tbLuong_DinhNghiaThamSo>(LstData);
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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
