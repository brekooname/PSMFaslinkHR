using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class viewThamSoCongThuc_Fake : DevExpress.XtraEditors.XtraForm
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
        List<tbLuong_DinhNghiaThamSo_Fake> lstPara = new List<tbLuong_DinhNghiaThamSo_Fake>();

        private tbCongThucTinh_Fake myValue;
        public Guid? MyId
        {
            get { return myValue == null ? (Guid?)null : myValue.id; }
            set 
            {
                myValue = db.tbCongThucTinh_Fakes.SingleOrDefault(i => i.id == value);
                textBox1.Text = myValue.noidung;
                this.Text = "Chỉnh sửa công thức " + myValue.ten;
            }
        }

        public viewThamSoCongThuc_Fake()
        {
            InitializeComponent();
            lstPara = db.tbLuong_DinhNghiaThamSo_Fakes.ToList();
        }
        private void EvaluatorEditor_Load(object sender, EventArgs e)
        {
        }
        
        void showCT(string congthuc)
        {
            var lst2 = new List<tbLuong_DinhNghiaThamSo_Fake>();
            var thiz = lstPara.FirstOrDefault(i => i.congthuc_id == MyId);
            if (thiz != null)
                lst2.Add(thiz);

            foreach (var it in lstPara)
            {
                if (congthuc.IndexOf("{" + it.ma + "}") > -1)
                {
                    lst2.Add(it);
                    congthuc = congthuc.Replace("{" + it.ma + "}", " <color=red>{" + it.ten + "}</color>");
                }
            }
            grd.DataSource = lst2;
            labelControl1.Text = congthuc;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            showCT(textBox1.Text);
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
