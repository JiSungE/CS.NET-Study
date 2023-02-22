using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004._02_클래스문법
{
    struct PairData
    {
        public string Name;
        public string Phone;
        public PairData(string _name, string _phone)
        {
            Name = _name;
            Phone = _phone;
        }
    }
    class Sample
    {
        private PairData[] datas;

        public Sample()
        {
            datas = new PairData[3];
            datas[0] = new PairData("홍길동", "010-1111-1111");
            datas[1] = new PairData("고길동", "010-2222-2222");
            datas[2] = new PairData("구길동", "010-3333-3333");
        }

        public PairData GetData(int idx)
        {
            return datas[idx];
        }

        public string GetIdxPhone(int idx)
        {
            return datas[idx].Phone;
        }

        public string GetPhone(string name)
        {
            foreach(PairData data in datas)
            {
                if(data.Name == name)
                { return data.Phone; }
            }
            return null;
        }

        public PairData this[int idx]
        {
            get { return datas[idx]; }
        }

        public string this[string name]
        {
            get
            {
                foreach(PairData data in datas)
                {
                    if (data.Name == name)
                        return data.Phone;
                }
                return null;
            }
        }
    }
    internal class _05_인덱서
    {
        public static void Main(string[] args)
        {
            Sample s1 = new Sample();

            Console.WriteLine(s1.GetPhone("홍길동"));
            Console.WriteLine(s1.GetIdxPhone(1));
            Console.WriteLine(s1.GetData(2).Name + ", " + s1.GetData(2).Phone);

            Console.WriteLine(s1["홍길동"]);
            PairData d = s1[2];
            Console.WriteLine(d.Name + ", " + d.Phone);
        }
    }
}
