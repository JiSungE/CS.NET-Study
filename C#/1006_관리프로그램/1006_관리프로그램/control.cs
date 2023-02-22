using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_관리프로그램
{
    class Control
    {
        Member[] members;
        public static int maxsize;

        public Control(int size)
        {
            maxsize = size;
            members = new Member[maxsize];
            for (int i = 0; i < members.Length; i++)
            {
                members[i] = new Member("", "", -1, '0');
            }
        }

        public void exit()
        {
            for (int i = 0; i < members.Length; i++)
            {
                members[i] = null;
            }
        }

        public void printall() 
        {
            for(int i = 0; i < members.Length; i++)
            {
                Member pmem = members[i];
                if (pmem.Age == -1)
                {
                    continue;
                }

                if (pmem != null)
                {
                    Console.Write("{0} : ", i);
                    pmem.print();
                }
            }
        }
        public void insert() 
        {
            Console.WriteLine("[회원 정보 저장]\n");
            int idx, age;
            string name, phone;
            char gender;

            Console.Write("저장할 인덱스(0~{0}) : ",maxsize - 1);
            idx = int.Parse(Console.ReadLine());
            if (idx > members.Length || members[idx].Age != -1)
            {
                Console.WriteLine("잘못된 인덱스입니다.");
                return;
            }

            Console.Write("이름 : ");
            name = Console.ReadLine();

            Console.Write("전화번호 : ");
            phone = Console.ReadLine();

            Console.Write("나이 : ");
            age = int.Parse(Console.ReadLine());

            Console.Write("성별(1: 남자 2: 여자) : ");
            gender = char.Parse(Console.ReadLine());

            Member pmem = new Member(name, phone, age, gender);
            members[idx] = pmem;
            Console.WriteLine("저장되었습니다.");

        }
        public void select() 
        {
            Console.WriteLine("[회원 정보 검색]\n");

            Console.Write("검색할 이름 : ");
            string name = Console.ReadLine();

            int idx = nametoidx(name);
            if(idx == -1)
            {
                Console.WriteLine("해당 이름은 존재하지 않습니다.");
                return;
            }

            Member pmem = members[idx];
            pmem.println();
        }
        public void update() 
        {
            Console.WriteLine("[회원 정보 수정]\n");

            Console.Write("검색할 이름 : ");
            string name = Console.ReadLine();

            int idx = nametoidx(name);
            if(idx == -1)
            {
                Console.WriteLine("해당 이름은 존재하지 않습니다.");
                return;
            }

            Member pmem = members[idx];

            Console.Write("전화번호 : ");
            string phone = Console.ReadLine();

            Console.Write("나이 : ");
            int age = int.Parse(Console.ReadLine());

            pmem.Phone = phone;
            pmem.Age = age;

            Console.WriteLine("수정되었습니다.");
        }

        public void delete() 
        {
            Console.WriteLine("[회원 정보 삭제]\n");

            Console.Write("삭제할 이름 : ");
            string name = Console.ReadLine();

            int idx = nametoidx(name);
            if(idx == -1)
            {
                Console.WriteLine("해당 이름은 존재하지 않습니다.");
                return;
            }

            members[idx] = new Member("", "", -1, '0');
            Console.WriteLine("삭제되었습니다.");

        }

        private int nametoidx(string name)
        {
            //for(int i = 0; i < 10; i++)
            //{
            //    Member pmem = members[i];
            //    string _name = pmem.Name;

            //    if(pmem != null && _name == name)
            //    {
            //        return i;
            //    }
            //}
            int cnt = 0;

            foreach(Member mem in members)
            {
                if(mem.Name == name)
                {
                    return cnt; 
                }
                else
                {
                    cnt++;
                }
            }
            return -1;
        }

    }
}
