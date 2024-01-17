using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace SyncSV.Cls
{
    public class GridSelectionCheckbox
    {
        GridView myGridView;
        DevExpress.XtraGrid.Columns.GridColumn chkCol;
        public bool[] datacheck;

        /// <summary>
        /// cấu hình selection bằng checkbox
        /// </summary>
        /// <param name="myGridView">grid view</param>
        /// <param name="useExtendMode">false: dùng theo selected, true: theo click (click row/cell để chọn) </param>
        public GridSelectionCheckbox(GridView myGridView, bool useExtendMode = true)
        {
            this.myGridView = myGridView;

            chkCol = new DevExpress.XtraGrid.Columns.GridColumn();
            chkCol.Caption = "[v]";
            chkCol.FieldName = "chkCol";
            chkCol.OptionsColumn.FixedWidth = true;
            chkCol.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            chkCol.Visible = true;
            chkCol.VisibleIndex = 0;
            chkCol.Width = 35;
            chkCol.OptionsColumn.AllowEdit = false;
            myGridView.Columns.Insert(0, chkCol);

            myGridView.CustomUnboundColumnData += myGridView_CustomUnboundColumnData;
            if (useExtendMode)
                myGridView.RowCellClick += myGridView_RowCellClick;
            else
                myGridView.SelectionChanged += myGridView_SelectionChanged;
            myGridView.GridControl.DataSourceChanged += GridControl_DataSourceChanged;
        }

        void myGridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                datacheck[e.RowHandle] = !datacheck[e.RowHandle];
                myGridView.RefreshRow(e.RowHandle);
            }
        }

        void GridControl_DataSourceChanged(object sender, EventArgs e)
        {
            datacheck = new bool[myGridView.RowCount];
        }

        void myGridView_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (datacheck == null)
                return;

            if (e.Action == System.ComponentModel.CollectionChangeAction.Add)
                datacheck[e.ControllerRow] = true;
            else if (e.Action == System.ComponentModel.CollectionChangeAction.Remove)
                datacheck[e.ControllerRow] = false;
            else if (e.Action == System.ComponentModel.CollectionChangeAction.Refresh)
            {
                for (int i = 0; i < myGridView.RowCount; i++)
                    datacheck[i] = myGridView.IsRowSelected(i);
                myGridView.RefreshData();
            }
        }

        void myGridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == chkCol.FieldName)
            {
                if (e.IsGetData)
                    e.Value = datacheck[e.ListSourceRowIndex];
                else if (e.IsSetData)
                    datacheck[e.ListSourceRowIndex] = (e.Value as bool?) ?? false;
            }
        }
    }
}
