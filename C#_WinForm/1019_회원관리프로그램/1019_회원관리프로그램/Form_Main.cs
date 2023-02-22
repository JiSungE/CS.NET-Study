using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1019_회원관리프로그램
{
    public partial class Form_Main : Form
    {
        private MemberControl mcontrol = MemberControl.Instance;

        public string MemberID { get; set; }

        //모달리스
        private Form_Select selectform = null;

        public Form_Main()
        {
            InitializeComponent();      
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            this.Text = MemberID;

            불러오기RToolStripMenuItem.Enabled = false;

            //상태바 초기화
            DateTime temp = DateTime.Now;
            toolStripStatusLabel2.Text = temp.ToShortDateString();
            toolStripStatusLabel3.Text = temp.ToLongTimeString();

            //리스트뷰 초기화
            PrintAll();
        }

        #region 메뉴 핸들러
        private void 불러오기RToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 저장하기SToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 프로그램종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void Form_Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int x = e.X + this.Left;
                int y = e.Y + this.Top;

                this.contextMenuStrip1.Show(x, y);//컨텍스트 메뉴 출력
            }
        }

        //타이머핸들러
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime temp = DateTime.Now;
            toolStripStatusLabel2.Text = temp.ToShortDateString();
            toolStripStatusLabel3.Text = temp.ToLongTimeString();
        }
    
        private void PrintAll()
        {
            listView1.Items.Clear();

            LinkedList<Member> list = mcontrol.Members;

            foreach (Member member in list)
            {
                ListViewItem item = new ListViewItem(member.Id);
                item.SubItems.Add(member.PassWord);
                item.SubItems.Add(member.Name);
                item.SubItems.Add(member.Phone);
                item.SubItems.Add(member.Date.ToShortDateString());
                item.SubItems.Add(member.Date.ToShortTimeString());
                listView1.Items.Add(item);
            }
        }

        //리스트뷰 컨트롤 선택
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection select = listView1.SelectedItems;

                ListViewItem item = select[0];
                textBox1.Text = item.SubItems[0].Text;
                textBox2.Text = item.SubItems[1].Text;
                textBox3.Text = item.SubItems[2].Text;
                textBox4.Text = item.SubItems[3].Text;
                textBox5.Text = item.SubItems[4].Text;
            }
            catch(Exception)
            {
            }
        }

        //수정버튼 핸들러
        private void button1_Click(object sender, EventArgs e)
        {
            string id   = textBox1.Text;
            string phone = textBox4.Text;

            if (mcontrol.UpdateData(id, phone) == true)
            {
                MessageBox.Show("수정");
                PrintAll();
            }
            else
                MessageBox.Show("없는 아이디입니다.");
        }

        //삭제버튼 핸들러
        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;

            if (mcontrol.DeleteData(id) == true)
            {
                MessageBox.Show("삭제");
                PrintAll();
            }
            else
                MessageBox.Show("없는 아이디입니다.");
        }

        //회원 검색(모달리스)
        private void 회원검색SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectform == null)
            {
                selectform = new Form_Select();
                selectform.Changed += Modaless_GetId;
                selectform.ChildClose += Modaless_Close;
                selectform.Show();
            }
            else
            {
                selectform.Focus();
            }
        }

        #region 모달리스 이벤트 수신핸들러
        private void Modaless_GetId(object sender, EventArgs e)
        {
            Member member = mcontrol.SelectMember(selectform.Id);
            if(member != null)
            {
                textBox1.Text = member.Id;
                textBox2.Text = member.PassWord;
                textBox3.Text = member.Name;
                textBox4.Text = member.Phone;
                textBox5.Text = member.Date.ToString();
            }
            else
            {
                MessageBox.Show("없는 아이디");
            }
        }

        private void Modaless_Close(object sender, EventArgs e)
        {
            selectform = null;
        }

        #endregion
    }
}
