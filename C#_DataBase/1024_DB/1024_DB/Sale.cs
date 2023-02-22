using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024_DB
{
    internal class Sale
    {
        public int Cid { get; private set; }
        public int Pid { get; private set; }
        public int Count { get; private set; }
        public string Date { get; private set; }

        public Sale(int cid, int pid, int count, string date)
        {
            Cid = cid;
            Pid = pid;
            Count = count;
            Date = date;
        }
    }
}
