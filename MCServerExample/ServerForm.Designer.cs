namespace MCServerExample
{
    partial class ServerForm
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
            this.components = new System.ComponentModel.Container();
            this.ServerConsoleBox = new System.Windows.Forms.TextBox();
            this.ServerCommandBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.SmaxRAMBox = new System.Windows.Forms.TextBox();
            this.SminRAMBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.ServerOptionButton = new System.Windows.Forms.Button();
            this.ServerJARDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.ConsoletabPage = new System.Windows.Forms.TabPage();
            this.OptiontabPage = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.ConsoletabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServerConsoleBox
            // 
            this.ServerConsoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerConsoleBox.BackColor = System.Drawing.Color.Black;
            this.ServerConsoleBox.Font = new System.Drawing.Font("굴림", 10F);
            this.ServerConsoleBox.ForeColor = System.Drawing.Color.Silver;
            this.ServerConsoleBox.Location = new System.Drawing.Point(8, 6);
            this.ServerConsoleBox.Multiline = true;
            this.ServerConsoleBox.Name = "ServerConsoleBox";
            this.ServerConsoleBox.ReadOnly = true;
            this.ServerConsoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ServerConsoleBox.Size = new System.Drawing.Size(692, 306);
            this.ServerConsoleBox.TabIndex = 0;
            // 
            // ServerCommandBox
            // 
            this.ServerCommandBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerCommandBox.Location = new System.Drawing.Point(8, 318);
            this.ServerCommandBox.Name = "ServerCommandBox";
            this.ServerCommandBox.Size = new System.Drawing.Size(536, 21);
            this.ServerCommandBox.TabIndex = 1;
            this.ServerCommandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServerCommandBox_KeyDown);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Location = new System.Drawing.Point(625, 318);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "시작";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(548, 318);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "중지";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(156, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "서버 자체 GUI 사용 안함";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 42);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(116, 16);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "체험판 모드 사용";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 89);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "서버 실행 설정";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.SmaxRAMBox);
            this.groupBox2.Controls.Add(this.SminRAMBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 89);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "서버 메모리";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(9, 67);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(140, 16);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "기가바이트 단위 사용";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // SmaxRAMBox
            // 
            this.SmaxRAMBox.Location = new System.Drawing.Point(59, 40);
            this.SmaxRAMBox.MaxLength = 16;
            this.SmaxRAMBox.Name = "SmaxRAMBox";
            this.SmaxRAMBox.Size = new System.Drawing.Size(135, 21);
            this.SmaxRAMBox.TabIndex = 9;
            this.SmaxRAMBox.Text = "2048";
            // 
            // SminRAMBox
            // 
            this.SminRAMBox.Location = new System.Drawing.Point(59, 15);
            this.SminRAMBox.MaxLength = 16;
            this.SminRAMBox.Name = "SminRAMBox";
            this.SminRAMBox.Size = new System.Drawing.Size(135, 21);
            this.SminRAMBox.TabIndex = 8;
            this.SminRAMBox.Text = "256";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "최대 : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 10F);
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "최소 : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainTimer
            // 
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // ServerOptionButton
            // 
            this.ServerOptionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerOptionButton.Location = new System.Drawing.Point(581, 12);
            this.ServerOptionButton.Name = "ServerOptionButton";
            this.ServerOptionButton.Size = new System.Drawing.Size(129, 23);
            this.ServerOptionButton.TabIndex = 8;
            this.ServerOptionButton.Text = "서버 설정";
            this.ServerOptionButton.UseVisualStyleBackColor = true;
            this.ServerOptionButton.Click += new System.EventHandler(this.ServerOptionButton_Click);
            // 
            // ServerJARDialog
            // 
            this.ServerJARDialog.Filter = "JAR 파일|*.jar|모든 파일|*.*";
            this.ServerJARDialog.Title = "서버 JAR 파일 선택";
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.ConsoletabPage);
            this.MainTabControl.Controls.Add(this.OptiontabPage);
            this.MainTabControl.Location = new System.Drawing.Point(6, 79);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(714, 371);
            this.MainTabControl.TabIndex = 9;
            // 
            // ConsoletabPage
            // 
            this.ConsoletabPage.Controls.Add(this.ServerConsoleBox);
            this.ConsoletabPage.Controls.Add(this.ServerCommandBox);
            this.ConsoletabPage.Controls.Add(this.StartButton);
            this.ConsoletabPage.Controls.Add(this.StopButton);
            this.ConsoletabPage.Location = new System.Drawing.Point(4, 22);
            this.ConsoletabPage.Name = "ConsoletabPage";
            this.ConsoletabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConsoletabPage.Size = new System.Drawing.Size(706, 345);
            this.ConsoletabPage.TabIndex = 0;
            this.ConsoletabPage.Text = "콘솔";
            this.ConsoletabPage.UseVisualStyleBackColor = true;
            // 
            // OptiontabPage
            // 
            this.OptiontabPage.Location = new System.Drawing.Point(4, 22);
            this.OptiontabPage.Name = "OptiontabPage";
            this.OptiontabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OptiontabPage.Size = new System.Drawing.Size(791, 411);
            this.OptiontabPage.TabIndex = 1;
            this.OptiontabPage.Text = "설정";
            this.OptiontabPage.UseVisualStyleBackColor = true;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 462);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.ServerOptionButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "서버 버킷";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.Shown += new System.EventHandler(this.ServerForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.ConsoletabPage.ResumeLayout(false);
            this.ConsoletabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ServerConsoleBox;
        private System.Windows.Forms.TextBox ServerCommandBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SmaxRAMBox;
        private System.Windows.Forms.TextBox SminRAMBox;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Button ServerOptionButton;
        private System.Windows.Forms.OpenFileDialog ServerJARDialog;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage ConsoletabPage;
        private System.Windows.Forms.TabPage OptiontabPage;
    }
}