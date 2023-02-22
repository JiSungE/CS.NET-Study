using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1020_Server
{
    public partial class Form1 : Form
    {
        Control con = Control.Instance;

        public Form1()
        {
            InitializeComponent();

            txt_port.Text = "9000";

            con.thisForm(this);
        }

        #region 시작 & 종료 버튼 핸들러
        
        //서버 실행(데이터,[네트웤], UI)
        private void btn_open_Click(object sender, EventArgs e)
        {
            con.ServerStart(int.Parse(txt_port.Text));            
        }

        //서버 종료
        private void btn_close_Click(object sender, EventArgs e)
        {
            con.ServerStop();
        }
        #endregion

        #region 로그 & 메시지 출력
        public void LogPrint(string msg)
        {
            DateTime dt = DateTime.Now;
            string temp = string.Format("{0}({1}:{2}:{3})\r\n", msg, dt.Hour, dt.Minute, dt.Second);
            txt_logview.AppendText(temp);
        }

        public void MsgPrint(string nickname, string msg)
        {
            DateTime dt = DateTime.Now;
            string temp = string.Format("[{0}] {1} ({2}:{3}:{4})\r\n", 
                nickname, msg, dt.Hour, dt.Minute, dt.Second);

            list_msgview.Items.Add(temp);
        }

        #endregion 
    }
}
