using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV.UC.UControl
{
    public partial class ucFilterPanel : DevExpress.XtraEditors.PanelControl
    {
        public ucFilterPanel()
        {
            InitializeComponent();
        }

        public ucFilterPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool CheckVailable()
        {
            foreach (Control c in this.Controls)
            {
                if (c is UC.UControl.ucBaseEdit)
                {
                    if (!((UC.UControl.ucBaseEdit)c).Vailable)
                        return false;
                }
            }

            return true;
        }
    }
}
