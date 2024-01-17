﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Core.Business;
using iHRM.Win.Cls;
using System.Threading;
using System.Net.NetworkInformation;
using iHRM.Core.Business.DbObject;
using AttMachineCore;
using iHRM.Common.Code;
using System.Reflection;

namespace iHRM.Win.Frm.MayChamCong
{
    public partial class TaiDuLieuMayChamCong : DevExpress.XtraEditors.XtraForm
    {
        AttMachineTools BioMatrix = new AttMachineTools();

        dcDatabaseMCCDataContext db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);

        //int iMachineNumber = 1;

        List<tbNhanVien> _lTTNV = new List<tbNhanVien>();

        List<tbCheckInOut> _lTAttendance = new List<tbCheckInOut>();

        List<tbNhanVien_Finger> _lNhanVien_Finger = new List<tbNhanVien_Finger>();

        public TaiDuLieuMayChamCong()
        {
            InitializeComponent();
        }

        private void KhaibaoMCC_Load(object sender, EventArgs e)
        {
            //groupDuLieuQuetThe.Width = this.Width / 2;

            dateTuNgay.DateTime = dateDenNgay.DateTime = DateTime.Now;

            lookupMayChamCong.Properties.ValueMember = "id";

            lookupMayChamCong.Properties.DisplayMember = "tenMay";

            lookupMayChamCong.Properties.DataSource = db.tbMayChamCongs.OrderBy(p => p.tenMay).AsEnumerable().ToList<tbMayChamCong>();

            if (db.tbMayChamCongs.Count() > 0)
            {
                lookupMayChamCong.EditValue = db.tbMayChamCongs.OrderBy(p => p.tenMay).First().id;
            }
            TranslateForm();
        }
        private bool pingAddress(string IP, int miliSecond)
        {
            Ping ping = new Ping();

            if (ping.Send(IP, miliSecond).Status == IPStatus.Success)

                return true;

            else

                return false;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (!bgr_Download.IsBusy)

                bgr_Download.RunWorkerAsync();
        }

        private void SaveDataToDataBase()
        {
            try
            {
                if (chkLuu.Checked)
                {
                    bgr_Download.ReportProgress(1, " Lưu dữ liệu quẹt thẻ vào database....");

                    foreach (tbCheckInOut item in _lTAttendance)
                    {
                        if (db.tbCheckInOuts.Where(p => p.tgQuet == item.tgQuet && p.maChamCong == item.maChamCong).Count() == 0) 
                        {
                            db.tbCheckInOuts.InsertOnSubmit(item);
                        }
                    }

                    db.SubmitChanges();

                    bgr_Download.ReportProgress(3, " Lưu dữ liệu quẹt thẻ vào database thành công.");
                }


            }
            catch (Exception)
            {
                bgr_Download.ReportProgress(2, " Lưu dữ liệu quẹt thẻ không thành công.");
            }
        }
        //private object downDuLieuQuetThe()
        //{
        //    int soMay = 0;
        //    if (radioMCC.SelectedIndex == 0)// radioMCC.SelectedIndex == 0. Chọn 1 máy chấm công.
        //    {
        //        if (Connect_MCC(lookupMayChamCong.GetColumnValue("diaChiIP").ToString(), lookupMayChamCong.GetColumnValue("port").ToString(), lookupMayChamCong.GetColumnValue("tenMay").ToString()))
        //        {
        //            soMay = Convert.ToInt16(lookupMayChamCong.GetColumnValue("soMay"));

