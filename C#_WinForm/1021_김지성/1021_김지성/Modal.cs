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

    public partial class Modal : Form
    {
        public Color Color { get; set; }
        public string OutputString { get; set; }
        public int StringSize { get; set; }
        public float Xpoint { get; set; }
        public float Ypoint { get; set; }

        private Data d = null;
        private Form f = null;

        public Modal(Form1 form, Data data)
        {
            InitializeComponent();
            Color = data.Color;
            OutputString = data.OutputString;
            StringSize = data.Size;
            Xpoint = data.Xpoint;
            Ypoint = data.Ypoint;
            d = data;
            f = form;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Modal_Load(object sender, EventArgs e)
        {
            string c = string.Format("{0}", Color);
            // 모달 활성화시 색상 정보

            switch(c)
            {
                case "Color [Red]": c = "빨간색"; break;
                case "Color [Green]": c = "녹색"; break;
                case "Color [Blue]": c = "파란색"; break;
            }

            textBox1.Text = string.Format("{0}",Xpoint);
            textBox2.Text = string.Format("{0}", Ypoint);
            comboBox1.Text = c;
            textBox4.Text = OutputString;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(comboBox1.Text)
            {
                case "빨간색": d.Color = Color.Red; break;
                case "녹색": d.Color = Color.Green; break;
                case "파란색": d.Color = Color.Blue; break;
            }

            d.Xpoint = float.Parse(textBox1.Text);
            d.Ypoint = float.Parse(textBox2.Text);
            d.OutputString = textBox4.Text;

            this.Close();
            f.Invalidate();
        }
    }
}
