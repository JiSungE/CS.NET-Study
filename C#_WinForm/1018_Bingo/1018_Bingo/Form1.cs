using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1018_Bingo
{
    public partial class Form1 : Form
    {
        private FormBingo[] users = new FormBingo[2];

        public int UserCount { get; private set; } = 0;

        public int ActiveUser { get; private set; }


        public Form1()
        {
            InitializeComponent();
            users[0] = new FormBingo(this, new Point(100, 10));
            users[0].IsUser = true;

            users[1] = new FormBingo(this, new Point(600, 10));
            users[1].IsUser = false;

        }

        public void Send_UserReady(FormBingo user)
        {
            textBox1.Text = "user 준비완료";
            UserCount++;
            if(UserCount == 2)
            {
                textBox1.Text = "게임 시작...........................";
                Thread.Sleep(1000);
                Random random = new Random();
                if(random.Next(0,2)==0)
                {
                    users[0].SetActive();
                    textBox1.Text = "user차례입니다...........................";

                }
                else
                {
                    users[1].SetActive();
                    textBox1.Text = "PC차례입니다...........................";

                }


                users[0].SetActive();
                users[1].SetActive();
                textBox1.Text = "게임 시작..........................";
            }
        }

        // 클릭된 좌표 정보를 획득
        public void SelectNumber(FormBingo user, int number)
        {
            FormBingo formuser = user as FormBingo;
            if (users[0] == user)
            {
                users[1].SelectNumber(number);
                textBox1.Text = "User가 번호를 입력하였습니다.";
                users[1].SetActive();
            }
            else
            {
                users[0].SelectNumber(number);
                textBox1.Text = "PC가 번호를 입력하였습니다.";
                users[0].SetActive();
            }
        }

        public void Winner(FormBingo user)
        {
            if (users[0] == user)
            {
                MessageBox.Show("내가 승리");
            }
            else
            {
                MessageBox.Show("컴퓨터 승리");
            }
        }

    }


}