        //            DateTime tuNgay = new DateTime(dateTuNgay.DateTime.Year, dateTuNgay.DateTime.Month, dateTuNgay.DateTime.Day, 0, 0, 0);
        //            DateTime denNgay = new DateTime(dateDenNgay.DateTime.Year, dateDenNgay.DateTime.Month, dateDenNgay.DateTime.Day, 23, 59, 59);
        //            bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu quẹt thẻ....");
        //            var a = BioMatrix.GetAttMachine(tuNgay, denNgay);
        //            foreach (var item in a)
        //            {
        //                _lTAttendance.Add(new tbCheckInOut
        //                {
        //                    maChamCong = item.EnrollNumber,
        //                    soMay = soMay,
        //                    tgQuet = item.DateTimePunch,
        //                    ngayQuet = item.DatePunch
        //                });
        //            }
        //            bgr_Download.ReportProgress(3, "Tải thành công " + _lTAttendance.Count + " record.");
        //        }
        //    }
        //    else // radioMCC.SelectedIndex == 1. Chọn tất cả các máy chấm công.
        //    {
        //        List<tbMayChamCong> a = (List<tbMayChamCong>)lookupMayChamCong.Properties.DataSource;
        //        DateTime tuNgay = new DateTime(dateTuNgay.DateTime.Year, dateTuNgay.DateTime.Month, dateTuNgay.DateTime.Day, 0, 0, 0);
        //        DateTime denNgay = new DateTime(dateDenNgay.DateTime.Year, dateDenNgay.DateTime.Month, dateDenNgay.DateTime.Day, 23, 59, 59);

        //        soMay = Convert.ToInt16(lookupMayChamCong.GetColumnValue("soMay"));

        //        foreach (var item in a)
        //        {
        //            int count = _lTAttendance.Count;
        //            if (Connect_MCC(item.diaChiIP, item.port, item.tenMay))
        //            {
        //                soMay = item.soMay;
        //                bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu quẹt thẻ....");
        //                var a2 = BioMatrix.GetAttMachine(tuNgay, denNgay);
        //                foreach (var item2 in a2)
        //                {
        //                    _lTAttendance.Add(new tbCheckInOut
        //                    {
        //                        maChamCong = item2.EnrollNumber,
        //                        soMay = soMay,
        //                        tgQuet = item2.DateTimePunch,
        //                        ngayQuet = item2.DatePunch
        //                    });
        //                }
        //                bgr_Download.ReportProgress(3, "Tải thành công " + _lTAttendance.Count + " record.");
        //            }
        //        }
        //    }
        //    return _lTAttendance;
        //}
        private object downDuLieuChamCong()
        {
            int soMay = 0;

            if (radioMCC.SelectedIndex == 0)// radioMCC.SelectedIndex == 0. Chọn 1 máy chấm công.
            {
                if (Connect_MCC(lookupMayChamCong.GetColumnValue("diaChiIP").ToString(), lookupMayChamCong.GetColumnValue("port").ToString(), lookupMayChamCong.GetColumnValue("tenMay").ToString()))
                {
                    soMay = Convert.ToInt16(lookupMayChamCong.GetColumnValue("soMay"));

                    DateTime tuNgay = new DateTime(dateTuNgay.DateTime.Year, dateTuNgay.DateTime.Month, dateTuNgay.DateTime.Day, 0, 0, 0);

                    DateTime denNgay = new DateTime(dateDenNgay.DateTime.Year, dateDenNgay.DateTime.Month, dateDenNgay.DateTime.Day, 23, 59, 59);

                    bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu quẹt thẻ....");

                    var a = BioMatrix.GetAttMachine(tuNgay, denNgay);

                    foreach (var item in a)
                    {
                        _lTAttendance.Add(new tbCheckInOut
                        {
                            maChamCong = item.EnrollNumber,
                            soMay = soMay,
                            tgQuet = item.DateTimePunch,
                            ngayQuet = item.DatePunch,
                            tgMayClient = DateTime.Now,
                            tgMayServer = ExtClass.Interface_Company.DateServer()

                        });
                    }

                    bgr_Download.ReportProgress(3, "Tải thành công " + _lTAttendance.Count + " record.");

                }
            }
            else // radioMCC.SelectedIndex == 1. Chọn tất cả các máy chấm công.
            {
                List<tbMayChamCong> a = (List<tbMayChamCong>)lookupMayChamCong.Properties.DataSource;

                DateTime tuNgay = new DateTime(dateTuNgay.DateTime.Year, dateTuNgay.DateTime.Month, dateTuNgay.DateTime.Day, 0, 0, 0);

                DateTime denNgay = new DateTime(dateDenNgay.DateTime.Year, dateDenNgay.DateTime.Month, dateDenNgay.DateTime.Day, 23, 59, 59);

                soMay = Convert.ToInt16(lookupMayChamCong.GetColumnValue("soMay"));

                foreach (var item in a)
                {
                    int count = _lTAttendance.Count;

                    if (Connect_MCC(item.diaChiIP, item.port, item.tenMay))
                    {
                        soMay = item.soMay;

                        bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu quẹt thẻ....");

                        var a2 = BioMatrix.GetAttMachine(tuNgay, denNgay);

                        foreach (var item2 in a2)
                        {
                            _lTAttendance.Add(new tbCheckInOut
                            {
                                maChamCong = item2.EnrollNumber,
                                soMay = soMay,
                                tgQuet = item2.DateTimePunch,
                                ngayQuet = item2.DatePunch,
                                tgMayClient = DateTime.Now,
                                tgMayServer = ExtClass.Interface_Company.DateServer()
                            });
                        }

                        bgr_Download.ReportProgress(3, "Tải thành công " + _lTAttendance.Count + " record.");
                    }
                }
            }

