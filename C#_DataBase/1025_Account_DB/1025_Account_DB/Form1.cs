using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1025_Account_DB
{
    public partial class Form1 : Form
    {
        private Wb_DataBase database = Wb_DataBase.database;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                database.Open();
                label4.Text = "연결상태 : Open";
            }
            catch(Exception ex)
            {
                label4.Text = ex.Message;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            database.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int cid = int.Parse(textBox1.Text);
                int money = int.Parse(textBox2.Text);
                database.NewAccount(cid, money);
                label3.Text = "계좌계설 성공";
            }
            catch(Exception ex)
            {
                label3.Text = ex.Message;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int accid = int.Parse(textBox3.Text);
                int money = int.Parse(textBox4.Text);
                database.InputAccount(accid, money);
                label7.Text = "입금 성공";
            }
            catch (Exception ex)
            {
                label7.Text = ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int accid = int.Parse(textBox6.Text);
                int money = int.Parse(textBox5.Text);
                database.OutputMoney(accid, money);
                label8.Text = "출금 성공";
            }
            catch (Exception ex)
            {
                label8.Text = ex.Message;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox7.Text;
                List<int> accs = database.GetAccList(name);

                comboBox1.Items.Clear();
                
                comboBox1.Items.Add("전체계좌리스트");
                foreach(int acc in accs)
                {
                    comboBox1.Items.Add(acc);
                }
                comboBox1.SelectedIndex = 0;
                label13.Text = "검색 성공";
            }
            catch (Exception ex)
            {
                label13.Text = ex.Message;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = comboBox1.SelectedIndex;
            List<Account> accounts = null;
            List<AccountLog> logs = null;
            if(idx == 0)
            {
                accounts = database.getAccountAll();
                logs = database.getLogAll();
            }
            else
            {
                int accid = int.Parse(comboBox1.Text);
                accounts = database.getAccount(accid);

                logs = database.getLog(accid);
            }

            listView1.Items.Clear();
            foreach(Account acc in accounts)
            {
                ListViewItem item = new ListViewItem(acc.AccID.ToString());
                item.SubItems.Add(acc.Name);
                item.SubItems.Add(acc.Balance.ToString());
                item.SubItems.Add(acc.Created.ToString());
                listView1.Items.Add(item);
            }


            listView2.Items.Clear();
            foreach (AccountLog Log in logs)
            {
                ListViewItem item = new ListViewItem(Log.IOID.ToString());
                item.SubItems.Add(Log.ACCID.ToString());
                item.SubItems.Add(Log.Input.ToString());
                item.SubItems.Add(Log.Output.ToString());
                item.SubItems.Add(Log.Balance.ToString());
                item.SubItems.Add(Log.IODATE.ToString());
                listView2.Items.Add(item);
            }

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
