using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WoosongBit.Network
{
    public delegate string RecvFunc(string packet);

    /// <summary>
    /// 대기소켓을 관리하는 클래스
    /// </summary>
    public class Wb_TcpListener
    {
        public RecvFunc RecvFunc { get; set; }

        public int Port { get; private set; }
        public Socket Server { get; private set; }
        public Thread thread { get; private set; }

        private LinkedList<Wb_TcpClient> tcpclients = new LinkedList<Wb_TcpClient>();
        public Wb_TcpListener(int port)
        {
            Port = port;
        }

        public void Start()
        {
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, Port);
            Server.Bind(ipep);
            Server.Listen(20);
        }
        #region 서버 동작(Run -> WorkThread -> 반복적인 RecvThread 생성)
        public void Run()
        {
            thread = new Thread(WorkThread);
            thread.IsBackground = true;
            thread.Start();
        }

        private void WorkThread()
        {
            while(true)
            {
                // 1. 접속
                Wb_TcpClient client = AcceptTcpClient();
                Console.WriteLine("[접속({0} : {1})]", client.RemoteIP, client.RemotePort);

                // 2. 저장
                tcpclients.AddLast(client);

                // 통신 스레드 생성
                Thread  th = new Thread(RecvThread);
                th.IsBackground = true;
                th.Start(client);
            }
        }

        private void RecvThread(object value)
        {
            Wb_TcpClient sock = (Wb_TcpClient)value;
            try
            {
                while (true)
                {
                    string msg = String.Empty;
                    int ret = sock.Recv(out msg); // 수신한 문자열이 있으면 화면에 출력
                    if(ret == -1)
                    {
                        throw new Exception("종료");
                    }
                    string pack = RecvFunc(msg);

                    SendAll(pack);
                    //sock.Send(pack);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("수신 에러" + ex.Message);
                tcpclients.Remove(sock);
            }
        }

        #region 전체 전송
        public void SendAll(string msg)
        {
            foreach(Wb_TcpClient clinet in tcpclients)
            {
                clinet.Send(msg);
            }
        }
        #endregion

        public Wb_TcpClient AcceptTcpClient()
        {
            Socket client = Server.Accept();  // 클라이언트 접속 대기

            Wb_TcpClient tcpclient = new Wb_TcpClient(client);

            return tcpclient;
        }
        #endregion

        public void Close()
        {
            Server.Close();
        }
    }
}