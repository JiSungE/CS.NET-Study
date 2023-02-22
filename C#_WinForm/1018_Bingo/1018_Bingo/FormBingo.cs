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
    public partial class FormBingo : Form
    {
        // 번호 관리(초기화, 사용(입력), 사용(출력))
        private int[,] iGame = new int[5, 5];
        // 선택 관리(초기화, 사용(입력), 사용(출력))
        private bool[,] bGame = new bool[5, 5];

        public bool IsUser { get; set; }
        public bool IsActive { get; set; } = false;

        private Form1 parent = null;
        public static int NumberCount { get; private set; }
        public int State { get; private set; } = 0; // 0: 숫자초기화전 1:숫자초기화 2:게임중



        public FormBingo(Form1 p, Point pt)
        {
            InitializeComponent();
            NumberCount = 1;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(470, 270);

            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    bGame[i, j] = false;
                }
            }

            initForm(p, pt);
        }

        #region 부모로 부터 메시지 수신
        public void SetActive()
        {
            IsActive = true;

            if(IsUser == false)
            {
                Thread.Sleep(2000);
                int row = -1;
                int col = -1;

                Random r = new Random();
                while (true) 
                { 

                    int number = r.Next(1, 26);
                    if (IsNumberCheck(number, ref row, ref col) == true)
                        break;
                }

                DrawCheck(row, col);

                this.parent.SelectNumber(this, iGame[row, col]);

                if(IsGameEnd() == true)
                {
                    parent.Winner(this);
                }

                IsActive = false;

            }
        }

        private bool IsNumberCheck(int number, ref int row, ref int col )
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (number == iGame[i, j])
                    {
                        if (bGame[i, j] == true)
                        {
                            row = j;
                            col = i;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }

        #endregion

        public void initForm(Form1 parent, Point pt)
        {
            TopLevel = false;
            parent.Controls.Add(this);
            this.parent = parent;
            Location = pt;
            Show();
        }

        #region 화면구성(5 * 5 사각형 그리기)
        private void DrawRec(Graphics gh)
        {
            gh.FillRectangle(new SolidBrush(Color.FromArgb(62, 62, 124)), 10, 10, 250, 250);
        }

        private void DrawLine(Graphics gh)
        {
            for (int i = 0; i < 6; i++) //가로선 그리기
            {
                gh.DrawLine(new Pen(Color.Black), 10, 10 + i * 50, 50 * 5 + 10, 10 + i * 50);
            }

            for (int i = 0; i < 6; i++) //세로선 그리기
            {
                gh.DrawLine(new Pen(Color.Black), 10 + i * 50, 10, 10 + i * 50, 50 * 5 + 10);

            }
        }


        private void DrawNum(Graphics gh, int iRow, int iCol, int iNum)
        {
            // 숫자를 그려준다.

            string str = string.Format("{0}", iNum);

            // 선택여부에 따른 색상 출력
            if (bGame[iRow,iCol] == true)
            { 
                gh.FillRectangle(new SolidBrush(Color.FromArgb(124, 0, 0)), 10 + iCol * 50, 10 + iRow * 50, 50, 50);
            }

            if (IsUser == false)
                return;


                //
                if (str.Length > 1)
            {
                gh.DrawString(str, Font, new SolidBrush(Color.FromArgb(255, 255, 255)),
                   27 + iCol * 50, 30 + iRow * 50);
            }
            else
            {
                gh.DrawString(str, Font, new SolidBrush(Color.FromArgb(255, 255, 255)),
                    30 + iCol * 50, 30 + iRow * 50);
            }

        }

        private void DrawNum(int iRow, int iCol, int iNum)
        {
            iGame[iRow, iCol] = iNum;

            this.Invalidate(new Rectangle(10 + iCol * 50, 10 + iRow * 50, 50, 50));
        }

        

        #endregion

        #region 게임초기화
        private void OrderNum(int row, int col)
        {
            if (iGame[row,col] != 0)
            {
                return;
            }
            iGame[row, col] = NumberCount++;
            DrawNum(row, col, iGame[row, col]);
        }

        #endregion

        #region 게임진행
        private void DrawCheck(int row, int col)
        {
            bGame[row, col] = true;
            this.Invalidate(new Rectangle(10+col*50,10+row*50,50,50));
        }

        public void SelectNumber(int number)
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (iGame[i,j] == number)
                    {
                        DrawCheck(i, j);
                        break;
                    }
                }
            }

            if(IsGameEnd() == true)
            {
                this.parent.Winner(this);
            }
        }


        private bool IsGameEnd()
        {
            int iLine = 0; // 개수
            int tempcount = 0;

            for (int i = 0; i < 5; i++) // 가로 검사
            {
                tempcount = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (bGame[i, j] == false)
                        break;
                    else
                        tempcount++;
                }
                if (tempcount == 5)
                    iLine++;
            }


            for (int i = 0; i < 5; i++) // 세로 검사
            {
                tempcount = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (bGame[j, i] == false)
                        break;
                    else
                        tempcount++;
                }
                if (tempcount == 5)
                    iLine++;
            }

            tempcount = 0;
            for (int i = 0; i < 5; i++) // 대각선 검사(＼ 방향)
            {
                if (bGame[i, i] == false)
                    break;
                else
                    tempcount++;
            }
            if (tempcount == 5)
                iLine++;

            tempcount = 0;
            for (int i = 0, j = 4; i < 5; i++, j--) // 대각선 검사(／ 방향)
            {
                if (bGame[i, j] == false)
                    break;
                else
                    tempcount++;
            }
            if (tempcount == 5) // 5줄 이상이면 빙고
                iLine++;


            if (iLine >= 5)
                return true;
            else
                return false;
        }
        #endregion


        private void FormBingo_Paint(object sender, PaintEventArgs e)
        {
            DrawRec(e.Graphics);

            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    
                    DrawNum(e.Graphics, i, j, iGame[i, j]);
                    
                }
            }
            DrawLine(e.Graphics);
        }

        private void FormBingo_MouseClick(object sender, MouseEventArgs e)
        {
            // TODO: Add your message handler code here and/or call default
            if (e.X > 260 || e.Y > 260) // 게임과 관련 없는곳 클릭시
                return;
            if (e.X < 10 || e.Y < 10)
                return;
            //if (!m_bConnect) // 접속 전이라면
            //    return;

            int row = -1, col = -1;
            PosToIndex(e.Location, out row, out col);

            OrderNum(row, col);

            if(State == 0)
            {
                OrderNum(row, col);
                if(NumberCount == 26)
                {
                    label1.Text = "유저 숫자초기화 완료";
                    State = 1;

                    if( IsGameEnd() == true)
                    {
                        this.parent.Winner(this);
                    }
                }
            }
            else if(State == 1)
            {
                NumberCount = 0;
            }
            else if(State == 2)
            {
                if(IsActive == false)
                {
                    return;
                }
                if (bGame[row,col] == false)
                {
                    DrawCheck(row, col);

                    parent.SelectNumber(this, iGame[row, col]);
                }

                IsActive = false;
            }
        }

        private void PosToIndex(Point pt, out int row, out int col)
        {
            row = -1;
            col = -1;
            for (int i = 0; i < 5; i++) //행 결정(Row)
            {
                if ((pt.Y > 10 + i * 50) && pt.Y <= (10 + (i + 1) * 50))
                {
                    row = i;
                    break;
                }
            }

            for (int j = 0; j < 5; j++) //열 결정(Col)
            {
                if ((pt.X > 10 + j * 50) && pt.X <= (10 + (j + 1) * 50))
                {
                    col = j;
                    break;
                }
            }
        }

        private void RandomNum()
        {
            int number = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    iGame[i, j] = number++;
                }
            }

            Random r = new Random();
            for (int i = 0; i < 26; i++)
            {
                int row = r.Next(5);
                int col = r.Next(5);
                int row2 = r.Next(5);
                int col2 = r.Next(5);

                int temp = iGame[row, col];
                iGame[row, col] = iGame[row2, col2];
                iGame[row2, col2] = temp;
            }

            this.Invalidate();
            label1.Text = "자동 숫자초기화 완료";
            State = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomNum();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(State == 0)
            {
                MessageBox.Show("숫자 초기화가 필요합니다.");
                return;
            }

            State = 2;
            label1.Text = "게임 준비 완료.";
            this.parent.Send_UserReady(this);
        }
    }
}
