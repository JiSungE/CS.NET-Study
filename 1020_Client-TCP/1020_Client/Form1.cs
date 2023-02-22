using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1020_Client
{
    public partial class Form1 : Form
    {
        private Control con = Control.Instance;

        public Form1()
        {
            InitializeComponent();
            txt_ip.Text     = "127.0.0.1";
            txt_port.Text   = 9000.ToString();

            con.ThisForm(this);
        }

        #region 버튼 핸들러
        private void btn_open_Click(object sender, EventArgs e)
        {
            con.Open(txt_ip.Text, int.Parse(txt_port.Text));
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            con.Close();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            con.SendData(txt_nickname.Text, txt_msgsend.Text);
        }
        #endregion

        #region 컨트롤에서 전달되는 메시지 수신
        public void MsgPrint(string nickname, string msg)
        {
            DateTime dt = DateTime.Now;
            string temp = string.Format("{0} {1} ({2}:{3}:{4})\r\n", 
                nickname, msg, dt.Hour, dt.Minute, dt.Second);

            txt_msgview.AppendText(temp);
        }
        #endregion
    }
}
