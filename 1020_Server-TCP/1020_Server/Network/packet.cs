using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoosongBit.Network
{
    internal static class Packet
    {
        public const string Pack_ShortMessage = "P_SHORTMESSAGE";
        public static string ShortMessage(string nickname, string msg)
        {
            string pack = string.Empty;

            pack += Pack_ShortMessage + "@";
            pack += nickname + "#";
            pack += msg;

            return pack;
        }
    }
}
