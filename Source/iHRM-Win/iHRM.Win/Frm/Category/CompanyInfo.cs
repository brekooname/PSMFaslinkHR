using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Category
{
    public partial class CompanyInfo : dlgCustomBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);

        public CompanyInfo()
        {
            InitializeComponent();
        }

        private void CompanyInfo_Load(object sender, EventArgs e)
        {
            var cty = db.tblRef_Companies.FirstOrDefault();

            if (cty == null)
            {
                return;
            }

            textEdit1.Text = cty.CompanyCode;

            textEdit2.Text = cty.CompanyName;

            textEdit3.Text = cty.Address;

            textEdit4.Text = cty.Phone;

            textEdit5.Text = cty.Fax;

            textEdit6.Text = cty.VATCode;

            if (cty.LogoCompany != null)
            {
                pictureLogoCongTy.EditValue = cty.LogoCompany.ToArray();
            }

            if (cty.LogoSoftware != null)
            {
                pictureLogoPhanMem.EditValue = cty.LogoSoftware.ToArray();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var cty = db.tblRef_Companies.FirstOrDefault();

                if (cty == null)
                {
                    cty.CompanyID = "CTY";
                }
                else
                {
                    cty.CompanyCode = textEdit1.Text;

                    cty.CompanyName = textEdit2.Text;

                    cty.Address = textEdit3.Text;

                    cty.Phone = textEdit4.Text;

                    cty.Fax = textEdit5.Text;

                    cty.VATCode = textEdit6.Text;

                    if (pictureLogoCongTy.EditValue == null)
                    {
                        cty.LogoCompany = null;
                    }
                    else
                    {
                        cty.LogoCompany = new Binary(pictureLogoCongTy.EditValue as byte[]);
                    }

                    if (pictureLogoPhanMem.EditValue == null)
                    {
                        cty.LogoSoftware = null;
                    }
                    else
                    {
                        cty.LogoSoftware = new Binary(pictureLogoPhanMem.EditValue as byte[]);
                    }
                }

                db.SubmitChanges();

                Cls.GUIHelper.Notifications_msg(Cls.GUIHelper.Notifications_msgType.EditSuccess);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
    }
}
