using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using WoosongBit.Network;

namespace _1013_Client
{
    internal class Program
    {
        private Wb_TcpClient client = new Wb_TcpClient("127.0.0.1", 7000);

        public void RecvMessage(string packet)
        {
            //Console.WriteLine("수신 메시지 : " + packet);
            string[] sp1 = packet.Split('@');
            if (sp1[0] == Packet.Pack_InsertMember_S)
            {
                string name = sp1[1];
                Console.Write(">> {0}의 회원가입 성공", name);
            }
            else if(sp1[0] == Packet.Pack_InsertMember_F)
            {
                string name = sp1[1];
                Console.Write(">> {0}의 회원가입 실패", name);
            }
            else if (sp1[0] == Packet.Pack_SelectAllMember_S)
            {
                Console.WriteLine("|이름|  |전화번호|  |나이|  |성별|");
                string[] sp2 = sp1[1].Split('#');
                foreach(string data in sp2)
                {
                    Console.WriteLine(data);
                }
            }
            else if (sp1[0] == Packet.Pack_SelectAllMember_F)
            {
                Console.WriteLine("전체 출력 실패");
            }
            else if (sp1[0] == Packet.Pack_SelectMember_S)
            {
                string[] sp2 = sp1[1].Split('#');
                Console.WriteLine("이름 : {0}", sp2[0]);
                Console.WriteLine("전화번호 : {0}", sp2[1]);
                Console.WriteLine("나이 : {0}", sp2[2]);
                Console.WriteLine("성별 : {0}", sp2[3]);
            }
            else if (sp1[0] == Packet.Pack_SelectMember_F)
            {
                Console.WriteLine("선택 실패");
            }
            else if (sp1[0] == Packet.Pack_UpdateMember_S)
            {
                Console.WriteLine("수정 성공");
            }
            else if (sp1[0] == Packet.Pack_UpdateMember_F)
            {
                Console.WriteLine("수정 실패");
            }
            else if (sp1[0] == Packet.Pack_DeleteMember_S)
            {
                Console.WriteLine("삭제 성공");
            }
            else if (sp1[0] == Packet.Pack_DeleteMember_F)
            {
                Console.WriteLine("삭제 실패");
            }
        }

        public Program()
        {
            client.RecvFunc = RecvMessage;
            Console.WriteLine("서버에 접속...");
        }

        static void Main(string[] args)
        {
            //Wb_TcpClient client = new Wb_TcpClient("127.0.0.1", 7000);
            Program pr = new Program();
            pr.Run();
            //string name = "홍길동";
            while(true)
            {
            

            char msg = char.Parse(Console.ReadLine());
            if (msg == 'q')
            {
                    break;
            }

            }
            //client.Send(pack);

            //client.Close();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                selectAll();
                Thread.Sleep(2000);
                switch (MenuPrint())
                {
                    case ConsoleKey.Q: return;
                    case ConsoleKey.F1: insert(); break;
                    case ConsoleKey.F2: select(); break;
                    case ConsoleKey.F3: update(); break;
                    case ConsoleKey.F4: delete(); break;
                    case ConsoleKey.F5: selectAll();  break;
                }
                Console.Write("\n결과를 기다립니다.....\n");
                Console.ReadKey(true);
            }
        }

        private ConsoleKey MenuPrint()
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine("[Q] 프로그램 종료");
            Console.WriteLine("[F1] Insert(회원 정보 저장)");
            Console.WriteLine("[F2] Select(회원 정보 검색)");
            Console.WriteLine("[F3] Update(회원 정보 수정)");
            Console.WriteLine("[F4] Delete(회원 정보 삭제)");
            Console.WriteLine("[F5] SelectAll(회원 전체 출력)");
            Console.WriteLine("***************************************************************");
            return Console.ReadKey(true).Key;   //#include <conio.h>
        }


        #region 기능함수
        private void insert()
        {
            Console.WriteLine("[회원 정보 저장]");

            Console.Write("이름 : ");
            string name = Console.ReadLine();

            Console.Write("전화번호 : ");
            string phone = Console.ReadLine();

            Console.Write("나이 : ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("성별([1]남성, [2]여성)");
            int gender = int.Parse(Console.ReadLine());

            string pack = Packet.InsertMenber(name, phone, age, gender);
            client.Send(pack);
        }

        private void select()
        {
            Console.WriteLine("[회원 정보 선택]");
            Console.Write("검색할 회원 이름 : ");
            string name = Console.ReadLine();
            string pack = Packet.Select(name);
            client.Send(pack);
        }

        private void selectAll()
        {
            Console.WriteLine("[회원 정보 전체 선택]");
            string pack = Packet.SelectAllMember();
            client.Send(pack);
        }

        private void update()
        {
            Console.WriteLine("[회원 정보 수정]");

            Console.Write("검색할 이름 : ");
            string name = Console.ReadLine();

            Console.Write("바꿀 전화번호 : ");
            string phone = Console.ReadLine();

            Console.Write("바꿀 나이 : ");
            int age = int.Parse(Console.ReadLine());

            string pack = Packet.Update(name, phone, age);
            client.Send(pack);
        }

        private void delete()
        {
            Console.WriteLine("[회원 정보 삭제]");

            Console.Write("검색할 이름 : ");
            string name = Console.ReadLine();

            string pack = Packet.delete(name);
            client.Send(pack);
        }
        #endregion
    }
}