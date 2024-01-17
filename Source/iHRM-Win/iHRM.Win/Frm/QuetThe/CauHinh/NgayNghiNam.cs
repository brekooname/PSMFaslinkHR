using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    public class NgayNghiNam : lstBase_grdEdit
    {
        public NgayNghiNam()
        {
            lstData.FormCaption = SelectTranslate("NgayNghiNam_Title", LoginHelper.langTrans);
            lstData.IdColumnName = "id";
            lstData.TableName = "tbNgayNghiPhepNam";

            lstData.GrdColumns.Add(new GridColumn1("ngay", SelectTranslate("NgayNghiNam_Ngay", LoginHelper.langTrans), ControlBinding_DataType.Int));
            lstData.GrdColumns.Add(new GridColumn1("thang", SelectTranslate("NgayNghiNam_Thang", LoginHelper.langTrans), ControlBinding_DataType.Int));
            lstData.GrdColumns.Add(new GridColumn1("nam", SelectTranslate("NgayNghiNam_Nam", LoginHelper.langTrans), ControlBinding_DataType.Int));
            lstData.GrdColumns.Add(new GridColumn1("ten", SelectTranslate("NgayNghiNam_Ten", LoginHelper.langTrans), ControlBinding_DataType.String));
            lstData.GrdColumns.Add(new GridColumn1("isThuong", SelectTranslate("NgayNghiNam_IsLuong", LoginHelper.langTrans), ControlBinding_DataType.Bool));
        }

        protected override void OnInitNewRow(ref DataRow r)
        {
            r[lstData.IdColumnName] = Guid.NewGuid();
        }
        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new System.Data.SqlClient.SqlParameter("CtrName", nameCrt),

                           new System.Data.SqlClient.SqlParameter("FormName", this.Name.ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                //có dữ liệu cho dùng chung
                if (ds.Tables[1].Rows.Count == 0)
                {
                    //không dùng riêng
                    return ds.Tables[0].Rows[0][lang].ToString().Trim();

                }
                else
                {
                    // có dùng riêng 
                    return ds.Tables[1].Rows[0][lang].ToString().Trim();
                }
            }
            else
            {
                return "";
            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NgayNghiNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(772, 368);
            this.Name = "NgayNghiNam";
            this.Text = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
