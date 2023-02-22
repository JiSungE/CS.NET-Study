using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1025_Account_DB
{
    internal class AccountLog
    {
        public int IOID { get; set; }
        public int ACCID { get; set; }
        public int Input { get; set; }
        public int Output { get; set; }
        public int Balance { get; set; }
        public string IODATE { get; set; }

        public AccountLog(int iOID, int aCCID, int input, int output, int balance, string iODATE)
        {
            IOID = iOID;
            ACCID = aCCID;
            Input = input;
            Output = output;
            Balance = balance;
            IODATE = iODATE;
        }
    }
}
