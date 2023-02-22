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
    public partial class Form_NewMember : Form
    {
        #region 컨트롤과 프로퍼티 연결
        public string Id
        {
            get { return txt_id.Text; }
            set { txt_id.Text = value; }
        }
        public string PassWord
        {
            get { return txt_pw1.Text; }
            set { txt_pw1.Text = value; }
        }
        public string MemberName
        {
            get { return txt_name.Text; }
            set { txt_name.Text = value; }
        }
        public string Phone
        {
            get { return txt_phone.Text; }
            set { txt_phone.Text = value; }
        }
        public DateTime Date 
        {
            get { return dtp_date.Value;   }
            set {  dtp_date.Value = value; }
        }
        public Member MemberData
        {
            get 
            {
                return new Member(Id, PassWord, MemberName, Phone, Date);
            }
        }
        #endregion

        private bool isidcheck = false;

        public Form_NewMember()
        {
            InitializeComponent();
        }

        public Member GetDataMember()
        {
            return new Member(Id, PassWord, MemberName, Phone, Date);
        }

        #region 컨트롤 입력 정보 확인
        //아이디 중복 체크 
        private void btn_check_Click(object sender, EventArgs e)
        {
            MemberControl mcon = MemberControl.Instance;
            if(mcon.IdCheck(Id) ==true)
            {
                MessageBox.Show("사용할 수 있는 아이디 입니다");
                txt_id.ReadOnly = true;
                isidcheck = true;
            }
            else
            {
                MessageBox.Show("중복된 아이디 입니다");
                Id = "";
                txt_id.Focus();
            }
        }
        
        //패스워드 체크
        private void txt_pw2_Leave(object sender, EventArgs e)
        {
            if (PassWord != txt_pw2.Text)
            {
                MessageBox.Show("패스워드가 다릅니다");
                txt_pw2.Text = "";
                txt_pw2.Focus();
            }
        }

        //모든 입력 처리가 되었는지 체크
        private bool InputDataCheck()
        {
            if (Id.Length == 0 || PassWord.Length == 0 || MemberName.Length == 0 ||
                Phone.Length == 0)
                return false;
            else
                return true;
        }

        #endregion 

        private void btn_newmember_Click(object sender, EventArgs e)
        {
            if(InputDataCheck() == false)
            {
                MessageBox.Show("필수 정보의 입력이 필요합니다");
                return;
            }
            
            if(isidcheck == false)
            {
                MessageBox.Show("아이디 중복 체크를 해주세요");
                return;
            }

            DialogResult = DialogResult.OK;
            //Form을 죽이는 것이지 객체가 죽는것은 아니다!
            this.Close();
        }
    }
}
