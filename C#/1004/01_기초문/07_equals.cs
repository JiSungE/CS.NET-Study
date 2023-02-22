using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004
{
#pragma warning disable CS0659 // 형식은 Object.Equals(object o)를 재정의하지만 Object.GetHashCode()를 재정의하지 않습니다.
    class MyDate
#pragma warning restore CS0659 // 형식은 Object.Equals(object o)를 재정의하지만 Object.GetHashCode()를 재정의하지 않습니다.
    {
        public int year { get; set; }
        public int Month { get; set; }

        public int Day { get; set; }

        public MyDate(int y, int m, int d)
        {
            year = y;
            Month = m;
            Day = d;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", year, Month, Day);
        }

        public override bool Equals(object obj) // upcasting
        {
            MyDate d = (MyDate)obj;

            if(this.year == d.year && this.Month == d.Month && this.Day == d.Day)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    internal class _07_equals
    {
        public static void Main(string[] args)
        {
            MyDate d1 = new MyDate(2022, 10, 5);
            Console.WriteLine(d1);

            MyDate d2 = new MyDate(2022, 10, 5);
            MyDate d3 = d1;
            if(d1.Equals(d2))
                Console.WriteLine("동일");
            else
                Console.WriteLine("다름");
        }
    }
}
