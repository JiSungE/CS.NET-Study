using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit.Network;

namespace _1020_Client
{
    internal class Control
    {
        #region 싱글톤
        public static Control Instance { get; private set; }
        static Control()
        {
            Instance = new Control();
        }
        private Control()
        {

        }
        #endregion

        private Wb_TcpClient client = null;
        private Form1 form1 = null;

        public void ThisForm(Form1 form)
        {
            form1 = form;
        }

        #region Form1에서 호출하는 메서드
        public void Open(string ip, int port)
        {
            client = new Wb_TcpClient(ip, port);
            client.Recvfunc = RecvMessage;
        }

        public void Close()
        {
            client.Close();
        }

        public void SendData(string nickname, string msg)
        {
            string packet = Packet.ShortMessage(nickname, msg);
            client.Send(packet);
        }
        #endregion

        #region Network에서 호출하는 메서드
        public void RecvMessage(string packet)
        {
            string[] sp1 = packet.Split('@');
            if (sp1[0] == Packet.Pack_ShortMessage)
            {
                string[] sp2 = sp1[1].Split('#');
                //form에 출력
                form1.MsgPrint(sp2[0], sp2[1]);
            }
        }
        #endregion
    }
}
