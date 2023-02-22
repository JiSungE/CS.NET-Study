using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WoosongBit.Network
{
        public delegate void RecvFunc(string packet);
    /// <summary>
    /// 통신소켓을 관리하는 클래스
    /// </summary>
    public class Wb_TcpClient
    {
        public RecvFunc RecvFunc { get; set; }

        public Socket Sock { get; private set; }

        public string RemoteIP
        {
            get
            {
                IPEndPoint ip = (IPEndPoint)Sock.RemoteEndPoint;
                return ip.Address.ToString();
            }
        }

        public int RemotePort
        {
            get
            {
                IPEndPoint ip = (IPEndPoint)Sock.RemoteEndPoint;
                return ip.Port;
            }
        }

        #region 생성자
        //서버에서 사용
        public Wb_TcpClient(Socket sock)
        {
            Sock = sock;
        }

        //클라이언트에서 사용
        public Wb_TcpClient(string ip, int port)
        {
            Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), port);
            Sock.Connect(ipep);

            // 수신 스레드

            Thread th = new Thread(RecvThread);
            th.IsBackground = true;
            th.Start();
        }

        private void RecvThread()
        {
            try
            {
                while (true)
                {
                    string msg = String.Empty;
                    this.Recv(out msg); // 수신한 문자열이 있으면 화면에 출력
                    RecvFunc(msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("수신 에러" + ex.Message);
            }
        }



        #endregion

        #region 입출력
        public int Send(string data)
        {
            byte[] msg = Encoding.Default.GetBytes(data);
            int ret = SendData(Sock, msg);
            return ret;
        }
        private int SendData(Socket client, byte[] data)
        {
            try
            {
                int total = 0;
                int size = data.Length;
                int left_data = size;

                byte[] data_size = new byte[4];
                data_size = BitConverter.GetBytes(size);
                int send_data = client.Send(data_size);

                while (total < size)
                {
                    send_data = client.Send(data, total, left_data, SocketFlags.None);
                    total += send_data;
                    left_data -= send_data;
                }
                return size;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        public int Recv(out string msg)
        {
            byte[] data = null;
            int ret = ReceiveData(Sock, ref data);
            if (ret == -1)
            {
                msg = String.Empty;
                return -1;
            }
            else
            {
                msg = Encoding.Default.GetString(data, 0, ret);
            }

            return ret;
        }

        private int ReceiveData(Socket client, ref byte[] data)
        {
            try
            {
                int total = 0;
                int size = 0;
                int left_data = 0;

                byte[] data_size = new byte[4];
                int recv_data = client.Receive(data_size, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                data = new byte[size];

                while (total < size)
                {
                    recv_data = client.Receive(data, total, left_data, 0);
                    if (recv_data == 0) break;
                    total += recv_data;
                    left_data -= recv_data;
                }
                return total;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        public void Close()
        {
            Sock.Close();
        }
    }
}