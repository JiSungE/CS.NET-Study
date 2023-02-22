using System;
using System.Text;
using WoosongBit.Network;
using System.Collections.Generic;

namespace _1013_Server
{
    internal class Program
    {
        private List<Member> members = new List<Member>();

        public string RecvMessage(string packet)
        {
            //Console.WriteLine("수신 메시지 : " + packet);
            string[] sp1 = packet.Split('@');

            if (sp1[0] == Packet.Pack_InsertMeMber)
            {
                string[] sp2 = sp1[1].Split('#');
                string name = sp2[0];
                string phone = sp2[1];
                int age = int.Parse(sp2[2]);
                enumGender gender = (enumGender)int.Parse(sp2[3]);

                Member member = new Member(name, phone, age, gender);
                members.Add(member);

                // 패킷 생성

                string pack = Packet.InsertMember(true, name);

                return pack;
            }
            else if(sp1[0] == Packet.Pack_SelectAllMember)
            {
                string pack = Packet.SelectAll(members);

                return pack;
            }
            else if (sp1[0] == Packet.Pack_SelectMember)
            {
                Member m = null;

                foreach(Member mem in members)
                {
                    if (sp1[1] == mem.Name)
                    {
                        m = mem;
                        break;
                    }
                }

                if (m == null)
                {
                    return Packet.Pack_SelectMember_F;
                }

                string pack = Packet.Select(m);

                return pack;
            }
            else if(sp1[0] == Packet.Pack_UpdateMember)
            {
                Member m = null;
                string[] sp2 = sp1[1].Split('#');

                foreach (Member mem in members)
                {
                    if (sp2[0] == mem.Name)
                    {
                        m = mem;
                        break;
                    }
                }
                if (m == null)
                {
                    return Packet.Pack_UpdateMember_F;
                }


                string pack = Packet.Update(m, sp2[1], int.Parse(sp2[2]));
                return pack;
            }
            else if (sp1[0] == Packet.Pack_DeleteMember)
            {
                Member m = null;

                foreach (Member mem in members)
                {
                    if (sp1[1] == mem.Name)
                    {
                        m = mem;
                        break;
                    }
                }

                if (m == null)
                {
                    return Packet.Pack_SelectMember_F;
                }

                string pack = Packet.Delete(members, m);
                return pack;
            }


                return string.Empty;
        }

        public void Run()
        {
            Wb_TcpListener server = new Wb_TcpListener(7000);  // TCP 7000번 포트 열기
            server.RecvFunc = RecvMessage;
            server.Start();
            Console.WriteLine("서버 시작... 클라이언트 접속 대기중...");
            server.Run();

            Console.ReadKey();

            server.Close();
        }

        static void Main(string[] args)
        {
            Program r = new Program();
            r.Run();
        }
    }
}