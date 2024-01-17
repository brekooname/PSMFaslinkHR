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
    public partial class frmCongThucTinh : DevExpress.XtraEditors.XtraForm
    {
        public class lstItem
        {
            public string nhom { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public string Usage { get; set; }
            public string Description { get; set; }
        }


        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
        private tbCongThucTinh myValue;
        public Guid? MyId
        {
            get { return myValue == null ? (Guid?)null : myValue.id; }
            set 
            {
                myValue = db.tbCongThucTinhs.SingleOrDefault(i => i.id == value);
                textBox1.Text = myValue.noidung;
                this.Text = "Chỉnh sửa công thức " + myValue.ten;
            }
        }

        private static List<lstItem> lstFunc;
        private static List<lstItem> lstOper;
        public static List<lstItem> lstPara;

        public frmCongThucTinh()
        {
            InitializeComponent();

            if (lstFunc == null)
                lstFunc = LoadXml(Core.Properties.Resources.MathEvaluator_lstFunction);
            if (lstOper == null)
                lstOper = LoadXml(Core.Properties.Resources.MathEvaluator_lstOperator);
            if (lstPara == null)
                lstPara = LoadXml(Core.Properties.Resources.Luong_Parameter);
        }

        private void EvaluatorEditor_Load(object sender, EventArgs e)
        {
            //listBoxControl1.Items.Clear();
            //listBoxControl1.Items.AddRange(lstFunc.Select(i => i.Name).ToArray());
            //listBoxControl2.Items.Clear();
            //listBoxControl2.Items.AddRange(lstOper.Select(i => i.Name).ToArray());
            grd.DataSource = new BindingList<lstItem>(lstPara);
        }

        public void RefeshLstPara()
        {
            grd.RefreshDataSource();
        }

        List<lstItem> LoadXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            var lst = new List<lstItem>();
            foreach (XmlNode n in doc.SelectNodes("func/item"))
            {
                lst.Add(new lstItem()
                {
                    Name = n.Attributes["Name"].Value,
                    Description = n.Attributes["Description"].Value,
                    Usage = n.Attributes["Usage"].Value
                });
            }

            return lst;
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string congthuc = (!string.IsNullOrWhiteSpace(textBox1.SelectedText) ? textBox1.SelectedText : textBox1.Text);
                var cnn = Provider.CreateConnection();
                var cmd = cnn.CreateCommand();
                foreach (var it in lstPara)
                {
                    if (congthuc.IndexOf("{" + it.Name + "}") >= 0)
                    {
                        congthuc = congthuc.Replace("{" + it.Name + "}", "@" + it.Name);
                        if (DungChung.Ham.IsNumber(it.Value))
                            cmd.Parameters.AddWithValue(it.Name, Convert.ToDouble(it.Value));
                        else
                            cmd.Parameters.AddWithValue(it.Name, it.Value);
                    }
                }
                cmd.CommandText = "use master; SELECT " + congthuc;
                cnn.Open();
                var obj = cmd.ExecuteScalar();
                cnn.Close();

                labelControl1.Text = obj == null ? "" : obj.ToString();
            }
            catch (Exception ex)
            {
                labelControl1.Text = ex.Message;
            }
        }

        void InsertText(string txt)
        {
            textBox1.Select(textBox1.SelectionStart, 0);
            textBox1.SelectedText = txt;
            textBox1.Focus();
        }
        
        private void grv_DoubleClick(object sender, EventArgs e)
        {
            var n = grv.GetFocusedRow() as lstItem;
            if (n == null)
                return;

            InsertText("{" + n.Name + "}");
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            myValue.noidung = textBox1.Text;
            db.SubmitChanges();
            GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);

            var log = Log2.CreateLog(Log2.Log2Action.sua, "Sửa công thức lương " + myValue.id, "tbCongThucTinh");
            log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
            {
                id = Guid.NewGuid(),
                log_id = log.id,
                target1 = "id",
                value1 = myValue.id.ToString(),
            });
            Log2.PushLog(log);
        }
        
        public static Guid newCT(string ten = "")
        {
            var ct = new tbCongThucTinh();
            ct.id = Guid.NewGuid();
            ct.ten = ten;
            ct.noidung = "";

            dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            db.tbCongThucTinhs.InsertOnSubmit(ct);
            db.SubmitChanges();

            return ct.id;
        }
        
        void showCT(string congthuc)
        {
            foreach (var it in lstPara)
            {
                congthuc = congthuc.Replace("{" + it.Name + "}", " <color=red>{" + it.Description + "}</color>");
            }
            labelControl1.Text = congthuc;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            showCT(textBox1.Text);
        }
    }
}
