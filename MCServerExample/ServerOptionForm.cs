using System;
using System.Windows.Forms;
using MCServerLib;

namespace MCServerExample
{
    public partial class ServerOptionForm : Form
    {
        public MCServerProperties MCProperties;

        public ServerOptionForm()
        {
            InitializeComponent();
        }

        private void ServerOptionForm_Load(object sender, EventArgs e)
        {
            MotdTextBox.Text = MCProperties.PropMotd;
            SeedTextBox.Text = MCProperties.PropLevelSeed;
            OnlineModeBox.Checked = MCProperties.PropOnlineMode;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            MCProperties.PropMotd = MotdTextBox.Text;
            MCProperties.PropLevelSeed = SeedTextBox.Text;
            MCProperties.PropOnlineMode = OnlineModeBox.Checked;

            MCProperties.Save();
            MessageBox.Show("서버 설정을 저장했습니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
    }
}
