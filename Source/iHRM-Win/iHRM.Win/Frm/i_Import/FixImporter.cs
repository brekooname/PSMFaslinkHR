using iHRM.Common.Code;
using iHRM.Win.Cls;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace iHRM.Win.Frm.i_Import
{
    public partial class FixImporter : DevExpress.XtraEditors.XtraForm
    {
        private string fileMau = "";
        public string FileMau
        {
            get { return fileMau; }
            set { fileMau = value; }
        }
        private string fileFilter = "Excel|*.xls;*.xlsx";
        public string FileFilter
        {
            get { return fileFilter; }
            set { fileFilter = value; }
        }

        public DataTable dtDataExcelImported = null;

        public event Action OnPreData;
        public event Action<DataTable> OnImportData;
        public event Action<DataRow> OnImportRow;
        public event Action<string> OnDownLoadFileTemplate;

        public FixImporter()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void Importer_Load(object sender, EventArgs e)
        {
        }

        private void txtFilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = fileFilter;
            if (od.ShowDialog() == DialogResult.OK)
                txtFilePath.Text = od.FileName;
        }

        
        private void bgw_import_DoWork(object sender, DoWorkEventArgs e)
        {
            int _countDone = 0;

            int _countErr = 0;

            try
            {
                ExcelExtend ex = new ExcelExtend();
                ex.OpenFile(Path.Combine(win_globall.apppath, txtFilePath.Text));
                dtDataExcelImported = ex.GetAllAvalidData();
                bgw_import.ReportProgress(2);
            }
            catch (Exception ex)
            {
                bgw_import.ReportProgress(-1, ex.Message);
                return;
            }

            if (OnPreData != null)
            {
                try
                {
                    OnPreData();
                }
                catch (Exception ex)
                {
                    bgw_import.ReportProgress(-1, ex.Message);
                    return;
                }
            }

            if (OnImportData != null)
            {
                try
                {
                    OnImportData(dtDataExcelImported);
                }
                catch (Exception ex)
                {
                    bgw_import.ReportProgress(-1, ex.Message);
                }
            }
            else
            {

                for (int i = 0; i < dtDataExcelImported.Rows.Count; i++)
                {
                    try
                    {
                        if (OnImportRow != null)
                            OnImportRow(dtDataExcelImported.Rows[i]);

                        bgw_import.ReportProgress(1, i);

                        _countDone++;
                    }
                    catch (Exception ex)
                    {
                        bgw_import.ReportProgress(-1, ex.Message);

                        _countErr++;
                    }
                }

                OutLog_DuringImport(">>" + DateTime.Now + ": Import thành công " + _countDone + " process");

                OutLog_DuringImport(">>" + DateTime.Now + ": Import thất bại " + _countErr + " process");
            }
        }
        private void bgw_import_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case -1:
                    richTextBox1.AppendText("\r\n" + (string)e.UserState);
                    richTextBox1.ScrollToCaret();
                    break;
                case 1:
                    prg.EditValue = e.UserState;
                    break;
                case 2:
                    prg.Properties.Maximum = dtDataExcelImported.Rows.Count;
                    break;
            }
        }
        private void bgw_import_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnImport.Enabled = true;
            btnImport.Image = Properties.Resources.play;
            prg.EditValue = prg.Properties.Maximum;
        }

        public void OutLog_DuringImport(string log)
        {
            if (bgw_import.IsBusy)
                bgw_import.ReportProgress(-1, log);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(fileMau) || OnDownLoadFileTemplate != null)
            {
                string fPath = Path.Combine(win_globall.apppath, "ExcelTemplate", fileMau);
                var sd = new SaveFileDialog();
                sd.Filter = fileFilter;
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    if (OnDownLoadFileTemplate == null)
                    {
                        File.Copy(fPath, sd.FileName, true);
                    }
                    else
                    {
                        OnDownLoadFileTemplate(sd.FileName);
                    }

                    txtFilePath.Text = sd.FileName;
                    win_globall.run(sd.FileName);
                }
            }
        }

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
        }
        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            richTextBox1.Clear();
        }
        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            if (bgw_import.IsBusy)
            {
                GUIHelper.MessageBox("Tiến trình import đang thực hiện");
                return;
            }

            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = false;
            btnImport.Image = Properties.Resources.loading;

            if (!bgw_import.IsBusy)
            {
                bgw_import.RunWorkerAsync();
            }
        }

    }
}
