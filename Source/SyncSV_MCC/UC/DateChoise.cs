using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV.UC
{
    public partial class DateChoise : UserControl
    {
        public DateChoise()
        {
            InitializeComponent();

            comboBoxEdit1.SelectedIndex = 0;
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hôm nay
            //Tuần này
            //Theo tháng
            //Theo quý
            //Tùy chọn

            labelControl1.Visible = labelControl2.Visible =
            comboBoxEdit2.Visible = dateEdit1.Visible = dateEdit2.Visible = false;
            switch (comboBoxEdit1.SelectedIndex)
            {
                case 0:
                    labelControl1.Visible = true; labelControl1.Text = "Ngày:";
                    dateEdit1.Visible = true; dateEdit1.EditValue = DateTime.Now;
                    dateEdit1.Properties.DisplayFormat.FormatString = dateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
                    break;
                case 1:
                    labelControl1.Visible = true; labelControl1.Text = "Từ ngày:";
                    dateEdit1.Visible = true; dateEdit1.EditValue = DateTime.Now.AddDays(-1 * (int)DateTime.Now.DayOfWeek + 1);
                    dateEdit1.Properties.DisplayFormat.FormatString = dateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
                    labelControl2.Visible = true; labelControl2.Text = "Đến ngày:";
                    dateEdit2.Visible = true; dateEdit2.EditValue = DateTime.Now.AddDays(-1 * (int)DateTime.Now.DayOfWeek + 8);
                    dateEdit2.Properties.DisplayFormat.FormatString = dateEdit2.Properties.EditFormat.FormatString = "dd/MM/yyyy";
                    break;
                case 2:
                    labelControl1.Visible = true; labelControl1.Text = "Tháng:";
                    comboBoxEdit2.Visible = true; 
                    comboBoxEdit2.Properties.Items.Clear();
                    comboBoxEdit2.Properties.Items.AddRange("1,2,3,4,5,6,7,8,9,10,11,12".Split(','));
                    comboBoxEdit2.EditValue = DateTime.Now.Month.ToString();
                    labelControl2.Visible = true; labelControl2.Text = "Năm:";
                    dateEdit2.Visible = true; dateEdit2.EditValue = DateTime.Now;
                    dateEdit2.Properties.DisplayFormat.FormatString = dateEdit2.Properties.EditFormat.FormatString = "yyyy";
                    break;
                case 3:
                    labelControl1.Visible = true; labelControl1.Text = "Quý:";
                    comboBoxEdit2.Visible = true;
                    comboBoxEdit2.Properties.Items.Clear();
                    comboBoxEdit2.Properties.Items.AddRange("1,2,3,4".Split(','));
                    comboBoxEdit2.EditValue = (int)(DateTime.Now.Month / 4) + 1;
                    labelControl2.Visible = true; labelControl2.Text = "Năm:";
                    dateEdit2.Visible = true; dateEdit2.EditValue = DateTime.Now;
                    dateEdit2.Properties.DisplayFormat.FormatString = dateEdit2.Properties.EditFormat.FormatString = "yyyy";
                    break;
                case 4:
                    labelControl1.Visible = true; labelControl1.Text = "Từ ngày:";
                    dateEdit1.Visible = true; dateEdit1.EditValue = DateTime.Now;
                    dateEdit1.Properties.DisplayFormat.FormatString = dateEdit1.Properties.EditFormat.FormatString = "dd/MM/yyyy";
                    labelControl2.Visible = true; labelControl2.Text = "Đến ngày:";
                    dateEdit2.Visible = true; dateEdit2.EditValue = DateTime.Now.AddDays(1);
                    dateEdit2.Properties.DisplayFormat.FormatString = dateEdit2.Properties.EditFormat.FormatString = "dd/MM/yyyy";
                    break;
            }
        }

        public DateTime ucValue1
        {
            get
            {
                switch (comboBoxEdit1.SelectedIndex)
                {
                    case 2:
                        return new DateTime(dateEdit2.DateTime.Year, Convert.ToInt32(comboBoxEdit2.EditValue), 1);
                    case 3:
                        return new DateTime(dateEdit2.DateTime.Year, Convert.ToInt32(comboBoxEdit2.EditValue)*3-2, 1);
                }
                return dateEdit1.DateTime.Date;
            }
        }
        public DateTime ucValue2
        {
            get
            {
                switch (comboBoxEdit1.SelectedIndex)
                {
                    case 0:
                        return dateEdit1.DateTime.Date.AddDays(1);
                    case 2:
                        return new DateTime(dateEdit2.DateTime.Year, Convert.ToInt32(comboBoxEdit2.EditValue) + 1, 1);
                    case 3:
                        return new DateTime(dateEdit2.DateTime.Year, Convert.ToInt32(comboBoxEdit2.EditValue) * 3 + 1, 1);
                }
                return dateEdit2.DateTime.Date;
            }
        }
    }
}
