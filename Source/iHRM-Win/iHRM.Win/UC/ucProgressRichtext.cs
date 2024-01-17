using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iHRM.Win.UC
{
    // Dùng cái này. Không bị giật nếu set messeage nhiều
    public partial class ucProgressRichtext : DevExpress.XtraEditors.XtraUserControl
    {
        public ucProgressRichtext()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Message: Tin nhắn báo lỗi or thành công của từng record ghi vào memoResult.
        /// Get: Lấy tin nhắn từ memoResult.
        /// Set: Set tin nhắn từ memoResult.
        /// </summary>
        public string Message
        {
            get
            {
                return rtb.Text;
            }
            set
            {
                rtb.AppendText("\n" + value);
            }
        }
        /// <summary>
        /// Status: Trạng thái thanh status.
        /// VD: Đang đăng ký ....
        ///     Đăng ký thành công 10/100.
        /// </summary>
        public string Status
        {
            get
            {
                return lbStatus.Text;
            }
            set
            {
                lbStatus.Text = value;
            }
        }
        /// <summary>
        /// Giả sử CurrentValue =50. Thanh barProcess sẽ chạy đc nửa.
        /// </summary>
        public int CurrentValue
        {
            get
            {
                return (int)progrBar.EditValue;
            }
            set
            {
                progrBar.EditValue = value;
            }
        }
        /// <summary>
        /// Khởi động chạy BarProcess, Gán rỗng cho memoResult và Status
        /// </summary>
        /// <param name="minValue">Giá trị nhỏ nhất của BarProcess</param>
        /// <param name="maxValue">Giá trị lớn nhất của BarProcess</param>
        public void start(int minValue, int maxValue)
        {
            progrBar.Position = 0;
            progrBar.Properties.Minimum = minValue;
            progrBar.Properties.Maximum = maxValue;
            rtb.Text = "";
            progrBar.EditValue = 0;
            lbStatus.Text = "";
        }
    }
    //public class Progress
    //{
    //    private int _minValue;
    //    private int _maxValue;
    //    private int _CurrentValue;
    //    private string _lbStatus;
    //    private string _lbNotes;
    //    public int MinValue
    //    {
    //        get { return _minValue; }
    //        set { _minValue = value; }
    //    }
    //    public int MaxValue
    //    {
    //        get { return _maxValue; }
    //        set { _maxValue = value; }
    //    }
    //    public int CurrentValue
    //    {
    //        get { return _CurrentValue; }
    //        set
    //        {
    //            _CurrentValue = value;
    //        }
    //    }
    //    public string LbStatus
    //    {
    //        get { return _lbStatus; }
    //        set
    //        {
    //            _lbStatus = value;
    //        }
    //    }
    //    public string LbNotes
    //    {
    //        get { return _lbNotes; }
    //        set
    //        {
    //            _lbNotes = value;
    //        }
    //    }

    //}

}
