namespace MCServerExample.Controls
{
    partial class BanListControl
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
            this.BanListView = new System.Windows.Forms.ListView();
            this.IDCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayerNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BanReasonCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BanDateTimeCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BanSourceCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BanButton = new System.Windows.Forms.Button();
            this.DeleteBanButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.BanPlayerJsonLoadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BanListView
            // 
            this.BanListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BanListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDCH,
            this.PlayerNameCH,
            this.BanReasonCH,
            this.BanDateTimeCH,
            this.BanSourceCH});
            this.BanListView.FullRowSelect = true;
            this.BanListView.HideSelection = false;
            this.BanListView.Location = new System.Drawing.Point(3, 3);
            this.BanListView.Name = "BanListView";
            this.BanListView.Size = new System.Drawing.Size(614, 307);
            this.BanListView.TabIndex = 0;
            this.BanListView.UseCompatibleStateImageBehavior = false;
            this.BanListView.View = System.Windows.Forms.View.Details;
            // 
            // IDCH
            // 
            this.IDCH.Text = "ID";
            this.IDCH.Width = 54;
            // 
            // PlayerNameCH
            // 
            this.PlayerNameCH.Text = "이름";
            this.PlayerNameCH.Width = 147;
            // 
            // BanReasonCH
            // 
            this.BanReasonCH.Text = "사유";
            this.BanReasonCH.Width = 139;
            // 
            // BanDateTimeCH
            // 
            this.BanDateTimeCH.Text = "밴 날짜";
            this.BanDateTimeCH.Width = 146;
            // 
            // BanSourceCH
            // 
            this.BanSourceCH.Text = "처리자";
            this.BanSourceCH.Width = 118;
            // 
            // BanButton
            // 
            this.BanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BanButton.Location = new System.Drawing.Point(3, 316);
            this.BanButton.Name = "BanButton";
            this.BanButton.Size = new System.Drawing.Size(101, 32);
            this.BanButton.TabIndex = 1;
            this.BanButton.Text = "밴";
            this.BanButton.UseVisualStyleBackColor = true;
            this.BanButton.Click += new System.EventHandler(this.BanButton_Click);
            // 
            // DeleteBanButton
            // 
            this.DeleteBanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteBanButton.Location = new System.Drawing.Point(110, 316);
            this.DeleteBanButton.Name = "DeleteBanButton";
            this.DeleteBanButton.Size = new System.Drawing.Size(104, 32);
            this.DeleteBanButton.TabIndex = 2;
            this.DeleteBanButton.Text = "밴 삭제";
            this.DeleteBanButton.UseVisualStyleBackColor = true;
            this.DeleteBanButton.Click += new System.EventHandler(this.DeleteBanButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.Location = new System.Drawing.Point(524, 316);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(93, 34);
            this.RefreshButton.TabIndex = 3;
            this.RefreshButton.Text = "새로고침";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // BanPlayerJsonLoadButton
            // 
            this.BanPlayerJsonLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BanPlayerJsonLoadButton.Location = new System.Drawing.Point(375, 316);
            this.BanPlayerJsonLoadButton.Name = "BanPlayerJsonLoadButton";
            this.BanPlayerJsonLoadButton.Size = new System.Drawing.Size(143, 34);
            this.BanPlayerJsonLoadButton.TabIndex = 4;
            this.BanPlayerJsonLoadButton.Text = "banned-players.json 다시 불러오기";
            this.BanPlayerJsonLoadButton.UseVisualStyleBackColor = true;
            this.BanPlayerJsonLoadButton.Click += new System.EventHandler(this.BanPlayerJsonLoadButton_Click);
            // 
            // BanListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BanPlayerJsonLoadButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.DeleteBanButton);
            this.Controls.Add(this.BanButton);
            this.Controls.Add(this.BanListView);
            this.Name = "BanListControl";
            this.Size = new System.Drawing.Size(620, 353);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView BanListView;
        private System.Windows.Forms.ColumnHeader PlayerNameCH;
        private System.Windows.Forms.ColumnHeader BanDateTimeCH;
        private System.Windows.Forms.ColumnHeader BanReasonCH;
        private System.Windows.Forms.Button BanButton;
        private System.Windows.Forms.ColumnHeader BanSourceCH;
        private System.Windows.Forms.Button DeleteBanButton;
        private System.Windows.Forms.ColumnHeader IDCH;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button BanPlayerJsonLoadButton;
    }
}
