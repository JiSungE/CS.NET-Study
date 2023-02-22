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
    public partial class PM_Practice : Form
    {
        public int FigureSizeX { get; set; }
        public int FigureSizeY { get; set; } // 도형 사이즈 Y
        public char CurrentColor { get; set; } // 현재 색상

        

        public PM_Practice()
        {
            InitializeComponent();
            FigureSizeX = 100;
            FigureSizeY = 100;
            label9.Text = "G";
            CurrentColor = 'G';
            label8.Text = String.Format("x: {0} * y: {1}", FigureSizeX, FigureSizeY);
        }

        private void PM_Practice_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics grfx = this.CreateGraphics();
            label10.Text = string.Format("x: {0}, y: {1}", e.X, e.Y);
            Brush b = null;
            
            if(CurrentColor == 'R')
            {
                b = Brushes.Red;
            }
            else if(CurrentColor == 'G')
            {
                b = Brushes.Green;
            }
            else if(CurrentColor == 'B')
            {   
                b = Brushes.Blue;  
            }
            else
            {
                b = Brushes.Green;
            }

            grfx.FillRectangle(b, e.X, e.Y, FigureSizeX, FigureSizeY);
            grfx.DrawRectangle(Pens.Black, e.X, e.Y, FigureSizeX, FigureSizeY);
            //grfx.DrawRectangle(Pens.Brown, e.X, e.Y, 100, 100);
            grfx.Dispose();
        }

        private void PM_Practice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'R')
            {
                CurrentColor = 'R';
                label9.Text = "R";
                
            }
            else if (e.KeyValue == 'G')
            {
                CurrentColor = 'G';
                label9.Text = "G";
            }
            else if (e.KeyValue == 'B')
            {
                CurrentColor = 'B';
                label9.Text = "B";
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        FigureSizeX += 25;
                        FigureSizeY += 25;
                        if (FigureSizeY == 100 || FigureSizeX == 100)
                        {
                            FigureSizeX = 25;
                            FigureSizeY = 25;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        FigureSizeX -= 25;
                        FigureSizeY -= 25;
                        if (FigureSizeY == 0 || FigureSizeX == 0)
                        {
                            FigureSizeX = 100;
                            FigureSizeY = 100;
                        }
                        break;
                    }
            }

            label8.Text = String.Format("x: {0} * y: {1}", FigureSizeX, FigureSizeY);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void 종료IToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
