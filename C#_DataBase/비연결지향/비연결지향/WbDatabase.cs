using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 비연결지향
{
    internal class WbDatabase
    {
        string constr = @"Data Source=LAPTOP-MSICAKQB\SQLEXPRESS; Initial Catalog=wb36; User ID=KimJiSung;Password=1234";
        
        private DataTable custom_table = null;
        private DataTable account_table = null;
        private DataTable accountio_table = null;

        #region 채우기
        public DataTable customFill()
        {
            string sql = "select * from Custom";

            using (SqlConnection con = new SqlConnection(constr))
            {
                custom_table = new DataTable("Custom");
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, con);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                adapter.Fill(custom_table);
                adapter.Dispose();
            }

            return custom_table;
        }

        public DataTable accountFill()
        {
            string sql = "select * from Account";

            using (SqlConnection con = new SqlConnection(constr))
            {
                account_table = new DataTable("Account");
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                adapter.SelectCommand = new SqlCommand(sql, con);

                adapter.Fill(account_table);
                adapter.Dispose();
            }

            return account_table;
        }

        public DataTable accountioFill()
        {
            string sql = "select * from Accountio";

            using (SqlConnection con = new SqlConnection(constr))
            {
                accountio_table = new DataTable("Accountio");
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                adapter.SelectCommand = new SqlCommand(sql, con);

                adapter.Fill(accountio_table);
                adapter.Dispose();
            }

            return accountio_table;
        }
        #endregion



        #region update
        public void customUpdate()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = customMakeUpdateCommand(con);
                adapter.InsertCommand = customMakeInsertCommand(con);
                adapter.DeleteCommand = customMakeDeleteCommand(con);
                adapter.Update(custom_table);

                adapter.Dispose();
            }
        }

        public static SqlCommand customMakeUpdateCommand(SqlConnection con)
        {
            string cmd_text = "update Custom set Phone=@Phone, Addr=@Addr where (CID = @CID)";
            SqlCommand cmd = new SqlCommand(cmd_text, con);

            cmd.Parameters.Add("@PHONE", SqlDbType.VarChar, 50, "PHONE");
            cmd.Parameters.Add("@ADDR", SqlDbType.VarChar, 50, "ADDR");
            cmd.Parameters.Add("@CID", SqlDbType.Int, 4, "CID");
            return cmd;
        }
        #endregion

        #region insert
        public static SqlCommand customMakeInsertCommand(SqlConnection con)
        {
            string cmd_text = "insert into Custom values(@CNAME, @PHONE, @ADDR)";
            SqlCommand cmd = new SqlCommand(cmd_text, con);

            cmd.Parameters.Add("@CNAME", SqlDbType.VarChar, 50, "CNAME");
            cmd.Parameters.Add("@PHONE", SqlDbType.VarChar, 50, "PHONE");
            cmd.Parameters.Add("@ADDR", SqlDbType.VarChar, 100, "ADDR");
            return cmd;
        }
        #endregion

        #region delete
        public static SqlCommand customMakeDeleteCommand(SqlConnection con)
        {
            string cmd_text = "delete from Custom where CID = @CID";
            SqlCommand cmd = new SqlCommand(cmd_text, con);

            cmd.Parameters.Add("@CID", SqlDbType.Int, 4, "CID");

            return cmd;
        }

        public void customDelete(int cid)
        {
            custom_table.Rows.Find(cid).Delete();
        }

        #endregion
    }

}
