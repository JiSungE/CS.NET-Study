using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1026_메모리DB
{
    public partial class Form1 : Form
    {
        private WBMemoryDB _memoryDB = new WBMemoryDB();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        #region 테이블 생성 소멸 버튼 핸들러
        private void button1_Click(object sender, EventArgs e)
        {
            _memoryDB.CreateCustomTable();
            textBox1.Text = _memoryDB.getCustomTableSchema();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _memoryDB.CreateAccountTable();
            textBox2.Text = _memoryDB.getAccountTableSchema();
            string[] columes = _memoryDB.get_AccountTableColumes();
            Form_UI.AccountTable_ListView_Col_Init(listView2, columes);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _memoryDB.CreateAccountIOTabel();
            textBox3.Text = _memoryDB.getAccountIOTableSchema();

            Form_UI.AccountIOTable_DateGridView_Binding(_memoryDB.AccountIO_Table, dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _memoryDB.DropCustomTable();
            textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _memoryDB.DropAccountTable();
            textBox2.Text = "";
            listView2.Columns.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _memoryDB.DropAccountIOTable();
            textBox3.Text = "";

            dataGridView1.DataSource = null;
        }

        #endregion

        #region 데이터셋 생성
        private void button7_Click(object sender, EventArgs e)
        {
            _memoryDB.CreateDataSet();
        }

        #endregion

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        #region Custom 테이블 버튼 핸들
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox4.Text;
                string phone = textBox5.Text;
                string addr = textBox6.Text;
                _memoryDB.InsertCustom(name, phone, addr);
                Form_UI.CustomTable_PrintAll(listView1, _memoryDB.Custom_Table);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int cid = int.Parse(textBox9.Text);
                int balance = int.Parse(textBox8.Text);

                int accid = _memoryDB.insertAccount(cid, balance);
                Form_UI.AccountTable_PrintAll(listView2, _memoryDB.Account_Table);

                _memoryDB.insertAccountIO(accid, balance, 0, balance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                int accid = int.Parse(textBox7.Text);
                int money = int.Parse(textBox13.Text);

                int temp = _memoryDB.depositAccount(accid, money);
                Form_UI.AccountTable_PrintAll(listView2, _memoryDB.Account_Table);

                _memoryDB.insertAccountIO(accid, money, 0, temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                int accid = int.Parse(textBox7.Text);
                int money = int.Parse(textBox13.Text);

                int temp = _memoryDB.withRawAccount(accid, money);
                Form_UI.AccountTable_PrintAll(listView2, _memoryDB.Account_Table);

                _memoryDB.insertAccountIO(accid, 0, money, temp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button11_Click(object sender, EventArgs e)
        {
            _memoryDB.XMLWrite();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _memoryDB.XMLRead();
            Form_UI.CustomTable_PrintAll(listView1, _memoryDB.Custom_Table);
            Form_UI.AccountTable_PrintAll(listView2, _memoryDB.Account_Table);
        }


    }
}
