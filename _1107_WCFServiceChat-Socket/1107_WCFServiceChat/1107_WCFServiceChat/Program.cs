using System;
using System.Configuration;
using System.ServiceModel;

namespace _1107_WCFServiceChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Address
            Uri uri = new Uri(ConfigurationManager.AppSettings["addr"]);
            //Contract-> Setting
            //Binding -> App.Config
            //ServiceHost host = new ServiceHost(typeof(_1107_WCFServiceChat.ChatService), uri);
            ServiceHost host = new ServiceHost(typeof(_1107_WCFServiceChat.ChatService));

            //오픈
            host.Open();

            string baseaddr = ConfigurationManager.AppSettings["baseaddr"];
            Console.WriteLine("채팅 서비스를 시작합니다. {0}", uri.ToString());
            Console.WriteLine(baseaddr);
            Console.WriteLine("멈추시려면 엔터를 눌러주세요..");
            Console.ReadLine();
            //서비스
            host.Abort();
            host.Close();
        }
    }
}
