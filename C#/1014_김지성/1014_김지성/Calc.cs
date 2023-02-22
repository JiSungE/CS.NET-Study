using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1014_김지성
{
    internal class Calc
    {
        #region 멤버필드
        public int Num1 { get; private set; }
        public int Num2 { get; private set; }
        public int Result { get; protected set; }
        public int InputResult { get; private set; }
        public bool IsResult { get; set; }
        #endregion

        #region 생성자
        public Calc()
        {
            Num1 = 0;
            Num2 = 0;
            Result = 0;
            InputResult = 0;
            IsResult = false;
        }

        public Calc(int num1, int num2)
        {
            Num1 = num1;
            Num2 = num2;
            Result = 0;
            InputResult = 0;
            IsResult = false;
        }
        #endregion

        #region 추상메서드
        public virtual void Cal()
        {
        }

        public virtual void Print()
        {

        }

        public virtual void ResultPrint()
        {

        }

        #endregion

        #region 인스턴스메서드
        public bool Exam(int f)
        {
            // 1) 맴버필드의 inputresult에 f값 저장
            InputResult = f;

            // 2) 맴버필드의 result와 inputresult를 비교해 결과를 isresult에 저장(동일하면 true, 다르면 false)
            if(Result == InputResult)
            {
                IsResult = true;
            }
            else
            {
                IsResult = false;
            }

            // 3) 저장된 isresult값을 리턴
            return IsResult;
        }
        #endregion
    }
}
