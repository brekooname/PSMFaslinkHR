using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSV.UC.UControl
{
    public partial class ucTitle : DevExpress.XtraEditors.LabelControl
    {
        private ucBaseEdit _ucTitleDefValue4Control = null;
        public ucBaseEdit ucTitleDefValue4Control
        {
            get { return _ucTitleDefValue4Control; }
            set { _ucTitleDefValue4Control = value; }
        }

        private string _ucTitleDefName = "";
        /// <summary>
        /// tên của chức năng
        /// </summary>
        public string ucTitleDefName
        {
            get { return _ucTitleDefName; }
            set { _ucTitleDefName = value; }
        }

        /// <summary>
        /// giá trị chức năng
        /// </summary>
        public string ucTitleDefValue
        {
            get { return _ucTitleDefValue4Control == null ? "" : _ucTitleDefValue4Control.ucValue.ToString(); }
        }

        public ucTitle()
        {
            InitializeComponent();
        }

        public ucTitle(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void ShowTitle(Cls.enums.eFormAttackMode attackMode)
        {
            this.Text = this.ucTitleDefName + " " + this.ucTitleDefValue;

            if (attackMode == Cls.enums.eFormAttackMode.Edit)
            {
                this.Appearance.Image = Properties.Resources.btnEdit_Image;
            }
            else if (attackMode == Cls.enums.eFormAttackMode.Add)
            {
                this.Text = "Thêm mới " + this.ucTitleDefName;
                this.Appearance.Image = Properties.Resources.btnAdd_Image;
            }
            else
            {
                this.Appearance.Image = null;
            }
        }
    }
}
