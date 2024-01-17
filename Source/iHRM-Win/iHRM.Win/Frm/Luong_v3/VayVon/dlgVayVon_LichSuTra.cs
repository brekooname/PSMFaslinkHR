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
    public partial class dlgVayVon_LichSuTra : frmBase
    {
        dcLuongv3DataContext db;
        List<tbVayVon_lichSuTra> LstData;
        public int vayvon_id { get; set; }

        dlgVayVon dlgEditor = new dlgVayVon();

        public dlgVayVon_LichSuTra()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            btnFind_Click(null, null);
            LoadGrvLayout(grv);
        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            db = new dcLuongv3DataContext(Core.Business.Provider.ConnectionString);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu tham số vay vốn...";
            dw_it.OnDoing = (s,ev) => 
            {
                var qry = db.tbVayVon_lichSuTras.Where(i => i.idVayVon == vayvon_id).OrderBy(p=>p.ngayThanhToan);
                
                LstData = qry.ToList();
                dw_it.bw.ReportProgress(1, LstData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd.DataSource = new BindingList<tbVayVon_lichSuTra>(LstData);
                btnFind.Enabled = true;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        
        private void grv_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                if (e.Column == gridColumn6)
                {
                    var r = e.Row as tbVayVon_lichSuTra;
                    if (r != null && Enums.eTTVayVon_Alias.ContainsKey(r.status))
                        e.Value = Enums.eTTVayVon_Alias[r.status];
                }
            }
        }
        
    }
}
