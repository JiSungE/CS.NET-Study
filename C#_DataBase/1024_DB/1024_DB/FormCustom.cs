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
    public partial class FormCustom : Form
    {
        private Wb_DataBase database = Wb_DataBase.database;
        public FormCustom()
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
            int count = database.CusTomRowCount();
            
            label4.Text = String.Format("저장 개수: {0}", count);

            List<Custom> customs = database.CustomSelectAll();

            listView1.Items.Clear();
            foreach (Custom c in customs)
            {
                ListViewItem item = new ListViewItem(c.CID.ToString());
                item.SubItems.Add(c.CNAME);
                item.SubItems.Add(c.PHONE);
                item.SubItems.Add(c.ADDR);

                listView1.Items.Add(item);
            }
        }

        private void FormCustom_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string cname = textBox1.Text;
                string phone = textBox2.Text;
                string addr = textBox3.Text;
                database.Insert_Custom(cname, phone, addr);
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int cid = int.Parse(textBox4.Text);
                database.Delete_Custom(cid);
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
                string phone = textBox6.Text;
                string addr = textBox7.Text;

                database.Update_Custom(pid, phone, addr);
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
