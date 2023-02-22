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
    public partial class Form3_Sub : Form
    {
        public string TextLabel     { get; set; }

        public Form3_Sub(string _text)
        {
            InitializeComponent();
            this.Text = _text;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            SolidBrush br = new SolidBrush(Color.Black);
            grfx.DrawString(TextLabel, this.Font, br, 10, 7);
        }
    }
}
