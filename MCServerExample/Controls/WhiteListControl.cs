using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using MCServerLib;

namespace MCServerExample.Controls
{
    public partial class WhiteListControl : UserControl
    {
        private MCServer Server;

        private bool UseWlChkBoxChangedEventEnable = true;

        public WhiteListControl(MCServer server)
        {
            Server = server;
            InitializeComponent();
            UsedWlCheck();
        }

        private void UsedWlCheck()
        {
            if (Server.ServerProperties.Loaded)
            {
                bool Wl = bool.Parse(Server.ServerProperties.Properties["white-list"]);
                UseWlChkBoxChangedEventEnable = false;

                if (!Wl)
                {
                    UseWlCheckBox.Checked = false;
                    PlayerListView.Enabled = WlAddPlayerNameBox.Enabled = WlAddButton.Enabled = WlRemoveButton.Enabled = WlJsonLoadButton.Enabled =
                     RefreshButton.Enabled = false;
                } else
                {
                    UseWlCheckBox.Checked = true;
                    PlayerListView.Enabled = WlAddPlayerNameBox.Enabled = WlAddButton.Enabled = WlRemoveButton.Enabled = WlJsonLoadButton.Enabled =
                     RefreshButton.Enabled = true;
                }

                UseWlChkBoxChangedEventEnable = true;
            }
            else
            {
                UseWlCheckBox.Enabled = PlayerListView.Enabled = WlAddPlayerNameBox.Enabled = WlAddButton.Enabled = WlRemoveButton.Enabled = WlJsonLoadButton.Enabled =
                    RefreshButton.Enabled = false;
            }
        }

        private void WlUpdate()
        {
            PlayerListView.Items.Clear();
            PlayerListView.BeginUpdate();

            foreach (var pair in Server.ServerJson.WhitelistPlayers)
            {
                MCWhitelistPlayerInfo info = pair.Value;

                ListViewItem item = new ListViewItem(pair.Key.ToString());
                item.SubItems.Add(info.Name);
                item.SubItems.Add(info.UUID);

                PlayerListView.Items.Add(item);
            }

            PlayerListView.EndUpdate();
        }

        private List<MCWhitelistPlayerInfo> GetSelectedPlayers()
        {
            List<MCWhitelistPlayerInfo> Ls = new List<MCWhitelistPlayerInfo>();

            for (int i = 0; i < PlayerListView.SelectedItems.Count; i++)
            {
                int ID = int.Parse(PlayerListView.SelectedItems[i].SubItems[0].Text);
                foreach (var pair in Server.ServerJson.WhitelistPlayers)
                {
                    if (pair.Key == ID)
                    {
                        Ls.Add(pair.Value);
                        break;
                    }
                }
            }

            return Ls;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            WlUpdate();
        }

        private void WlJsonLoadButton_Click(object sender, EventArgs e)
        {
            Server.ServerJson.LoadWhitelistPlayers();
        }

        private void WlAddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WlAddPlayerNameBox.Text))
            {
                MessageBox.Show("추가할 플레이어의 닉네임을 입력하십시오.", "화이트리스트 추가", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Server.IsDone)
            {
                MessageBox.Show("서버가 실행할 준비가 되어 있지 않습니다.", "서버가 실행되어 있지 않음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Server.WhitelistAdd(WlAddPlayerNameBox.Text);

            Server.ServerJson.LoadWhitelistPlayers();
            WlUpdate();

            WlAddPlayerNameBox.Text = string.Empty;
        }

        private void WlRemoveButton_Click(object sender, EventArgs e)
        {
            if (PlayerListView.Items.Count < 1)
            {
                MessageBox.Show("1명 이상의 플레이어를 선택해야 합니다.", "화이트리스트 제거", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Server.IsDone)
            {
                MessageBox.Show("서버가 실행할 준비가 되어 있지 않습니다.", "서버가 실행되어 있지 않음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult msg = MessageBox.Show("선택한 플레이어를 화이트리스트에서 제거하시겠습니까?", "화이트리스트 제거", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg != DialogResult.Yes)
                return;

            foreach (var player in GetSelectedPlayers())
            {
                Server.SendCommand($"whitelist remove {player.Name}", true);
            }

            Server.ServerJson.LoadWhitelistPlayers();
            WlUpdate();
        }

        private void WlAddPlayerNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                WlAddButton.PerformClick();
            }
        }

        private void UseWlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!UseWlChkBoxChangedEventEnable)
                return;

            if (Server.IsRunning)
            {
                MessageBox.Show("서버가 실행 중입니다. 서버를 다시 시작해야 변경 사향을 적용할 수 있습니다.", "서버 실행 중", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (UseWlCheckBox.Checked)
                Server.ServerProperties.Properties["white-list"] = "true";
            else
                Server.ServerProperties.Properties["white-list"] = "false";
            Server.ServerProperties.Save();

            UsedWlCheck();
        }
    }
}
