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
    public partial class dlgVayVon_ThanhLy : dlgCustomBase
    {
        dcLuongv3DataContext db = new dcLuongv3DataContext(Provider.ConnectionString);

        private tbVayVon myValue = null;
        public int? myID
        {
            get {
                if (myValue == null)
                {
                    return null;
                }
                else
                {
                    return myValue.id;
                }
            }
            set
            {
                myValue = db.tbVayVons.SingleOrDefault(i => i.id == value);
                ucFileStorage1.myID = myValue.idFile_thanhLy;
            }
        }

        public dlgVayVon_ThanhLy()
        {
            InitializeComponent();
        }
        private void dlgDinhNghiaThamSo_Load(object sender, EventArgs e)
        {
            txtSoTienConLai.EditValue = (myValue.soTien - myValue.tbVayVon_lichSuTras.Where(i => i.status == 1).Sum(i => i.soTien));
        }
        
        private void dlgDangKyCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkEdit1.Checked)
            {
                GUIHelper.MessageBox("Bạn cần xác nhận đã trả tiền");
                return;
            }

            try
            {
                using (var ts = new System.Transactions.TransactionScope())
                {
                    myValue.status = (int)Enums.eTTVayVon.daThanhLy;
                    myValue.ghiChuThanhLy = txtLyDo.Text;
                    ucFileStorage1.DelAndUploadNewFile(); myValue.idFile_thanhLy = ucFileStorage1.myID;
                    if (myValue.soHD_TL == null)
                        myValue.soHD_TL = db.p_vayvonGetNextSoHD_TL();
                    db.SubmitChanges();

                    var ls = new tbVayVon_lichSuTra();
                    ls.id = Guid.NewGuid();
                    ls.idNV = myValue.idNV;
                    ls.idVayVon = myValue.id;
                    ls.kyThanhToan = -1;
                    ls.ngayBatDau = myValue.traGopTuThang;
                    ls.ngayThanhToan = DateTime.Now;
                    ls.soTien = (myValue.soTien - myValue.tbVayVon_lichSuTras.Where(i => i.status == 1).Sum(i => i.soTien));
                    ls.status = 1;
                    ls.tenNV = myValue.tenNV;
                    db.tbVayVon_lichSuTras.InsertOnSubmit(ls);
                    db.SubmitChanges();

                    ts.Complete();
                }

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
                this.DialogResult = DialogResult.OK;
                this.Close();

                var log = Log2.CreateLog(Log2.Log2Action.phantich, "Thanh lý vay vốn " + myValue.id, "tbVayVon");
                log.tbLog2_details.Add(new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "id",
                    value1 = myValue.id.ToString(),
                });
                Log2.PushLog(log);
            }
            catch(Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
    }
}
