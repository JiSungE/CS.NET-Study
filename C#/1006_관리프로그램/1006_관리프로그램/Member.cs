using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_관리프로그램
{
    class Member
    {
        private static int s_number = 1000 - Control.maxsize;
        public int Number { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }


        public Member(string name, string phone, int age, char gender)
        {
            this.Name = name;
            this.Phone = phone;
            this.Age = age;
            this.Gender = gender;
            this.Number = s_number;
            s_number = s_number + 1;
        }

        public void print()
        {
            Console.Write("[{0}] \t", Number);
            Console.Write("{0} \t", Name);
            Console.Write("{0} \t", Phone);
            Console.Write("{0} \t", Age);
            Console.Write("{0} \t\n", Gender);
        }

        public void println()
        {
            Console.Write("[{0}] \n", Number);
            Console.Write("{0} \n", Name);
            Console.Write("{0} \n", Phone);
            Console.Write("{0} \n", Age);
            Console.Write("{0} \n", Gender);
        }
        
    }
}
