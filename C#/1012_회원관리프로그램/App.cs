using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012_회원관리프로그램
{
    internal class App
    {
		private Control control;
		private LogViewer viewer;
      
		#region 싱글톤 패턴
		public static App Singleton { get; private set; }
		static App()
        {
			Singleton = new App();
        }
        private App()
        {
			control = Control.Singleton;
			viewer = new LogViewer();
        }
        #endregion

        public void Init()
		{
			Logo();
			//control.Init();
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
					case ConsoleKey.F2:		control.Select(); break;
					case ConsoleKey.F3:		control.Update(); break;
					case ConsoleKey.F4:		control.Delete(); break;
				}
				WbLib.Pause();
			}
		}

		public void Exit()
		{
			Ending();
			//control.Exit();
		}

		private void Logo()
		{
			Console.Clear();
			Console.WriteLine("***************************************************************");
			Console.WriteLine(" 비트 고급 36기");
			Console.WriteLine(" C#언어 과정");
			Console.WriteLine(" OOP 기반의 회원 관리 프로그램");
			Console.WriteLine(" 2022.10.06");
			Console.WriteLine(" 최창민");
			Console.WriteLine("***************************************************************");
			WbLib.Pause();
		}

		private ConsoleKey MenuPrint()
		{
			Console.WriteLine("***************************************************************");
			Console.WriteLine("[ESC] 프로그램 종료");
			Console.WriteLine("[F1] Insert(회원 정보 저장)");
			Console.WriteLine("[F2] Select(회원 정보 검색 - 이름으로 검색, 이름은 uniq)");
			Console.WriteLine("[F3] Update(회원 정보 수정 - 이름으로 검색해서 전화번호와 나이를 수정)");
			Console.WriteLine("[F4] Delete(회원 정보 삭제 - 이름으로 검색해서 해당 정보를 0으로 초기화)");
			Console.WriteLine("***************************************************************");
			return Console.ReadKey(true).Key;   //#include <conio.h>
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
