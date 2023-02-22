using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1017_WinFOrm1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();

            ListBox listbox = new ListBox();

            listBox1.Items.Add("사과");
            listBox1.Items.Add("포도");
            listBox1.Items.Add("포도");


            ComboBox combobox = new ComboBox();
            comboBox1.Items.Add("사과");
            comboBox1.Items.Add("포도");
            comboBox1.Items.Add("포도");

            //comboBox2.Items.Add("사과");
            //comboBox2.Items.Add("포도");
            //comboBox2.Items.Add("포도");

            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            comboBox1.DrawMode = DrawMode.OwnerDrawVariable;

        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {

        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;

            Brush brush = Brushes.Black;

            switch (e.Index)
            {
                case 0:
                    brush = Brushes.Red;
                    break;
                case 1:
                    brush = Brushes.Violet;
                    break;
                case 2:
                    brush = Brushes.Green;
                    break;
            }
            g.DrawString(listBox1.Items[e.Index].ToString(),
                          e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;

            Brush brush = Brushes.Black;

            switch (e.Index)
            {
                case 0:
                    brush = Brushes.Red;
                    break;
                case 1:
                    brush = Brushes.Violet;
                    break;
                case 2:
                    brush = Brushes.Green;
                    break;
            }
            g.DrawString(comboBox1.Items[e.Index].ToString(),
                          e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }

        private void comboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = (string)listBox1.SelectedItem;
            this.Text = value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = (string)comboBox1.SelectedItem;
            this.Text = value;
        }
    }
}
