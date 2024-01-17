using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Category
{
    public partial class SetupAllCategory : Form
    {
        DataTable dtData;
        DataRow cRow;
        DataTable dtData2;

        public SetupAllCategory()
        {
            InitializeComponent();
        }

        private void SetupAllCategory_Load(object sender, EventArgs e)
        {
            repositoryItemLookUpEdit1.DataSource = new object[]
            {
                new { caption = "string",   value = 1 },
                new { caption = "int",      value = 2 },
                new { caption = "float",    value = 3 },
                new { caption = "bool",     value = 4 },
                new { caption = "datetime", value = 5 }
            };

            buttonPanel1_OnFind(null, null);
        }

        private void buttonPanel1_OnFind(object sender, EventArgs e)
        {
            if (dtData != null)
                dtData.Rows.Clear();
            dtData = Provider.ExecuteDataTableReader_SQL("SELECT * FROM [tbCatDefine]");
            grd.DataSource = dtData;
        }
        private void buttonPanel1_OnDelete(object sender, EventArgs e)
        {
            var rows = grv.GetSelectedRows().Select(i => grv.GetDataRow(i)).ToList();
            for (int i = rows.Count - 1; i >= 0; i--)
                rows[i].Delete();
        }
        private void buttonPanel1_OnSave(object sender, EventArgs e)
        {
            try
            {
                Provider.UpdateData(dtData, "tbCatDefine");
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dr = grv.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["id"] = Guid.NewGuid();
            }
        }
        private void grv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            cRow = grv.GetFocusedDataRow();
            buttonPanel2_OnFind(null, null);
        }

        private void buttonPanel2_OnFind(object sender, EventArgs e)
        {
            grd2.DataSource = null;
            if (cRow == null)
                return;

            if (dtData2 != null)
                dtData2.Rows.Clear();
            dtData2 = Provider.ExecuteDataTableReader_SQL("SELECT * FROM [tbCatDefineColumn] WHERE catDefID = '" + cRow["id"] + "'");
            grd2.DataSource = dtData2;
        }
        private void buttonPanel2_OnDelete(object sender, EventArgs e)
        {
            var rows = grv2.GetSelectedRows().Select(i => grv2.GetDataRow(i)).ToList();
            for (int i = rows.Count - 1; i >= 0; i--)
                rows[i].Delete();
        }
        private void buttonPanel2_OnSave(object sender, EventArgs e)
        {
            try
            {
                Provider.UpdateData(dtData2, "tbCatDefineColumn");
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void grv2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dr = grv2.GetDataRow(e.RowHandle);
            if (dr != null)
            {
                dr["id"] = Guid.NewGuid();
                dr["catDefID"] = cRow == null ? DBNull.Value : cRow["id"];
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (cRow == null)
                return;

            var dt = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM [{0}] WHERE 1=2", cRow["tableName"]));
            int idx = 1;
            foreach(DataColumn dc in dt.Columns)
            {
                var r = dtData2.NewRow();
                r["id"] = Guid.NewGuid();
                r["catDefID"] = cRow["id"];
                r["columnName"] = dc.ColumnName;
                r["caption"] = dc.Caption;
                r["dataType"] = getDataType(dc.DataType);
                r["sortIdx"] = idx;
                r["width"] = 0;
                r["dataLength"] = dc.MaxLength;
                r["dataIsNullable"] = dc.AllowDBNull;
                r["dataSource"] = "";

                idx += 1;
                dtData2.Rows.Add(r);
            }
        }

        int getDataType(Type t)
        {
            if (t == typeof(int) || t == typeof(long) || t == typeof(byte) || t == typeof(short))
                return 2;
            if (t == typeof(float) || t == typeof(double) || t == typeof(decimal))
                return 3;
            if (t == typeof(bool))
                return 4;
            if (t == typeof(DateTime) || t == typeof(TimeSpan))
                return 5;

            return 1;
        }
    }
}
