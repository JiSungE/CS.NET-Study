using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004
{
    struct S_Sample
    {
        public int num1;
        public string msg;
        public S_Sample(int n1, string m)
        {
            num1 = n1;
            msg = m;
             
        }

    }

    class C_Sample
    {
        public int num1;
        public string msg;

        public C_Sample(int n1, string m)
        {
            num1 = n1;
            msg = m;
        }


    }
    
    internal class _09_new의_사용
    {
        public static void Main(string[] args)
        {
            S_Sample s1 = new S_Sample(10, "홍길동");
            Console.WriteLine(s1.msg);

            S_Sample s2 = s1;

            C_Sample c1 = new C_Sample(20, "고길동");
            Console.WriteLine(c1.msg);
        }
    }
}
