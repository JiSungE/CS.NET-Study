using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1024_DB
{
    public partial class MainForm : Form
    {
        private Wb_DataBase database = Wb_DataBase.database;
        private FormProduct product = new FormProduct();
        private FormCustom custom = new FormCustom();
        private FormSale sale = new FormSale();
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            product.InitForm(tabPage1, new Point(10, 10));
            custom.InitForm(tabPage2, new Point(10, 10));
            sale.InitForm(tabPage3, new Point(10, 20));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            custom.PrintAll();
            sale.PrintAll();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
