using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1011_계좌
{
    internal class FaithAccount:Account
    {
        public FaithAccount(int id, string name, int money):base(id, name, (int)(money + money * 0.01))
        {

        }

        public FaithAccount(int id, string name):base(id, name)
        {

        }

        public override void AddMoney(int val)
        {
            int money = (int)(val + val * 0.01);
            base.AddMoney(money);
        }
    }
}
