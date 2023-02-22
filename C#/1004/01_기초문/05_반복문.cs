using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004
{
    internal class _05_반복문
    {
        class test
        {
            public int _test;

            public test(int test)
            {
                this._test = test;
            }

            public override string ToString() //재정의
            {
                return _test.ToString();
            }
        }

        class MyInt // 사용자 정의 클래스 - 참조 형식
        {
            private int a;
            private int Value { get; set; } //return Value // Value = 입력한 값
            public MyInt(int value) //생성자
            {
                Value = value;
            }

            public void Add(int a)
            {
                Value = a;            
            }

            public void test()
            {
                a = Value;
            }

            

            public override string ToString() //재정의
            {
                
                return Value.ToString();
            }
        }
    class Program
    {
        static void Main(string[] args)
        {
                //int i = 1; //값 형식 변수 i 선언 및 초기화
                //int j = i; //값 형식 변수 j 선언 및 초기화(i를 초기화에 사용)
                //i++; //i를 1 증가
                //Console.WriteLine("i:{0} j:{0}", i, j); //값 형식인 i와 j값을 출력
                //MyInt a = new MyInt(1); // MyInt 개체를 생성하여 변수 a에 대입
                //MyInt b = a; //MyInt 형식 변수 b 선언 및 초기화(a를 초기화에 사용)
                //a.Value++; //a의 속성 Value를 1 증가
                //Console.WriteLine("a:{0} b:{0}", a, b); //참조 형식인 a와 b를 출력
                MyInt a = new MyInt(1);
                Console.WriteLine(a);

                test b = new test(2);
                Console.WriteLine(b);

                b._test = 10;
        }
    }
}
}
