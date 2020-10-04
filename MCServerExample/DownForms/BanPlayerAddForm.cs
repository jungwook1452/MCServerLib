using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCServerExample.DownForms
{
    public partial class BanPlayerAddForm : Form
    {
        public string BanReason;

        public BanPlayerAddForm()
        {
            InitializeComponent();
        }

        private void PlayerNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PlayerAddButton.PerformClick();
            }
        }

        private void PlayerAddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PlayerNameBox.Text))
            {
                MessageBox.Show("추가할 플레이어 닉네임을 입력하십시오.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PlayerListBox.Items.Add(PlayerNameBox.Text);
            PlayerNameBox.Text = string.Empty;
        }

        private void PlayerListItemDeleteButton_Click(object sender, EventArgs e)
        {
            if (PlayerListBox.SelectedItems.Count < 1)
            {
                MessageBox.Show("목록에 추가된 항목을 선택하십시오.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PlayerListBox.BeginUpdate();

            for (int i = 0; i < PlayerListBox.SelectedItems.Count; i++)
            {
                PlayerListBox.Items.Remove(PlayerListBox.SelectedItems[i]);
            }

            PlayerListBox.EndUpdate();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (PlayerListBox.Items.Count < 1)
            {
                MessageBox.Show("1명 이상의 플레이어를 목록에 추가해야 합니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(ReasonTextBox.Text))
                BanReason = ReasonTextBox.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
