namespace _1021_김지성
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.색상CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.빨강RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.초록GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파랑BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.옵션OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모달MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.색상CToolStripMenuItem,
            this.옵션OToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.종료XToolStripMenuItem});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 색상CToolStripMenuItem
            // 
            this.색상CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.빨강RToolStripMenuItem,
            this.초록GToolStripMenuItem,
            this.파랑BToolStripMenuItem});
            this.색상CToolStripMenuItem.Name = "색상CToolStripMenuItem";
            this.색상CToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.색상CToolStripMenuItem.Text = "색상(&C)";
            // 
            // 빨강RToolStripMenuItem
            // 
            this.빨강RToolStripMenuItem.Name = "빨강RToolStripMenuItem";
            this.빨강RToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.빨강RToolStripMenuItem.Text = "빨간색(&R)";
            this.빨강RToolStripMenuItem.Click += new System.EventHandler(this.빨강RToolStripMenuItem_Click);
            // 
            // 초록GToolStripMenuItem
            // 
            this.초록GToolStripMenuItem.Name = "초록GToolStripMenuItem";
            this.초록GToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.초록GToolStripMenuItem.Text = "녹 색(&G)";
            this.초록GToolStripMenuItem.Click += new System.EventHandler(this.초록GToolStripMenuItem_Click);
            // 
            // 파랑BToolStripMenuItem
            // 
            this.파랑BToolStripMenuItem.Name = "파랑BToolStripMenuItem";
            this.파랑BToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.파랑BToolStripMenuItem.Text = "파란색(&B)";
            this.파랑BToolStripMenuItem.Click += new System.EventHandler(this.파랑BToolStripMenuItem_Click);
            // 
            // 옵션OToolStripMenuItem
            // 
            this.옵션OToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.모달MToolStripMenuItem});
            this.옵션OToolStripMenuItem.Name = "옵션OToolStripMenuItem";
            this.옵션OToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.옵션OToolStripMenuItem.Text = "옵션(&O)";
            // 
            // 종료XToolStripMenuItem
            // 
            this.종료XToolStripMenuItem.Name = "종료XToolStripMenuItem";
            this.종료XToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.종료XToolStripMenuItem.Text = "종료(&X)";
            this.종료XToolStripMenuItem.Click += new System.EventHandler(this.종료XToolStripMenuItem_Click);
            // 
            // 모달MToolStripMenuItem
            // 
            this.모달MToolStripMenuItem.Name = "모달MToolStripMenuItem";
            this.모달MToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.모달MToolStripMenuItem.Text = "모달(&M)";
            this.모달MToolStripMenuItem.Click += new System.EventHandler(this.모달MToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 색상CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 빨강RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 초록GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파랑BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 옵션OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 모달MToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

