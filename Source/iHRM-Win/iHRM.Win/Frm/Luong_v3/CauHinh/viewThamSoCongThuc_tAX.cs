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
    public partial class viewThamSoCongThuc_Tax : DevExpress.XtraEditors.XtraForm
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
        List<tbLuong_DinhNghiaThamSo_Tax> lstPara = new List<tbLuong_DinhNghiaThamSo_Tax>();

        private tbCongThucTinh_Tax myValue;
        public Guid? MyId
        {
            get { return myValue == null ? (Guid?)null : myValue.id; }
            set 
            {
                myValue = db.tbCongThucTinh_Taxes.SingleOrDefault(i => i.id == value);
                textBox1.Text = myValue.noidung;
                this.Text = "Chỉnh sửa công thức " + myValue.ten;
            }
        }

        public viewThamSoCongThuc_Tax()
        {
            InitializeComponent();
            lstPara = db.tbLuong_DinhNghiaThamSo_Taxes.ToList();
        }
        private void EvaluatorEditor_Load(object sender, EventArgs e)
        {
        }
        
        void showCT(string congthuc)
        {
            var lst2 = new List<tbLuong_DinhNghiaThamSo_Tax>();
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
    }
}
