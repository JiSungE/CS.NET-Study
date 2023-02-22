using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_회원관리프로그램
{
    internal class Container
    {
        private object[] arr;
        public object[] Arr { get { return arr; } }

        public int Size { get; private set; } //저장개수, 저장할 위치

        public int Max  { get {  return arr.Length; }  }               

        public object this[int idx]
        {
            get 
            {
                if (idx < 0 || idx >= Size)
                    throw new Exception("잘못된 인덱스 입니다");
                return arr[idx]; 
            }
        }

        public Container() : this(10)
        {

        }

        public Container(int max)
        {
            arr = new object[max];  
            Size = 0;
        }
    

        public void Insert(object value)
        {
            if(arr.Length <= Size)   
            {
                throw new Exception("저장공간이 없다(Overflow");
            }

            arr[Size] = value;
            Size++;
        }
    
        public void Delete(int idx)
        {
            if (idx < 0 || idx >= Size)
                throw new Exception("잘못된 인덱스 입니다");

            for(int i = idx; i< Size-1; i++)
            {
                arr[i] = arr[i + 1];
            }
            Size--;
        }
    }
}
