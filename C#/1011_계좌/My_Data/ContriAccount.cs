using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1011_계좌
{
    internal class ContriAccount: Account
    {
        public int Contribution { get; private set; }

        public ContriAccount(int id, string name, int balance):base(id, name, (int)(balance - balance * 0.01))
        {
            Contribution = (int)(balance * 0.01);
        }

        public ContriAccount(int id, string name):base(id, name)
        {
            Contribution = 0;
        }

        public override void AddMoney(int val)
        {
            int money = (int)(val - val * 0.01);
            base.AddMoney(money);
            Contribution += (int)(val * 0.01);
        }

        public override void ShowAllData()
        {
            base.ShowAllData();
            Console.WriteLine("총 기부액 : {0}", Contribution);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}원, {3} {4}원기부", M_id, M_name, M_balance, CreateDate, Contribution);
        }
    }
}
