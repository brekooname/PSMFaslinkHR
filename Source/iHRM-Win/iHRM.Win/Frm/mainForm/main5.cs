using DevExpress.Utils.Animation;
using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.mainForm
{
    public partial class main5 : mainBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        List<w5sysFunction> _lFunc = new List<w5sysFunction>();

        public main5()
        {
            InitializeComponent();
        }

        private void main5_Load(object sender, EventArgs e)
        {
            _lFunc = db.w5sysFunctions.ToList();
            loadMenu();
        }

        #region show form

        Color[] cs = new Color[] { Color.FromArgb(0, 135, 156), Color.FromArgb(204, 109, 0), Color.FromArgb(0, 115, 196), Color.FromArgb(62, 112, 56), Color.FromArgb(0, 192, 192), Color.FromArgb(192, 192, 0), Color.Gray };
        public void loadMenu()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            foreach (var page in _lFunc.Where(p => p.parentId == 2 && p.status.Value == 1).OrderBy(p => p.order1))
            {
                if (!BitHelper.Has(LoginHelper.getRightAccess(page.id), (int)Enums.eFunction.Find)) //cos quyeefn find thi moi hien
                    continue; 

                var tileBarItem = new DevExpress.XtraBars.Navigation.TileBarItem();
                tileBarGroup2.Items.Add(tileBarItem);
                //tileBarItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
                tileBarItem.AppearanceItem.Normal.BackColor = cs[rnd.Next(cs.Length)];
                tileBarItem.AppearanceItem.Normal.Options.UseBackColor = true;

                tileBarItem.Elements.Add(new DevExpress.XtraEditors.TileItemElement()
                {
                    Image = page.icon == null ? null : Image.FromStream(new MemoryStream(page.icon.ToArray())),
                    Text = page.caption
                });
                tileBarItem.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
                tileBarItem.ShowDropDownButton = DevExpress.Utils.DefaultBoolean.True;
                var tileBarDropDownContainer1 = new DevExpress.XtraBars.Navigation.TileBarDropDownContainer();
                tileBarDropDownContainer1.Controls.Add(loadMenu2(page));
                tileBarItem.DropDownControl = tileBarDropDownContainer1;
            }
        }
        
        public DevExpress.XtraBars.Navigation.TileBar loadMenu2(w5sysFunction page)
        {
            var title1 = new DevExpress.XtraBars.Navigation.TileBar();
            title1.AllowDrag = false;
            title1.AllowSelectedItem = true;
            title1.AppearanceGroupText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            title1.AppearanceGroupText.Options.UseForeColor = true;
            title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            title1.Dock = System.Windows.Forms.DockStyle.Top;
            title1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            title1.Location = new System.Drawing.Point(0, 0);
            title1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            title1.SelectionBorderWidth = 2;
            title1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));

            foreach (var group in _lFunc.Where(p => p.parentId == page.id && p.status.Value == 1).OrderBy(p => p.order1))
            {
                if (!BitHelper.Has(LoginHelper.getRightAccess(group.id), (int)Enums.eFunction.Find))
                    continue;

                var rb_Group = new DevExpress.XtraBars.Navigation.TileBarGroup();
                rb_Group.Text = group.caption;
                foreach (var button in _lFunc.Where(p => p.parentId == group.id && p.status.Value == 1).OrderBy(p => p.order1))
                {
                    if (!BitHelper.Has(LoginHelper.getRightAccess(button.id), (int)Enums.eFunction.Find))
                        continue;

                    var btn_Item = new DevExpress.XtraBars.Navigation.TileBarItem();
                    //btn_Item.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
                    btn_Item.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
                    btn_Item.AppearanceItem.Normal.Options.UseBackColor = true;
                    btn_Item.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
                    btn_Item.Elements.Add(new DevExpress.XtraEditors.TileItemElement()
                    {
                        Image = button.icon == null ? null : Image.FromStream(new MemoryStream(button.icon.ToArray())),
                        Text = button.caption
                    });
                    btn_Item.Id = 0;
                    btn_Item.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
                    btn_Item.Tag = button;
                    btn_Item.ItemClick += Btn_Item_ItemClick;
                    rb_Group.Items.Add(btn_Item);
                }
                title1.Groups.Add(rb_Group);
            }

            return title1;
        }

        private void Btn_Item_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            mainTileBar.HideDropDownWindow();
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                w5sysFunction fn = (w5sysFunction)e.Item.Tag;
                string name = fn.asemblyInherits;
                return showFormByPath(name);
            }).ContinueWith(t => 
            {
                var frm_Cre = t.Result;
                if (frm_Cre == null)
                    return;

                switch (str_state)
                {
                    case "dialog":
                        frm_Cre.ShowDialog();
                        break;
                    case "owner":
                        frm_Cre.Owner = this;
                        frm_Cre.Show();
                        break;
                    case "another":
                        frm_Cre.Show();
                        break;
                    case "close":
                    case "logout":
                        this.Close();
                        break;
                    default:
                        frm_Cre.TopLevel = false;
                        frm_Cre.FormBorderStyle = FormBorderStyle.None;
                        frm_Cre.Dock = DockStyle.Fill;

                        this.Invoke(new Action(() =>
                        {
                            Form frm = null;
                            if (panelControl1.Controls.Count > 0)
                                frm = panelControl1.Controls[0] as Form;

                            panelControl1.Controls.Add(frm_Cre);

                            transitionManager1.StartTransition(panelControl1);

                            try
                            {
                                frm_Cre.Visible = true;

                                if (frm != null)
                                    frm.Visible = false;
                            }
                            finally
                            {
                                transitionManager1.EndTransition();
                            }

                            if (frm != null)
                                panelControl1.Controls.Remove(frm);
                        }));
                        break;
                }
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        string str_state = "";
        private string[] getStrFormFromName(string name)
        {
            string str_state = "", str_Form = "";

            if (name[0] == '#')
            {
                str_state = name.Substring(1, name.IndexOf("/") - 1);
                name = name.Substring(name.IndexOf("/") + 1);
            }

            if (name.IndexOf("(") > 0)
            {
                str_Form = name.Substring(0, name.IndexOf("("));
            }
            else
            {
                str_Form = name;
            }
            return new string[] { str_Form, str_state };
        }
        private Dictionary<string, string> getParamfromName(string name)
        {
            Dictionary<string, string> paramts = new Dictionary<string, string>();
            string str_Param = "";
            if (name.IndexOf("(") > 0)
            {
                str_Param = name.Substring(name.IndexOf("("), name.IndexOf(")") - name.IndexOf("(") + 1);
                foreach (string item in str_Param.Replace(" ", "").Replace("(", "").Replace(")", "").Split(','))
                {
                    string key = item.Split('=')[0];
                    string value = item.Split('=')[1];
                    paramts.Add(key, value);
                }
            }
            return paramts;
        }
        private Form showFormByPath(string name)
        {
            string str_Form = "";
            // Get params in form.
            Form frm_Exist = GetFormExist(name);
            if (frm_Exist != null)
            {
                frm_Exist.Activate();
                return null;
            }

            Dictionary<string, string> param = new Dictionary<string, string>();
            var a1 = getStrFormFromName(name);
            str_Form = a1[0];
            str_state = a1[1];
            param = getParamfromName(name);

            Type typ = Type.GetType(str_Form);
            Form frm_Cre = (Form)Activator.CreateInstance(typ);
            // Set param for form
            try
            {
                foreach (var p in param)
                {
                    var a = typ.GetProperty(p.Key);
                    a.SetValue(frm_Cre, p.Value, null);
                }
            }
            catch (Exception)
            {
                GUIHelper.Notifications("Lỗi set parameter Form", "Lỗi", GUIHelper.NotifiType.error);
            }
            
            return frm_Cre;
        }
        private Form GetFormExist(string name)
        {
            Type typ_Frm = Type.GetType(getStrFormFromName(name)[0]);
            Form frm = (Form)Activator.CreateInstance(typ_Frm);

            foreach (Form item in this.MdiChildren)
            {
                Type typ_Item = item.GetType();
                if (typ_Item == typ_Frm) // Nếu là form thì so sánh tiếp param.
                {
                    bool isEqualParams = true;

                    foreach (var p_Frm in getParamfromName(name))
                    {

                        try
                        {
                            var p_Item = typ_Item.GetProperty(p_Frm.Key);
                            if (p_Item.GetValue(item, null).ToString() != p_Frm.Value.ToString())
                            {
                                isEqualParams = false;
                            }
                        }
                        catch (Exception)
                        {
                            isEqualParams = false;
                            GUIHelper.Notifications("Không thể truy cập thuộc tính " + p_Frm.Key, "Lỗi", GUIHelper.NotifiType.error);
                        }

                    }
                    if (isEqualParams)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
