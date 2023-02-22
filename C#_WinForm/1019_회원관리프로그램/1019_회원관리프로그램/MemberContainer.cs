using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1019_회원관리프로그램
{
    public  class MemberContainer : LinkedList<Member>
    {
        public MemberContainer()
        {
            TestData();
        }

        private void TestData()
        {
            this.AddLast(new Member("111", "1111", "홍길동", "010-1111-1111"));
            this.AddLast(new Member("222", "2222", "이길동", "010-2222-2222"));
        }
    }
}
