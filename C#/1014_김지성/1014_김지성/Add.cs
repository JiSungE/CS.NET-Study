using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1014_김지성
{
    internal class Add: Calc
    {
        #region 생성자
        public Add(int num1, int num2):base(num1, num2)
        {
            this.Cal();
        }
        #endregion

        #region 맴버함수 재정의1
        public override void Cal()
        {
            Result = Num1 + Num2;
        }

        #endregion

        #region 맴버함수 재정의2
        public override void Print()
        {
            Console.WriteLine("{0} + {1} = ", Num1, Num2);
        }
        #endregion

        #region 맴버함수 재정의3
        public override void ResultPrint()
        {
            string ch;
            if(IsResult == true)
            {
                ch = "정답";
            }
            else
            {
                ch = "오답";
            }

            Console.WriteLine("{0} + {1} = {2} [사용자입력:{3}] [{4}]", Num1, Num2, Result, InputResult, ch);
        }

        #endregion
    }
}
