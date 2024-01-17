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
    public partial class dlgChuyenBangLuong_Fake : DevExpress.XtraEditors.XtraForm
    {
      

        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);

        public dlgChuyenBangLuong_Fake()
        {
            InitializeComponent();
        }

        private void EvaluatorEditor_Load(object sender, EventArgs e)
        {
            
            txtThangLuong.EditValue = DateTime.Now;

            txt_TsThue.Properties.DataSource = Provider.ExecuteDataTableReader("p_luong_tbLuong_DinhNghiaThamSo_Fake_KieuNhap");
            txt_TsLuong.Properties.DataSource = Provider.ExecuteDataTableReader("p_luong_tbLuong_DinhNghiaThamSo"); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
            if (txtThangLuong.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn tháng tính lương");
                return;
            }
            if (txt_TsLuong.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn tham số tính lương");
                return;
            }
            if (txt_TsThue.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn tham số tính lương báo cáo");
                return;
            }
            if (chonPhongBan1.SelectedValue == null)
            {
                GUIHelper.MessageBox("Cần chọn phòng ban");
                return;
            }

            if (IsLock.IsLock.Check_IsLock("tbLuong_NhapDuLieu_Fake", new DateTime(txtThangLuong.DateTime.Year, txtThangLuong.DateTime.Month, 1)))
            {
                GUIHelper.MessageBox("Dữ liệu thuế đã chốt khổng thể thao tác!");
                return;
            }

            try
            {
                Provider.ExecuteDataTableReader("p_luong_layDuLieuLuong_Fake",
                   new SqlParameter("thangLuong", new DateTime(txtThangLuong.DateTime.Year, txtThangLuong.DateTime.Month, 1)),
                   new SqlParameter("tsThue", txt_TsThue.EditValue),
                   new SqlParameter("tsLuong", txt_TsLuong.EditValue),
                   new SqlParameter("phongban_id", chonPhongBan1.SelectedValue)
               );

                var log = Log2.CreateLog(Log2.Log2Action.phantich, "Chuyển tham số lương sang tham số lương báo cáo phòng ban " + chonPhongBan1.SelectedRow.DepName, "tbLuong_NhapDuLieu_Fake");
                log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "thang",
                    value1 = " Tháng lương " + string.Format("{0:MM/yyyy}", new DateTime(txtThangLuong.DateTime.Year, txtThangLuong.DateTime.Month, 1)) +
                    " Tham số thuế " + txt_TsThue.EditValue + " tham số lương " + txt_TsLuong.EditValue + " phòng ban " + chonPhongBan1.SelectedRow.DepName
                });
                Log2.PushLog(log);

                GUIHelper.MessageBox("Chuyển tham số lương sang tham số lương báo cáo thành công");

            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }    
    }
}
