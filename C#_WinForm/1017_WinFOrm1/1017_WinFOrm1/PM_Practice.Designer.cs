namespace _1017_WinFOrm1
{
    partial class PM_Practice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새파일NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.가져오기IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.브러쉬색상RGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.빨강RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.초록GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파랑BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.브러쉬색상RGBToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1422, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.새파일NToolStripMenuItem,
            this.가져오기IToolStripMenuItem,
            this.종료IToolStripMenuItem});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 새파일NToolStripMenuItem
            // 
            this.새파일NToolStripMenuItem.Name = "새파일NToolStripMenuItem";
            this.새파일NToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.새파일NToolStripMenuItem.Text = "새파일(&N)";
            // 
            // 가져오기IToolStripMenuItem
            // 
            this.가져오기IToolStripMenuItem.Name = "가져오기IToolStripMenuItem";
            this.가져오기IToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.가져오기IToolStripMenuItem.Text = "가져오기(&I)";
            // 
            // 종료IToolStripMenuItem
            // 
            this.종료IToolStripMenuItem.Name = "종료IToolStripMenuItem";
            this.종료IToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.종료IToolStripMenuItem.Text = "종료(I)";
            this.종료IToolStripMenuItem.Click += new System.EventHandler(this.종료IToolStripMenuItem_Click);
            // 
            // 브러쉬색상RGBToolStripMenuItem
            // 
            this.브러쉬색상RGBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.빨강RToolStripMenuItem,
            this.초록GToolStripMenuItem,
            this.파랑BToolStripMenuItem});
            this.브러쉬색상RGBToolStripMenuItem.Name = "브러쉬색상RGBToolStripMenuItem";
            this.브러쉬색상RGBToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.브러쉬색상RGBToolStripMenuItem.Text = "브러쉬색상(RGB)";
            // 
            // 빨강RToolStripMenuItem
            // 
            this.빨강RToolStripMenuItem.Name = "빨강RToolStripMenuItem";
            this.빨강RToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.빨강RToolStripMenuItem.Text = "빨강(&R)";
            // 
            // 초록GToolStripMenuItem
            // 
            this.초록GToolStripMenuItem.Name = "초록GToolStripMenuItem";
            this.초록GToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.초록GToolStripMenuItem.Text = "초록(&G)";
            // 
            // 파랑BToolStripMenuItem
            // 
            this.파랑BToolStripMenuItem.Name = "파랑BToolStripMenuItem";
            this.파랑BToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.파랑BToolStripMenuItem.Text = "파랑(&B)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "도형타입";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "펜두께";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "도형크기";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "현재 색상";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "좌표";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(126, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(126, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(129, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(126, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "label10";
            // 
            // PM_Practice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PM_Practice";
            this.Text = "PM_Practice";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PM_Practice_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PM_Practice_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새파일NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 가져오기IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 브러쉬색상RGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 빨강RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 초록GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파랑BToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}