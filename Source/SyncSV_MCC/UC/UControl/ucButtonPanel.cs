using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV.UC.UControl
{
    public partial class ucButtonPanel : UserControl
    {
        #region property

        private bool _enableHotkey = true;
        public bool ucEnableHotkey
        {
            get { return _enableHotkey; }
            set { _enableHotkey = value; }
        }

        void ParentForm_KeyDown(object sender, KeyEventArgs e)
        {
            //btnFind       Ctrl+R
            //btnNew        Ctrl+N
            //btnEdit       Ctrl+E
            //btnDel        Ctrl+D
            //btnImport     Ctrl+I
            //btnExport     Ctrl+M
            //btnPrint      Ctrl+P
            //btnChoose     Ctrl+O
            //btnSave       Ctrl+S
            //btnExit       Esc

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R:
                        if (btnFind.Enabled && btnFind.Visible)
                            btnFind.PerformClick();
                        break;
                    case Keys.N:
                        if (btnNew.Enabled && btnNew.Visible)
                            btnNew.PerformClick();
                        break;
                    case Keys.E:
                        if (btnEdit.Enabled && btnEdit.Visible)
                            btnEdit.PerformClick();
                        break;
                    case Keys.D:
                        if (btnDel.Enabled && btnDel.Visible)
                            btnDel.PerformClick();
                        break;
                    case Keys.I:
                        if (btnImport.Enabled && btnImport.Visible)
                            btnImport.PerformClick();
                        break;
                    case Keys.M:
                        if (btnExport.Enabled && btnExport.Visible)
                            btnExport.PerformClick();
                        break;
                    case Keys.P:
                        if (btnPrint.Enabled && btnPrint.Visible)
                            btnPrint.PerformClick();
                        break;
                    case Keys.O:
                        if (btnChoose.Enabled && btnChoose.Visible)
                            btnChoose.PerformClick();
                        break;
                    case Keys.S:
                        if (btnSave.Enabled && btnSave.Visible)
                            btnSave.PerformClick();
                        break;
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (btnExit.Enabled && btnExit.Visible)
                    btnExit.PerformClick();
            }
        }

        private bool _mini = false;
        public bool ucMini
        {
            get { return _mini; }
            set
            {
                _mini = value;
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c is DevExpress.XtraEditors.SimpleButton)
                    {
                        (c as DevExpress.XtraEditors.SimpleButton).Size = new Size(_buttonOnly ? (_mini ? 24 : 34) : (_mini ? 62 : 75), _mini ? 18 : 34);
                        (c as DevExpress.XtraEditors.SimpleButton).ImageList = _mini ? imageCollection2 : imageCollection1;
                    }
                }
                this.MaximumSize = new Size(9999, _mini ? 24: 40);
                this.MinimumSize = new Size(140, _mini ? 24 : 40);
                this.Size = new Size(this.Width, _mini ? 24 : 40);
            }
        }

        private bool _buttonOnly = false;
        public bool ucButtonOnly
        {
            get { return _buttonOnly; }
            set
            {
                _buttonOnly = value;
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c is DevExpress.XtraEditors.SimpleButton)
                    {
                        (c as DevExpress.XtraEditors.SimpleButton).Width = _mini ? 24 : 40;
                    }
                }
            }
        }

        public enum eShowStyle { Custom, List, Choose, Detail, Print, All }
        private eShowStyle showStyle = eShowStyle.Custom;
        public eShowStyle ShowStyle
        {
            get { return showStyle; }
            set
            {
                showStyle = value;
                switch (showStyle)
                {
                    case eShowStyle.Choose:
                        btnFind.Visible = btnChoose.Visible = btnExit.Visible = true;
                        _useButtonFind = _useButtonChoose = _useButtonEdit = true;
                        btnSave.Visible = btnNew.Visible = btnEdit.Visible = btnDel.Visible = btnImport.Visible = btnExport.Visible = btnPrint.Visible = false;
                        _useButtonSave = _useButtonNew = _useButtonEdit = _useButtonDelete = _useButtonImport = _useButtonExport = _useButtonPrint = false;
                        break;
                    case eShowStyle.List:
                        btnFind.Visible = btnNew.Visible = btnEdit.Visible = btnDel.Visible = btnExit.Visible = true;
                        _useButtonFind = _useButtonNew = _useButtonEdit = _useButtonDelete = _useButtonEdit = true;
                        btnSave.Visible = btnChoose.Visible = btnImport.Visible = btnExport.Visible = btnPrint.Visible = false;
                        _useButtonSave = _useButtonChoose = _useButtonImport = _useButtonExport = _useButtonPrint = false;
                        break;
                    case eShowStyle.Detail:
                        btnSave.Visible = btnExit.Visible = true;
                        _useButtonSave = _useButtonEdit = true;
                        btnFind.Visible = btnChoose.Visible = btnNew.Visible = btnEdit.Visible = btnDel.Visible = btnImport.Visible = btnExport.Visible = btnPrint.Visible = false;
                        _useButtonFind = _useButtonChoose = _useButtonNew = _useButtonEdit = _useButtonDelete = _useButtonImport = _useButtonExport = _useButtonPrint = false;
                        break;
                    case eShowStyle.Print:
                        btnFind.Visible = btnImport.Visible = btnExport.Visible = btnPrint.Visible = btnExit.Visible = true;
                        _useButtonFind = _useButtonImport = _useButtonExport = _useButtonPrint = _useButtonExit = true;
                        btnSave.Visible = btnChoose.Visible = btnNew.Visible = btnEdit.Visible = btnDel.Visible = false;
                        _useButtonSave = _useButtonChoose = _useButtonNew = _useButtonEdit = _useButtonDelete = false;
                        break;
                    case eShowStyle.All:
                        btnSave.Visible = btnFind.Visible = btnImport.Visible = btnExport.Visible = btnPrint.Visible = btnExit.Visible = btnChoose.Visible = btnNew.Visible = btnEdit.Visible = btnDel.Visible = true;
                        _useButtonSave = _useButtonChoose = _useButtonNew = _useButtonEdit = _useButtonDelete = _useButtonFind = _useButtonImport = _useButtonExport = _useButtonPrint = _useButtonExit = true;
                        break;
                }
            }
        }

        #region use button
        private bool _useButtonFind = false;
        public bool useButtonFind
        {
            get { return _useButtonFind; }
            set { _useButtonFind = btnFind.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonChoose = false;
        public bool useButtonChoose
        {
            get { return _useButtonChoose; }
            set { _useButtonChoose = btnChoose.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonNew = false;
        public bool useButtonNew
        {
            get { return _useButtonNew; }
            set { _useButtonNew = btnNew.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonEdit = false;
        public bool useButtonEdit
        {
            get { return _useButtonEdit; }
            set { _useButtonEdit = btnEdit.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonDelete = false;
        public bool useButtonDelete
        {
            get { return _useButtonDelete; }
            set { _useButtonDelete = btnDel.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonImport = false;
        public bool useButtonImport
        {
            get { return _useButtonImport; }
            set { _useButtonImport = btnImport.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonExport = false;
        public bool useButtonExport
        {
            get { return _useButtonExport; }
            set { _useButtonExport = btnExport.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonPrint = false;
        public bool useButtonPrint
        {
            get { return _useButtonPrint; }
            set { _useButtonPrint = btnPrint.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonExit = true;
        public bool useButtonExit
        {
            get { return _useButtonExit; }
            set { _useButtonExit = btnExit.Visible = value; showStyle = eShowStyle.Custom; }
        }
        private bool _useButtonSave = false;
        public bool useButtonSave
        {
            get { return _useButtonSave; }
            set { _useButtonSave = btnSave.Visible = value; showStyle = eShowStyle.Custom; }
        }
        #endregion

        #region show button
        public bool showButtonFind
        {
            get { return btnFind.Visible; }
            set { btnFind.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonChoose
        {
            get { return btnChoose.Visible; }
            set { btnChoose.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonNew
        {
            get { return btnNew.Visible; }
            set { btnNew.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonEdit
        {
            get { return btnEdit.Visible; }
            set { btnEdit.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonDelete
        {
            get { return btnDel.Visible; }
            set { btnDel.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonImport
        {
            get { return btnImport.Visible; }
            set { btnImport.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonExport
        {
            get { return btnExport.Visible; }
            set { btnExport.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonPrint
        {
            get { return btnPrint.Visible; }
            set { btnPrint.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonExit
        {
            get { return btnExit.Visible; }
            set { btnExit.Visible = value; showStyle = eShowStyle.Custom; }
        }
        public bool showButtonSave
        {
            get { return btnSave.Visible; }
            set { btnSave.Visible = value; showStyle = eShowStyle.Custom; }
        }
        #endregion

        #region enable button
        public bool enableButtonFind
        {
            get { return btnFind.Enabled; }
            set { btnFind.Enabled = value; }
        }
        public bool enableButtonChoose
        {
            get { return btnChoose.Enabled; }
            set { btnChoose.Enabled = value; }
        }
        public bool enableButtonNew
        {
            get { return btnNew.Enabled; }
            set { btnNew.Enabled = value; }
        }
        public bool enableButtonEdit
        {
            get { return btnEdit.Enabled; }
            set { btnEdit.Enabled = value; }
        }
        public bool enableButtonDelete
        {
            get { return btnDel.Enabled; }
            set { btnDel.Enabled = value; }
        }
        public bool enableButtonImport
        {
            get { return btnImport.Enabled; }
            set { btnImport.Enabled = value; }
        }
        public bool enableButtonExport
        {
            get { return btnExport.Enabled; }
            set { btnExport.Enabled = value; }
        }
        public bool enableButtonPrint
        {
            get { return btnPrint.Enabled; }
            set { btnPrint.Enabled = value; }
        }
        public bool enableButtonExit
        {
            get { return btnExit.Enabled; }
            set { btnExit.Enabled = value; }
        }
        public bool enableButtonSave
        {
            get { return btnSave.Enabled; }
            set { btnSave.Enabled = value; }
        }
        #endregion

        #endregion

        public ucButtonPanel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (_enableHotkey)
            {
                if (this.ParentForm == null)
                    return;

                this.ParentForm.KeyPreview = true;
                this.ParentForm.KeyDown += ParentForm_KeyDown;
            }
            base.OnLoad(e);
        }

        #region scroll

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (panel1.Width < flowLayoutPanel1.Width)
            {
                hScrollBar1.Visible = true;
                hScrollBar1.Minimum = panel1.Width - flowLayoutPanel1.Width;
                hScrollBar1.Value = flowLayoutPanel1.Left;
            }
            else
            {
                hScrollBar1.Visible = false;
            }
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Left = hScrollBar1.Value;
        }
        #endregion
        
        #region event

        public event EventHandler OnFind;
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (OnFind != null)
                OnFind(sender, e);
        }

        public event EventHandler OnChosse;
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (OnChosse != null)
                OnChosse(sender, e);
        }

        public event EventHandler OnNew;
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (OnNew != null)
                OnNew(sender, e);
        }

        public event EventHandler OnEdit;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (OnEdit != null)
                OnEdit(sender, e);
        }

        public event EventHandler OnSave;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (OnSave != null)
                OnSave(sender, e);
        }

        public event EventHandler OnDelete;
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (OnDelete != null)
                OnDelete(sender, e);
        }

        public event EventHandler OnImport;
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (OnImport != null)
                OnImport(sender, e);
        }

        public event EventHandler OnExport;
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (OnExport != null)
                OnExport(sender, e);
        }

        public event EventHandler OnPrintf;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (OnPrintf != null)
                OnPrintf(sender, e);
        }

        public event EventHandler OnExit;
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (OnExit == null)
                this.ParentForm.Close();
            else
                OnExit(sender, e);
        }

        #endregion

    }
}
