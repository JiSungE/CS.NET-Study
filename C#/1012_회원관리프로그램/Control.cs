using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012_회원관리프로그램
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
            int max = WbLib.getInt("저장개수");
            container = new Container(max);
        }
        #endregion

        #region 이벤트 정의
        public event AddMemberEvent AddMemberEvent = null;
        public event SelectMemberEvent SelectMemberEvent = null;
        public UpdateMemberEvent UpdateDele = null;

        #endregion

        public void PrintAll()
        {
            for (int i = 0; i < container.Size; i++)
            {
                Member mem = (Member)container[i];
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
                Console.WriteLine("[회원 정보 저장]");

                string name = WbLib.getString("이름");
                string phone = WbLib.getString("전화번호");
                int age = WbLib.getInt("나이");
                int gender = WbLib.getInt("성별([1]남성, [2]여성)");

                Member member = new Member(name, phone, age, (enumGender)gender);

                container.Insert(member);

                Console.WriteLine("저장되었습니다");

                if(AddMemberEvent != null)
                {
                    AddMemberEvent(this, new AddMemberEventArgs(
                        member.Number, member.Name, member.Phone, member.Age, member.Gender));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Select()
        {
            try
            {
                Console.WriteLine("[회원 정보 검색]");

                string name = WbLib.getString("검색할 이름");

                int idx = NameToIdx(name);

                Member member = (Member)container[idx];

                member.Println();

                if (SelectMemberEvent != null)
                {
                    SelectMemberEvent(this, new SelectMemberEventArgs(member.Name));
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }
        private int NameToIdx(string name)
        {
	        for(int i=0; i< container.Size; i++)
	        {
                Member member = (Member)container[i];
		        if (member != null && member.Name ==  name) 
		        {
			        return i;
		        }
            }
            throw new Exception("존재하지 않는 이름입니다.");
        }
        public void Update()
        {
            try
            {
                Console.WriteLine("[회원 정보 수정]");

                string name = WbLib.getString("검색할 이름");

                int idx = NameToIdx(name);

                Member member = (Member)container[idx];
                member.Phone = WbLib.getString("전화번호");
                member.Age = WbLib.getInt("나이");

                Console.WriteLine("수정되었습니다");

                if (UpdateDele != null)
                {
                    UpdateDele(this, new UpdateMemberEventArgs(
                        member.Name, member.Phone, member.Age));
                }
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
                Console.WriteLine("[회원 정보 삭제]");

                string name = WbLib.getString("삭제할 이름");

                int idx = NameToIdx(name);

                container.Delete(idx);

                Console.WriteLine("삭제되었습니다");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
