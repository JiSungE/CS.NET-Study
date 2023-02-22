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
    public partial class Form5 : Form
    {
        public Color FillColor { get; set; }
        public Form5()
        {
            InitializeComponent();

            FillColor = Color.Red;
            FillColor = Color.FromArgb(255, 0, 0);
        }

        private void Form5_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics grfx = this.CreateGraphics();
            this.Text = string.Format("{0}, {1}",e.X, e.Y);
            Brush b = new SolidBrush(FillColor);
            
            grfx.FillRectangle(b, e.X, e.Y, 100, 100);
            //grfx.DrawRectangle(Pens.Brown, e.X, e.Y, 100, 100);
            grfx.Dispose();
        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            int value = e.KeyValue;
            if(value == 'G')
            {
                FillColor = Color.Green;
            }
            else if(value == 'B')
            {
                FillColor = Color.Blue;
            }
            else if(value == 'R')
            {
                FillColor = Color.Red;
            }
            else if(value == 'P')
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.FillEllipse(new SolidBrush(FillColor), pictureBox1.ClientRectangle);
                
                g.Dispose();
            }
        }

        
    }
}
