using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_회원관리프로그램
{
    internal class Control
    {
        private Container container;

        #region 싱글톤 패턴
        public static Control Singleton { get; private set; }
        static Control()
        {
            Singleton = new Control();
        }
        private Control()
        {
            Init();
        }
        #endregion

        public void Init()
        {
            int max;
            try
            {
                FileIO.LoadMax(out max);
            }
            catch (Exception)
            {
                max = WbLib.getInt("저장개수");
            }

            container = new Container(max);
            try
            {
                FileIO.Load(container);
            }
            catch (Exception)
            {
            }
        }

        public void Exit()
        {
            FileIO.SaveMax(container.Max);
            FileIO.Save(container);
        }


        public void PrintAll()
        {
            for (int i = 0; i < container.Size; i++)
            {
                Data mem = (Data)container[i];
                if (mem != null)
                {
                    Console.Write("{0} : ", i);
                    mem.Print();
                }
            }
        }

        public void Insert()
        {
            try
            {
                Console.WriteLine("[회원가입]");

                string name = WbLib.getString("아이디");
                string pw = WbLib.getString("비밀번호");

                Data member = new Data(name, pw);

                container.Insert(member);

                Console.WriteLine("저장되었습니다");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Login()
        {
            try
            {
                Console.WriteLine("[로그인]");

                string id = WbLib.getString("아이디를 입력하세요: ");
                string password = WbLib.getString("비밀번호를 입력하세요: ");
                int idx = NameToIdx(id);
                if (isLogin(idx, password) == true)
                {
                    Data member = (Data)container[idx];

                    Console.WriteLine("로그인이 되었습니다.");
                }
                else
                {
                    Console.WriteLine("패스워드가 틀렸습니다.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }


        public void Update()
        {
            try
            {
                Console.WriteLine("[비밀번호 변경]");

                string name = WbLib.getString("검색할 아이디");

                int idx = NameToIdx(name);

                Data member = (Data)container[idx];
                member.Pw = WbLib.getString("바꿀 비밀번호");

                Console.WriteLine("수정되었습니다");
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
        }
        public void Delete()
        {
            try
            {
                Console.WriteLine("[회원탈퇴]");

                string name = WbLib.getString("삭제할 아이디");

                int idx = NameToIdx(name);

                container.Delete(idx);

                Console.WriteLine("삭제되었습니다");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool isLogin(int idx, string password)
        {
            Data d = (Data)container[idx];
            if (d.Pw == password)
            {
                return true;
            }
            return false;
        }

        private int NameToIdx(string name)
        {
            for (int i = 0; i < container.Size; i++)
            {
                Data member = (Data)container[i];
                if (member != null && member.Id == name)
                {
                    return i;
                }
            }
            throw new Exception("존재하지 않는 아이디입니다.");
        }
    }
}
