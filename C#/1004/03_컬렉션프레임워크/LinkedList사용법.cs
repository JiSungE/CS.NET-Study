using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004
{
    internal class LinkedList사용법
    {
        private LinkedList<int> ar = new LinkedList<int>();

        #region 저장
        public void InsertSample()
        {
            for (int i = 1; i <= 10; i++)
            {
                ar.AddLast(i);
            }
        }

        public void InsertSample1()
        {
            LinkedListNode<int> first = ar.First;
            LinkedListNode<int> last = ar.Last;
            first = first.Next.Next;
           
            ar.AddAfter(first, 33);
            ar.AddBefore(last, 333);
        }

        #endregion

        #region 삭제
        public void DeleteSample()
        {
            ar.Remove(1);
            ar.RemoveFirst();
            ar.RemoveLast();
            //ar.Clear();
        }


        #endregion

        #region 특정요소 보관여부(Contains)
        public void Contain()
        {
            if (ar.Contains(10))
            {
                Console.WriteLine("보관됨");
            }
            else
            {
                Console.WriteLine("없음");
            }
        }
        #endregion

        #region 검색
        public void Select()
        {
            foreach (int i in ar)
            {
                if (i == 5)
                {
                    Console.WriteLine("찾음");
                }
            }
            Console.WriteLine("없음");
        }

        #endregion

        #region 수정
        public void Update()
        {
            LinkedListNode<int> cur = ar.First.Next.Next;
            cur.Value = 100;
        }

        #endregion

        public void PrintAllSample()
        {
            Console.WriteLine("저장개수 : " + ar.Count);
            foreach (int item in ar)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
        }



        public static void Main(string[] args)
        {
            LinkedList사용법 list = new LinkedList사용법();
            list.InsertSample();
            list.PrintAllSample();
            list.InsertSample1();
            list.PrintAllSample();
            list.Contain();
            list.Update();
            list.PrintAllSample();
            list.DeleteSample();
            list.PrintAllSample();
        }
    }
}