            return _lTAttendance;
        }
        private object downVanTayNV()
        {
            int soMay = 0;

            DateTime tuNgay = new DateTime(dateTuNgay.DateTime.Year, dateTuNgay.DateTime.Month, dateTuNgay.DateTime.Day, 0, 0, 0);

            DateTime denNgay = new DateTime(dateDenNgay.DateTime.Year, dateDenNgay.DateTime.Month, dateDenNgay.DateTime.Day, 23, 59, 59);

            if (radioMCC.SelectedIndex == 0)// radioMCC.SelectedIndex == 0. Chọn 1 máy chấm công.
            {
                if (Connect_MCC(lookupMayChamCong.GetColumnValue("diaChiIP").ToString(), lookupMayChamCong.GetColumnValue("port").ToString(), lookupMayChamCong.GetColumnValue("tenMay").ToString()))
                {
                    soMay = Convert.ToInt16(lookupMayChamCong.GetColumnValue("soMay"));

                    //axCZKEM1.ReadAllTemplate(1);//read all the users' fingerprint templates to the memory

                    bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu vân tay....");

                    var a = BioMatrix.GetAllUserTemp_ColorDivice();

                    if (a.Count() > 0)
                    {
                        foreach (var item in a)
                        {
                            foreach (var item2 in item._lFinger)
                            {
                                _lNhanVien_Finger.Add(new tbNhanVien_Finger
                                {
                                    maChamCong = Convert.ToInt32(item.EnrollNumber),
                                    num_Finger = item2.FingerIdx,
                                    str_Finger = item2.FingerStr,
                                    //byte_Finger = new System.Data.Linq.Binary( item2.FingerData.to)
                                });
                            }
                        }
                    }

                    bgr_Download.ReportProgress(3, " Tải thành công " + _lNhanVien_Finger.Count + " dữ liệu vân tay.");

                }
            }
            else
            {
                MessageBox.Show("Bạn chỉ có thể tải dữ liệu vân tay từ 1 máy chấm công!", "Tải dữ liệu vân tay", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _lNhanVien_Finger;
        }
        private object downThongTinNV()
        {
            if (radioMCC.SelectedIndex == 0)// radioMCC.SelectedIndex == 0. Chọn 1 máy chấm công.
            {
                if (Connect_MCC(lookupMayChamCong.GetColumnValue("diaChiIP").ToString(), lookupMayChamCong.GetColumnValue("port").ToString(), lookupMayChamCong.GetColumnValue("tenMay").ToString()))
                {
                    var a = BioMatrix.getAllUserInfor().ToList();

                    bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu nhân viên....");

                    foreach (var item in a)
                    {
                        _lTTNV.Add(new tbNhanVien
                        {
                            maChamCong = Convert.ToInt32(item.EnrollNumber),
                            tenChamCong = item.Name,
                            maThe = item.CardNumber
                        }
                        );
                    }

                    bgr_Download.ReportProgress(3, " Tải thành công " + _lTTNV.Count + " nhân viên.");
                }
            }
            else // radioMCC.SelectedIndex == 1. Chọn tất cả các máy chấm công.
            {
                List<tbMayChamCong> mcc = (List<tbMayChamCong>)lookupMayChamCong.Properties.DataSource;

                foreach (var item in mcc)
                {
                    int count = _lTTNV.Count;

                    if (Connect_MCC(item.diaChiIP, item.port, item.tenMay))
                    {
                        if (Connect_MCC(lookupMayChamCong.GetColumnValue("diaChiIP").ToString(), lookupMayChamCong.GetColumnValue("port").ToString(), lookupMayChamCong.GetColumnValue("tenMay").ToString()))
                        {
                            var a = BioMatrix.getAllUserInfor().ToList();

                            bgr_Download.ReportProgress(1, "Bắt đầu tải dữ liệu nhân viên....");

                            foreach (var item2 in a)
                            {
                                _lTTNV.Add(new tbNhanVien
                                {
                                    maChamCong = Convert.ToInt32(item2.EnrollNumber),
                                    tenChamCong = item2.Name,
                                    maThe = item2.CardNumber
                                }
                                );
                            }

                            bgr_Download.ReportProgress(3, " Tải thành công " + _lTTNV.Count + " nhân viên.");
                        }
                    }
                }
            }

            return _lTTNV;
        }
        private bool Connect_MCC(string IP, string Port, string tenMay)
        {
            if (IP.Trim() == "" || Port.Trim() == "")
            {
                bgr_Download.ReportProgress(2, "Máy " + tenMay + " chưa có IP hoặc Port");

                return false;
            }

            bgr_Download.ReportProgress(1, "Kết nối máy " + tenMay + "....");

            bgr_Download.ReportProgress(3, "");

            bgr_Download.ReportProgress(3, "---- Máy chấm công " + tenMay);

            bgr_Download.ReportProgress(2, "");

            bgr_Download.ReportProgress(2, "---- Máy chấm công " + tenMay);

            bool bIsConnected = false;

            bIsConnected = BioMatrix.PingAddress(IP, 3000);

            if (bIsConnected)
            {
                bgr_Download.ReportProgress(3, " Ping thành công máy " + tenMay);
            }
            else
            {
                bgr_Download.ReportProgress(2, " Ping không thành công máy " + tenMay);

                return false;
            }

            bIsConnected = BioMatrix.Connect_Net(IP, Convert.ToInt32(Port));

            if (bIsConnected == true)
            {
                bgr_Download.ReportProgress(3, "Kết nối thành công " + tenMay);
            }
            else
            {
                bgr_Download.ReportProgress(2, " Kết nối không thành công máy " + tenMay);
            }

            return bIsConnected;
        }

        private void radioMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioMethod.SelectedIndex == 1)
            {
                radioMCC.SelectedIndex = 0;

                dateDenNgay.Enabled = dateTuNgay.Enabled = false;
            }
            else
            {
                dateDenNgay.Enabled = dateTuNgay.Enabled = true;
            }

        }

