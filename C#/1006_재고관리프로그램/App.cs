using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_재고관리프로그램
{
    class App
    {
        Control con;

        public void init()
        {
            int size = wblib.getint("전체 크기");
            con = new Control(size);

            logo();
        }

        public void run()
        {
            while (true)
            {
                Console.Clear();
                con.printall();
                switch (menuprint())
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.F1: con.insert(); break;
                    case ConsoleKey.F2: con.select(); break;
                    case ConsoleKey.F3: con.update(); break;
                    case ConsoleKey.F4: con.substract(); break;
                    case ConsoleKey.F5: con.add(); break;
                }
                Console.ReadKey();
            }
        }

        private ConsoleKey menuprint()
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine(" [ESC] 프로그램 종료");
            Console.WriteLine(" [F1] Insert(제품 정보 저장)");
            Console.WriteLine(" [F2] Select(제품 정보 검색 - 이름으로 검색, 이름은 uniq)");
            Console.WriteLine(" [F3] Update(제품 가격 수정 - 이름으로 검색해서 전화번호와 나이를 수정)");
            Console.WriteLine(" [F4] sub(제품 재고 빼기 - 이름으로 검색해서 해당 정보를 0으로 초기화)");
            Console.WriteLine(" [F5] add(제품 재고 추가 - 이름으로 검색해서 해당 정보를 0으로 초기화)");
            Console.WriteLine("***************************************************************");

            return Console.ReadKey(true).Key;
            //char c = wblib.getchar("입력 ");
            //return c;
        }


        private void logo()
        {
            Console.Clear();
            Console.WriteLine("***************************************************************");
            Console.WriteLine(" 비트 고급 36기");
            Console.WriteLine(" C#언어 과정");
            Console.WriteLine(" C# 기반의 재고 관리 프로그램");
            Console.WriteLine(" 2022.10.06");
            Console.WriteLine(" 김지성");
            Console.WriteLine("***************************************************************");
            wblib.Pause();
        }

        private void ending()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("***************************************************************");
            Console.WriteLine("종료합니다");
            Console.WriteLine("***************************************************************");
            Console.WriteLine("\n");
            wblib.Pause();
        }

        public void exit()
        {
            ending();
        }
    }
}
