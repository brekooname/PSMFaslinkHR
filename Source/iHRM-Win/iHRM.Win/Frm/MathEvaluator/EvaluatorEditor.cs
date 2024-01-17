using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace iHRM.Win.Frm.MathEvaluator
{
    public partial class EvaluatorEditor : DevExpress.XtraEditors.XtraForm
    {
        public class lstItem
        {
            public string Name { get; set; }
            public double Value { get; set; }
            public string Usage { get; set; }
            public string Description { get; set; }
        }

        public string CalcText
        {
            get { return richTextBox1.Text; }
            set { richTextBox1.Text = value; }
        }
        
        public static List<lstItem> lstPara;

        public EvaluatorEditor()
        {
            InitializeComponent();
            
            if (lstPara == null)
                lstPara = LoadXml(Core.Properties.Resources.Luong_Parameter);
        }

        private void EvaluatorEditor_Load(object sender, EventArgs e)
        {
            grd.DataSource = lstPara;
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
                string congthuc = (!string.IsNullOrWhiteSpace(richTextBox1.SelectedText) ? richTextBox1.SelectedText : richTextBox1.Text);
                var cnn = Provider.CreateConnection();
                var cmd = cnn.CreateCommand();
                foreach (var it in lstPara)
                {
                    if (congthuc.IndexOf("{" + it.Name + "}") >= 0)
                    {
                        congthuc.Replace("{" + it.Name + "}", "@" + it.Name);
                        cmd.Parameters.AddWithValue(it.Name, it.Value);
                    }
                }
                cmd.CommandText = "SELECT " + congthuc;
                var obj = cmd.ExecuteScalar();

                lblInfo.Text = obj == null ? "" : obj.ToString();
            }
            catch(Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        void InsertText(string txt)
        {
            richTextBox1.Select(richTextBox1.SelectionStart, 0);
            richTextBox1.SelectedText = txt;
            richTextBox1.Focus();
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
