using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1011_계좌
{
    internal class AccountControl_Linked
    {
        private LinkedList<Account> LInked_;

        #region 싱글톤 패턴
        public static AccountControl_Linked Singleton { get; private set; }
        static AccountControl_Linked()
        {
            Singleton = new AccountControl_Linked();
        }
        private AccountControl_Linked()
        {
        }
        #endregion


        public void PrintAll()
        {
            int idx = 0;
            foreach(Account acc in LInked_)
            {
                if(acc != null)
                {
                    Console.Write("{0} : ", idx);
                    Console.WriteLine(acc);
                    idx++;
                }
            }
        }

        public void Insert()
        {
            try
            {
                Console.WriteLine("[회원 정보 저장]");

                int accnumber = wbLib.getint("계좌번호");
                string name = wbLib.getstring("이름");
                int balance = wbLib.getint("입금액");

                int type = wbLib.getint("계좌종류 [1]일반 [2]신용 [3]기부")
;
                Account acc;

                if (type == 1)
                {
                    acc = new Account(accnumber, name, balance);
                }
                else if (type == 2)
                {
                    acc = new FaithAccount(accnumber, name, balance);
                }
                else if (type == 3)
                {
                    acc = new ContriAccount(accnumber, name, balance);
                }
                else
                {
                    throw new Exception("계좌종류 선택 오류");
                }


                LInked_.AddLast(acc);
                Console.WriteLine("생성되었습니다");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Select()
        {
            try
            {
                Console.WriteLine("[계좌번호 검색]");

                int accnum = wbLib.getint("검색할 계좌번호");

                LinkedListNode<Account> current = LInked_.First;

                while(current.Value.M_id != accnum)
                {
                    current = current.Next;
                }

                current.Value.ShowAllData();
                //Account acc = container[idx] as Account;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //private int AccNumberToIdx(int accnum)
        //{
        //    for (int i = 0; i < container.Count; i++)
        //    {
        //        Account acc = container[i] as Account;
        //        if (acc != null && acc.M_id == accnum)
        //        {
        //            return i;
        //        }
        //    }
        //    throw new Exception("존재하지 않는 번호입니다.");
        //}
        public void Update1()
        {
            try
            {
                Console.WriteLine("[입금]");

                int accnum = wbLib.getint("입금할 계좌번호");

                LinkedListNode<Account> current = LInked_.First;

                while (current.Value.M_id != accnum)
                {
                    current = current.Next;
                }
                int deposit = wbLib.getint("입금액");

                current.Value.M_balance += deposit;

                Console.WriteLine("입금되었습니다");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void update2()
        {
            try
            {
                Console.WriteLine("[출금]");

                int accnum = wbLib.getint("출금할 계좌번호");

                LinkedListNode<Account> current = LInked_.First;

                while (current.Value.M_id != accnum)
                {
                    current = current.Next;
                }
                int withraw = wbLib.getint("출금액");

                current.Value.M_balance -= withraw;

                Console.WriteLine("출금되었습니다");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete()
        {
            try
            {
                Console.WriteLine("[계좌 삭제]");

                int accnum = wbLib.getint("삭제할 계좌번호");

                LinkedListNode<Account> current = LInked_.First;

                while (current.Value.M_id != accnum)
                {
                    current = current.Next;
                }

                LInked_.Remove(current);

                Console.WriteLine("삭제되었습니다");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Sort1()// 내림차순
        {
            List<Account> temp = LInked_.OrderByDescending(x => x.M_name).ToList();

            LinkedListNode<Account> current = LInked_.First;

            foreach(Account a in temp)
            {
                current.Value = a;
                current = current.Next;
            }
        }

        public void Sort2()// 오름차순
        {
            List<Account> temp = LInked_.OrderBy(x => x.M_name).ToList();

            LinkedListNode<Account> current = LInked_.First;

            foreach (Account a in temp)
            {
                current.Value = a;
                current = current.Next;
            }
        }

    }
}