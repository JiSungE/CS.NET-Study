using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1014_김지성
{
    internal class Program
    {
        #region 맴버필드
        private CalcControl Calc_control = new CalcControl();

        #endregion

        #region 5.3 맴버함수(Run)
        private void Run()
        {
            while (true)
            {
                Console.Clear();
                switch (Menuprint())
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.F1: Calc_control.InsertCalc(); break;
                    case ConsoleKey.F2: Calc_control.ExampleCal(); break;
                    case ConsoleKey.F3: Calc_control.ResultPrintCal(); break;
                }
                Console.Write("\n잠시기다려주세요.....\n");
                Thread.Sleep(1000);
                Console.ReadKey(true);
            }
        }

        #endregion


        #region 5.2 맴버함수 (Menuprint)
        private ConsoleKey Menuprint()
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine("[ESC] 프로그램 종료");
            Console.WriteLine("[F1] 문제 생성");
            Console.WriteLine("[F2] 문제 풀이");
            Console.WriteLine("[F3] 결과 보기");
            Console.WriteLine("***************************************************************");
            return Console.ReadKey(true).Key;   //#include <conio.h>
        }
        #endregion


        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Run(); 
        }
    }
}
