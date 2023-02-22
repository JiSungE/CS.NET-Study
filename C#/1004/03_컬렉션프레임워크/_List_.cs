using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004
{
    internal class _List_
    {
        private List<int> ar = new List<int>();

        #region 저장
        public void InsertSample()
        {
            for(int i = 1; i <= 10; i++)
            {
                ar.Add(i);
            }
        }

        public void InsertSample1()
        {
            ar.Insert(0, 11);
        }

        #endregion

        #region 삭제
        public void DeleteSample()
        {
            ar.Remove(1);
            ar.RemoveAt(3);
            ar.Clear();
        }


        #endregion

        #region 특정요소 보관여부(Contains)
        public void Contain()
        {
            if(ar.Contains(10))
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
            for(int i =0; i< ar.Count; i++)
            {
                int value = ar[i];
                if(value == 5)
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
            //int value = ar[2];
            //value = 100;
            ar[1] = 100;
        }

        #endregion

        public void PrintAllSample()
        {
            Console.WriteLine("저장개수 : " + ar.Count);
            foreach(int item in ar)
            {
                Console.Write(item+"  ");
            }
            Console.WriteLine();
        }

        

        public static void Main(string[] args)
        {
            _List_ list = new _List_();
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
