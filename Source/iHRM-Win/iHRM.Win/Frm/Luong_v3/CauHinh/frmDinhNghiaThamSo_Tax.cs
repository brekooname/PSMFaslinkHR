using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject.luongv3;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong_v3
{
    public partial class frmDinhNghiaThamSo_Tax : frmBase
    {
        dcLuongv3DataContext db;
        List<tbLuong_DinhNghiaThamSo_Tax> LstData;

        dlgDinhNghiaThamSo_Tax dlgEditor = new dlgDinhNghiaThamSo_Tax();
        private class KieuDuLieu
        {
            public string Ten { get; set; }
            public int kieuDuLieu { get; set; }
        }
        public frmDinhNghiaThamSo_Tax()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            List<KieuDuLieu> arrKDL = new List<KieuDuLieu>();
            arrKDL.Add(new KieuDuLieu { Ten = "Nhập tay", kieuDuLieu = 1 });
            arrKDL.Add(new KieuDuLieu { Ten = "( --- )", kieuDuLieu = 2 });
            arrKDL.Add(new KieuDuLieu { Ten = "Được tính toán", kieuDuLieu = 3 });
            repositoryItemLookUpEdit1.DataSource = arrKDL;
            repositoryItemLookUpEdit1.DisplayMember = "Ten";
            repositoryItemLookUpEdit1.ValueMember = "kieuDuLieu";

            btnFind_Click(null, null);
            LoadGrvLayout(grv);
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu tham số tính lương...";
            dw_it.OnDoing = (s,ev) => 
            {
                if (string.IsNullOrWhiteSpace(txtSearchKey.Text))
                    LstData = db.tbLuong_DinhNghiaThamSo_Taxes.ToList();
                else
                    LstData = db.tbLuong_DinhNghiaThamSo_Taxes.Where(i => i.ten.IndexOf(txtSearchKey.Text.Trim()) >= 0).ToList();
                dw_it.bw.ReportProgress(1, LstData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = new BindingList<tbLuong_DinhNghiaThamSo_Tax>(LstData);
                btnFind.Enabled = true;
                dlgEditor.LstThamSo = LstData;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var drs = grv.GetSelectedRows().Select(i => grv.GetRow(i) as tbLuong_DinhNghiaThamSo_Tax);
            if (drs.Count() == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            if (!GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa các bản ghi đã chọn?"))
                return;

            try
            {
                db.tbLuong_DinhNghiaThamSo_Taxes.DeleteAllOnSubmit(drs);
                db.SubmitChanges();

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                grv.DeleteSelectedRows();
                dlgEditor.LstThamSo = LstData;

                var log = Log2.CreateLog(Log2.Log2Action.xoa, "Xóa " + drs.Count() + " bản ghi tham số lương", "tbLuong_DinhNghiaThamSo_Tax");
                log.tbLog2_details.AddRange(drs.Select(i => new Core.Business.DbObject.tbLog2_detail()
                {
                    id = Guid.NewGuid(),
                    log_id = log.id,
                    target1 = "id",
                    target2 = "ten",
                    value1 = i.id.ToString(),
                    value2 = i.ten
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
            var r = grv.GetFocusedRow() as tbLuong_DinhNghiaThamSo_Tax;
            if (r != null)
                show_edit(r);
        }
        void show_edit(tbLuong_DinhNghiaThamSo_Tax r)
        {
            dlgEditor.MyValue = r;
            dlgEditor.AttackMode = "edit";
            if (dlgEditor.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
                    dlgEditor.LstThamSo = LstData;

                    var log = Log2.CreateLog(Log2.Log2Action.sua, "Sửa tham số lương " + r.ten, "tbLuong_DinhNghiaThamSo_Tax");
                    Log2.AddLogDetail(log, new string[] {"id",
                        "ma",
                        "ten",
                        "tsIdx",
                        "laCoDinh",
                        "ghiChu",
                        "kieuDuLieu",
                        "kieuNhap",
                        "kieuMapping",
                        "congthuc_id",
                        "moduleDef_id",
                        "giatri_macdinh",
                        "macdinh_theothangtruoc",
                        "lvTinhToan",
                        "hienTrenBangLuong",
                        "nhom",
                        "hienTrenPhieuLuong",
                        "stt"
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
            dlgEditor.MyValue = new tbLuong_DinhNghiaThamSo_Tax();
            dlgEditor.AttackMode = "add";
            if (dlgEditor.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(dlgEditor.MyValue.tsIdx))
                    {
                        int i;
                        string ts_Pre = "ts";
                        if (dlgEditor.MyValue.kieuDuLieu == 2)
                            ts_Pre = "tss";
                        for (i = 1; i < 199; i++)
                            if (db.tbLuong_DinhNghiaThamSo_Taxes.Count(j => j.tsIdx == ts_Pre + i) == 0)
                                break;
                        if (i >= 199)
                        {
                            GUIHelper.MessageBox("Đã hết tham số (Xin vui lòng liên hệ quản trị viên để tiếp tục)");
                            return;
                        }
                        dlgEditor.MyValue.tsIdx = ts_Pre + i;
                    }

                    db.tbLuong_DinhNghiaThamSo_Taxes.InsertOnSubmit(dlgEditor.MyValue);
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);

                    LstData.Add(dlgEditor.MyValue);
                    grd.DataSource = new BindingList<tbLuong_DinhNghiaThamSo_Tax>(LstData);
                    dlgEditor.LstThamSo = LstData;

                    //bật lại form sửa
                    show_edit(dlgEditor.MyValue);

                    var log = Log2.CreateLog(Log2.Log2Action.them, "Thêm tham số lương " + dlgEditor.MyValue.ten, "tbLuong_DinhNghiaThamSo_Tax");
                    Log2.AddLogDetail(log, new string[] {"id",
                        "ma",
                        "ten",
                        "tsIdx",
                        "laCoDinh",
                        "ghiChu",
                        "kieuDuLieu",
                        "kieuNhap",
                        "kieuMapping",
                        "congthuc_id",
                        "moduleDef_id",
                        "giatri_macdinh",
                        "macdinh_theothangtruoc",
                        "lvTinhToan",
                        "hienTrenBangLuong",
                        "nhom",
                        "hienTrenPhieuLuong",
                        "stt"
                    }, dlgEditor.MyValue);
                    Log2.PushLog(log);

                }
                catch (Exception ex)
                {
                    GUIHelper.MessageError(ex.Message);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var r = grv.GetFocusedRow() as tbLuong_DinhNghiaThamSo_Tax;
            if (r != null)
            {
                viewThamSoCongThuc_Tax v = new viewThamSoCongThuc_Tax();
                v.MyId = r.congthuc_id;
                v.Show();
            }
        }

        private void grv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                GridControl grid = sender as GridControl;
                GridView view = grd.FocusedView as GridView;
                Clipboard.SetText(view.GetFocusedDisplayText());
                e.Handled = true;
            }
        }
    }
}
