using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncSV.Cls
{
    public class MoveForm
    {
        Form frmContainer;
        Control control2Effect;
        private Point LastFormPoint = new Point();

        public MoveForm(Form frm, Control control2Effect = null)
        {
            frmContainer = frm;
            this.control2Effect = control2Effect;

            if (control2Effect != null)
            {
                control2Effect.MouseDown += control2Effect_MouseDown;
                control2Effect.MouseMove += control2Effect_MouseMove;
                control2Effect.DoubleClick += control2Effect_DoubleClick;
            }
            else
            {
                frmContainer.MouseDown += control2Effect_MouseDown;
                frmContainer.MouseMove += control2Effect_MouseMove;
                frmContainer.DoubleClick += control2Effect_DoubleClick;
            }
        }

        void control2Effect_DoubleClick(object sender, EventArgs e)
        {
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                Point formTopLeft = new Point(frmContainer.Left, frmContainer.Top);

                if (screen.WorkingArea.Contains(formTopLeft))
                {
                    if (Control.ModifierKeys == Keys.Control)
                        frmContainer.Bounds = screen.WorkingArea;
                    else
                        frmContainer.Bounds = screen.Bounds;
                    break;
                }
            }
        }
        void control2Effect_MouseMove(object sender, MouseEventArgs e)
        {
            if (LastFormPoint != Point.Empty && e.Button == MouseButtons.Left)
            {
                frmContainer.Location = new Point(frmContainer.Left + e.Location.X - LastFormPoint.X, frmContainer.Top + e.Location.Y - LastFormPoint.Y);
            }
        }
        void control2Effect_MouseDown(object sender, MouseEventArgs e)
        {
            LastFormPoint = e.Location;
        }
    }
}
