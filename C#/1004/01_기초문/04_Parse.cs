using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004
{
    internal class _04_Parse
    {
        public static void Main(string[] args)
        {
            Exam2();
        }

        private static void Exam1()
        {
            try
            {
                Console.Write("정수 입력 : ");
                int number = int.Parse(Console.ReadLine());

                Console.WriteLine(number);
            }
            catch(Exception ex)
            {
                Console.WriteLine("진행");
                Console.WriteLine(ex.ToString());
            }
        }

        private static void Exam2()
        {
            int number;
            Console.Write("정수 입력 : ");
            if(int.TryParse(Console.ReadLine(), out number) == true)
            {
                Console.WriteLine("입력한 정수 : "+number);
            }
            else
            {
                Console.WriteLine("잘못 입력함");
            }
        }
    }
}
