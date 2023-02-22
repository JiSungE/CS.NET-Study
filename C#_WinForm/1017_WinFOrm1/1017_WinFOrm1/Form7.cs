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
    public partial class Form7 : Form
    {
        private Image image = null;
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image imageFile = Image.FromFile("ocean.jpg");
            Graphics grfx = Graphics.FromImage(imageFile);
            
            grfx.DrawString("안녕하세요", new Font("돋음",20), Brushes.Pink, 10, 10);
            grfx.Dispose();

            imageFile.Save("ocean.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

            this.image = Image.FromFile("ocean.bmp");
            pictureBox1.Invalidate(pictureBox1.ClientRectangle);
        }

        private void Form7_Paint(object sender, PaintEventArgs e)
        {
            Graphics grfx = pictureBox1.CreateGraphics();
            if (image != null)
                grfx.DrawImage(image, pictureBox1.ClientRectangle);
            grfx.Dispose();
        }
    }
}
