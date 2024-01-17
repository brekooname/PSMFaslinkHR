using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Win.ExtClass;


namespace iHRM.Win.UC
{
    //[DesignTimeVisible(false)]
    //[System.ComponentModel.ToolboxItem(false)]
    public partial class ChonKyLuong : UserControl
    {
        public bool isVisibleKyLuong
        {
            get { return linkLBKyLuong.Visible; }
            set { linkLBKyLuong.Visible = value; }
        }
        //public string _linkLBKyLuong
        //{
        //    get { return linkLBKyLuong.Text; }
        //    set { linkLBKyLuong.Text = value; }
        //}
        public bool isReadOnlyTuNgay
        {
            get { return txtTuNgay.ReadOnly; }
            set { txtTuNgay.ReadOnly = value; }
        }
        public bool isReadOnlyDenNgay
        {
            get { return txtDenNgay.ReadOnly; }
            set { txtDenNgay.ReadOnly = value; }
        }
        private bool _isThang = false;
        public bool isThang
        {
            set
            {
                if (value)
                {
                    if (Frm.Common.frmLogin.langTrans == "ENGLISH")
                    {
                        linkLBKyLuong.Text = "Month";
                        labelControl2.Text = "From day:";
                        labelControl1.Text = "To day:";
                        contextMenuStrip1.Items[0].Text = "Current month";
                        contextMenuStrip1.Items[2].Text = "January";
                        contextMenuStrip1.Items[3].Text = "February";
                        contextMenuStrip1.Items[4].Text = "March";
                        contextMenuStrip1.Items[5].Text = "April";
                        contextMenuStrip1.Items[6].Text = "May";
                        contextMenuStrip1.Items[7].Text = "June";
                        contextMenuStrip1.Items[8].Text = "July";
                        contextMenuStrip1.Items[9].Text = "August";
                        contextMenuStrip1.Items[10].Text = "September";
                        contextMenuStrip1.Items[11].Text = "October";
                        contextMenuStrip1.Items[12].Text = "November";
                        contextMenuStrip1.Items[13].Text = "December";
                    }
                 
                    //linkLBKyLuong.Location = new Point(80, 0);
                    SetThang(DateTime.Today.Month);
                    _isThang = true;
                }
                else
                {
                    if (Frm.Common.frmLogin.langTrans == "ENGLISH")
                    {
                        linkLBKyLuong.Text = "Payment";
                        labelControl2.Text = "From day:";
                        labelControl1.Text = "To day:";

                        contextMenuStrip1.Items[0].Text = "Current month";
                        contextMenuStrip1.Items[2].Text = "January";
                        contextMenuStrip1.Items[3].Text = "February";
                        contextMenuStrip1.Items[4].Text = "March";
                        contextMenuStrip1.Items[5].Text = "April";
                        contextMenuStrip1.Items[6].Text = "May";
                        contextMenuStrip1.Items[7].Text = "June";
                        contextMenuStrip1.Items[8].Text = "July";
                        contextMenuStrip1.Items[9].Text = "August";
                        contextMenuStrip1.Items[10].Text = "September";
                        contextMenuStrip1.Items[11].Text = "October";
                        contextMenuStrip1.Items[12].Text = "November";
                        contextMenuStrip1.Items[13].Text = "December";
                    }
                    //linkLBKyLuong.Location = new Point(76, -1);
                    SetKyLuong(DateTime.Today.Month);
                    _isThang = false;
                }
            }
            get { return _isThang; }
        }
        public DateTime TuNgay
        {
            get
            {
                return txtTuNgay.DateTime;
            }
            set { txtTuNgay.DateTime = value; }
        }
        public DateTime Thang
        {
            get
            {
                return new DateTime(txtDenNgay.DateTime.Year, txtDenNgay.DateTime.Month, 1);
            }
        }
        public DateTime DenNgay
        {
            get
            {
                return txtDenNgay.DateTime;
            }
            set { txtDenNgay.DateTime = value; }
        }
        public DateTime DenNgay_End
        {
            get
            {
                return new DateTime(txtDenNgay.DateTime.Year, txtDenNgay.DateTime.Month, txtDenNgay.DateTime.Day, 23, 59, 59);
            }
        }
        public ChonKyLuong()
        {
            InitializeComponent();
          
        }

        protected override void OnLoad(EventArgs e)
        {
            if (_isThang)
            {
               
                SetThang(DateTime.Today.Month);              
            }
            else
            {
                SetKyLuong(DateTime.Today.Month);               
            }

            //base.OnLoad();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            contextMenuStrip1.Show(linkLBKyLuong, 0, 22);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int idx = contextMenuStrip1.Items.IndexOf(e.ClickedItem);
            if (idx > 0)
                idx -= 1;
            else
                idx = DateTime.Today.Month;
            if (_isThang)
            {

                SetThang(idx);
            }
            else
            {
                SetKyLuong(idx);
            }
        }

        void SetKyLuong(int t)
        {
            txtTuNgay.DateTime = new DateTime(DateTime.Today.Year, t, Interface_Company.ngayBatDauChuKy);
            txtDenNgay.DateTime = new DateTime(DateTime.Today.Year, t, Interface_Company.ngayBatDauChuKy).AddMonths(1).AddDays(-1);
        }
        void SetThang(int t)
        {
            txtTuNgay.DateTime = new DateTime(DateTime.Today.Year, t, 1);
            txtDenNgay.DateTime = new DateTime(DateTime.Today.Year, t, 1).AddMonths(1).AddDays(-1);
        }


      

    }
}
