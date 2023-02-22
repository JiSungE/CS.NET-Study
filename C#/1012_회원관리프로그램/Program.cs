using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012_회원관리프로그램
{
    public static class ExtensionMethod
    {
        public static void func(this string num, string value)
        {
            Console.WriteLine(value);
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            App app = App.Singleton;
            app.Init();
            app.Run();
            app.Exit();
            //string test = "55";
            //test.func("66");
        }
    }
}
