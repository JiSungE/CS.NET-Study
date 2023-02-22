using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1019_회원관리프로그램
{
    internal class MemberControl
    {
        #region 싱글톤
        
        public static MemberControl Instance { get; private set; }
        static MemberControl()      { Instance = new MemberControl();  }
        private MemberControl() { }

        #endregion
            
        //private LinkedList<Member> members = new LinkedList<Member>();
        private MemberContainer members = new MemberContainer();
    
        public LinkedList<Member> Members { get { return members; } }

        //로그인 성공 여부
        public bool IsLogin(string id, string pw)
        {
            foreach(Member m in members)
            {
                if(m.Id == id && m.PassWord == pw)
                    return true;
            }
            return false;
        }
    
        //아이디 중복 여부(사용가능한 ID라면 true, 중복되어 있으면 false)
        public bool IdCheck(string id)
        {
            foreach (Member m in members)
            {
                if (m.Id == id)
                    return false;
            }
            return true;
        }

        //회원 가입
        public void InsertMember(Member member)
        {
            members.AddFirst(member);
        }

        //회원 정보 수정
        public bool UpdateData(string id, string phone)
        {
            foreach(Member member in members)
            {
                if(member.Id == id)
                {
                    member.Phone = phone;
                    return true;
                }
            }
            return false;
        }

        //회원 정보 삭제
        public bool DeleteData(string id)
        {
            foreach (Member member in members)
            {
                if (member.Id == id)
                {
                    members.Remove(member);
                    return true;
                }
            }
            return false;
        }
    
        //회원검색
        public Member SelectMember(string id)
        {
            foreach (Member member in members)
            {
                if (member.Id == id)
                {
                    return member;
                }
            }
            return null;
        }
    }
}
