using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1006_관리프로그램;


namespace _1006_관리프로그램
{
    internal static class wblib
    {
        public static int getint(string msg)
        {
            Console.Write(msg + " : ");
            int num = int.Parse(Console.ReadLine());
            return num;
        }

        public static char getchar(string msg)
        {
            Console.Write(msg + " : ");
            char ch = char.Parse(Console.ReadLine());
            return ch;
        }

        public static string getstring(string msg)
        {
            Console.Write(msg + " : ");
            string str = Console.ReadLine();
            return str;
        }

        public static void Pause()
        {
            Console.Write("\n엔터키를 누르세요.\n");
            Console.ReadKey(true);
        }
    }
}