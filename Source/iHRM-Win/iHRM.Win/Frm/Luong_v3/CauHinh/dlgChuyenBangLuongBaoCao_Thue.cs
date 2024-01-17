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
    public partial class dlgChuyenBangLuongBaoCao_Thue : DevExpress.XtraEditors.XtraForm
    {
      

        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);

        public dlgChuyenBangLuongBaoCao_Thue()
        {
            InitializeComponent();
        }

        private void EvaluatorEditor_Load(object sender, EventArgs e)
        {
            txt_ThangThue.EditValue = DateTime.Now;
            txtThangLuong.EditValue = DateTime.Now;

            txt_TsThue.Properties.DataSource = Provider.ExecuteDataTableReader("p_luong_tbLuong_DinhNghiaThamSo_Tax_KieuNhap");
            txt_TsLuong.Properties.DataSource = Provider.ExecuteDataTableReader("p_luong_tbLuong_DinhNghiaThamSo_Fake"); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txt_ThangThue.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn tháng tính thuế");
                return;
            }
            if (txtThangLuong.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn tháng tính lương báo cáo");
                return;
            }
            if (txt_TsLuong.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn tham số tính lương báo cáo");
                return;
            }
            if (txt_TsThue.EditValue == null)
            {
                GUIHelper.MessageBox("Cần chọn tham số tính thuế");
                return;
            }
            if (chonPhongBan1.SelectedValue == null)
            {
                GUIHelper.MessageBox("Cần chọn phòng ban");
                return;
            }

            if (IsLock.IsLock.Check_IsLock("tbLuong_NhapDuLieu_Tax", new DateTime(txt_ThangThue.DateTime.Year, txt_ThangThue.DateTime.Month, 1)))
            {
                GUIHelper.MessageBox("Dữ liệu thuế đã chốt khổng thể thao tác!");
                return;
            }

            try
            {
                Provider.ExecuteDataTableReader("p_luong_layDuLieuLuongBaoCao_Thue",
                   new SqlParameter("thangThue", new DateTime(txt_ThangThue.DateTime.Year, txt_ThangThue.DateTime.Month, 1)),
                   new SqlParameter("thangLuong", new DateTime(txtThangLuong.DateTime.Year, txtThangLuong.DateTime.Month, 1)),
                   new SqlParameter("tsThue", txt_TsThue.EditValue),
                   new SqlParameter("tsLuong", txt_TsLuong.EditValue),
                   new SqlParameter("phongban_id", chonPhongBan1.SelectedValue)
               );

                var log = Log2.CreateLog(Log2.Log2Action.phantich, "Chuyển tham số lương báo cáo sang tham số thuế phòng ban  " + chonPhongBan1.SelectedRow.DepName, "tbLuong_NhapDuLieu_Tax");
                log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "thang",
                    value1 = " Tháng thuế " + string.Format("{0:MM/yyyy}", new DateTime(txt_ThangThue.DateTime.Year, txt_ThangThue.DateTime.Month, 1)) +
                    " Tháng lương báo cáo " + string.Format("{0:MM/yyyy}", new DateTime(txtThangLuong.DateTime.Year, txtThangLuong.DateTime.Month, 1)) +
                    " Tham số thuế " + txt_TsThue.EditValue + " tham số lương báo cáo " + txt_TsLuong.EditValue + " phòng ban " + chonPhongBan1.SelectedRow.DepName
                });
                Log2.PushLog(log);

                GUIHelper.MessageBox("Chuyển tham số lương báo cáo sang tham số thuế thành công");

            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }    
    }
}
