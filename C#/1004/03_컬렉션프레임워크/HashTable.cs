using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004
{
    internal class HashTable
    {
        Dictionary<string, string> table = new Dictionary<string, string>();
        
        public void InsertSample()
        {
            table.Add("홍길동", "010-1111-1111");
            table.Add("고길동", "010-2222-2222");
            table["이길동"] = "010-3333-3333";
            table["김길동"] = "010-4444-4444";
            table["홍길동"] = "010-5555-5555"; // This is Not ErrorCode Just a Update
        }

        public void DeleteSample()
        {
            table.Remove("홍길동");
        }
        
        public void Select()
        {
            try
            {
                string phone = table["없는 값"];
                if (phone != null)
                {
                    Console.WriteLine(phone);
                }
                else
                {
                    Console.WriteLine("-");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update()
        {
            table["김길동"] = "010-7777-7777";
        }

        public void PrintAll()
        {
            Console.WriteLine("저장개수 : " + table.Count);
            foreach(KeyValuePair<string, string> t in table)
            {
                Console.Write("[Key] : "+ t.Key + "\t");
                Console.WriteLine("[Value] : " + t.Value + "\n");
            }
        }

        public static void Main(string[] args)
        {
            HashTable ht = new HashTable();
            ht.InsertSample();
            ht.PrintAll();
            ht.DeleteSample();
            ht.PrintAll();
            ht.Select();
            ht.Update();
            ht.PrintAll();
        }
    }
}
