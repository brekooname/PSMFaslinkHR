using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Misc
{
    public partial class OpenSyncSV : Form
    {
        public string commandAgrs { get; set; }

        public OpenSyncSV()
        {
            InitializeComponent();
        }

        private void OpenSyncSV_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = Path.Combine(win_globall.apppath, "SyncSV.exe"),
                    UseShellExecute = true,
                    Arguments = commandAgrs
                });
            }
            catch(Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
            this.Close();
        }
    }
}
