using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCServerLib;

namespace MCServerExample.Controls
{
    public partial class BanListControl : UserControl
    {
        public MCServer server;

        public BanListControl()
        {
            InitializeComponent();
        }

        private void BanListUpdate()
        {
            BanListView.Items.Clear();
            BanListView.BeginUpdate();

            foreach (var pair in server.ServerJson.BanPlayers)
            {
                var info = pair.Value;

                ListViewItem item = new ListViewItem(pair.Key.ToString());
                item.SubItems.Add(info.Name);
                item.SubItems.Add(info.BanReason);
                item.SubItems.Add(info.BanDateTime.ToString());
                item.SubItems.Add(info.BanSource);

                BanListView.Items.Add(item);
            }

            BanListView.EndUpdate();
        }

        private List<MCBanPlayerInfo> GetSelectedPlayers()
        {
            List<MCBanPlayerInfo> Ls = new List<MCBanPlayerInfo>();
            
            for (int i = 0; i < BanListView.SelectedItems.Count; i++)
            {
                int ID = int.Parse(BanListView.SelectedItems[i].SubItems[0].Text);
                foreach (var pair in server.ServerJson.BanPlayers)
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

        private void BanButton_Click(object sender, EventArgs e)
        {
            if (!server.IsDone)
            {
                MessageBox.Show("서버가 실행이 완료되어 있어야 합니다.", "밴", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DownForms.BanPlayerAddForm form = new DownForms.BanPlayerAddForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in form.PlayerListBox.Items)
                {
                    if (form.BanReason == null)
                        server.SendCommand($"ban {item}", true);
                    else
                        server.SendCommand($"ban {item} {form.BanReason}", true);
                }

                System.Threading.Thread.Sleep(100);
                server.ServerJson.LoadBanPlayers();
                BanListUpdate();
            }
        }

        private void DeleteBanButton_Click(object sender, EventArgs e)
        {
            if (!server.IsDone)
            {
                MessageBox.Show("서버가 실행이 완료되어 있어야 합니다.", "밴 삭제", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (BanListView.SelectedItems.Count < 1)
            {
                MessageBox.Show("밴 해제 대상 플레이어를 선택하십시오. (여러번 선택가능)", "밴 삭제", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult msg = MessageBox.Show("선택한 플레이어의 밴 상태를 해제하시겠습니까?", "밴 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (msg != DialogResult.Yes)
                return;

            foreach (var player in GetSelectedPlayers())
            {
                server.SendCommand($"pardon {player.Name}", true);
            }

            System.Threading.Thread.Sleep(100);
            server.ServerJson.LoadBanPlayers();
            BanListUpdate();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            BanListUpdate();
        }

        private void BanPlayerJsonLoadButton_Click(object sender, EventArgs e)
        {
            server.ServerJson.LoadBanPlayers();
            BanListUpdate();
        }
    }
}
