using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _1107_WCFServiceChat
{
    //델리게이트 정의
    public delegate void Chat(int idx, string msg, string type);

    internal class ChatService : IChat
    {
        // 개인용 델리게이트
        private Chat MyChat = null;

        //전체에게 보낼 정보를 담고 있는 델리게이트
        IChatCallback callback = null;

        #region IChat 인터페이스 구현 상속
        public bool Join(int idx)
        {            
            MyChat = UserHandler;   //MyChat = new Chat(UserHandler);

            //2. 사용자에게 보내 줄 채널을 설정한다.
            callback = OperationContext.Current.GetCallbackChannel<IChatCallback>();

            //현재 접속자 정보를 모두에게 전달
            BroadcastMessage(idx, "", "UserEnter");
            return true;
        }

        public void Say(int idx, string msg)
        {
            BroadcastMessage(idx, msg, "Receive");
        }   

        public void Leave(int idx)
        {           
            MyChat = null;
        }
        #endregion

        #region 채팅 기능
        private void BroadcastMessage(int idx, string msg, string msgType)
        {
            //동기호출
            //MyChat(idx, msg, msgType);
            //MyChat.Invoke(idx, msg, msgType);

            //비동기호출
            MyChat.BeginInvoke(idx, msg, msgType, new AsyncCallback(EndAsync), null);
        }

        private void UserHandler(int idx, string msg, string msgType)
        {
            try
            {
                //클라이언트에게 보내기
                switch (msgType)
                {
                    case "Receive":
                        callback.Receive(idx, msg);
                        break;
                    case "UserEnter":
                        callback.UserEnter(idx);
                        break;
                }
            }
            catch//에러가 발생했을 경우
            {
                Console.WriteLine("{0} 에러", idx);
            }
        }
        
        private void EndAsync(IAsyncResult ar)
        {
            Chat d = null;
            try
            {
                System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
                d = ((Chat)asres.AsyncDelegate);
                d.EndInvoke(ar);
            }
            catch
            {
            }
        }
        #endregion
    }
}
