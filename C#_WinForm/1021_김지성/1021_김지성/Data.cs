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
    public class Data
    {
        public Color Color { get; set; }
        public string OutputString { get; set; }
        public int Size { get; set; }
        public float Xpoint { get; set; }
        public float Ypoint { get; set; }

        public Data(Color color, string ooutput, int size, float xpoint, float ypoint)
        {
            Color = color;
            OutputString = ooutput;
            Size = size;
            Xpoint = xpoint;
            Ypoint = ypoint;
        }
    }
}
