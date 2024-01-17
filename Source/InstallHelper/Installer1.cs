using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace InstallHelper
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        public Installer1()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            
            //string thumuc = this.Context.Parameters["thumuc"];

            //var p = Process.Start(new ProcessStartInfo()
            //{
            //    FileName = Path.Combine(thumuc, "SetupAttMachine.exe"),
            //    Arguments = thumuc,
            //    UseShellExecute = true
            //});
            //p.WaitForExit();
            //if (p.ExitCode != 1)
            //{
            //    this.Rollback(stateSaver);
            //}
            















            //System.Diagnostics.Process.Start(thumuc + @"\SetupAttMachine.exe");
            //File.WriteAllText("D:\\a.txt", thumuc + @"\SetupAttMachine.exe");
            ////my code
            //if (Environment.Is64BitOperatingSystem)
            //{
            //    foreach (var item in Directory.GetFiles(thumuc + @"\SETUP_SDK\SDK64bit"))
            //    {
            //        string fileSys32 = @"C:\Windows\System32\" + Path.GetFileName(item);
            //        string fileSys64 = @"C:\Windows\SysWOW64\" + Path.GetFileName(item);
            //        if (File.Exists(fileSys32))
            //        {
            //            File.Delete(fileSys32);
            //        }
            //        if (File.Exists(fileSys64))
            //        {
            //            File.Delete(fileSys64);
            //        }
            //        File.Copy(item, fileSys32);
            //        File.Copy(item, fileSys64);
            //    }
            //}
            //else
            //{
            //    foreach (var item in Directory.GetFiles(thumuc + @"\SETUP_SDK\SDK32bit"))
            //    {
            //        string fileSys32 = @"C:\Windows\System32\" + Path.GetFileName(item);
            //        if (File.Exists(fileSys32))
            //        {
            //            File.Delete(fileSys32);
            //        }
            //        File.Copy(item, fileSys32);
            //    }
            //}
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = @"/c regsvr32 %windir%\system32\zkemkeeper.dll";
            //process.StartInfo = startInfo;
            //process.Start();
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
    }
}
