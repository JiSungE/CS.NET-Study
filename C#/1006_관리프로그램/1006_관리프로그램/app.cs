using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_관리프로그램
{
    
    class App
    {
        Control con;
        public void init()
        {
            int size = wblib.getint("전체 크기 ");
            con = new Control(size);

            logo();
        }

        public void run() 
        {
            while(true)
            {
                Console.Clear();
                con.printall();
                switch(menuprint())
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.F1: con.insert(); break;
                    case ConsoleKey.F2: con.select(); break;
                    case ConsoleKey.F3: con.update(); break;
                    case ConsoleKey.F4: con.delete(); break;
                }
                Console.ReadKey();
            }
        }
        public void exit() 
        {
            con.exit();
            ending();
        }
        private void logo() 
        {
            Console.Clear();
            Console.WriteLine("***************************************************************");
            Console.WriteLine(" 비트 고급 36기");
            Console.WriteLine(" C#언어 과정");
            Console.WriteLine(" C# 기반의 회원 관리 프로그램");
            Console.WriteLine(" 2022.10.06");
            Console.WriteLine(" 김지성");
            Console.WriteLine("***************************************************************");
            wblib.Pause();
        }
        private ConsoleKey menuprint() 
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine(" [ESC] 프로그램 종료");
            Console.WriteLine(" [F1] Insert(회원 정보 저장)");
            Console.WriteLine(" [F2] Select(회원 정보 검색 - 이름으로 검색, 이름은 uniq)");
            Console.WriteLine(" [F3] Update(회원 정보 수정 - 이름으로 검색해서 전화번호와 나이를 수정)");
            Console.WriteLine(" [F4] Delete(회원 정보 삭제 - 이름으로 검색해서 해당 정보를 0으로 초기화)");
            Console.WriteLine("***************************************************************");

            return Console.ReadKey(true).Key;
            //char c = wblib.getchar("입력 ");
            //return c;
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

    }
}
