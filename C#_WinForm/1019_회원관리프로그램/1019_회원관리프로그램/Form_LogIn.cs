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
    public partial class Form_LogIn : Form
    {
        private MemberControl mcontrol = MemberControl.Instance;

        public string Id { get; set; }
        
        //프로퍼티와 컨트롤 속성을 연결!
        public string PassWord 
        { 
            get         {  return txt_password.Text; }
            private set { txt_password.Text = value; }
        }

        public Form_LogIn()
        {
            InitializeComponent();
            txt_id.Text = "111";
            PassWord = "1111";
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Id = txt_id.Text;
            if(mcontrol.IsLogin(Id, PassWord) == true)
            {
                this.Hide();

                //모달
                Form_Main form_Main = new Form_Main();
                form_Main.MemberID = Id;
                form_Main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("id, pw를 확인해주세요");
                txt_id.Text = "";
                PassWord = "";
            }
        }

        private void btn_NewMember_Click(object sender, EventArgs e)
        {
            this.Hide();

            //모달
            Form_NewMember form = new Form_NewMember();
            //줄수있고(set속성,메서드)
            if( form.ShowDialog() == DialogResult.OK )
            {
                //받을수있다(get속성, 메서드)
                Member member = form.MemberData;
                mcontrol.InsertMember(member);
            }

            this.Show();
        }
    }
}
