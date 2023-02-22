using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004._02_클래스문법
{
    class Sample
    {
        private int num1;
        public int Num1
        {
            get { return num1; }
            set { num1 = value; }
        }

        public int Num2 { get; private set; }


        // 응용
        // 나는 get만 외부로 노출하고 싶을 때
        private int num3;
        public int Num3
        {
            get { return num3; }
            private set { num3 = value; }
        }

        public int Num4 { get; private set; }

    }
    internal class _01_프로퍼티
    {
    }
}
