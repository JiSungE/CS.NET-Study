using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1021_김지성
{
    public partial class Form1 : Form
    {
        Data data = new Data(Color.Red, "초기화된 문자열", 10, 0, 0);
        public Form1()
        {
            InitializeComponent();
            this.Invalidate();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawString(data.OutputString, new Font("Arial", data.Size), new SolidBrush(data.Color), data.Xpoint, data.Ypoint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime temp = DateTime.Now;
            this.Text = String.Format("{0}", temp);
        }

        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
        }

        private void 빨강RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.Color = Color.Red;
            this.Invalidate();
        }

        private void 초록GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.Color = Color.Green;
            this.Invalidate();
        }

        private void 파랑BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.Color = Color.Blue;
            this.Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            data.Xpoint = e.X;
            data.Ypoint = e.Y;
            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up: data.Size += 2; this.Invalidate(); break;
                case Keys.Down: data.Size -= 2; this.Invalidate(); break;
            }
        }

        private void 모달MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modal m = new Modal(this, data);
            m.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime temp = DateTime.Now;
            this.Text = String.Format("{0}", temp);
        }
    }
}
