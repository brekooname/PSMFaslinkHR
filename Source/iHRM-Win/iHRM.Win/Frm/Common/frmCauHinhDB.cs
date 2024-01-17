using iHRM.Win.Cls;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Common
{
    public partial class frmCauHinhDB : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        public frmCauHinhDB()
        {
            InitializeComponent();
        }

        private void frmCauHinhDB_Load(object sender, EventArgs e)
        {
            //grd.DataSource = new BindingList<Cls.AppConfig.strcnn>(Config.appConfig.lstStrcnn);
            DataSet _data = new DataSet();

            Provider.LoadData(_data, "w5sysConnectionString");

            DataTable _dataTable = new DataTable();

            _dataTable = _data.Tables[0];

            grd.DataSource = _dataTable;
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (grv.ActiveEditor == null)
            //    return;

            //Frm.Common.frmConnect frmCH = new Frm.Common.frmConnect();
            //frmCH.MyValue = grv.ActiveEditor.EditValue as string;
            //if (frmCH.ShowDialog() == DialogResult.OK)
            //{
            //    grv.ActiveEditor.EditValue = frmCH.MyValue;
            //}
        }

        private void buttonPanel1_OnSave(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void grv_DoubleClick(object sender, EventArgs e)
        {
            if (grv.GetSelectedRows().Count() != 1) //Xét điều kiện không chọn nhiều hơn một dòng.
            {
                return;
            }

            int[] rc = grv.GetSelectedRows(); //Lấy dữ liệu trong lưới

            for (int i = rc.Count(); i > 0; i--)
            {
                var r = grv.GetDataRow(rc[i - 1]);

                if (r != null)
                {
                    if (grv.FocusedRowHandle != -1)
                    {
                        dlgCauHinhDB _dlg = new dlgCauHinhDB();

                        _dlg._code = r["code"] as String;

                        _dlg.ShowDialog();
                    }
                }
            }
        }
    }
}
