using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Alerter;

namespace SyncSV.Cls
{
    public class GUIHelper
    {
        public static void MessageBox(string message, string title = "Thông báo")
        {
            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MessageError(string message, string title = "Thông báo")
        {
            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool ConfirmBox(string message, string title = "Xác nhận lại")
        {
            return XtraMessageBox.Show(message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }

        public enum NotifiType { none, download, comment, delete, edit, error, image, info, lockk, neww, plus, question, rss, stop, tick }
        public static AlertControl Notifications(string message, string caption = "", NotifiType type = NotifiType.none, int timeout = 0)
        {
            System.Drawing.Image img = null;
            switch (type)
            {
                case NotifiType.download:
                    img = Properties.Resources.ico20_arrow_down;
                    break;
                case NotifiType.comment:
                    img = Properties.Resources.ico20_comment;
                    break;
                case NotifiType.delete:
                    img = Properties.Resources.ico20_delete;
                    break;
                case NotifiType.edit:
                    img = Properties.Resources.ico20_edit;
                    break;
                case NotifiType.error:
                    img = Properties.Resources.ico20_error;
                    break;
                case NotifiType.image:
                    img = Properties.Resources.ico20_image;
                    break;
                case NotifiType.info:
                    img = Properties.Resources.ico20_info;
                    break;
                case NotifiType.lockk:
                    img = Properties.Resources.ico20_lock;
                    break;
                case NotifiType.neww:
                    img = Properties.Resources.ico20_new;
                    break;
                case NotifiType.plus:
                    img = Properties.Resources.ico20_plus;
                    break;
                case NotifiType.question:
                    img = Properties.Resources.ico20_question;
                    break;
                case NotifiType.rss:
                    img = Properties.Resources.ico20_rss;
                    break;
                case NotifiType.stop:
                    img = Properties.Resources.ico20_stop;
                    break;
                case NotifiType.tick:
                    img = Properties.Resources.ico20_tick;
                    break;
            }

            return Notifications(message, caption, img, timeout);
        }
        public static AlertControl Notifications(string message, string caption, System.Drawing.Image img = null, int timeout = 0)
        {
            AlertControl alertControl1 = new AlertControl();
            alertControl1.ShowCloseButton = true;
            alertControl1.ShowToolTips = false;
            alertControl1.AllowHtmlText = true;
            if (timeout > 0)
                alertControl1.AutoFormDelay = timeout;
            alertControl1.AutoHeight = true;
            alertControl1.FormDisplaySpeed = AlertFormDisplaySpeed.Moderate;
            alertControl1.FormLocation = AlertFormLocation.BottomRight;
            alertControl1.FormShowingEffect = AlertFormShowingEffect.SlideVertical;
            AlertInfo info = new AlertInfo(caption, message, img);
            alertControl1.Show(null, info);
            return alertControl1;
        }
    }
}
