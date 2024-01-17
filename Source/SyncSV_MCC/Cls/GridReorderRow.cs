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
    public class GridReorderRow
    {
        GridView myGridView;
        GridHitInfo grdDictory_downHitInfo = null;

        public string property2order = "STT";

        public GridReorderRow(GridView myGridView, Control btnUp = null, Control btnDown = null)
        {
            this.myGridView = myGridView;
            myGridView.MouseDown += gridView1_MouseDown;
            myGridView.MouseMove += gridView1_MouseMove;
            myGridView.GridControl.DragOver += gridControl1_DragOver;
            myGridView.GridControl.DragDrop += gridControl1_DragDrop;

            if (btnUp !=null)
                btnUp.Click += btnUp_Click;
            if (btnDown != null)
                btnDown.Click += btnDown_Click;
        }

        private void gridView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GridView view = sender as GridView;
            grdDictory_downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                grdDictory_downHitInfo = hitInfo;
        }
        private void gridView1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && grdDictory_downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(grdDictory_downHitInfo.HitPoint.X - dragSize.Width / 2,
                    grdDictory_downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                //if (!dragRect.Contains(new Point(e.X, e.Y)))
                //{
                    view.GridControl.DoDragDrop(grdDictory_downHitInfo, DragDropEffects.All);
                    //grdDictory_downHitInfo = null;
                //}
            }
        }
        private void gridControl1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GridHitInfo)))
            {
                GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                if (downHitInfo == null)
                    return;

                GridControl grid = sender as GridControl;
                GridView view = grid.MainView as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
        }
        private void gridControl1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.MainView as GridView;
            GridHitInfo srcHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
            GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
            int sourceRow = srcHitInfo.RowHandle;
            int targetRow = hitInfo.RowHandle;
            MoveRow(sourceRow, targetRow);
        }

        private void btnUp_Click(object sender, System.EventArgs e)
        {
            GridView view = myGridView;
            view.GridControl.Focus();
            int idx = view.FocusedRowHandle;
            if (idx <= 0)
                return;

            MoveRow(idx, idx - 1);
            view.FocusedRowHandle = idx - 1;
            view.UnselectRow(idx);
            view.SelectRow(idx - 1);
        }
        private void btnDown_Click(object sender, System.EventArgs e)
        {
            GridView view = myGridView;
            view.GridControl.Focus();
            int idx = view.FocusedRowHandle;
            if (idx < 0 || idx >= view.DataRowCount - 1)
                return;

            MoveRow(idx, idx + 1);
            view.FocusedRowHandle = idx + 1;
            view.UnselectRow(idx);
            view.SelectRow(idx + 1);
        }



        private void MoveRow(int sourceRow, int targetRow)
        {
            if (sourceRow == targetRow)
                return;

            //for (int i = 0; i < myGridView.RowCount; i++)
            //    SetPropertyValue(myGridView.GetRow(i), property2order, i + 1);

            double sourceSTT = Convert.ToDouble(GetPropertyValue(myGridView.GetRow(sourceRow), property2order));
            object targetObj = myGridView.GetRow(targetRow);
            SetPropertyValue(myGridView.GetRow(sourceRow), property2order, GetPropertyValue(targetObj, property2order));
            SetPropertyValue(targetObj, property2order, sourceSTT);
        }

        static object GetPropertyValue(object obj, string propertyName)
        {
            if (obj == null)
                return null;

            return obj.GetType().GetProperties()
               .Single(pi => pi.Name == propertyName)
               .GetValue(obj, null);
        }
        static void SetPropertyValue(object obj, string propertyName, object value)
        {
            if (obj == null)
                return;

            Type type = obj.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            propertyInfo.SetValue(obj, Convert.ChangeType(value, propertyInfo.PropertyType), null);
        }
    }
}
