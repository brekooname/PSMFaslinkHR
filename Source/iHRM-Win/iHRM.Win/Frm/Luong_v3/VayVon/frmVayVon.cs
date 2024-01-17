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

namespace iHRM.Win.Frm.Luong_v3.VayVon
{
    public partial class frmVayVon : frmBase
    {
        dcLuongv3DataContext db;
        List<tbVayVon> LstData;
        tbVayVon CRow = null;

        dlgVayVon dlgEditor = new dlgVayVon();

        public frmVayVon()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
            LoadGrvLayout(grv);

            btnFind.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Find);
            btnAdd.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.New);
            btnEdit.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Edit);
            btnDelete.Enabled = LoginHelper.user.isAdmin || BitHelper.Has(iRule.rules, (int)Enums.eFunction.Delete);

            toolStripButton1.Visible = toolStripButton2.Visible = LoginHelper.user.isAdmin || BitHelper.Has(iRule.customRules ?? 0, 1);
            toolStripSplitButton1.Visible = toolStripButton5.Visible = LoginHelper.user.isAdmin || BitHelper.Has(iRule.customRules ?? 0, 2);
            toolStripButton3.Visible = LoginHelper.user.isAdmin || BitHelper.Has(iRule.customRules ?? 0, 4);
            toolStripButton4.Visible = LoginHelper.user.isAdmin || BitHelper.Has(iRule.customRules ?? 0, 8);
            checkEdit2.Visible = checkEdit3.Visible = checkEdit4.Visible = checkEdit5.Visible = toolStripButton5.Visible = LoginHelper.user.isAdmin ||  BitHelper.Has(iRule.customRules ?? 0, 16);
            if ( !BitHelper.Has(iRule.customRules ?? 0, 16))
            {
                checkEdit2.Visible = checkEdit3.Visible = checkEdit4.Visible = checkEdit5.Visible = toolStripButton5.Visible = true;
            }
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (btnFind.Enabled )
            {
                btnFind.Enabled = false;
                CRow = null;
                db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
                mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
                dw_it.Caption = "Đang tải dữ liệu tham số tính lương...";
                dw_it.OnDoing = (s, ev) =>
                {
                    var qry = db.tbVayVons.Where(i => true);

                    if (!string.IsNullOrWhiteSpace(txtSearchKey.Text))
                        qry = qry.Where(i => i.tenNV.IndexOf(txtSearchKey.Text.Trim()) >= 0);

                    if (checkEdit1.Checked)
                        qry = qry.Where(i => i.status == (int)Enums.eTTVayVon.taoMoi);
                    if (checkEdit2.Checked)
                        qry = qry.Where(i => i.status == (int)Enums.eTTVayVon.daDuyet);
                    if (checkEdit3.Checked)
                        qry = qry.Where(i => i.status == (int)Enums.eTTVayVon.daHoanThanh);
                    if (checkEdit4.Checked)
                        qry = qry.Where(i => i.status == (int)Enums.eTTVayVon.daHuy);
                    if (checkEdit5.Checked)
                        qry = qry.Where(i => i.status == (int)Enums.eTTVayVon.daThanhLy);

                    LstData = qry.ToList();
                    dw_it.bw.ReportProgress(1, LstData);
                };
                dw_it.OnProcessing = (ps, data) =>
                {
                    grd.DataSource = new BindingList<tbVayVon>(LstData);
                    grv_FocusedRowChanged(null, null);
                    btnFind.Enabled = true;
                };

                main.Instance.DoworkItem_Reg(dw_it);
            }
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetRow(i) as tbVayVon);
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            if (!GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa các bản ghi đã chọn?"))
                return;

            try
            {
                db.tbVayVons.DeleteAllOnSubmit(drs);
                db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                grv.DeleteSelectedRows();

                var log = Log2.CreateLog(Log2.Log2Action.xoa, "Xóa " + drs.Count() + " bản ghi", "tbVayVons");
                log.tbLog2_details.AddRange(drs.Select(i => new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "id",
                    target2 = "soHD",
                    value1 = i.id.ToString(),
                    value2 = (i.soHD ?? 0).ToString()
                }).ToArray());
                Log2.PushLog(log);

            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CRow != null)
                show_edit(CRow);
        }
        void show_edit(tbVayVon r)
        {
            dlgEditor.MyValue = r;
            dlgEditor.AttackMode = "edit";
            if (dlgEditor.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);

                    var log = Log2.CreateLog(Log2.Log2Action.sua, "Sửa vay vốn " + r.soHD, "tbVayVon");
                    Log2.AddLogDetail(log, new string[] {"id",
                        "soHD",
                        "soHD_TL",
                        "soHD_XN",
                        "idNV",
                        "tenNV",
                        "ngayTao",
                        "nguoiTao",
                        "soTien",
                        "mucDich",
                        "chungTuDiKem",
                        "traGopTuThang",
                        "traGopSoThang",
                        "traGopMoiThang",
                        "ngayDuyet",
                        "nguoiDuyet",
                        "yKienPheDuyet",
                        "status",
                        "ghiChuThanhLy",
                        "idFile_donXin",
                        "idFile_bienBanXacNhan",
                        "idFile_hopDong",
                        "idFile_thanhLy",
                        "datra"
                    }, r);
                    Log2.PushLog(log);

                }
                catch (Exception ex)
                {
                    GUIHelper.MessageError(ex.Message);
                }
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var v = new tbVayVon();
            v.ngayTao = DateTime.Now;
            v.nguoiTao = LoginHelper.user.id;
            v.traGopTuThang = DateTime.Today.AddMonths(1);
            v.status = 0;

            dlgEditor.MyValue = v;
            dlgEditor.AttackMode = "add";
            if (dlgEditor.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    db.tbVayVons.InsertOnSubmit(dlgEditor.MyValue);
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

                    LstData.Add(dlgEditor.MyValue);
                    grd.DataSource = new BindingList<tbVayVon>(LstData);

                    //bật lại form sửa
                    show_edit(dlgEditor.MyValue);

                    var log = Log2.CreateLog(Log2.Log2Action.them, "Thêm vay vốn " + dlgEditor.MyValue.soHD, "tbVayVon");
                    Log2.AddLogDetail(log, new string[] {"id",
                        "soHD",
                        "soHD_TL",
                        "soHD_XN",
                        "idNV",
                        "tenNV",
                        "ngayTao",
                        "nguoiTao",
                        "soTien",
                        "mucDich",
                        "chungTuDiKem",
                        "traGopTuThang",
                        "traGopSoThang",
                        "traGopMoiThang",
                        "ngayDuyet",
                        "nguoiDuyet",
                        "yKienPheDuyet",
                        "status",
                        "ghiChuThanhLy",
                        "idFile_donXin",
                        "idFile_bienBanXacNhan",
                        "idFile_hopDong",
                        "idFile_thanhLy",
                        "datra"
                    }, dlgEditor.MyValue);
                    Log2.PushLog(log);

                }
                catch (Exception ex)
                {
                    GUIHelper.MessageError(ex.Message);
                }
            }
        }

        dlgVayVon_LyDo frmLD = new dlgVayVon_LyDo();
        void PheDuyet(Enums.eTTVayVon stt)
        {
            if (CRow != null)
            {
                try
                {
                    frmLD.myLyDo = CRow.yKienPheDuyet;
                    if (frmLD.ShowDialog() == DialogResult.OK)
                    {
                        CRow.yKienPheDuyet = frmLD.myLyDo;
                        CRow.nguoiDuyet = LoginHelper.user.id;
                        CRow.ngayDuyet = DateTime.Now;
                        CRow.status = (int)stt;
                        db.SubmitChanges();
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);

                        var log = Log2.CreateLog(Log2.Log2Action.phantich, "Phê duyệt vay vốn " + CRow.soHD, "tbVayVon");
                        Log2.AddLogDetail(log, new string[] {"id",
                        "yKienPheDuyet",
                        "nguoiDuyet",
                        "ngayDuyet",
                        "status"
                    }, CRow);
                        Log2.PushLog(log);

                    }
                }
                catch (Exception ex)
                {
                    if (globall.indebug)
                        throw ex;
                    GUIHelper.MessageBox(ex.Message, "Có lỗi ngoại lệ xảy ra!");
                }
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PheDuyet(Enums.eTTVayVon.daDuyet);
            
            if (CRow != null && CRow.soHD == null)
            {
                CRow.soHD = db.p_vayvonGetNextSoHD();
                db.SubmitChanges();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PheDuyet(Enums.eTTVayVon.daHuy);
        }

        private void grv_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == gridColumn6)
                {
                    var r = e.Row as tbVayVon;
                    if (r != null && Enums.eTTVayVon_Alias.ContainsKey(r.status))
                        e.Value = Enums.eTTVayVon_Alias[r.status];
                }
            }
        }

        private void đơnxinHỗTrợVayTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IN_WORD("don_xin");
        }
        private void IN_WORD(string fName)
        {
            if (CRow == null)
            {
                GUIHelper.MessageBox("Cần chọn bản ghi");
                return;
            }

            var v = db.tbVayVons.SingleOrDefault(i => i.id == CRow.id);
            var nv = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == v.idNV);
            if (nv == null)
            {
                GUIHelper.MessageBox("Cần chọn nhân viên");
                return;
            }

            var sd = new SaveFileDialog();
            sd.Filter = "Word|*.doc;*.docx";

            if (fName == "don_xin")
                sd.FileName = string.Format("HC.D.10.{1:yy}-{0:0000}", v.id, v.ngayTao);
            if (fName == "hd_vay_tien")
                sd.FileName = string.Format("CB.B.07.{1:yy}-{0:0000}", v.soHD, v.ngayTao);
            if (fName == "bien_ban_xac_nhan")
                sd.FileName = string.Format("HC.D.11.{1:yy}-{0:0000}", v.soHD_XN, v.ngayTao);
            if (fName == "thanh_ly_hd")
                sd.FileName = string.Format("HC.B.08.{1:yy}-{0:0000}", v.soHD_TL, v.ngayTao);

            if (sd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var doc = new WordExtend();
                doc.OpenFile(Path.Combine(win_globall.apppath, "ExcelTemplate\\VayVon\\" + fName + ".doc"));
                doc.WriteToBoolmark("chungtu_dikem", v.chungTuDiKem);
                doc.WriteToBoolmark("mucdich", v.mucDich);
                doc.WriteToBoolmark("nv_chucvu", nv.EmpTypeName);
                doc.WriteToBoolmark("nv_cmnd", nv.IDCard);
                doc.WriteToBoolmark("nv_cmnd_ngaycap", nv.IssueDate == null ? "-" : nv.IssueDate.Value.ToString("dd/MM/yyyy"));
                doc.WriteToBoolmark("nv_cmnd_noicap", nv.IssuePlace);
                doc.WriteToBoolmark("nv_diachi", nv.Address);
                doc.WriteToBoolmark("nv_dienthoai_didong", nv.Phone);
                doc.WriteToBoolmark("nv_dienthoai_nha", "");
                doc.WriteToBoolmark("nv_hk_thuongtru", nv.PermanentAddress);
                doc.WriteToBoolmark("nv_phongban", nv.DepName_Final);
                doc.WriteToBoolmark("nv_ten", nv.EmployeeName); 
                doc.WriteToMergeField("mf_nv_ten", nv.EmployeeName);
                doc.WriteToMergeField("mf_nv_ngaynhanvien", string.Format("{0:dd/MM/yyyy}", nv.AppliedDate));
                doc.WriteToMergeField("mf_nv_ngayduyetHD", string.Format("{0:dd/MM/yyyy}", nv.ContractDate));

                doc.WriteToMergeField("mf_sotien", v.soTien.ToString("#,0"));
                doc.WriteToMergeField("mf_sotien1thang", v.traGopMoiThang.ToString("#,0"));

                doc.WriteToMergeField("mf_thangBatDauTra", v.traGopTuThang == null ? "-" : v.traGopTuThang.Value.ToString("MM/yyyy"));

                doc.WriteToBoolmark("sotien", v.soTien.ToString("#,0"));
                doc.WriteToBoolmark("sotien_2", v.soTien.ToString("#,0"));
                doc.WriteToBoolmark("sotien_daTT", string.Format("{0:#,0}", v.tbVayVon_lichSuTras.Where(i => i.kyThanhToan >= 0).Sum(i => i.soTien)));
                doc.WriteToBoolmark("sotien_traThanhLy", string.Format("{0:#,0}", v.tbVayVon_lichSuTras.Where(i => i.kyThanhToan == -1).Sum(i => i.soTien)));
                var sotien_tongTienDaTT = v.tbVayVon_lichSuTras.Sum(i => i.soTien);
                doc.WriteToBoolmark("sotien_tongTienDaTT", string.Format("{0:#,0}", v.tbVayVon_lichSuTras.Sum(i => i.soTien)));
                doc.WriteToBoolmark("sotien_tongTienDaTT_bangchu", ConvertNumber2String.NumberToTextVN(sotien_tongTienDaTT));
                doc.WriteToBoolmark("sotien_bangchu", ConvertNumber2String.NumberToTextVN(v.soTien));
                doc.WriteToBoolmark("sotien_bangchu_2", ConvertNumber2String.NumberToTextVN(v.soTien));
                doc.WriteToBoolmark("sotien1thang", v.traGopMoiThang.ToString("#,0"));
                doc.WriteToBoolmark("sotien1thang_bangchu", ConvertNumber2String.NumberToTextVN(v.traGopMoiThang));

                doc.WriteToBoolmark("thangBatDauTra", v.traGopTuThang == null ? "-" : v.traGopTuThang.Value.ToString("MM/yyyy"));
                doc.WriteToBoolmark("nv_ngaysinh", nv.Birthday == null ? "-" : nv.Birthday.Value.ToString("dd/MM/yyyy"));
                doc.WriteToBoolmark("ngayHomNay", string.Format("ngày {0:dd} tháng {0:MM} năm {0:yyyy}", DateTime.Today));
                doc.WriteToBoolmark("ngayHomNay_2", string.Format("ngày {0:dd} tháng {0:MM} năm {0:yyyy}", DateTime.Today));
                doc.WriteToBoolmark("sothangvay", "" + v.traGopSoThang);
                doc.WriteToBoolmark("sothangvay_2", "" + v.traGopSoThang);
                doc.WriteToBoolmark("ngayTao", string.Format("ngày {0:dd} tháng {0:MM} năm {0:yyyy}", v.ngayTao));
                doc.WriteToBoolmark("ngayduyetHD", string.Format("ngày {0:dd} tháng {0:MM} năm {0:yyyy}", v.ngayDuyet));

                doc.WriteToBoolmark("soCT_donXin", string.Format("HC/D.10/{1:yy}-{0:0000}", v.id, v.ngayTao));
                doc.WriteToBoolmark("soCT_bienBan", string.Format("HC/D.11/{1:yy}-{0:0000}", v.soHD_XN, v.ngayTao));
                doc.WriteToBoolmark("soCT_hopDong", string.Format("CB/B.07/{1:yy}-{0:0000}", v.soHD, v.ngayTao));
                doc.WriteToMergeField("soCT_hopDong", string.Format("CB/B.07/{1:yy}-{0:0000}", v.soHD, v.ngayTao));
                doc.WriteToBoolmark("soCT_thanhLy", string.Format("HC/B.08/{1:yy}-{0:0000}", v.soHD_TL, v.ngayTao));

                doc.Save(sd.FileName);
                win_globall.run(sd.FileName);
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch(Exception ex)
            {
                GUIHelper.MessageError(ex.Message);
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            toolStripSplitButton1.ShowDropDown();
        }

        private void biênBảnXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CRow != null && CRow.soHD_XN == null)
            {
                CRow.soHD_XN = db.p_vayvonGetNextSoHD_XN();
                db.SubmitChanges();
            }

            IN_WORD("bien_ban_xac_nhan");
        }

        private void hợpĐồngVayTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IN_WORD("hd_vay_tien");
        }

        private void thanhLýHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IN_WORD("thanh_ly_hd");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //PheDuyet(Enums.eTTVayVon.daThanhLy);
            
            if (CRow != null)
            {
                dlgVayVon_ThanhLy ls = new dlgVayVon_ThanhLy();
                ls.myID = CRow.id;
                if (ls.ShowDialog() == DialogResult.OK)
                {
                    CRow.status = (int)Enums.eTTVayVon.daThanhLy;
                    grd.RefreshDataSource();
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (CRow != null)
            {
                dlgVayVon_LichSuTra ls = new dlgVayVon_LichSuTra();
                ls.vayvon_id = CRow.id;
                ls.Show(this);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            IN_WORD("don_xin");
        }

        private void grv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CRow = grv.GetFocusedRow() as tbVayVon;

            biênBảnXácNhậnToolStripMenuItem.Enabled = false;
            hợpĐồngVayTiềnToolStripMenuItem.Enabled = false;
            thanhLýHợpĐồngToolStripMenuItem.Enabled = false;

            if (CRow != null)
            {
                switch (CRow.status)
                {
                    case (int)Enums.eTTVayVon.daDuyet:
                        biênBảnXácNhậnToolStripMenuItem.Enabled = true;
                        hợpĐồngVayTiềnToolStripMenuItem.Enabled = true;
                        thanhLýHợpĐồngToolStripMenuItem.Enabled = true;
                        break;
                    case (int)Enums.eTTVayVon.daHoanThanh:
                        thanhLýHợpĐồngToolStripMenuItem.Enabled = true;
                        break;
                    case (int)Enums.eTTVayVon.daHuy:
                        break;
                    case (int)Enums.eTTVayVon.daThanhLy:
                        thanhLýHợpĐồngToolStripMenuItem.Enabled = true;
                        break;
                    case (int)Enums.eTTVayVon.taoMoi:
                        break;
                }
            }
        }
    }
}
