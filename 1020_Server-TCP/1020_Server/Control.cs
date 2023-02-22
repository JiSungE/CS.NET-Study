using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit.Network;

namespace _1020_Server
{
    internal class Control
    {
        private Wb_TcpListener server = null;
        private Form1 form1 = null;

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

        public void thisForm(Form1 form)
        {
            form1 = form;
        }

        #region 네트웤

        //메시지 수신부
        public string RecvMessage(string packet)
        {
            string[] sp1 = packet.Split('@');
            if (sp1[0] == Packet.Pack_ShortMessage)
            {
                //수신 처리
                string[] sp2 = sp1[1].Split('#');                
                form1.MsgPrint(sp2[0], sp2[1]);

                //송신 생성(echo)
                string pack = Packet.ShortMessage(sp2[0], sp2[1]);
                return pack;
            }          
            return string.Empty;
        }

        //로그메시지 수신부(서버시작/종료/클라이언트연결/해제)
        public void LogMessage(string msg)
        {
            form1.LogPrint(msg);
        }

        public void ServerStart(int port)
        {
            server = new Wb_TcpListener(port); 
            server.Recvfunc = RecvMessage;
            server.Logfunc  = LogMessage;
            server.Start();            
            server.Run();
        }

        public void ServerStop()
        {
            server.Close();
        }
        #endregion

       }
}
