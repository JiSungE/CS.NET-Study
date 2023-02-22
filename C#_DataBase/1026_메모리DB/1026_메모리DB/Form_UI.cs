using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1026_메모리DB
{
    internal class Form_UI
    {
        public static void AccountTable_ListView_Col_Init(ListView listview, string[] colums)
        {
            listview.Columns.Clear();

            foreach(string c in colums)
            {
                ColumnHeader ch1 = new ColumnHeader();
                ch1.Text = c;
                ch1.Width = 140;
                listview.Columns.Add(ch1);
            }
        }

        public static void AccountIOTable_DateGridView_Binding(DataTable table, DataGridView view)
        {
            view.DataSource = table;
        }

        public static void CustomTable_PrintAll(ListView listview, DataTable table)
        {
            listview.Items.Clear();
            foreach (DataRow dr in table.Rows)
            {
                int cid = int.Parse(dr[0].ToString());
                string name = dr[1].ToString();
                string phone = dr[2].ToString();
                string addr = dr[3].ToString();

                ListViewItem item = new ListViewItem(cid.ToString());
                item.SubItems.Add(name);
                item.SubItems.Add(phone);
                item.SubItems.Add(addr);
                listview.Items.Add(item);
            }
        }

        public static void AccountTable_PrintAll(ListView listview, DataTable table)
        {
            listview.Items.Clear();
            foreach (DataRow dr in table.Rows)
            {
                int accid = int.Parse(dr[0].ToString());
                int cid = int.Parse(dr[1].ToString());
                int balance = int.Parse(dr[2].ToString());
                string date = dr[3].ToString();

                ListViewItem item = new ListViewItem(accid.ToString());
                item.SubItems.Add(cid.ToString());
                item.SubItems.Add(balance.ToString());
                item.SubItems.Add(date);
                listview.Items.Add(item);
            }
        }

    }
}
