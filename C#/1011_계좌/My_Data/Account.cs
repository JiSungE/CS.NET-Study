using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1011_계좌
{
    internal class Account
    {
        public int M_id { get; private set; }
        public int M_balance { get; set; }

        public string M_name { get; private set; }

        public DateTime CreateDate { get; private set; }

        public Account(int id, string name, int balance)
        {
            M_id = id;
            M_balance = balance;
            M_name = name;
            CreateDate = DateTime.Now;
        }

        public Account(int id, string name):this(id, name, 0) { }

        public virtual void AddMoney(int val)
        {
            if(val < 0)
            {
                throw new Exception("잘못된 금액");
            }

            M_balance += val;
        }

        public void MinMoney(int val)
        {
            if(val < 0)
            {
                throw new Exception("잘못된 금액");
            }

            if(M_balance < val)
            {
                throw new Exception("부족하다. 잔액. 돌아가라.");
            }
        }

        public virtual void ShowAllData()
        {
            Console.WriteLine("계좌  ID : {0}", M_id);
            Console.WriteLine("이    름 : {0}", M_name);
            Console.WriteLine("잔    액 : {0}", M_balance);
            Console.WriteLine("개설일시 : {0}", CreateDate);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}원, {3}", M_id, M_name, M_balance, CreateDate);
        }

        
    }
}
