using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1025_Account_DB
{
    internal class Account
    {
        public int AccID { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public DateTime Created { get; set; }

        public Account(int accID, string name, int balance, DateTime created)
        {
            AccID = accID;
            Name = name;
            Balance = balance;
            Created = created;
        }
    }
}
