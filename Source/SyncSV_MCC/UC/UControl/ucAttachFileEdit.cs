using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SyncSV.UC.UControl
{
    public partial class ucAttachFileEdit : ucBaseEdit
    {
        string oldFile = "";
        string newFile = "";

        public ucAttachFileEdit()
        {
            InitializeComponent();

            txt1.GotFocus += textEdit1_GotFocus;
            txt1.LostFocus += textEdit1_LostFocus;
        }

        void textEdit1_LostFocus(object sender, EventArgs e)
        {
            edit1.BackColor = txt1.BackColor = NomalColor;
        }
        void textEdit1_GotFocus(object sender, EventArgs e)
        {
            edit1.BackColor = txt1.BackColor = FocusColor;
        }

        protected override void setValue(object value)
        {
            if (value == DBNull.Value)
                txt1.EditValue = null;

            oldFile = value as string;
            txt1.EditValue = value;

            linkLabel1.Visible = linkLabel2.Visible = !string.IsNullOrEmpty(oldFile);
        }
        protected override object getValue()
        {
            save();
            return txt1.Text;
        }
        protected override bool getLocked()
        {
            return edit1.Properties.ReadOnly;
        }
        protected override void setLocked(bool value)
        {
            edit1.Properties.ReadOnly = value;
        }
        
        private void txt1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog od = new System.Windows.Forms.OpenFileDialog();
            if (od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt1.Text = System.IO.Path.GetFileName(od.FileName);
                newFile = od.FileName;
            }
        }

        public void reset()
        {
            oldFile = "";
            newFile = "";
        }
        private bool save()
        {
            if (newFile == "")
                return false;

            txt1.Text = Cls.globall.resourceDelAndSaveFile(oldFile, newFile, Cls.globall.resourcefolder.tepdinhkem);
            newFile = "";
            return true;
        }

        private void linkLabel2_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            if (oldFile != "")
            {
                if (Cls.GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa?"))
                {
                    Cls.globall.resourceDel(Cls.globall.resourcefolder.tepdinhkem, oldFile);
                    txt1.Text = oldFile = newFile = "";
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            if (oldFile != "")
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = Cls.globall.resourceGet(Cls.globall.resourcefolder.tepdinhkem, oldFile),
                    UseShellExecute = true
                });
            }
        }
    }
}
