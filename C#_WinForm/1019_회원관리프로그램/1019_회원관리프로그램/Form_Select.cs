using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1019_회원관리프로그램
{
    public partial class Form_Select : Form
    {
        public event EventHandler Changed;
        public event EventHandler ChildClose;

        public string Id { get { return textBox1.Text; } }

        public Form_Select()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(this, new EventArgs());
        }

        private void Form_Select_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ChildClose != null)
                ChildClose(this, new EventArgs());
        }
    }
}
