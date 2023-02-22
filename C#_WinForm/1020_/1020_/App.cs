using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_회원관리프로그램
{
    internal class App
    {
		private Control control;
      
		#region 싱글톤 패턴
		public static App Singleton { get; private set; }
		static App()
        {
			Singleton = new App();
        }
        private App()
        {
			control = Control.Singleton;
        }
        #endregion

        public void Init()
		{
			Logo();
		}

		public void Run()
		{
			while (true)
			{
				Console.Clear();
				control.PrintAll();
				switch (MenuPrint())
				{
					case ConsoleKey.Escape: return;
					case ConsoleKey.F1:		control.Insert(); break;
					case ConsoleKey.F2:		control.Login(); break;
					case ConsoleKey.F3:		control.Update(); break;
					case ConsoleKey.F4:		control.Delete(); break;
				}
				WbLib.Pause();
			}
		}

		public void Exit()
		{
			Ending();
			control.Exit();
		}

		private void Logo()
		{
			Console.Clear();
			Console.WriteLine("***************************************************************");
			Console.WriteLine("사용법");
			Console.WriteLine("1. 최초 단계에서는 유저를 담을 수 있는 저장공간에 크기를 입력(두 번째 실행부터는 Skip (txt파일이 있기 때문에))");
			Console.WriteLine("2. 버튼들로 기능을 사용해서 데이터를 처리.");
			Console.WriteLine("3. ESC버튼을 누름과 동시에 txt파일이 생성");
			Console.WriteLine("4. 프로그램 종료 후 다시 실행시키면 txt파일에 저장돼있는 데이터가 화면에 출력됌");
			Console.WriteLine("***************************************************************");
			WbLib.Pause();
		}

		private ConsoleKey MenuPrint()
		{
			Console.WriteLine("***************************************************************");
			Console.WriteLine("[ESC]데이터 저장 후 프로그램 종료");
			Console.WriteLine("[F1] 회원가입");
			Console.WriteLine("[F2] 로그인");
			Console.WriteLine("[F3] 수정");
			Console.WriteLine("[F4] 유저삭제");
			Console.WriteLine("***************************************************************");
			return Console.ReadKey(true).Key;  
		}

		private void Ending()
		{
			Console.Clear();
			Console.WriteLine("***************************************************************");
			Console.WriteLine(" 프로그램을 종료합니다.\n");
			Console.WriteLine("***************************************************************");
			WbLib.Pause();
		}
	}
}
