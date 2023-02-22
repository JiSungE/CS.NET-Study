using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1026_메모리DB
{
    internal class WBMemoryDB
    {
        private DataSet   wb36_dataset = null;
        private DataTable custom_table = null;
        private DataTable account_table = null;
        private DataTable accountio_table = null;

        public DataTable Custom_Table { get { return custom_table; } }
        public DataTable AccountIO_Table { get { return accountio_table; } }
        public DataTable Account_Table { get { return account_table; } }
        #region 테이블 생성 및 소멸

        public void CreateCustomTable()
        {
            custom_table = new DataTable("Custom");

            DataColumn dc_cid = new DataColumn("CID", typeof(int));
            dc_cid.AutoIncrement = true;
            dc_cid.AutoIncrementSeed = 1;
            dc_cid.AutoIncrementStep = 1;
            custom_table.Columns.Add(dc_cid);

            DataColumn dc_name = new DataColumn("CNAME", typeof(string));
            dc_name.AllowDBNull = false;
            custom_table.Columns.Add(dc_name);

            DataColumn dc_phone = new DataColumn("PHONE", typeof(string));
            dc_phone.AllowDBNull = false;
            custom_table.Columns.Add(dc_phone);

            DataColumn dc_addr = new DataColumn("ADDR", typeof(string));
            dc_addr.AllowDBNull = false;
            custom_table.Columns.Add(dc_addr);

            DataColumn[] pkeys = new DataColumn[1];
            pkeys[0] = dc_cid;
            custom_table.PrimaryKey = pkeys;
        }

        public void CreateAccountTable()
        {
            account_table = new DataTable("Account");

            DataColumn dc_accid = new DataColumn("ACCID", typeof(int));
            dc_accid.AutoIncrement = true;
            dc_accid.AutoIncrementSeed = 1000;
            dc_accid.AutoIncrementStep = 10;
            account_table.Columns.Add(dc_accid);

            DataColumn dc_cid = new DataColumn("CID", typeof(int));
            dc_cid.AllowDBNull = false;
            account_table.Columns.Add(dc_cid);

            DataColumn dc_accbalance = new DataColumn("ACCBALANCE", typeof(int));
            dc_accbalance.AllowDBNull = false;
            dc_accbalance.DefaultValue = 0;
            account_table.Columns.Add(dc_accbalance);

            DataColumn dc_accdate = new DataColumn("ACCDATE", typeof(DateTime));
            dc_accdate.AllowDBNull = false;
            account_table.Columns.Add(dc_accdate);

            DataColumn[] pkeys = new DataColumn[1];
            pkeys[0] = dc_accid;
            account_table.PrimaryKey = pkeys;
        }

        public void CreateAccountIOTabel()
        {
            accountio_table = new DataTable("AccountIO");

            DataColumn dc_ioid = new DataColumn("IOID", typeof(int));
            dc_ioid.AutoIncrement = true;
            dc_ioid.AutoIncrementSeed = 1;
            dc_ioid.AutoIncrementStep = 1;
            accountio_table.Columns.Add(dc_ioid);

            DataColumn dc_accid = new DataColumn("ACCID", typeof(int));
            dc_accid.AllowDBNull = false;
            accountio_table.Columns.Add(dc_accid);

            DataColumn dc_input = new DataColumn("INPUT", typeof(int));
            dc_input.AllowDBNull = false;
            accountio_table.Columns.Add(dc_input);

            DataColumn dc_output = new DataColumn("OUTPUT", typeof(int));
            dc_output.AllowDBNull = false;
            accountio_table.Columns.Add(dc_output);

            DataColumn dc_balance = new DataColumn("BALANCE", typeof(int));
            dc_balance.AllowDBNull = false;
            accountio_table.Columns.Add(dc_balance);

            DataColumn dc_iodate = new DataColumn("IODATE", typeof(DateTime));
            dc_iodate.AllowDBNull = false;
            accountio_table.Columns.Add(dc_iodate);

            DataColumn[] pkeys = new DataColumn[1];
            pkeys[0] = dc_ioid;
            accountio_table.PrimaryKey = pkeys;
        }

        public void DropCustomTable()
        {
            custom_table.Dispose();
            custom_table = null;
        }

        public void DropAccountTable()
        {
            account_table.Dispose();
            account_table = null;
        }

        public void DropAccountIOTable()
        {
            accountio_table.Dispose();
            accountio_table = null;
        }
        #endregion

        #region 테이블 스키마 정보 제공
        public string getCustomTableSchema()
        {
            string temp = string.Empty;
            temp += "------------------------------------------------\r\n";
            temp += "[테이블명]" + custom_table.TableName + "\r\n";
            temp += "[컬럼개수]" + custom_table.Columns.Count + "\r\n";
            temp += "[기 본 키]" + custom_table.PrimaryKey[0].ColumnName + "\r\n";
            temp += "------------------------------------------------\r\n\r\n";

            foreach (DataColumn dc in custom_table.Columns)
            {
                temp += dc.ColumnName + "\t" + dc.DataType + "\r\n";
            }

            return temp;
        }

        public string getAccountTableSchema()
        {
            string temp = string.Empty;
            temp += "------------------------------------------------\r\n";
            temp += "[테이블명]" + account_table.TableName + "\r\n";
            temp += "[컬럼개수]" + account_table.Columns.Count + "\r\n";
            temp += "[기 본 키]" + account_table.PrimaryKey[0].ColumnName + "\r\n";
            temp += "------------------------------------------------\r\n\r\n";

            foreach (DataColumn dc in account_table.Columns)
            {
                temp += dc.ColumnName + "\t" + dc.DataType + "\r\n";
            }

            return temp;
        }

        public string getAccountIOTableSchema()
        {
            string temp = string.Empty;
            temp += "------------------------------------------------\r\n";
            temp += "[테이블명]" + accountio_table.TableName + "\r\n";
            temp += "[컬럼개수]" + accountio_table.Columns.Count + "\r\n";
            temp += "[기 본 키]" + accountio_table.PrimaryKey[0].ColumnName + "\r\n";
            temp += "------------------------------------------------\r\n\r\n";

            foreach (DataColumn dc in accountio_table.Columns)
            {
                temp += dc.ColumnName + "\t" + dc.DataType + "\r\n";
            }

            return temp;
        }
        #endregion

        #region AccountTable 컬럼정보 반환
        public string[] get_AccountTableColumes()
        {
            string[] colums = new string[account_table.Columns.Count];


            for(int i =0; i < account_table.Columns.Count; i++)
            {
                colums[i] = account_table.Columns[i].ColumnName;
            }

            return colums;
        }
        #endregion

        #region DateSet생성
        public void CreateDataSet()
        {
            wb36_dataset = new DataSet("wb36");

            wb36_dataset.Tables.Add(custom_table);
            wb36_dataset.Tables.Add(account_table);
            wb36_dataset.Tables.Add(accountio_table);

            DataColumn dc_custom_cid  = custom_table.Columns["CID"];
            DataColumn dc_account_cid = account_table.Columns["CID"];
            DataRelation dr = new DataRelation("고객ID",dc_custom_cid, dc_account_cid);
            wb36_dataset.Relations.Add(dr);

            DataColumn dc_account_acid = account_table.Columns["ACCID"];
            DataColumn dc_accountio_acid = accountio_table.Columns["ACCID"];
            DataRelation dr1 = new DataRelation("계좌번호", dc_account_acid, dc_accountio_acid);
            wb36_dataset.Relations.Add(dr1);
        }
        #endregion

        #region Custom 테이블 기능
        public void InsertCustom(string name, string phone, string addr)
        {
            DataRow dr = custom_table.NewRow();
            dr[1] = name;
            dr[2] = phone;
            dr[3] = addr;
            custom_table.Rows.Add(dr);
            
        }
        #endregion

        #region Account 테이블 기능
        public int insertAccount(int cid, int balance)
        {
            DataRow dr = account_table.NewRow();
            dr[1] = cid;
            dr[2] = balance;
            dr[3] = DateTime.Now;
            account_table.Rows.Add(dr);
            return int.Parse(dr[0].ToString());
        }

        public int depositAccount(int accid, int money)
        {
            DataRow dr = account_table.Rows.Find(accid);
            int temp = int.Parse(dr[2].ToString());
            dr[2] = temp + money;
            return int.Parse(dr[2].ToString());
        }

        public int withRawAccount(int accid, int money)
        {
            DataRow dr = account_table.Rows.Find(accid);
            int temp = int.Parse(dr[2].ToString());
            if((temp - money) < 0)
            {
                throw new Exception("잔액이 부족합니다.");
            }
            dr[2] = temp - money;
            return int.Parse(dr[2].ToString());
        }

        #endregion

        #region AccountIO 테이블 기능
        public void insertAccountIO(int accid, int input, int output, int balance)
        {
            DataRow dr = accountio_table.NewRow();
            dr[1] = accid;
            dr[2] = input;
            dr[3] = output;
            dr[4] = balance;
            dr[5] = DateTime.Now;
            accountio_table.Rows.Add(dr);

        }
        #endregion

        #region XML 저장 & 로드
        public void XMLWrite()
        {
            custom_table.WriteXml("custom.xml", true);
            account_table.WriteXml("account.xml", true);
            accountio_table.WriteXml("accountio.xml", true);

        }

        public void XMLRead()
        {
            custom_table.ReadXml("custom.xml");
            account_table.ReadXml("account.xml");
            accountio_table.ReadXml("accountio.xml");
        }
        #endregion
    }
}
