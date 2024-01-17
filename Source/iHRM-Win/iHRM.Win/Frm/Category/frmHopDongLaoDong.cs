using System;
using System.Data;
using System.Linq;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Cls;

namespace iHRM.Win.Frm.Category
{
    public partial class frmHopDongLaoDong : frmBase
    {
        public frmHopDongLaoDong()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void HopDongLaoDong_Load(object sender, EventArgs e)
        {
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            var a = db.tblHopDongLaoDongs.ToList();
            var b = a.FirstOrDefault();
            if (b != null)
            {
                txtMaHD.Text = b.MaHopDong;
                txtTenCT.Text = b.tenCongTy;
                txtTenGD.Text = b.tenGiamDoc;
                txtQuocTichGD.Text = b.QuocTichGiamDoc;
                txtSDT.Text = b.SDT;
                txtDiaChiCT.Text = b.DiaChiCongTy;
                txtDiaDiemLV.Text = b.DiaDiemLamViec;
                txtChucVuGD.Text = b.ChucVuGD;
                txtMaHD_ENG.Text = b.MaHopDong_Eng;
                txtTenCT_ENG.Text = b.tenCongTy_Eng;
                txtTenGD_ENG.Text = b.tenGiamDoc_Eng;
                txtQuocTichGD_ENG.Text = b.QuocTichGiamDoc_Eng;
                txtDiaChiCT_ENG.Text = b.DiaChiCongTy_Eng;
                txtDiaDiemLV_ENG.Text = b.DiaDiemLamViec_Eng;
                txtChucVuGD_ENG.Text = b.ChucVuGD_Eng;
                txtFax.Text = b.Fax;
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

                dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
                tblHopDongLaoDong result = (from p in db.tblHopDongLaoDongs
                                            select p).FirstOrDefault();
                if (result == null)
                {
                    result = new tblHopDongLaoDong();

                    db.tblHopDongLaoDongs.InsertOnSubmit(result);
                }
                result.MaHopDong = txtMaHD.Text;
                result.tenCongTy = txtTenCT.Text;
                result.tenGiamDoc = txtTenGD.Text;
                result.QuocTichGiamDoc = txtQuocTichGD.Text;
                result.SDT = txtSDT.Text;
                result.DiaChiCongTy = txtDiaChiCT.Text;
                result.DiaDiemLamViec = txtDiaDiemLV.Text;
                result.ChucVuGD = txtChucVuGD.Text;
                result.MaHopDong_Eng = txtMaHD_ENG.Text;
                result.tenCongTy_Eng = txtTenCT_ENG.Text;
                result.tenGiamDoc_Eng = txtTenGD_ENG.Text;
                result.QuocTichGiamDoc_Eng = txtQuocTichGD_ENG.Text;
                result.DiaChiCongTy_Eng = txtDiaChiCT_ENG.Text;
                result.DiaDiemLamViec_Eng = txtDiaDiemLV_ENG.Text;
                result.ChucVuGD_Eng = txtChucVuGD_ENG.Text;
                result.Fax = txtFax.Text;

                db.SubmitChanges();
                GUIHelper.Notifications("Lưu thành công", "Lưu thông tin hợp đồng lao động", GUIHelper.NotifiType.tick);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void toolStripLuu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


