using iHRM.Common.Code;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3.VayVon
{
    public partial class dlgVayVon : dlgCustomBase
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);

        private tbVayVon myValue;
        public tbVayVon MyValue
        {
            get { return myValue; }
            set
            {
                myValue = value;
                txtNV_id.Text = myValue.idNV;
                txtNV_ten.Text = 
                txtNV_chucVu.Text = 
                txtNV_phongBan.Text = 
                txtNV_ngayVao.Text = 
                txtNV_hdChinhThuc.Text = 
                txtNV_mucLuong.Text = "";
                if (!string.IsNullOrWhiteSpace(txtNV_id.Text))
                    btnTimNV_Click(null, null);

                txtSoTienVay.EditValue = myValue.soTien;
                txtSoThangVay.EditValue = myValue.traGopSoThang;
                txtThangBatDau.EditValue = myValue.traGopTuThang;
                txtMoiThangTra.EditValue = myValue.traGopMoiThang;
                txtMucDichVay.EditValue = myValue.mucDich;
                txtCacChungTu.EditValue = myValue.chungTuDiKem;
                ucFileStorage1.myID = myValue.idFile_donXin;
                ucFileStorage2.myID = myValue.idFile_bienBanXacNhan;
                ucFileStorage3.myID = myValue.idFile_hopDong;
                ucFileStorage4.myID = myValue.idFile_thanhLy;

                labelControl18.Visible = linkLabel1.Visible = myValue.status != (int)Enums.eTTVayVon.taoMoi;
                switch (myValue.status)
                {
                    case (int)Enums.eTTVayVon.daDuyet:
                        labelControl18.Text = "HĐ đã phê duyệt";
                        labelControl18.ForeColor = Color.Orange;
                        break;
                    case (int)Enums.eTTVayVon.daHoanThanh:
                        labelControl18.Text = "HĐ đã hoàn thành";
                        labelControl18.ForeColor = Color.Green;
                        break;
                    case (int)Enums.eTTVayVon.daHuy:
                        labelControl18.Text = "HĐ đã bị hủy";
                        labelControl18.ForeColor = Color.Red;
                        break;
                }
                txtNV_id.ReadOnly = txtSoTienVay.ReadOnly = txtSoThangVay.ReadOnly =
                txtThangBatDau.ReadOnly = txtMoiThangTra.ReadOnly = txtMucDichVay.ReadOnly = txtCacChungTu.ReadOnly = (myValue.status != (int)Enums.eTTVayVon.taoMoi);
                btnSave.Visible = (myValue.status == (int)Enums.eTTVayVon.taoMoi);
            }
        }

        public string AttackMode { get; set; }
        frmCongThucTinh dlgCalcEditor = new frmCongThucTinh();

        public dlgVayVon()
        {
            InitializeComponent();
        }
        private void dlgDinhNghiaThamSo_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool ok = true;
                if (string.IsNullOrWhiteSpace(txtNV_id.Text))
                {
                    errorProvider1.SetError(txtNV_id, "Bạn chưa nhập mã...");
                    ok = false;
                }
                if (searchedNV == null || searchedNV.EmployeeID != txtNV_id.Text)
                {
                    errorProvider1.SetError(txtNV_id, "Bạn chưa tìm nhân viên...");
                    ok = false;
                }
                if (txtSoTienVay.Value <= 0)
                { 
                    errorProvider1.SetError(txtSoTienVay, "Số tiền cần lớn hơn 0");
                    ok = false;
                }
                if (txtSoThangVay.Value <= 0)
                { 
                    errorProvider1.SetError(txtSoThangVay, "Số tháng cần lớn hơn 0");
                    ok = false;
                }
                if (txtMoiThangTra.Value <= 0)
                { 
                    errorProvider1.SetError(txtMoiThangTra, "Số tiền mỗi tháng cần lớn hơn 0");
                    ok = false;
                }

                if (!ok)
                    return;

                myValue.idNV = txtNV_id.Text;
                myValue.tenNV = txtNV_ten.Text;
                myValue.soTien = Convert.ToDouble(txtSoTienVay.EditValue);
                myValue.traGopSoThang = Convert.ToInt32(txtSoThangVay.EditValue);
                myValue.traGopTuThang = new DateTime(txtThangBatDau.DateTime.Year, txtThangBatDau.DateTime.Month, 1);
                myValue.traGopMoiThang = Convert.ToDouble(txtMoiThangTra.EditValue);
                myValue.mucDich = txtMucDichVay.Text;
                myValue.chungTuDiKem = txtCacChungTu.Text;

                ucFileStorage1.DelAndUploadNewFile(); myValue.idFile_donXin = ucFileStorage1.myID;
                ucFileStorage2.DelAndUploadNewFile(); myValue.idFile_bienBanXacNhan = ucFileStorage2.myID;
                ucFileStorage3.DelAndUploadNewFile(); myValue.idFile_hopDong = ucFileStorage3.myID;
                ucFileStorage4.DelAndUploadNewFile(); myValue.idFile_thanhLy = ucFileStorage4.myID;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
            
        }

        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        tblEmployee searchedNV = null;
        private void btnTimNV_Click(object sender, EventArgs e)
        {
            searchedNV = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == txtNV_id.Text);
            if (searchedNV == null)
            {
                GUIHelper.MessageBox("Không tìm thấy thông tin nhân viên");
                return;
            }

            txtNV_id.Text = searchedNV.EmployeeID;
            txtNV_ten.Text = searchedNV.EmployeeName;
            txtNV_chucVu.Text = searchedNV.EmpTypeName;
            txtNV_phongBan.Text = searchedNV.DepName_Final;
            txtNV_ngayVao.Text = string.Format(" {0:dd/MM/yyyy}", searchedNV.AppliedDate); // $"{searchedNV.AppliedDate:dd/MM/yyyy}";
            txtNV_hdChinhThuc.Text = searchedNV.ContractID;
            txtNV_mucLuong.Text = string.Format("{0:#,0}", searchedNV.BasicSalary); //  $"{searchedNV.BasicSalary:#,0}";
        }

        private void txtSoTienVay_EditValueChanged(object sender, EventArgs e)
        {
            txtMoiThangTra.EditValue = txtSoThangVay.Value == 0 ? 0 : (txtSoTienVay.Value / txtSoThangVay.Value);
        }

        private void txtNV_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTimNV_Click(null, null);
        }

        dlgVayVon_LyDo frmLD = null;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmLD == null)
                frmLD = new dlgVayVon_LyDo();
            frmLD.myLyDo = myValue.yKienPheDuyet;
            frmLD.myReadOnly = true;
            frmLD.ShowDialog();
        }
    }
}
