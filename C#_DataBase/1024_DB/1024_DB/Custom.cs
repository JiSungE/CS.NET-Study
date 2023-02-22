using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024_DB
{
    internal class Custom
    {
        public int CID { get; private set; }
        public string CNAME { get; private set; }
        public string PHONE { get; private set; }
        public string ADDR { get; private set; }

        public Custom(int cID, string cNAME, string pHONE, string aDDR)
        {
            CID = cID;
            CNAME = cNAME;
            PHONE = pHONE;
            ADDR = aDDR;
        }
    }
}
