using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1011_계좌
{

    
    internal class AccountControl_List
    {
        private List<Account> container;

        #region 싱글톤 패턴
        public static AccountControl_List Singleton { get; private set; }
        static AccountControl_List()
        {
            Singleton = new AccountControl_List();
        }
        private AccountControl_List()
        {
        }
        #endregion


        public void PrintAll()
        {
            for (int i = 0; i < container.Count; i++)
            {
                Account acc = container[i] as Account;
                if (acc != null)
                {
                    Console.Write("{0} : ", i);
                    Console.WriteLine(acc);
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

                if(type == 1)
                {
                    acc = new Account(accnumber, name, balance);
                }
                else if(type == 2)
                {
                    acc = new FaithAccount(accnumber, name, balance);
                }
                else if(type == 3)
                {
                    acc = new ContriAccount(accnumber, name, balance);
                }
                else
                {
                    throw new Exception("계좌종류 선택 오류");
                }


                container.Add(acc);

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

                int idx = AccNumberToIdx(accnum);

                Account acc = container[idx] as Account;

                acc.ShowAllData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private int AccNumberToIdx(int accnum)
        {
            for (int i = 0; i < container.Count; i++)
            {
                Account acc = container[i] as Account;
                if (acc != null && acc.M_id == accnum)
                {
                    return i;
                }
            }
            throw new Exception("존재하지 않는 번호입니다.");
        }
        public void Update1()
        {
            try
            {
                Console.WriteLine("[입금]");

                int accnum = wbLib.getint("입금할 계좌번호");

                int idx = AccNumberToIdx(accnum);

                Account acc = container[idx] as Account;
                acc.AddMoney(wbLib.getint("입금액"));

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

                int idx = AccNumberToIdx(accnum);

                Account acc = container[idx] as Account;
                acc.MinMoney(wbLib.getint("출금액"));

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

                int idx = AccNumberToIdx(accnum);

                container.RemoveAt(idx);

                Console.WriteLine("삭제되었습니다");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Sort1()// 내림차순
        {
            container = container.OrderByDescending(x => x.M_name).ToList();

            foreach (var student in container)
            {
                Console.WriteLine(student);
            }
        }

        public void Sort2()// 오름차순
        {
            container = container.OrderBy(x => x.M_name).ToList();

            foreach (var student in container)
            {
                Console.WriteLine(student);
            }
        }

    }
}