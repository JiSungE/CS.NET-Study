using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1013_Server
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

        public static string InsertMember(bool result, string name)
        {
            string packet = string.Empty;

            if(result)
            {
                packet += Pack_InsertMember_S + "@";
            }
            else
            {
                packet += Pack_InsertMember_F + "@";
            }

            packet += name;

            return packet;
        }

        public static string SelectAll(List<Member> members)
        {
            string packet = string.Empty;
            
            packet += Pack_SelectAllMember_S + "@";
            foreach(Member mem in members)
            {
                packet += mem.Name + ", " ;
                packet += mem.Phone + ", ";
                packet += mem.Age + ", ";
                packet += mem.Gender + "#";
            }

            return packet;
        }

        public static string Select(Member mem)
        {
            string packet = string.Empty;

            packet += Pack_SelectMember_S + "@";

            packet += mem.Name + "#";
            packet += mem.Phone + "#";
            packet += mem.Age + "#";
            packet += mem.Gender;
            return packet;
        }

        public static string Update(Member mem, string phone, int age)
        {
            string packet = string.Empty;

            mem.Phone = phone;
            mem.Age = age;

            packet += Pack_UpdateMember_S + "@";

            return packet;
        }
        
        public static string Delete(List<Member> members, Member m)
        {
            string packet = string.Empty;

            members.Remove(m);
            packet += Pack_DeleteMember_S + "@";

            return packet;
        }

    }
}
