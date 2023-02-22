using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _1004._02_클래스문법
{
    class Sample
    {
        private const int num1 = 10;// 멤버 필드 위치에서 초기화(모든 객체들이 동일한 값)
        private readonly int num2;
        private int num3;

        public Sample(int num2, int num3)
        {
            this.num2 = num2;
            this.num3 = num3;
        }
    }


    internal class _02_상수멤버필드
    {
        public static void Main(string[] args)
        {
            Sample s1 = new Sample(20, 30);
            Sample s2 = new Sample(25, 30);
        }
    }
}
