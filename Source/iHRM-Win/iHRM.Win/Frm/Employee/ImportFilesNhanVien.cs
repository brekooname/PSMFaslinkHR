using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.FileDB;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Employee
{
    public partial class ImportFilesNhanVien : frmBase
    {
        OpenFileDialog od = new OpenFileDialog();

        public ImportFilesNhanVien()
        {
            InitializeComponent();
        }
        
        private void btnFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) //Chọn file
            {
                od = new OpenFileDialog();

                string filterFile = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                filterFile += "|Word files (*.doc, *.docx)|*.doc; *.docx; ";

                filterFile += "|Pdf files (*.pdf)|*.pdf; ";

                filterFile += "|All files (*.*)|*.*;";

                od.Filter = filterFile;

                od.Multiselect = true;
                
                if (od.ShowDialog() == DialogResult.OK)
                {
                    string[] arrFileName = od.FileNames;

                    int total = arrFileName.Count();

                    btnFile.Text = string.Format("Đã chọn {0} files", total);
                }
            }
            else //Hủy file
            {
                btnFile.Text = "";
            }
        }

        private void ImportAnhNhanVien_Load(object sender, EventArgs e)
        {
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

            lookUpTTHS.Properties.DataSource = db.tblRef_CurriculumVitaes;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lookUpTTHS.EditValue == null)
            {
                GUIHelper.Notifications("Bạn chưa chọn loại thông tin hồ sơ", "Nhập files hàng loạt", GUIHelper.NotifiType.error);

                return;
            }

            string[] arrFilePath = od.FileNames;

            int total = arrFilePath.Count();

            if (total == 0)
            {
                GUIHelper.Notifications("Bạn chưa chọn file", "Nhập ảnh hàng loạt", GUIHelper.NotifiType.error);

                return;
            }

            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

            FileStorageHelper fs = new FileStorageHelper();

            //List<string> _lExt = new List<string>();

            //_lExt.AddRange(".jpg,.jpeg,.jpe,.jfif,.png".Split(','));

            string duoiFile = "";

            int count = 0;

            ucProgress1.start(0, total);

            ucProgress1.Status = "Đang nhập dữ liệu";

            foreach (string fP in arrFilePath)
            {
                count += 1;

                ucProgress1.Status = string.Format("Đang nhập dữ liệu {0}/{1}", count, total);

                duoiFile = Path.GetExtension(fP).ToLower();

                string fileName = Path.GetFileName(fP).Replace(duoiFile.ToLower(), "").Replace(duoiFile.ToUpper(), "");

                //var a = _lExt.Where(p => p == duoiFile).FirstOrDefault();
                //if (a == null)
                //{
                //    ucProgress1.Message += "\r\n" + string.Format("File {0} không đúng định dạng ảnh", fP);
                //    continue;
                //}

                var emp = db.tblEmployees.Where(p => p.EmployeeID == fileName).FirstOrDefault();

                if (emp == null)
                {
                    ucProgress1.Message += "\r\n" + string.Format("File {0} có mã nhân viên không tồn tại", fP);

                    continue;
                }
                var empFile = db.tblEmpFilesLienQuans.Where(p => p.CurriculumVitaeCode == lookUpTTHS.EditValue.ToString() 
                                                                       && p.EmployeeID == fileName).FirstOrDefault();

                tblEmpFilesLienQuan newEmpFile;

                if (empFile == null)
                {
                    newEmpFile = new tblEmpFilesLienQuan();

                    newEmpFile.EmployeeID = fileName;

                    newEmpFile.CurriculumVitaeCode = lookUpTTHS.EditValue.ToString();

                    newEmpFile.idFile = Guid.NewGuid();

                    db.tblEmpFilesLienQuans.InsertOnSubmit(newEmpFile);
                }
                else
                {
                    newEmpFile = empFile;

                    if (empFile.idFile == null)
                    {
                        newEmpFile.idFile = Guid.NewGuid();
                    }
                }

                byte[] bytes = System.IO.File.ReadAllBytes(fP);

                if (fs.InsertOrUpdateDBFiles(newEmpFile.idFile.Value, bytes, duoiFile))
                {
                    db.SubmitChanges();

                    LogAction.LogAction.PushLog("Import file nhân viên"
                                                , fileName
                                                , ""
                                                , "Import file nhân viên thành công"
                                                , "tblEmpFilesLienQuan");

                    ucProgress1.Message += "\r\n" + string.Format("File {0} nhập thành công.", fP);
                }
                else
                {
                    ucProgress1.Message += "\r\n" + string.Format("File {0} nhập có lỗi xảy ra.", fP);
                }

                ucProgress1.CurrentValue = count;
            }

            ucProgress1.Status = string.Format("Nhập hình ảnh hoàn thành!", count, total);
        }
    }
}
