using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_회원관리프로그램
{
   
    [Serializable]
    internal class Data
    {
        private static int s_number = 1;

        public int Number   { get; private set; }
        public string Id  { get; private set; }
        public string Pw { get;  set; }

        public Data(string _id, string _pw)
        {
            Number = s_number++;
            Id = _id;
            Pw = _pw;
        }

        public void  Print()
        {
            Console.Write("[" +  Number + "]번째 유저 | ");
            Console.Write("아이디: "+Id + "\t\n");

        }

        public void Println()
        {
            Console.WriteLine("{0}번째 유저", Number);
            Console.WriteLine("이    름 : {0}", Id);
            Console.WriteLine("비밀번호 : {0}", Pw);
        }
    }
}
