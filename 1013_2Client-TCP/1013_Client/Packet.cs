using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1013_Client
{
    internal static class Packet
    {
        public const string Pack_InsertMeMber = "P_INSERTMEMBER";
        public const string Pack_InsertMember_S = "P_INSERTMEMBER_S";
        public const string Pack_InsertMember_F = "P_INSERTMEMBER_F";

        public const string Pack_SelectAllMember = "P_SELECTALLMEMBER";
        public const string Pack_SelectAllMember_S = "P_SELECTALLMEMBER_S";
        public const string Pack_SelectAllMember_F = "P_SELECTALLMEMBER_F";

        public const string Pack_SelectMember = "P_SELECTMEMBER";
        public const string Pack_SelectMember_S = "P_SELECTMEMBER_S";
        public const string Pack_SelectMember_F = "P_SELECTMEMBER_F";

        public const string Pack_UpdateMember = "P_UPDATEMEMBER";
        public const string Pack_UpdateMember_S = "P_UPDATEMEMBER_S";
        public const string Pack_UpdateMember_F = "P_UPDATEMEMBER_F";

        public const string Pack_DeleteMember = "P_DELETEMEMBER";
        public const string Pack_DeleteMember_S = "P_DELETEMEMBER_S";
        public const string Pack_DeleteMember_F = "P_DELETEMEMBER_F";

        public static string InsertMenber(string name, string phone, int age, int gender)
        {
            string pack = string.Empty;

            pack += Pack_InsertMeMber + "@";
            pack += name + "#";
            pack += phone + "#";
            pack += age + "#";
            pack += gender;

            return pack;
        }

        public static string SelectAllMember()
        {
            string pack = string.Empty;
            pack += Pack_SelectAllMember + "@";
            return pack;
        }

        public static string Select(string name)
        {
            string pack = string.Empty;
            pack += Pack_SelectMember + "@";
            pack += name;
            return pack;
        }

        public static string Update(string name, string phone, int age)
        {
            string pack = string.Empty;

            pack += Pack_UpdateMember + "@";
            pack += name + "#";
            pack += phone + "#";
            pack += age;
            return pack;
        }

        public static string delete(string name)
        {
            string pack = string.Empty;

            pack += Pack_DeleteMember + "@";
            pack += name;
            return pack;
        }

    }
}
