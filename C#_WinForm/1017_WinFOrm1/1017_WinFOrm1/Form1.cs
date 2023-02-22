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
    public partial class Form1 : Form
    { 
        private Form[] newMDIChild = new Form[3];  // ❷ 자식 폼 생성
        
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            for (int i = 0; i < newMDIChild.Length; i++)
            {
                newMDIChild[i] = new Form();
                newMDIChild[i].Text = i + "번째 자식창";
                newMDIChild[i].MdiParent = this;  // ❸. MDI 자식 폼 만들기
                newMDIChild[i].Show();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
