using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSV.Cls
{
    public class GridSaveLoadLayout
    {
        public static string SaveGrvLayout(DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            System.IO.Stream stream = new System.IO.MemoryStream();
            grv.SaveLayoutToStream(stream);
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.StreamReader reader = new System.IO.StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static void LoadGrvLayout(DevExpress.XtraGrid.Views.Grid.GridView grv, string layoutstring)
        {
            if (string.IsNullOrWhiteSpace(layoutstring))
                return;

            byte[] byteArray = Encoding.ASCII.GetBytes(layoutstring);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
            try { grv.RestoreLayoutFromStream(stream); } catch { }
        }
    }
}
