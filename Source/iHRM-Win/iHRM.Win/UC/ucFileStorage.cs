using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iHRM.Core.Business;
using System.IO;

namespace iHRM.Win.UC
{
    public partial class ucFileStorage : UserControl
    {
        Core.FileDB.FileStorageHelper logic = new Core.FileDB.FileStorageHelper();
        DataRow myValue = null;

        string newFile = "";

        public Guid? myID
        {
            get { return myValue == null ? null : DbHelper.DrGetGuid(myValue, "id"); }
            set
            {
                if (value == null)
                {
                    myValue = null;
                }
                else
                {
                    myValue = logic.GetFileByIDDBFiles(value.Value);
                }

                if (myValue == null)
                {
                    buttonEdit1.Properties.Buttons[1].Visible = false;
                }
                else
                {
                    buttonEdit1.Text = DbHelper.DrGetString(myValue, "tenFile") + DbHelper.DrGetString(myValue, "duoiFile");
                    buttonEdit1.Properties.Buttons[1].Visible = true;
                }
            }
        }

        public ucFileStorage()
        {
            InitializeComponent();
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                var od = new OpenFileDialog();
                if (od.ShowDialog() == DialogResult.OK)
                {
                    newFile = od.FileName;
                    buttonEdit1.Text = Path.GetFileName(od.FileName);
                }
            }
            else if (e.Button.Index == 1)
            {
                if (myValue == null)
                    return;

                var sd = new SaveFileDialog();
                sd.Filter = "File|*" + DbHelper.DrGet(myValue, "duoiFile");
                sd.FileName = DbHelper.DrGetString(myValue, "tenFile") + DbHelper.DrGetString(myValue, "duoiFile");
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllBytes(sd.FileName, myValue["dataFile"] as byte[]);
                    System.Diagnostics.Process.Start(sd.FileName);
                }
            }
        }

        public bool DelAndUploadNewFile()
        {
            if (string.IsNullOrWhiteSpace(newFile))
                return true;

            //delete old file
            if (myID != null)
                logic.DeleteFileByIDDBFiles(myID.Value);

            //upload new file
            if (myValue == null)
            {
                var dt = new DataTable();
                dt.Columns.Add("id", typeof(Guid));
                dt.Columns.Add("dataFile", typeof(byte[]));
                dt.Columns.Add("duoiFile", typeof(string));
                dt.Columns.Add("tenFile", typeof(string));
                myValue = dt.NewRow();
            }

            myValue["id"] = Guid.NewGuid();
            myValue["dataFile"] = File.ReadAllBytes(newFile);
            myValue["duoiFile"] = Path.GetExtension(newFile);
            myValue["tenFile"] = Path.GetFileNameWithoutExtension(newFile);
            return logic.InsertOrUpdateDBFiles((Guid)myValue["id"], (byte[])myValue["dataFile"], (string)myValue["duoiFile"], (string)myValue["tenFile"]);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            buttonEdit1.Font = this.Font;
            this.Height = buttonEdit1.Height;
        }
    }
}
