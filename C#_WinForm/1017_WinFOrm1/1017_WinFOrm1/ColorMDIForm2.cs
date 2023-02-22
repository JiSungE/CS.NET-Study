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
    public partial class ColorMDIForm2 : Form
    {
        private Button[] btn        = new Button[4];
        private Form[] newMDIChild  = new Form[10];
        private string[] strData    = { "수평", "수직", "계단식", "아이콘" };

        public ColorMDIForm2()
        {
            InitializeComponent();
            this.BackColor = Color.Wheat;

            for (int i = 0; i < 4; i++)
            {
                btn[i] = new Button();
                btn[i].Text = strData[i];
                btn[i].SetBounds(50 * i, 10, 50, 50);
                btn[i].Click += ColorMDIForm2_Click;
                this.Controls.Add(btn[i]);
            }
        }

        private void ColorMDIForm2_Click(object sender, EventArgs e)
        {
            if ((Button)sender == btn[0])      // ❸ “수평” 버튼일 경우
            {
                this.LayoutMdi(MdiLayout.TileHorizontal);
                this.Text = "수평 바둑판 정렬";
            }
            else if ((Button)sender == btn[1]) // ❹ “수직” 버튼일 경우
            {
                this.LayoutMdi(MdiLayout.TileVertical);
                this.Text = "수직 바둑판 정렬";
            }
            else if ((Button)sender == btn[2]) // ❺ “계단식” 버튼일 경우
            {
                this.LayoutMdi(MdiLayout.Cascade);
                this.Text = "계단식 정렬";
            }
            else if ((Button)sender == btn[3])  // ❻ “아이콘” 버튼일 경우
            {
                this.LayoutMdi(MdiLayout.ArrangeIcons);
                this.Text = "아이콘 정렬";
            }
        }

        private void ColorMDIForm2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < newMDIChild.Length; i++)
            {
                newMDIChild[i] = new Form();
                newMDIChild[i].Text = i + "번째 자식창";
                newMDIChild[i].MdiParent = this; // MDI 자식 폼 등록
                newMDIChild[i].Show();
            }
        }
    }
}
