using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iHRM.Win.UC
{
    public partial class Logger : UserControl
    {
        public Logger()
        {
            InitializeComponent();
        }

        public enum LogType { normal, success, warning, error }
        public void OutLog(string msg, LogType type = LogType.normal)
        {
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.AppendText(string.Format("{0:HH:mm:ss} ", DateTime.Now));
            switch (type)
            {
                case LogType.success:
                    richTextBox1.SelectionColor = Color.Green;
                    break;
                case LogType.warning:
                    richTextBox1.SelectionColor = Color.Orange;
                    break;
                case LogType.error:
                    richTextBox1.SelectionColor = Color.Red;
                    break;
            }
            richTextBox1.AppendText(msg + "\r\n");
            richTextBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Log|*.rtf";
            if (sd.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(sd.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
