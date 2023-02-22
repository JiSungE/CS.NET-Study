using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004
{
    internal class _06_인자전달
    {
        public static void Main(string[] args)
        {
            Exam1();
        }

        private static void Exam1()
        {
            int n1 = 50;
            int n2 = 20;
            int n3;

            Exam1_1(n1, ref n2, out n3);
        }

        private static void Exam1_1(int num1, ref int num2,out int num3)
        {
            // 문법2 : out은 강제문법
            num3 = 10;
        }
    }
}
