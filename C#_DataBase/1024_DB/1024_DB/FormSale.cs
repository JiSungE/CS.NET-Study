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
    public partial class FormSale : Form
    {
        Wb_DataBase database = Wb_DataBase.database;
        public FormSale()
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

        public void PrintAll()
        {
            List<string> cnames = database.CustomNameSelectAll();

            listBox1.Items.Clear();
            foreach (string s in cnames)
            {
                listBox1.Items.Add(s);
            }

            List<string> pnames = database.ProductNameSelectAll();

            comboBox1.Items.Clear();
            foreach(string s in pnames)
            {
                comboBox1.Items.Add(s);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Format("{0}",listBox1.Text);
            textBox4.Text = string.Format("{0}", listBox1.Text);
            //ListBox.SelectedIndexCollection item = listBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = string.Format("{0}", comboBox1.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cname = textBox1.Text;
                string pname = textBox2.Text;
                int count = int.Parse(textBox3.Text);
                database.Insert_Sale(cname, pname, count);
                PrintAll();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox4.Text == "")
            {
                List<Sale> cnames = database.SaleSelectAll();

                listView1.Items.Clear();
                foreach (Sale s in cnames)
                {
                    ListViewItem item = new ListViewItem(s.Cid.ToString());
                    item.SubItems.Add(s.Pid.ToString());
                    item.SubItems.Add(s.Count.ToString());
                    item.SubItems.Add(s.Date);

                    listView1.Items.Add(item);
                }
            }
            else
            {
                // select * from Sale where CID = (select CID from Custom where CNAME = '홍길동');
                string name = textBox4.Text;
                Sale sale = database.SelectSale(name);

                listView1.Items.Clear();

                ListViewItem item = new ListViewItem(sale.Cid.ToString());
                item.SubItems.Add(sale.Pid.ToString());
                item.SubItems.Add(sale.Count.ToString());
                item.SubItems.Add(sale.Date);

                listView1.Items.Add(item);
            }
        }
    }
}
