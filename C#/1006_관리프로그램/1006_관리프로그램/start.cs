using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_관리프로그램
{
    internal class start
    {
        public static void Main(string[] args)
        {
            App app = new App();
            app.init();
            app.run();
            app.exit();
        }
    }
}
