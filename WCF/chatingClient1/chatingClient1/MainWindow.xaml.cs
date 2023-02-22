using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using chatingClient1.ServiceReference1;

namespace chatingClient1
{
    // MainWindow.xaml에 대한 상호 작용 논리
    public partial class MainWindow : Window, IChatCallback
    {
        int idx;
        private IChat chat;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //2 ===================================================
            InstanceContext site = new InstanceContext(this);
            chat = new chatingClient1.ServiceReference1.ChatClient(site);
            btnSend.IsEnabled = false;
        }

        #region IChatCallback 인터페이스 함수 생성
        public void Receive(int idx, string message)
        {
            string msgtemp = string.Format("[{0}]: {1}", idx, message);
            chatlist.Items.Add(msgtemp);
        }


        public void UserEnter(string group, int idx, string name) 
        {
            string msgtemp = string.Format("{0}님이 입장하셨습니다.", name);
            // 리스트뷰에 msgtemp 추가코드
        }



        public void UserEnter(int idx)
        {
            string msgtemp = string.Format("{0}님이 로그인하셨습니다.", idx);
            chatlist.Items.Add(msgtemp);
        }

        public void ear(int idx, string msg)
        {
            string msgtemp = string.Format("{0}님과 귓속말을 시작합니다.", idx);
            chatlist.Items.Add(msgtemp);
        }

        public void UserLeave(int idx)
        {
            string msgtemp = string.Format("{0}님이 로그아웃하셨습니다.", idx);
            chatlist.Items.Add(msgtemp);
        }
        #endregion


        #region 로그인/로그아웃 핸들러
        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btnJoin.Content == "로그인")
            {
                this.Connect();
                string msgtemp = string.Format("{0}님이 로그인하셨습니다.", idx);
                btnSend.IsEnabled = true;
            }
            else this.DisConnect();
        }

        private void Connect()
        {
            try
            {
                idx = int.Parse(seatbox.Text);

                //서버 접속
                bool data = chat.Join(idx);

                btnJoin.Content = "로그아웃";
                string login = string.Format("{0}님이 로그인하셨습니다.", seatbox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("접속 오류 :{0}", ex.Message);
            }
        }

        private void DisConnect()
        {
            try
            {
                chat.Leave(idx);

                btnJoin.Content = "로그인";

                string logout = string.Format("{0}님이 로그아웃하셨습니다.", seatbox.Text);
                chatlist.Items.Add(logout);
                btnSend.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("나가기 오류 :{0}", ex.Message);
            }
        }
        #endregion

        #region 마우스 이벤트 핸들러
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            seatbox.Text = (string)((Label)sender).Content;
        }
        // 메시지 전송
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string msg = msgbox.Text;

            //string temp = string.Format("[{0}]", msg);
            //chatlist.Items.Add(temp);

            chat.Say(idx, msg);
            msgbox.Clear();

        }
        #endregion

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            int idx1 = int.Parse(seatbox.Text);
            int idx2 = int.Parse(people.Text);
            string msg = msgbox.Text;

            
            chat.whisper(idx1, idx2, msg);
            msgbox.Clear();
        }

        public IAsyncResult BeginReceive(int idx, string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceive(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUserEnter(int idx, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUserEnter(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUserLeave(int idx, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUserLeave(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult Beginear(int idx, string msg, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void Endear(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}