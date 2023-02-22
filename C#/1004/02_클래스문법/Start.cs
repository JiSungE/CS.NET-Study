using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1005._02_클래스문법;

namespace _1004._02_클래스문법
{
    internal class Start
    {
        public static void Main(string[] args)
        {
            LibraryData d1 = new LibraryData(50, "C#", 260000);
            d1.Print();
        }
    }
}
