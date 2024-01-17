using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class dlgChuyenNhomHL_NV : frmBase
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);

        public List<String> _listEmp = new List<String>();

        List<tblEmployee> LstData;

        public String _idNhom = "0";
        public dlgChuyenNhomHL_NV()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void EvaluatorEditor_Load(object sender, EventArgs e)
        {
            String _Text = "";

            txt_NhomHL.Properties.DataSource = Provider.ExecuteDataTable("p_tbDM_nhomNV_idDM_idUser_True"
                
                                                        , new System.Data.SqlClient.SqlParameter("idUser", LoginHelper.user.id)

                                                        , new System.Data.SqlClient.SqlParameter("idNhom", _idNhom));

            txt_NhomHL.EditValue = txt_NhomHL.Properties.GetDataSourceValue(txt_NhomHL.Properties.ValueMember, 0);

            txt_NhomHLChuyen.Properties.DataSource = Provider.ExecuteDataTable("p_tbDM_nhomNV_idDM_idUser_False"

                                                        , new System.Data.SqlClient.SqlParameter("idUser", LoginHelper.user.id)

                                                        , new System.Data.SqlClient.SqlParameter("idNhom", _idNhom));

            LstData = db.tbNhanVien_NhomNVs.Where(i => i.nhomnv_id == int.Parse(_idNhom)).Select(i => i.tblEmployee).ToList();

            foreach (var it in _listEmp)
            {
                if (LstData.Where(i => i.EmployeeID == it.ToString()).Count() >= 0)

                    _Text = _Text + "'" + LstData.Where(i => i.EmployeeID == it.ToString()).Select(x => x.EmployeeID).SingleOrDefault().ToString() + "'" + "; ";
            }

            txtDSNV.Text = _Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var newLst = new List<tblEmployee>();

            foreach (var it in _listEmp)
            {
                if (LstData.Where(i => i.EmployeeID == it.ToString()).Count() >= 0)

                    newLst.Add(LstData.Where(i => i.EmployeeID == it.ToString()).SingleOrDefault());
            }

            if (_listEmp.Count() == 0 || txt_NhomHLChuyen.EditValue == null || txt_NhomHLChuyen.EditValue == "")
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            try
            {
                Provider.ExecNoneQuery("p_tbDM_nhomNV_idDM_nhomNV_Update"

                                        , new System.Data.SqlClient.SqlParameter("id", txt_NhomHLChuyen.EditValue)

                                        , Provider.CreateParameter_StringList("ListNV", _listEmp));

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);

                var log = Log2.CreateLog(Log2.Log2Action.sua, "Cập nhật " + newLst.Count() + " bản ghi", "tbNhanVien_NhomNV");
                log.tbLog2_details.AddRange(newLst.Select(i => new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "id",
                    target2 = "ten",
                    value1 = i.EmployeeID.ToString(),
                    value2 = i.EmployeeName
                }).ToArray());
                Log2.PushLog(log);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
            finally
            {
                this.Close();
            }
        }    
    }
}
