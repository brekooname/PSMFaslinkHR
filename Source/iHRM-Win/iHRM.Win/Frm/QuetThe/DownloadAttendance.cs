using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using iHRM.Win.ExtClass;

namespace iHRM.Win.Frm.QuetThe
{
    public partial class DownloadAttendance : dlgCustomBase
    {
        iHRM.Core.Business.Logic.ChamCong.dsMayChamCong dbMayChamCong;
        public DownloadAttendance()
        {
            InitializeComponent();
            dbMayChamCong = new Core.Business.Logic.ChamCong.dsMayChamCong();
        }
        private void XuLyDuLieu_Load(object sender, EventArgs e)
        {

            this.Form_Title = SelectTranslate("DownloadAttendance_Title", LoginHelper.langTrans);
            this.Text = SelectTranslate("DownloadAttendance_Title", LoginHelper.langTrans);

            dateTuNgay.DateTime = dateDenNgay.DateTime = DateTime.Today;
            this.Form_Description = SelectTranslate("DownloadAttendance_Des", LoginHelper.langTrans)+" " + Interface_Company.strLuuDataQuetThe;
            lblTuNgay.Text = SelectTranslate("DownloadAttendance_TuNgay", LoginHelper.langTrans);
            lblDenNgay.Text = SelectTranslate("DownloadAttendance_DenNgay", LoginHelper.langTrans);
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            DateTime TuNgay = dateTuNgay.DateTime;
            DateTime DenNgay = new DateTime(dateDenNgay.DateTime.Year, dateDenNgay.DateTime.Month, dateDenNgay.DateTime.Day, 23, 59, 59);
            DataTable dataInOut = GetData(TuNgay, DenNgay);
            for (DateTime i = TuNgay; i <= DenNgay;)
            {
                StreamWriter sw = new StreamWriter(string.Format(Interface_Company.strLuuDataQuetThe + "\\{0:00}-{1:00}-{2:0000}.txt", i.Month, i.Day, i.Year));
                try
                {
                    var q = dataInOut.Select(string.Format("TimeDate = '{0}'", i));
                    foreach (var item in q)
                    {
                        sw.WriteLine(string.Format("{0:000},{1},{2},{3:dd/MM/yyyy},{4:HH:mm:ss},{5}", item["MachineNo"], item["UserFullCode"], item["WorkCode"], item["TimeDate"], item["TimeStr"], item["EmployeeID"]));
                    }
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                catch (Exception)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                i = i.AddDays(1);
            }
            GUIHelper.Notifications("Lấy dữ liệu thành công", "Download dữ liệu quẹt thẻ", GUIHelper.NotifiType.info);
        }
        private DataTable GetData(DateTime TuNgay, DateTime DenNgay)
        {
            SqlConnection connection = new SqlConnection(Provider.ConnectionString_MCC);
            connection.Open();
            using (var conn = connection)
            {
                // Define the command 
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "p_GetDataQuetThe"; // Tên Store
                    cmd.Parameters.Add(new SqlParameter("tuNgay", TuNgay));
                    cmd.Parameters.Add(new SqlParameter("denNgay", DenNgay));
                    try
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            var data = new DataTable();
                            if (dr.HasRows)
                                data.Load(dr);
                            return data;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

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
    }
}
