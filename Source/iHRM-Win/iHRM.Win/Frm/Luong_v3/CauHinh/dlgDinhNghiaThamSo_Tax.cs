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

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class dlgDinhNghiaThamSo_Tax : dlgCustomBase
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
        public List<tbLuong_DinhNghiaThamSo_Tax> LstThamSo
        {
            set
            {
                frmCongThucTinh_Tax.lstPara.Clear();
                if (value != null)
                {
                    frmCongThucTinh_Tax.lstPara.AddRange(value.Select(i => new frmCongThucTinh_Tax.lstItem()
                    {
                        Name = i.ma,
                        Description = i.ten,
                        nhom = i.nhom
                    }));
                }
                dlgCalcEditor.RefeshLstPara();
            }
        }

        private tbLuong_DinhNghiaThamSo_Tax myValue;
        public tbLuong_DinhNghiaThamSo_Tax MyValue
        {
            get { return myValue; }
            set
            {
                myValue = value;
                txtMa.Text = myValue.ma;
                txtIdx.Text = myValue.tsIdx;
                txtTen.Text = myValue.ten;
                txtNhom.Text = myValue.nhom;
                txtKieuDL.SelectedIndex = (myValue.kieuDuLieu ?? 0) - 1;
                txtKieuNhap.SelectedIndex = (myValue.kieuNhap ?? 0) - 1;
                txtKieuChuyenDL.SelectedIndex = (myValue.kieuMapping ?? 0) - 1;
                txtGiaTriMD.Text = string.Format("{0}", myValue.giatri_macdinh);
                txtLvTinh.EditValue = myValue.lvTinhToan;
                chkHienTrenBC.Checked = myValue.hienTrenBangLuong ?? false;
                chkHienTrenPL.Checked = myValue.hienTrenPhieuLuong ?? false;
                checkEdit1.Checked = myValue.macdinh_theothangtruoc ?? false;
                txtStt.EditValue = myValue.stt;
            }
        }

        public string AttackMode { get; set; }
        frmCongThucTinh_Tax dlgCalcEditor = new frmCongThucTinh_Tax();

        public dlgDinhNghiaThamSo_Tax()
        {
            InitializeComponent();
        }
        private void dlgDinhNghiaThamSo_Load(object sender, EventArgs e)
        {
            txtKieuDL.ReadOnly = AttackMode != "add";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                bool ok = true;
                if (string.IsNullOrWhiteSpace(txtMa.Text))
                {
                    errorProvider1.SetError(txtMa, "Bạn chưa nhập mã...");
                    ok = false;
                }
                if (string.IsNullOrWhiteSpace(txtTen.Text))
                { 
                    errorProvider1.SetError(txtTen, "Bạn chưa nhập tên...");
                    ok = false;
                }
                if (string.IsNullOrWhiteSpace(txtKieuDL.Text))
                {
                    errorProvider1.SetError(txtKieuDL, "Bạn chưa chọn kiểu dữ liệu...");
                    ok = false;
                }

                if (!ok)
                    return;

                myValue.ma = txtMa.Text;
                myValue.tsIdx = txtIdx.Text;
                myValue.ten = txtTen.Text;
                myValue.nhom = txtNhom.Text;
                myValue.kieuDuLieu = txtKieuDL.SelectedIndex + 1;
                myValue.kieuNhap = txtKieuNhap.SelectedIndex + 1;
                myValue.kieuMapping = txtKieuChuyenDL.SelectedIndex + 1;
                if (!string.IsNullOrWhiteSpace(txtGiaTriMD.Text))
                    myValue.giatri_macdinh = Convert.ToDouble(txtGiaTriMD.EditValue);
                if (!string.IsNullOrWhiteSpace(txtLvTinh.Text))
                    myValue.lvTinhToan = Convert.ToInt32(txtLvTinh.EditValue);
                myValue.hienTrenBangLuong = chkHienTrenBC.Checked;
                myValue.hienTrenPhieuLuong = chkHienTrenPL.Checked;
                myValue.macdinh_theothangtruoc = checkEdit1.Checked;
                myValue.stt = (int)txtStt.Value;

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

        private void txtKieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCauHinh.Visible = (txtKieuNhap.SelectedIndex > 0);
            switch (txtKieuNhap.SelectedIndex)
            {
                case 0:
                    myValue.moduleDef_id = null;
                    //myValue.congthuc_id = null;
                    break;
                case 1:
                    btnCauHinh.Text = " Cấu hình module";
                    break;
                case 2:
                    btnCauHinh.Text = " Cấu hình công thức";
                    break;
            }
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            if (AttackMode == "add")
            {
                GUIHelper.MessageBox("Cần lưu trước đã");
                return;
            }

            switch (txtKieuNhap.SelectedIndex)
            {
                case 1: // " Cấu hình module";
                    var frm2 = new frmDinhNghiaThamSo_ModuleSelect_Tax();
                    frm2.MyId = myValue.moduleDef_id;
                    if (frm2.ShowDialog() == DialogResult.OK)
                        myValue.moduleDef_id = frm2.MyId;
                    break;
                case 2: // " Cấu hình công thức";
                    if (myValue.congthuc_id == null)
                        myValue.congthuc_id = frmCongThucTinh_Tax.newCT();

                    dlgCalcEditor.MyId = myValue.congthuc_id;
                    dlgCalcEditor.ShowDialog();
                    break;
            }
        }

        private void txtKieuChuyenDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCauHinh2.Visible = txtKieuChuyenDL.SelectedIndex == 1;
        }

        private void btnCauHinh2_Click(object sender, EventArgs e)
        {
            if (AttackMode == "add")
            {
                GUIHelper.MessageBox("Cần lưu trước đã");
                return;
            }

            var frm = new frmDinhNghiaThamSo_TruthDef_Tax();
            frm.MyId = myValue.id;
            frm.ShowDialog();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaTriMD.Enabled = !checkEdit1.Checked;
        }

    }
}
