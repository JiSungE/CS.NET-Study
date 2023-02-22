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
    public partial class Form4 : Form
    {
        public Color MyFontBackColor { get; set; }
        public Color MyFontForeColor { get; set; }

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;            
            colorDlg.Color = MyFontBackColor;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                MyFontBackColor = colorDlg.Color;
                this.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.Color = MyFontForeColor;

            if (colorDlg.ShowDialog() == DialogResult.OK)
                MyFontForeColor = colorDlg.Color;
        }

        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g =  e.Graphics;

            g.FillRectangle(new SolidBrush(MyFontBackColor), 10, 100, 110, 110);
        }
    }
}
