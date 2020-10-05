namespace MCServerExample.Controls
{
    partial class WhiteListControl
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayerListView = new System.Windows.Forms.ListView();
            this.IDCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayerNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UUIDCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WlAddButton = new System.Windows.Forms.Button();
            this.WlAddPlayerNameBox = new System.Windows.Forms.TextBox();
            this.WlAddPlayerNameLabel = new System.Windows.Forms.Label();
            this.UseWlCheckBox = new System.Windows.Forms.CheckBox();
            this.WlJsonLoadButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.WlRemoveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayerListView
            // 
            this.PlayerListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDCH,
            this.PlayerNameCH,
            this.UUIDCH});
            this.PlayerListView.FullRowSelect = true;
            this.PlayerListView.HideSelection = false;
            this.PlayerListView.Location = new System.Drawing.Point(3, 25);
            this.PlayerListView.Name = "PlayerListView";
            this.PlayerListView.Size = new System.Drawing.Size(694, 323);
            this.PlayerListView.TabIndex = 0;
            this.PlayerListView.UseCompatibleStateImageBehavior = false;
            this.PlayerListView.View = System.Windows.Forms.View.Details;
            // 
            // IDCH
            // 
            this.IDCH.Text = "ID";
            this.IDCH.Width = 72;
            // 
            // PlayerNameCH
            // 
            this.PlayerNameCH.Text = "이름";
            this.PlayerNameCH.Width = 146;
            // 
            // UUIDCH
            // 
            this.UUIDCH.Text = "플레이어 UUID";
            this.UUIDCH.Width = 277;
            // 
            // WlAddButton
            // 
            this.WlAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WlAddButton.Location = new System.Drawing.Point(169, 354);
            this.WlAddButton.Name = "WlAddButton";
            this.WlAddButton.Size = new System.Drawing.Size(95, 36);
            this.WlAddButton.TabIndex = 1;
            this.WlAddButton.Text = "추가";
            this.WlAddButton.UseVisualStyleBackColor = true;
            this.WlAddButton.Click += new System.EventHandler(this.WlAddButton_Click);
            // 
            // WlAddPlayerNameBox
            // 
            this.WlAddPlayerNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WlAddPlayerNameBox.Location = new System.Drawing.Point(3, 369);
            this.WlAddPlayerNameBox.MaxLength = 64;
            this.WlAddPlayerNameBox.Name = "WlAddPlayerNameBox";
            this.WlAddPlayerNameBox.Size = new System.Drawing.Size(160, 21);
            this.WlAddPlayerNameBox.TabIndex = 2;
            this.WlAddPlayerNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WlAddPlayerNameBox_KeyDown);
            // 
            // WlAddPlayerNameLabel
            // 
            this.WlAddPlayerNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WlAddPlayerNameLabel.Location = new System.Drawing.Point(3, 354);
            this.WlAddPlayerNameLabel.Name = "WlAddPlayerNameLabel";
            this.WlAddPlayerNameLabel.Size = new System.Drawing.Size(160, 12);
            this.WlAddPlayerNameLabel.TabIndex = 3;
            this.WlAddPlayerNameLabel.Text = "추가할 플레이어:";
            // 
            // UseWlCheckBox
            // 
            this.UseWlCheckBox.AutoSize = true;
            this.UseWlCheckBox.Location = new System.Drawing.Point(3, 3);
            this.UseWlCheckBox.Name = "UseWlCheckBox";
            this.UseWlCheckBox.Size = new System.Drawing.Size(124, 16);
            this.UseWlCheckBox.TabIndex = 4;
            this.UseWlCheckBox.Text = "화이트리스트 사용";
            this.UseWlCheckBox.UseVisualStyleBackColor = true;
            this.UseWlCheckBox.CheckedChanged += new System.EventHandler(this.UseWlCheckBox_CheckedChanged);
            // 
            // WlJsonLoadButton
            // 
            this.WlJsonLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WlJsonLoadButton.Location = new System.Drawing.Point(498, 356);
            this.WlJsonLoadButton.Name = "WlJsonLoadButton";
            this.WlJsonLoadButton.Size = new System.Drawing.Size(100, 34);
            this.WlJsonLoadButton.TabIndex = 6;
            this.WlJsonLoadButton.Text = "whitelist.json 다시 불러오기";
            this.WlJsonLoadButton.UseVisualStyleBackColor = true;
            this.WlJsonLoadButton.Click += new System.EventHandler(this.WlJsonLoadButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.Location = new System.Drawing.Point(604, 356);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(93, 34);
            this.RefreshButton.TabIndex = 5;
            this.RefreshButton.Text = "새로고침";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // WlRemoveButton
            // 
            this.WlRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WlRemoveButton.Location = new System.Drawing.Point(270, 354);
            this.WlRemoveButton.Name = "WlRemoveButton";
            this.WlRemoveButton.Size = new System.Drawing.Size(95, 36);
            this.WlRemoveButton.TabIndex = 7;
            this.WlRemoveButton.Text = "제거";
            this.WlRemoveButton.UseVisualStyleBackColor = true;
            this.WlRemoveButton.Click += new System.EventHandler(this.WlRemoveButton_Click);
            // 
            // WhiteListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WlRemoveButton);
            this.Controls.Add(this.WlJsonLoadButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.UseWlCheckBox);
            this.Controls.Add(this.WlAddPlayerNameLabel);
            this.Controls.Add(this.WlAddPlayerNameBox);
            this.Controls.Add(this.WlAddButton);
            this.Controls.Add(this.PlayerListView);
            this.Name = "WhiteListControl";
            this.Size = new System.Drawing.Size(700, 393);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView PlayerListView;
        private System.Windows.Forms.ColumnHeader PlayerNameCH;
        private System.Windows.Forms.ColumnHeader UUIDCH;
        private System.Windows.Forms.Button WlAddButton;
        private System.Windows.Forms.TextBox WlAddPlayerNameBox;
        private System.Windows.Forms.Label WlAddPlayerNameLabel;
        private System.Windows.Forms.CheckBox UseWlCheckBox;
        private System.Windows.Forms.Button WlJsonLoadButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button WlRemoveButton;
        private System.Windows.Forms.ColumnHeader IDCH;
    }
}
