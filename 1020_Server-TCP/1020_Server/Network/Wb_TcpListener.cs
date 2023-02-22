using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WoosongBit.Network
{
    public delegate string RecvFunc(string packet);
    public delegate void LogFunc(string msg);

    /// <summary>
    /// 대기소켓을 관리하는 클래스
    /// </summary>
    public class Wb_TcpListener
    {
        #region 델리게이트 레퍼런스 필드
        public RecvFunc Recvfunc    { get; set; }
        public LogFunc Logfunc      { get; set; }
        #endregion 

        public int Port         { get; private set; }
        public Socket Server    { get; private set; }
        public Thread thread    { get; private set; }

        private LinkedList<Wb_TcpClient> tcpclients = new LinkedList<Wb_TcpClient>();

        public Wb_TcpListener(int port)
        {
            Port = port;
        }
    
        public void Start()
        {
            Server = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, Port);
            Server.Bind(ipep);
            Server.Listen(20);
        }

        #region 서버 동작(Run -> WorkThread[AcceptTcpClient] -> 반복적인 RecvThread 생성)
        public void Run()
        {
            thread = new Thread(WorkThread);
            thread.IsBackground = true;
            thread.Start();
            Logfunc("서버 시작......");
        }

        //Thread함수
        private void WorkThread()
        {
            try
            {
                while (true)
                {
                    //1.접속
                    Wb_TcpClient client = AcceptTcpClient();

                    string temp = string.Format("[접속({0}:{1}]", client.RemoteIP, client.RemotePort);
                    Logfunc(temp);

                    //2.저장
                    tcpclients.AddLast(client);

                    //3.통신 스레드 생성
                    Thread th = new Thread(RecvThread);
                    th.IsBackground = true;
                    th.Start(client);
                }
            }
            catch (Exception)
            {
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
                    int ret = sock.Recv(out msg);   // 수신한 문자열이 있으면 화면에 출력
                    if (ret == -1)
                        throw new Exception("클라이언트 종료");
                    
                    string packet = Recvfunc(msg);

                    SendAll(packet);
                    //sock.Send(packet);
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("수신 에러 : {0}", ex.Message);
                string temp = string.Format("[종료({0}:{1}]", sock.RemoteIP, sock.RemotePort);
                Logfunc(temp);

                tcpclients.Remove(sock);
                sock.Close();
            }
        }

        private Wb_TcpClient AcceptTcpClient()
        {
            Socket client = Server.Accept();  // 클라이언트 접속 대기

            Wb_TcpClient tcpclient = new Wb_TcpClient(client);

            return tcpclient;
        }
        #endregion

        #region 전체 전송
        public void SendAll(string msg)
        {
            foreach(Wb_TcpClient client in tcpclients)
            {
                client.Send(msg);
            }
        }
        #endregion 

        public void Close()
        {
            Server.Close();
            Logfunc("서버종료....");
        }
    }
}