        private void radioMCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioMCC.SelectedIndex == 0)
            {
                lookupMayChamCong.Enabled = true;
            }
            else
            {
                lookupMayChamCong.Enabled = false;
            }
        }

        private void bgr_Download_DoWork(object sender, DoWorkEventArgs e)
        {
            // Bấm click download
            progressBar.Properties.Paused = false;

            if (Convert.ToInt32(radioMethod.EditValue) == 0) // Tải dữ liệu quẹt trên máy
            {
                _lTAttendance.Clear();

                var a = downDuLieuChamCong();

                bgr_Download.ReportProgress(7, a);

                SaveDataToDataBase();

                bgr_Download.ReportProgress(1, "Kết thúc!");

            }
            else if (Convert.ToInt32(radioMethod.EditValue) == 1)// Tải dữ liệu thông tin nhân viên trên máy
            {
                _lTTNV.Clear();

                var a = downThongTinNV();

                bgr_Download.ReportProgress(5, a);

                bgr_Download.ReportProgress(1, "Kết thúc!");

            }
            else if(Convert.ToInt32(radioMethod.EditValue) == 2) // Tải vân tay nhân viên trên máy
            {
                _lNhanVien_Finger.Clear();

                var a = downVanTayNV();

                bgr_Download.ReportProgress(6, a);

                bgr_Download.ReportProgress(1, "Kết thúc!");

            }
        }

        private void bgr_Download_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1) // 1: Hiển thị process bằng label.
            {
                lbProcess.Text = e.UserState.ToString();
            }
            else if (e.ProgressPercentage == 2) // 2: Nếu lỗi. Lưu vào listBoxError.
            {
                listBoxError.Items.Add(e.UserState.ToString());
            }
            else if (e.ProgressPercentage == 3) // 3: Nếu thành công. Lưu vào listBoxResult.
            {
                listBoxResult.Items.Add(e.UserState.ToString());
            }
            else if (e.ProgressPercentage == 4) // 4: Nếu thành công. Lưu vào Grid Dữ liệu quẹt thẻ.
            {
                grcQuetThe.DataSource = null;

                grcQuetThe.DataSource = e.UserState;

            }
            else if (e.ProgressPercentage == 5) // 5: Nếu thành công. Lưu vào Grid Thông tin nhân viên.
            {
                grcTTNV.DataSource = null;

                grcTTNV.DataSource = e.UserState;

            }
            else if (e.ProgressPercentage == 6) // 6: Nếu thành công. Lưu vào Grid Vân tay.
            {
                grcVanTay.DataSource = null;

                grcVanTay.DataSource = e.UserState;

            }else if (e.ProgressPercentage == 7) // 6: Nếu thành công. Lưu vào Grid Vân tay.
            {
                grcQuetThe.DataSource = null;

                grcQuetThe.DataSource = e.UserState;
            }
        }

        private void bgr_Download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panelControl7.Enabled = true;

            progressBar.Properties.Paused = true;
        }

        private void btnUpdateVanTay_Click(object sender, EventArgs e)
        {
            if (_lNhanVien_Finger.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu vân tay nào để lưu", "Lưu dữ liệu vân tay", MessageBoxButtons.OK);
            }

            DialogResult dr = MessageBox.Show("Nếu bạn đồng ý, Dữ liệu vân tay từ máy chấm công sẽ được lưu đè vào máy chủ. Bạn có chắc chắn muốn lưu?"
                                                , "Lưu dữ liệu vân tay"
                                                , MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    List<tbNhanVien_Finger> lNhanVienUpdate = new List<tbNhanVien_Finger>();

                    dcDatabaseMCCDataContext db = new dcDatabaseMCCDataContext(Provider.ConnectionString_MCC);

                    //db.ExecuteCommand("TRUNCATE TABLE tbNhanVien_Finger");

                    foreach (var idxRow in grvVanTay.GetSelectedRows())
                    {
                        tbNhanVien_Finger nv = (tbNhanVien_Finger) grvVanTay.GetRow(idxRow);

                        lNhanVienUpdate.Add(nv);
                    }
                    foreach (var item in lNhanVienUpdate)
                    {
                        var f = db.tbNhanVien_Fingers.Where(p => p.maChamCong == item.maChamCong && p.num_Finger == item.num_Finger).FirstOrDefault();

                        if (f == null) // nếu không tồn tại mã chấm công và số ngón tay thì insert
                        {
                            db.tbNhanVien_Fingers.InsertOnSubmit(item); 

                            db.SubmitChanges(); 
                        }
                        else // chấm công và số ngón tay tồn tại thì update str_Finger
                        {
                            f.str_Finger = item.str_Finger;
 
                            db.SubmitChanges(); 
                        }
                    }
                    GUIHelper.Notifications("Lấy dữ liệu vân tay về máy tính thành công!","Lấy dữ liệu vân tay",GUIHelper.NotifiType.download);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
        #region Translate language
        public static List<string> listCtr = new List<string>();
        public static Dictionary<string, string> myData = new Dictionary<string, string>();

        private IEnumerable<DevExpress.XtraGrid.Columns.GridColumn> EnumerateGridColumn()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraGrid.Columns.GridColumn).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraGrid.Columns.GridColumn)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<DevExpress.XtraEditors.SimpleButton> EnumerateSimpleButton()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.SimpleButton).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.SimpleButton)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<ToolStripButton> EnumerateToolStripButton()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(ToolStripButton).IsAssignableFrom(field.FieldType)
                   let component = (ToolStripButton)field.GetValue(this)
                   where component != null
                   select component;
        }

        private IEnumerable<DevExpress.XtraEditors.LabelControl> EnumerateLabelControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.LabelControl).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.LabelControl)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<DevExpress.XtraEditors.CheckEdit> EnumerateCheckEdit()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.CheckEdit).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.CheckEdit)field.GetValue(this)
                   where component != null
                   select component;
        }
        private IEnumerable<DevExpress.XtraEditors.GroupControl> EnumerateGroupControl()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraEditors.GroupControl).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraEditors.GroupControl)field.GetValue(this)
                   where component != null
                   select component;
        }
        //DevExpress.XtraGrid.Views.BandedGrid.GridBand
        private IEnumerable<DevExpress.XtraGrid.Views.BandedGrid.GridBand> EnumerateGridBand()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(DevExpress.XtraGrid.Views.BandedGrid.GridBand).IsAssignableFrom(field.FieldType)
                   let component = (DevExpress.XtraGrid.Views.BandedGrid.GridBand)field.GetValue(this)
                   where component != null
                   select component;
        }
        public string SelectTranslate(string nameCrt, string lang)
        {
            //get data
            DataSet ds = Provider.ExecuteDataSetReader("p_Translate",

                           new System.Data.SqlClient.SqlParameter("CtrName", nameCrt),

                           new System.Data.SqlClient.SqlParameter("FormName", this.Name.ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                //có dữ liệu cho dùng chung
                if (ds.Tables[1].Rows.Count == 0)
                {
                    //không dùng riêng
                    return ds.Tables[0].Rows[0][lang].ToString().Trim();

                }
                else
                {
                    // có dùng riêng 
                    return ds.Tables[1].Rows[0][lang].ToString().Trim();
                }
            }
            else
            {
                return "";
            }

        }
        public void TranslateForm()
        {
            myData.Clear();
            listCtr.Clear();
            string langTrans = LoginHelper.langTrans;
            string formText = SelectTranslate(this.Name, langTrans);
            if (formText != "")
            {
                this.Text = formText;
            }
            #region Khai báo list loai control trong form
            var _GridColumn = EnumerateGridColumn();
            var _ToolStripButton = EnumerateToolStripButton();
            var _LableControl = EnumerateLabelControl();
            var _SimpleButton = EnumerateSimpleButton();
            var _CheckEdit = EnumerateCheckEdit();
            var _GridBand = EnumerateGridBand();
            var _GroupControl = EnumerateGroupControl();
            #endregion

            #region Dịch form
            foreach (DevExpress.XtraGrid.Columns.GridColumn s in _GridColumn)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Caption);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Caption = trans;
                }
            }
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand s in _GridBand)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Caption);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Caption = trans;
                }
            }
            foreach (ToolStripButton s in _ToolStripButton)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.SimpleButton s in _SimpleButton)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.LabelControl s in _LableControl)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.GroupControl s in _GroupControl)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            foreach (DevExpress.XtraEditors.CheckEdit s in _CheckEdit)
            {
                listCtr.Add(s.Name);
                myData.Add(s.Name, s.Text);
                string trans = SelectTranslate(s.Name, langTrans);
                if (trans != "")
                {
                    s.Text = trans;
                }
            }
            myData.Add(this.Name, this.Text);
            listCtr.Add(this.Name);
            radioMCC.Properties.Items[0].Description = SelectTranslate("radioMCC_0", langTrans);
            radioMCC.Properties.Items[1].Description = SelectTranslate("radioMCC_1", langTrans);

            radioMethod.Properties.Items[0].Description = SelectTranslate("radioMethod_0", langTrans);
            radioMethod.Properties.Items[1].Description = SelectTranslate("radioMethod_1", langTrans);
            radioMethod.Properties.Items[2].Description = SelectTranslate("radioMethod_2", langTrans);

            #endregion
        }

        #endregion
        private void TaiDuLieuMayChamCong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                // mở form dịch            
                Translate.frmTranslate frm = new Translate.frmTranslate();
                frm.listCtrontrol = listCtr;
                frm.myDataControl = myData;
                frm.formName = this.Name;
                frm.ShowDialog();
                KhaibaoMCC_Load(null, null);
            }
        }
    }
}