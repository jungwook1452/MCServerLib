namespace MCServerExample.DownForms
{
    partial class BanPlayerAddForm
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
            this.OKButton = new System.Windows.Forms.Button();
            this.ReasonTextBox = new System.Windows.Forms.TextBox();
            this.ReasonLabel = new System.Windows.Forms.Label();
            this.PlayerListBox = new System.Windows.Forms.ListBox();
            this.PlayerAddButton = new System.Windows.Forms.Button();
            this.PlayerNameBox = new System.Windows.Forms.TextBox();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.PlayerListItemDeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(415, 312);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(99, 29);
            this.OKButton.TabIndex = 13;
            this.OKButton.Text = "확인";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ReasonTextBox
            // 
            this.ReasonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReasonTextBox.Location = new System.Drawing.Point(15, 285);
            this.ReasonTextBox.MaxLength = 255;
            this.ReasonTextBox.Name = "ReasonTextBox";
            this.ReasonTextBox.Size = new System.Drawing.Size(499, 21);
            this.ReasonTextBox.TabIndex = 12;
            // 
            // ReasonLabel
            // 
            this.ReasonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReasonLabel.Font = new System.Drawing.Font("굴림", 10F);
            this.ReasonLabel.Location = new System.Drawing.Point(12, 267);
            this.ReasonLabel.Name = "ReasonLabel";
            this.ReasonLabel.Size = new System.Drawing.Size(502, 15);
            this.ReasonLabel.TabIndex = 11;
            this.ReasonLabel.Text = "사유:";
            this.ReasonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerListBox
            // 
            this.PlayerListBox.AllowDrop = true;
            this.PlayerListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerListBox.FormattingEnabled = true;
            this.PlayerListBox.ItemHeight = 12;
            this.PlayerListBox.Location = new System.Drawing.Point(15, 50);
            this.PlayerListBox.Name = "PlayerListBox";
            this.PlayerListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PlayerListBox.Size = new System.Drawing.Size(499, 208);
            this.PlayerListBox.TabIndex = 10;
            // 
            // PlayerAddButton
            // 
            this.PlayerAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerAddButton.Location = new System.Drawing.Point(439, 22);
            this.PlayerAddButton.Name = "PlayerAddButton";
            this.PlayerAddButton.Size = new System.Drawing.Size(75, 23);
            this.PlayerAddButton.TabIndex = 9;
            this.PlayerAddButton.Text = "추가";
            this.PlayerAddButton.UseVisualStyleBackColor = true;
            this.PlayerAddButton.Click += new System.EventHandler(this.PlayerAddButton_Click);
            // 
            // PlayerNameBox
            // 
            this.PlayerNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerNameBox.Location = new System.Drawing.Point(15, 23);
            this.PlayerNameBox.MaxLength = 128;
            this.PlayerNameBox.Name = "PlayerNameBox";
            this.PlayerNameBox.Size = new System.Drawing.Size(418, 21);
            this.PlayerNameBox.TabIndex = 8;
            this.PlayerNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayerNameBox_KeyDown);
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerNameLabel.Font = new System.Drawing.Font("굴림", 10F);
            this.PlayerNameLabel.Location = new System.Drawing.Point(12, 5);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(502, 15);
            this.PlayerNameLabel.TabIndex = 7;
            this.PlayerNameLabel.Text = "추가할 플레이어:";
            this.PlayerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayerListItemDeleteButton
            // 
            this.PlayerListItemDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerListItemDeleteButton.Location = new System.Drawing.Point(15, 312);
            this.PlayerListItemDeleteButton.Name = "PlayerListItemDeleteButton";
            this.PlayerListItemDeleteButton.Size = new System.Drawing.Size(115, 29);
            this.PlayerListItemDeleteButton.TabIndex = 14;
            this.PlayerListItemDeleteButton.Text = "선택한 항목 삭제";
            this.PlayerListItemDeleteButton.UseVisualStyleBackColor = true;
            this.PlayerListItemDeleteButton.Click += new System.EventHandler(this.PlayerListItemDeleteButton_Click);
            // 
            // BanPlayerAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 347);
            this.Controls.Add(this.PlayerListItemDeleteButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ReasonTextBox);
            this.Controls.Add(this.ReasonLabel);
            this.Controls.Add(this.PlayerListBox);
            this.Controls.Add(this.PlayerAddButton);
            this.Controls.Add(this.PlayerNameBox);
            this.Controls.Add(this.PlayerNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BanPlayerAddForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "밴 플레이어 추가";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox ReasonTextBox;
        private System.Windows.Forms.Label ReasonLabel;
        private System.Windows.Forms.Button PlayerAddButton;
        private System.Windows.Forms.TextBox PlayerNameBox;
        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.Button PlayerListItemDeleteButton;
        public System.Windows.Forms.ListBox PlayerListBox;
    }
}