namespace MCServerExample
{
    partial class ServerOptionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.MotdTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SeedTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OnlineModeBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 10F);
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "이름:";
            // 
            // MotdTextBox
            // 
            this.MotdTextBox.Location = new System.Drawing.Point(65, 7);
            this.MotdTextBox.MaxLength = 59;
            this.MotdTextBox.Name = "MotdTextBox";
            this.MotdTextBox.Size = new System.Drawing.Size(201, 21);
            this.MotdTextBox.TabIndex = 1;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(295, 136);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(95, 41);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "저장";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SeedTextBox
            // 
            this.SeedTextBox.Location = new System.Drawing.Point(65, 34);
            this.SeedTextBox.MaxLength = 59;
            this.SeedTextBox.Name = "SeedTextBox";
            this.SeedTextBox.Size = new System.Drawing.Size(201, 21);
            this.SeedTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "시드:";
            // 
            // OnlineModeBox
            // 
            this.OnlineModeBox.AutoSize = true;
            this.OnlineModeBox.Font = new System.Drawing.Font("굴림", 10F);
            this.OnlineModeBox.Location = new System.Drawing.Point(12, 61);
            this.OnlineModeBox.Name = "OnlineModeBox";
            this.OnlineModeBox.Size = new System.Drawing.Size(101, 18);
            this.OnlineModeBox.TabIndex = 5;
            this.OnlineModeBox.Text = "온라인 모드";
            this.OnlineModeBox.UseVisualStyleBackColor = true;
            // 
            // ServerOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 189);
            this.Controls.Add(this.OnlineModeBox);
            this.Controls.Add(this.SeedTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.MotdTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerOptionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "서버 설정";
            this.Load += new System.EventHandler(this.ServerOptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MotdTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox SeedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox OnlineModeBox;
    }
}