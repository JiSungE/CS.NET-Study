using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004
{
    class Sample
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }

        public Sample(string _name, string _phone)
        {
            Name = _name;
            Phone = _phone;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            string str = string.Format("{0}, {1} {2}", Name, Phone, Date.ToLongDateString());
            return str;
        }
    }

    internal class _03_ToString
    {
        public static int Main(string[] args)
        {
            Sample s1 = new Sample("홍길동", "010-1111-1111");
            Console.WriteLine(s1); // -- s1.ToString()

            return 0;
        }
    }
}
