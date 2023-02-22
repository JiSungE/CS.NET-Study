using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1024_DB
{
    public partial class FormProduct : Form
    {
        private Wb_DataBase database = Wb_DataBase.database;
        public FormProduct()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void InitForm(TabPage parent, Point pt)
        {
            TopLevel = false;
            parent.Controls.Add(this);
            Parent = parent;
            Location = pt;
            Show();
        }


        #region 연결 & 해제 버튼 핸들러
        // DB연결
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormCustom c = new FormCustom();
                database.Open();
                // 정보 획득
                DataBaseStatePrint();
                PrintAll();
                //c.PrintAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // DB연결 종료
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                database.Close();
                DataBaseStatePrintClear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region DB 상태정보 획득 및 리스트 view에 출력
        private void DataBaseStatePrint()
        {
            listView1.Items.Clear();


            ListViewItem item = new ListViewItem(database.Scon.WorkstationId);
            item.SubItems.Add(database.Scon.ServerVersion);
            item.SubItems.Add(database.Scon.PacketSize.ToString());
            item.SubItems.Add(database.Scon.ConnectionTimeout + "초");
            item.SubItems.Add(database.Scon.Database);
            item.SubItems.Add(database.Scon.DataSource);
            item.SubItems.Add(database.Scon.State.ToString());

            listView1.Items.Add(item);

        }

        private void DataBaseStatePrintClear()
        {
            listView1.Items.Clear();
        }
        #endregion

        #region 저장 기능

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string pname        = textBox1.Text;
                int price           = int.Parse(textBox2.Text);
                string description  = textBox3.Text;
                database.Insert_Product(pname, price, description);
                PrintAll();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 전체 출력기능
        public void PrintAll()
        {
            int count = database.ProductRowCount();

            label4.Text = String.Format("저장 개수: {0}", count);

            List<Product> products = database.SelecAll();

            listView2.Items.Clear();
            foreach(Product p in products)
            {
                ListViewItem item = new ListViewItem(p.Pid);
                item.SubItems.Add(p.Name) ;
                item.SubItems.Add(p.Price.ToString());
                item.SubItems.Add(p.Description);

                listView2.Items.Add(item);
            }
        }

        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = int.Parse(textBox4.Text);
                database.Delete_Custom(pid);
                PrintAll();
                textBox4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = int.Parse(textBox5.Text);
                int price = int.Parse(textBox6.Text);
                string description = textBox7.Text;

                database.Update_Product(pid, price, description);
                PrintAll();
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
