using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1005._02_클래스문법
{
    internal class LibraryData
    {
        #region 프로퍼티
        private const int num1 = 19;
        private readonly int num;
        public int Num { get; set; }
        public int Num1 { get; set; }

        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        private int price;
        public int Price
        {
            get { return price; }
            set 
            {
                if (value <= 0)
                {
                    Console.WriteLine("안됌");
                    return;
                }
                price = value;
            }
        }
        #endregion

        #region 생성자
        public LibraryData(int _num, string _name, int _price):this(_num, _name, DateTime.Now, _price){}
        public LibraryData(int _num, string _name, DateTime _date, int _price)
        {
            num = _num;
            Name = _name;
            Date = _date;
            Price = _price;
        }
        #endregion

        #region 메소드
        public void Print()
        {
            Num1 = 90;
            Num = 80;
            Console.WriteLine(Num1);
            Console.Write("[번호]" + Num + "\t");
            Console.Write("[도서 이름]" + Name + "\t");
            Console.Write("[가격]" + Price + "\t");
            Console.WriteLine("[출 판 일]" + Date + "\t");
        }

        public void Println()
        {
            Console.WriteLine("[번호]" + Num + "\t");
            Console.WriteLine("[도서 이름]" + Name + "\t");
            Console.WriteLine("[가격]" + Price + "\t");
            Console.WriteLine("[출 판 일]" + Date + "\t");
        }
        #endregion
    }
}
