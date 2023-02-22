using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1014_김지성
{
    internal class CalcControl
    {
        #region 컬렉션 객체 맴버필드
        List<Calc> calcs = new List<Calc>();
        #endregion

        #region 기능1) 문제생성구현
        public void InsertCalc()
        {
            Random random = new Random();
            // 연산자 랜덤
            int operator_ = random.Next(0, 2);
            // 피연산자 랜덤
            int operand_1 = random.Next(0, 10);
            int operand_2 = random.Next(0, 10);

            // 객체 생성
            if(operator_ == 0)
            {
                Add add = new Add(operand_1, operand_2);
                // 객체 저장
                calcs.Add(add);
            }
            else
            {
                Sub sub = new Sub(operand_1, operand_2);
                // 객체 저장
                calcs.Add(sub);
            }

            // 문장 출력
            Console.WriteLine("문제 출제가 완료되었습니다.");



        }


        #endregion

        #region 기능2) 문제풀이구현
        public void ExampleCal()
        {
            foreach(Calc c in calcs)
            {
                c.Print();
                Console.Write("[정답 입력] : ");
                int input = int.Parse(Console.ReadLine());
                bool check = c.Exam(input);
                c.IsResult = check;
                Console.WriteLine("{0}", (check ? "[정답]" : "[오답]"));
            }
        }

        #endregion

        #region 기능3) 결과보기구현
        public void ResultPrintCal()
        {
            foreach(Calc c in calcs)
            {
                c.ResultPrint();
            }
        }
        #endregion
    }
}
