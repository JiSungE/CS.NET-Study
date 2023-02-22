using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _1024_DB
{
    internal class Wb_DataBase
    {
        public static Wb_DataBase database { get; private set; }
        static Wb_DataBase()
        {
            database = new Wb_DataBase();
        }
        private Wb_DataBase()
        {

        }



        public SqlConnection Scon { get; private set; }
        public void Open()
        {
            // 서버 이름 : LAPTOP-MSICAKQB\SQLEXPRESS
            string constr = @"Data Source=LAPTOP-MSICAKQB\SQLEXPRESS; Initial Catalog=wb36; User ID=KimJiSung;Password=1234";
            Scon = new SqlConnection(constr);            //작업 수행
            Scon.Open(); //연결 열기
        }

        public void Close()
        {
            Scon.Close();
        }
        #region  ExecuteNonQuery(insert, update, delete)
        public void Insert_Product(string pname, int price, string desc)
        {

            string sql = string.Format("insert into Product values('{0}', {1}, '{2}')", pname, price, desc);
            ExecuteNonQuery(sql);
        }

        public void Insert_Custom(string cname, string phone, string addr)
        {
            string sql = string.Format("insert into Custom values('{0}', '{1}', '{2}')", cname, phone, addr);
            ExecuteNonQuery(sql);
        }

        public void Insert_Sale(string cname, string pname, int count)
        {
            string sql = string.Format("insert into Sale values((select CID from Custom where CNAME = '{0}'), (select PID from Product where PNAME = '{1}'), {2}, GETDATE());",cname, pname, count);
            ExecuteNonQuery(sql);
        }

        public void Delete_Product(int pid)
        {
            string sql = string.Format("delete from Product where PID = {0};", pid);
            ExecuteNonQuery(sql);
        }

        public void Delete_Custom(int pid)
        {
            string sql = string.Format("delete from Custom where CID = {0};", pid);
            ExecuteNonQuery(sql);
        }


        public void Update_Product(int pid, int price, string description)
        {
            string sql = string.Format("update Product set Price = {0} where PID = {1};", price, pid);
            string sql2 = string.Format("update Product set Description = '{0}' where PID = {1};", description, pid);

            ExecuteNonQuery(sql);
            ExecuteNonQuery(sql2);
        }

        public void Update_Custom(int cid, string phone, string addr)
        {
            string sql = string.Format("update Custom set PHONE = '{0}' where CID = {1};", phone, cid);
            string sql2 = string.Format("update Custom set ADDR = '{0}' where CID = {1};", addr, cid);

            ExecuteNonQuery(sql);
            ExecuteNonQuery(sql2);
        }

        private void ExecuteNonQuery(string sql)
        {
            using (SqlCommand scom = new SqlCommand(sql, Scon))
            {
                int ret = scom.ExecuteNonQuery(); // insert, update, delete와 같은 기본 처리문에서 사용함
                if (ret != 1)
                {
                    throw new Exception("저장 실패");
                }
            }
        }
        #endregion

        #region ExecuteReader(select)
        public List<Product> SelecAll()
        {
            string sql = "select * from Product;";

            SqlCommand scom = new SqlCommand(sql, Scon);
            SqlDataReader reader = scom.ExecuteReader();

            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product(reader[0].ToString(), reader[1].ToString(), int.Parse(reader[2].ToString()), reader[3].ToString());
                products.Add(p);
            }

            reader.Close();
            return products;
        }

        public List<Custom> CustomSelectAll()
        {
            string sql = "select * from Custom;";

            SqlCommand scom = new SqlCommand(sql, Scon);
            SqlDataReader reader = scom.ExecuteReader();

            List<Custom> customs = new List<Custom>();
            while (reader.Read())
            {
                Custom p = new Custom(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                customs.Add(p);
            }

            reader.Close();
            return customs;
        }

        public List<string> CustomNameSelectAll()
        {
            string sql = "select CNAME from Custom";

            SqlCommand scom = new SqlCommand(sql, Scon);
            SqlDataReader reader = scom.ExecuteReader();

            List<string> cnames = new List<string>();

            while(reader.Read())
            {
                string s = string.Format("{0}", reader[0]);
                cnames.Add(s);
            }
            reader.Close();

            return cnames;
        }

        public List<string> ProductNameSelectAll()
        {
            string sql = "select PNAME from Product";

            SqlCommand scom = new SqlCommand(sql, Scon);
            SqlDataReader reader = scom.ExecuteReader();

            List<string> pnames = new List<string>();

            while (reader.Read())
            {
                string s = string.Format("{0}", reader[0]);
                pnames.Add(s);
            }
            reader.Close();

            return pnames;
        }

        public List<Sale> SaleSelectAll()
        {
            string sql = "select * from Sale";

            SqlCommand scom = new SqlCommand(sql, Scon);
            SqlDataReader reader = scom.ExecuteReader();

            List<Sale> sales = new List<Sale>();

            while (reader.Read())
            {
                Sale s = new Sale(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), int.Parse(reader[2].ToString()), reader[3].ToString());
                sales.Add(s);
            }
            reader.Close();

            return sales;
        }

        public Sale SelectSale(string name)
        {
            string sql = string.Format("select * from Sale where CID = (select CID from Custom where CNAME = '{0}');", name);
            SqlCommand scom = new SqlCommand(sql, Scon);
            SqlDataReader reader = scom.ExecuteReader();

            reader.Read();

            Sale s = new Sale(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), int.Parse(reader[2].ToString()), reader[3].ToString());

            reader.Close();

            return s;
        }

        #endregion

        #region ExecuteScalar(select)
        public int ProductRowCount()
        {
            string sql = "select COUNT(*) from Product;";

            SqlCommand scom = new SqlCommand(sql, Scon);
            int count = (int)scom.ExecuteScalar();

            return count;
        }

        public int CusTomRowCount()
        {
            string sql = "select COUNT(*) from Custom;";

            SqlCommand scom = new SqlCommand(sql, Scon);
            int count = (int)scom.ExecuteScalar();

            return count;
        }
        #endregion


    }
}
