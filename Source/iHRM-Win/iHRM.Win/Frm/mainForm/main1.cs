﻿using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace iHRM.Win.Frm.mainForm
{
    public partial class main1 : mainBase
    {
        Cls.MoreFormByControl mf;
        Frm.Common.frmProgress frmPrg;

        public main1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            mf = new MoreFormByControl(this, panel1, labelControl1);
            frmPrg = new Frm.Common.frmProgress();
            frmPrg.Owner = this;
        }
        private void main_Load(object sender, EventArgs e)
        {
            #region tải menu async
            var actionInitMenu = new DoWork_Item();
            actionInitMenu.Caption = "Đang tải phân quyền...";
            actionInitMenu.OnDoing = (bg) =>
            {
                //load top menu                
                var dt = LoginHelper.user.w5sysRole.w5sysRules
                    .Where(i => i.w5sysFunction.parentId == const1.functionRootTreeID)
                    .OrderBy(i => i.w5sysFunction.order1).ToList();
                bg.ReportProgress(1, dt);
            };
            actionInitMenu.OnReport = (idx, obj) =>
            {
                if (idx == 1)
                    initTopMenu(obj as List<w5sysRule>);
            };
            DoWork_Reg(actionInitMenu);
            #endregion
        }


        #region 4 mennu event
        void initTopMenu(List<w5sysRule> dt)
        {
            menuTop.Items.AddRange(dt.Select(i =>
                new DevExpress.XtraBars.Navigation.NavigationBarItem()
                {
                    Text = Language.CurrentLng == eLanguage.VN ? i.w5sysFunction.caption : i.w5sysFunction.caption_EN,
                    Tag = i
                }
            ).ToArray());

            btnUser.Text = LoginHelper.user.caption;
            btnUser.Left = this.Width - btnUser.Width - 6;

            if (Language.CurrentLng == eLanguage.VN)
            {
                toolStripStatusLabel3.Image = Properties.Resources.vn;
                toolStripStatusLabel3.Text = "Tiếng việt";
                lblDept.Text = DbHelper.DrGetString(LoginHelper.Dept, "caption");
            }
            else
            {
                toolStripStatusLabel3.Image = Properties.Resources.en;
                toolStripStatusLabel3.Text = "English";
                lblDept.Text = DbHelper.DrGetString(LoginHelper.Dept, "caption_EN");
            }

            //idLogo.Src = DbHelper.DrGetString(LoginHelper.Dept, "logo");
            //if (string.IsNullOrWhiteSpace(idLogo.Src))
            //    idLogo.Src = "/sHRM/Styles/img/Logo_129.png";
            toolStripStatusLabel5.Text = Environment.MachineName;
            toolStripStatusLabel6.Text = DbHelper.DrGetString(LoginHelper.Dept, "code");

            //treeList1.DataSource = LoginHelper.user.w5sysRole.w5sysRules.Select(i => i.w5sysFunction)
            //    .OrderBy(i => i.order1).ToList();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm.Common.frmTTTK frm = new Frm.Common.frmTTTK();
            frm.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cm_User.Show(btnUser, 0, btnUser.Height);
        }

        private void menuTop_ItemClick(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            w5sysRule ru = e.Item.Tag as w5sysRule;
            treeList1.DataSource = AddLeftMenu(ru.functionID);
        }
        List<w5sysFunction> AddLeftMenu(long pID)
        {
            var lst = LoginHelper.user.w5sysRole.w5sysRules.Select(i => i.w5sysFunction)
                .Where(i => i.parentId == pID)
                .OrderBy(i => i.order1).ToList();

            List<w5sysFunction> lst2 = new List<w5sysFunction>();
            foreach (var it in lst)
                lst2.AddRange(AddLeftMenu(it.id));

            lst.AddRange(lst2);

            foreach(var it in lst)
            {
                if (!string.IsNullOrWhiteSpace(it.asemblyInherits) && !it.caption.StartsWith("*"))
                    it.caption = "*" + it.caption;
            }

            return lst;
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode == null)
                return;

            var fn = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as w5sysFunction;
            //treeList1.FocusedNode.Selected = true;
            ShowForm(fn.asemblyInherits);
        }
        
        #endregion

        #region doWork
        
        public override void DoWork_Reg(DoWork_Item item)
        {
            DoWork_queueItem.Enqueue(item);
            if (!bgw_doWork.IsBusy)
            {
                bgw_doWork.RunWorkerAsync();
                toolStripStatusLabel8.Visible = toolStripProgressBar1.Visible = true;
            }
        }

        private void bgw_doWork_DoWork(object sender, DoWorkEventArgs e)
        {
            while (DoWork_queueItem.Count > 0)
            {
                DoWork_doingItem = DoWork_queueItem.Dequeue();
                bgw_doWork.ReportProgress(-1, DoWork_doingItem.Caption);
                if (DoWork_doingItem.OnDoing != null)
                    DoWork_doingItem.OnDoing(bgw_doWork);
            }
        }
        private void bgw_doWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                toolStripStatusLabel1.Text = e.UserState.ToString();
            }
            else
            {
                if (DoWork_doingItem != null && DoWork_doingItem.OnReport != null)
                    DoWork_doingItem.OnReport(e.ProgressPercentage, e.UserState);
            }
        }
        private void bgw_doWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel8.Visible = toolStripProgressBar1.Visible = false;
            toolStripStatusLabel1.Text = "Ready";
        }

        private void toolStripStatusLabel8_Click(object sender, EventArgs e)
        {
            bgw_doWork.CancelAsync();
        }

        #endregion

        #region do progress
        
        public override void DoProgress_Reg(DoProgress_Item item)
        {
            DoProgress_queueItem.Enqueue(item);
            if (!bgw_doProgress.IsBusy)
            {
                bgw_doProgress.RunWorkerAsync();
                toolStripProgressBar2.Visible = true;
            }
        }

        private void bgw_doProgress_DoWork(object sender, DoWorkEventArgs e)
        {
            while (DoProgress_queueItem.Count > 0)
            {
                DoProgress_doingItem = DoProgress_queueItem.Dequeue();
                bgw_doProgress.ReportProgress(-1);

                DoProgress_doingItem.SetProgressValue = (v) => { bgw_doProgress.ReportProgress(-2, v); };
                DoProgress_doingItem.SetProgressText = (v) => { bgw_doProgress.ReportProgress(-3, v); };
                DoProgress_doingItem.SetProgressStatus = (v) => { bgw_doProgress.ReportProgress(-4, v); };
                DoProgress_doingItem.OutProgressMessage = (v) => { bgw_doProgress.ReportProgress(-5, v); };

                if (DoProgress_doingItem.OnDoing != null)
                    DoProgress_doingItem.OnDoing(bgw_doProgress);
            }
        }
        private void bgw_doProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case -1:
                    toolStripStatusLabel1.Text = DoProgress_doingItem.Caption;
                    frmPrg.Form_Title = DoProgress_doingItem.Caption;
                    frmPrg.Form_Description = DoProgress_doingItem.Desciption;
                    frmPrg.Show(); frmPrg.BringToFront();
                    break;
                case -2:
                    frmPrg.SetProgressValue((int)e.UserState);
                    break;
                case -3:
                    frmPrg.SetProgressText((string)e.UserState);
                    break;
                case -4:
                    frmPrg.SetProgressStatus((DoProgress_status)e.UserState);
                    break;
                case -5:
                    frmPrg.OutProgressMessage((string)e.UserState);
                    break;
                default:
                    if (DoProgress_doingItem != null && DoProgress_doingItem.OnReport != null)
                        DoProgress_doingItem.OnReport(e.ProgressPercentage, e.UserState);
                    break;
            }
        }
        private void bgw_doProgress_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //frmPrg.Hide();
            toolStripProgressBar2.Visible = false;
            toolStripStatusLabel1.Text = "Ready";
        }
        #endregion

    }
}
