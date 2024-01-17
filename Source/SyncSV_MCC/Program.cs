using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SyncSV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] agrs)
        {
            SyncSV.Cls.globall.agrs = (agrs == null || agrs.Length == 0 ? "" : agrs[0]);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            if (agrs.Length > 0 && agrs[0] == "config")
                Application.Run(new frmConnect());
            else
            {
                Application.Run(new frmConncetMCC());
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Frm.Common.frmError er = new Frm.Common.frmError();
            er.ShowEx(e.Exception);
            er.ShowDialog();
        }
    }
}
