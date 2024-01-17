using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SetupAttMachine
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                string thumuc = System.IO.Directory.GetCurrentDirectory();
                if (Environment.Is64BitOperatingSystem)
                {
                    foreach (var item in Directory.GetFiles(thumuc + @"\SETUP_SDK\SDK64bit"))
                    {
                        string fileSys32 = @"C:\Windows\System32\" + Path.GetFileName(item);
                        string fileSys64 = @"C:\Windows\SysWOW64\" + Path.GetFileName(item);
                        if (File.Exists(fileSys32))
                        {
                            File.Delete(fileSys32);
                        }
                        if (File.Exists(fileSys64))
                        {
                            File.Delete(fileSys64);
                        }
                        File.Copy(item, fileSys32);
                        File.Copy(item, fileSys64);
                    }
                }
                else
                {
                    foreach (var item in Directory.GetFiles(thumuc + @"\SETUP_SDK\SDK32bit"))
                    {
                        string fileSys32 = @"C:\Windows\System32\" + Path.GetFileName(item);
                        if (File.Exists(fileSys32))
                        {
                            File.Delete(fileSys32);
                        }
                        File.Copy(item, fileSys32);
                    }
                }
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = @"/c regsvr32 %windir%\system32\zkemkeeper.dll";
                process.StartInfo = startInfo;
                process.Start();

                return 1;
            }
            catch { }
            return 0;
        }
    }
}
