using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 비연결지향
{
    internal class WbDataBase1
    {
        string constr = @"Data Source=LAPTOP-MSICAKQB\SQLEXPRESS; Initial Catalog=wb36; User ID=KimJiSung;Password=1234";

        private DataSet data_set = new DataSet("wb36");

        #region Fill메서드 사용
        public DataTable customFill()
        {
            string sql = "select * from Custom";

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, con);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                adapter.Fill(data_set, "Custom");
                adapter.Dispose();
            }

            return data_set.Tables["Custom"];
        }

        public DataTable accountFill()
        {
            string sql = "select * from Account";

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, con);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                adapter.Fill(data_set, "Account");
                adapter.Dispose();
            }

            return data_set.Tables["Account"];
        }

        public DataTable accountioFill()
        {
            string sql = "select * from Accountio";

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, con);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                adapter.Fill(data_set, "Accountio");
                adapter.Dispose();
            }

            return data_set.Tables["Accountio"];
        }

        #endregion



        public void customUpdate()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = customMakeUpdateCommand(con);
                adapter.InsertCommand = customMakeInsertCommand(con);
                adapter.DeleteCommand = customMakeDeleteCommand(con);
                adapter.Update(data_set.Tables["Custom"]);

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


        public static SqlCommand customMakeInsertCommand(SqlConnection con)
        {
            string cmd_text = "insert into Custom values(@CNAME, @PHONE, @ADDR)";
            SqlCommand cmd = new SqlCommand(cmd_text, con);

            cmd.Parameters.Add("@CNAME", SqlDbType.VarChar, 50, "CNAME");
            cmd.Parameters.Add("@PHONE", SqlDbType.VarChar, 50, "PHONE");
            cmd.Parameters.Add("@ADDR", SqlDbType.VarChar, 100, "ADDR");
            return cmd;
        }
        public static SqlCommand customMakeDeleteCommand(SqlConnection con)
        {
            string cmd_text = "delete from Custom where CID = @CID";
            SqlCommand cmd = new SqlCommand(cmd_text, con);

            cmd.Parameters.Add("@CID", SqlDbType.Int, 4, "CID");

            return cmd;
        }

        public void customDelete(int cid)
        {
            data_set.Tables["Custom"].Rows.Find(cid).Delete();
        }

    }
}
