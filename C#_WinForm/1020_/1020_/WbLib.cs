using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_회원관리프로그램
{
    internal static class WbLib
    {
		public static int getInt(string msg)
		{			
			Console.Write(msg + " : ");
			int num = int.Parse(Console.ReadLine());
			return num;
		}

		public static char getChar(string msg)
		{
			Console.Write(msg + " : ");
			char ch = char.Parse(Console.ReadLine());
			return ch;
		}

		public static string getString(string msg)
		{
			Console.Write(msg + " : ");
			string str = Console.ReadLine();
			return str;
		}
	
		public static void Pause()
        {
			Console.Write("\n아무키나 누르세요");
			Console.ReadKey(true);
        }
	}
}
