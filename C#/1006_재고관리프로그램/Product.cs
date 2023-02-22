using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_재고관리프로그램
{
    enum etype { 가전제품, 식품, 가구, 생필품}
    class Product
    {
        private static int productNum = 1000 - Control.maxsize;

        public int Num { get; set; }
        public string Name { get; private set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public etype Type { get; set; }

        public Product(string name, int amount, int price, etype type)
        {
            Num = productNum++;
            Name = name;
            Amount = amount;
            Price = price;
            Type = type;
        }

        public void print()
        {
            Console.Write("[{0}] \t", Num);
            Console.Write("{0} \t", Name);
            Console.Write("{0} \t", Amount);
            Console.Write("{0} \t", Price);
            Console.Write("{0} \t\n", Type);
        }

        public void println()
        {
            Console.Write("제품 번호   : [{0}] \n", Num);
            Console.Write("제품 이름   : {0} \n", Name);
            Console.Write("제품 재고량 : {0} \n", Amount);
            Console.Write("제품 가격   : {0} \n", Price);
            Console.Write("제품 종류   : {0} \n", Type);
        }
    }
}
