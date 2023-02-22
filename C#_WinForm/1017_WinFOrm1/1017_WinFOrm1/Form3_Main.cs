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
    public partial class Form3_Main : Form
    {
        public Form3_Main()
        {
            InitializeComponent();

            Array arr = System.Enum.GetValues(typeof(KnownColor));
            Form3_Sub[] frm = new Form3_Sub[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                frm[i] = new Form3_Sub(arr.GetValue(i).ToString());
                frm[i].TextLabel = arr.GetValue(i).ToString();
                frm[i].BackColor = Color.FromName(arr.GetValue(i).ToString());
                frm[i].SetBounds(0, 0, 200, 50);
                frm[i].MdiParent = this;
                frm[i].Show();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
