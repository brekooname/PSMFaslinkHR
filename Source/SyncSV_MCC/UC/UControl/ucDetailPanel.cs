using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV.UC.UControl
{
    public partial class ucDetailPanel : DevExpress.XtraEditors.PanelControl
    {
        private ucTitle _myTitle = null;
        /// <summary>
        /// chỉ định control hiện thị title của panel
        /// </summary>
        public ucTitle ucMyTitle
        {
            get { return _myTitle; }
            set { _myTitle = value; }
        }

        private ucButtonPanel _myButtonPanel = null;
        /// <summary>
        /// chỉ định thanh điều khiển attackmode của panel
        /// </summary>
        public ucButtonPanel ucMyButtonPanel
        {
            get { return _myButtonPanel; }
            set
            {
                _myButtonPanel = value;
                if (_myButtonPanel != null)
                {
                    _myButtonPanel.OnNew += _myButtonPanel_OnNew;
                    _myButtonPanel.OnEdit += _myButtonPanel_OnEdit;
                    _myButtonPanel.OnChosse += _myButtonPanel_OnChosse;
                }
            }
        }

        void _myButtonPanel_OnChosse(object sender, EventArgs e)
        {
            ucAttackMode = Cls.enums.eFormAttackMode.View;
        }
        void _myButtonPanel_OnEdit(object sender, EventArgs e)
        {
            ucAttackMode = Cls.enums.eFormAttackMode.Edit;
        }
        void _myButtonPanel_OnNew(object sender, EventArgs e)
        {
            ucAttackMode = Cls.enums.eFormAttackMode.Add;
        }

        private UC.UControl.ucBaseEdit _myFocusFirstChild = null;
        /// <summary>
        /// chỉ định control sẽ focus đầu tiên khi đổi chế độ sửa/thêm
        /// </summary>
        public UC.UControl.ucBaseEdit ucFocusFirstChild
        {
            get { return _myFocusFirstChild; }
            set
            {
                _myFocusFirstChild = value;
            }
        }

        private Cls.enums.eFormAttackMode attackMode = Cls.enums.eFormAttackMode.None;
        /// <summary>
        /// chỉ định panel đang ở chế độ sửa hay xóa
        /// </summary>
        public Cls.enums.eFormAttackMode ucAttackMode
        {
            get { return attackMode; }
            set
            {
                attackMode = value;
                if (_myTitle != null)
                    _myTitle.ShowTitle(attackMode);
                switch (attackMode)
                {
                    case Cls.enums.eFormAttackMode.View:
                        this.ucLocked = true;
                        break;
                    case Cls.enums.eFormAttackMode.Add:
                        this.ucClearData();
                        this.ucLocked = false;
                        FocusFirstChild();
                        break;
                    case Cls.enums.eFormAttackMode.Edit:
                        this.ucLocked = false;
                        FocusFirstChild();
                        break;
                }

                if (_myButtonPanel != null)
                    _myButtonPanel.showButtonSave = (attackMode == Cls.enums.eFormAttackMode.Add || attackMode == Cls.enums.eFormAttackMode.Edit);
            }
        }

        /// <summary>
        /// focus vào txt đầu tiên khi sửa hoặc xóa
        /// </summary>
        private void FocusFirstChild()
        {
            if (_myFocusFirstChild != null)
                _myFocusFirstChild.Focus();
        }

        private bool _ucLocked = false;
        public bool ucLocked
        {
            get { return _ucLocked; }
            set { _ucLocked = value; setLocked(_ucLocked); }
        }

        public ucDetailPanel()
        {
            InitializeComponent();
        }

        public ucDetailPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region method
        public void ucClearData()
        {
            foreach (Control c in this.Controls)
            {
                if (c is UC.UControl.ucBaseEdit)
                {
                    UC.UControl.ucBaseEdit edit = c as UC.UControl.ucBaseEdit; 
                    edit.ucValue = null;
                }
            }
        }

        private void setLocked(bool value)
        {
            foreach (Control c in this.Controls)
            {
                if (c is UC.UControl.ucBaseEdit)
                {
                    UC.UControl.ucBaseEdit edit = c as UC.UControl.ucBaseEdit; 
                    edit.ucLocked = value;
                }
            }
        }

        public bool CheckVailable()
        {
            bool isVailable = true;
            foreach (Control c in this.Controls)
            {
                if (c is UC.UControl.ucBaseEdit)
                    isVailable &= ((UC.UControl.ucBaseEdit)c).Vailable;
            }

            return isVailable;
        }
        
        public void ucBindDataRow(DataRow dr)
        {
            ucClearData();
            if (dr == null)
                return;

            foreach (Control c in this.Controls)
            {
                if (c is UC.UControl.ucBaseEdit)
                {
                    UC.UControl.ucBaseEdit edit = c as UC.UControl.ucBaseEdit;
                    if (!string.IsNullOrWhiteSpace(edit.ucFieldName) && dr.Table.Columns.Contains(edit.ucFieldName))
                        edit.ucValue = dr[edit.ucFieldName];
                }
            }

            _myButtonPanel_OnChosse(null, null);
        }
        public void ucGetDataRow(DataRow dr)
        {
            foreach (Control c in this.Controls)
            {
                if (c is UC.UControl.ucBaseEdit)
                {
                    UC.UControl.ucBaseEdit edit = c as UC.UControl.ucBaseEdit;
                    if (!string.IsNullOrWhiteSpace(edit.ucFieldName) && dr.Table.Columns.Contains(edit.ucFieldName))
                        dr[edit.ucFieldName] = edit.ucValue;
                }
            }
        }

        public void ucBindData(object obj)
        {
            ucClearData();
            if (obj == null)
                return;

            foreach (Control c in this.Controls)
            {
                if (c is UC.UControl.ucBaseEdit)
                {
                    UC.UControl.ucBaseEdit edit = c as UC.UControl.ucBaseEdit;
                    if (!string.IsNullOrWhiteSpace(edit.ucFieldName))
                        edit.ucValue = SyncSV.Cls.PropertyExtension1.GetPropValue(obj, edit.ucFieldName);
                }
            }

            _myButtonPanel_OnChosse(null, null);
        }
        public void ucGetData(object obj)
        {
            foreach (Control c in this.Controls)
            {
                if (c is UC.UControl.ucBaseEdit)
                {
                    UC.UControl.ucBaseEdit edit = c as UC.UControl.ucBaseEdit;
                    if (!string.IsNullOrWhiteSpace(edit.ucFieldName))
                        SyncSV.Cls.PropertyExtension1.SetPropValue(obj, edit.ucFieldName, edit.ucValue);
                }
            }
        }

        #endregion
    }
}
