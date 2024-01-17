using System.Collections.Generic;
using System.Windows.Forms;
using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Linq;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class dlgLyDoDuyet : dlgCustomBase
    {
        public string reason = string.Empty;
        bool isDuyet = true;
        private bool _isThoat = false;
        public dlgLyDoDuyet(bool _isDuyet)
        {
            InitializeComponent();
            this.isDuyet = _isDuyet;
            this.txtReason.Focus();
        }

        private void butAgree_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtReason.Text.Trim()) && !this.isDuyet)
            {
                GUIHelper.MessageError("Vui lòng nhập lý do duyệt.", "Nhập lý do duyệt");
                this.txtReason.Focus();
                return;
            }
            else
            {
                this.reason = this.txtReason.Text.TrimEnd();
            }
            this.Close();
        }

        private void butClosed_Click(object sender, EventArgs e)
        {
            this.reason = string.Empty;
            _isThoat = true;
            this.Close();          
        }

        private void txtReason_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                this.butAgree.Focus();
        }

        private void dlgLyDoDuyet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isDuyet)
            {
                if (this.reason.Trim() == string.Empty && _isThoat == false)
                {
                    GUIHelper.MessageError("Vui lòng nhập lý do duyệt.", "Nhập lý do duyệt");
                    e.Cancel = true;
                }
            }
        }
    }
}
