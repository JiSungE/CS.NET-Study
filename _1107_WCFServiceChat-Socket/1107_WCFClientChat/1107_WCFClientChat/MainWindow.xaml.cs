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
using _1107_WCFClientChat.ServiceReference1;

namespace _1107_WCFClientChat
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window, IChatCallback
    {
        private IChat chat = null;

        public int IdxNumber
        {
            get { return int.Parse(txt_id.Text);    } 
            set { txt_id.Text = value.ToString();   }
        }
        public string SendMsg { 
            get { return msg_txt.Text; } 
            set {  msg_txt.Text = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            InstanceContext site = new InstanceContext(this);
            chat = new ServiceReference1.ChatClient(site);
        }

        #region IChatCallback 인터페이스 구현 상속
        public void Receive(int idx, string message)
        {
            string msgtemp = string.Format("{0}", message);
            listbox.Items.Add(msgtemp);
        }

        public void UserEnter(int idx)
        {
            string msgtemp = string.Format("{0}님이 로그인하셨습니다.", idx);
            listbox.Items.Add(msgtemp);
        }
        #endregion 

        //Join
        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            if( chat.Join(IdxNumber) == true)
            {
                MessageBox.Show("접속 성공");
            }
            else
            {
                MessageBox.Show("접속 실패");
            }
        }       

        //Leave
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                chat.Leave(IdxNumber);
                MessageBox.Show("연결 종료");
            }
            catch (Exception)
            {
                MessageBox.Show("로그인을 하세요");
            }
        }

        //Send
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                chat.Say(IdxNumber, SendMsg);
                SendMsg = "";
            }
            catch(Exception)
            {
                MessageBox.Show("로그인을 하세요");
            }
        }




    }
}
