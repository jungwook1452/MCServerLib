﻿using System;
using System.Windows.Forms;

using MCServerLib;

namespace MCServerExample
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private delegate void DServerConsoleWriteLine(string text);

        private MCServer Server;

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void ServerForm_Shown(object sender, EventArgs e)
        {
            ServerJARDialog.FileName = string.Empty;

            if (ServerJARDialog.ShowDialog() == DialogResult.OK)
            {
                Server = new MCServer(ServerJARDialog.FileName);
                Server.OutputReceived += Server_OutputReceived;
                Server.Exited += Server_Exited;
                Server.StartOption.NoGUI = true;

                MainTimer.Enabled = true;
            } else
            {
                Close();
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Server == null)
                return;

            if (Server.IsRunning)
            {
                // 사용자가 직접 종료를 버튼을 때만 메시지가 표시됨
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult msg = MessageBox.Show("서버가 실행 중입니다. 서버에 stop 명령어를 보내고 종료할까요?", "서버 실행 중", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (msg != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                Server.Stop();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!Server.IsRunning)
            {
                ServerConsoleBox.Text = string.Empty;
                ServerConsoleWriteLine("Server Starting...");

                StopButton.Enabled = true;

                Server.StartOption.MinMemory = int.Parse(SminRAMBox.Text);
                Server.StartOption.MaxMemory = int.Parse(SmaxRAMBox.Text);
                Server.StartOption.MemoryGB = checkBox3.Checked;

               Server.Start();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Server.Stop();
        }

        private void ServerCommandBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(ServerCommandBox.Text) && Server.IsRunning)
                {
                    Server.SendCommand(ServerCommandBox.Text);
                    ServerCommandBox.Text = string.Empty;
                }
            }
        }

        private void ServerConsoleWriteLine(string text)
        {
            if (ServerConsoleBox.InvokeRequired)
            {
                ServerConsoleBox.Invoke(new DServerConsoleWriteLine(ServerConsoleWriteLine), new object[] { text });
            }
            else
            {
                ServerConsoleBox.AppendText(string.Format("{0}\r\n", text));
                ServerConsoleBox.ScrollToCaret();
            }
        }

        private void Server_OutputReceived(object sender, MCServerOutputEventArgs e)
        {
            if (e.LogInfo != null)
            {
                ServerConsoleWriteLine(e.LogInfoNoOutput);
            }
        }

        private void Server_Exited(object sender, EventArgs e)
        {
            ServerConsoleWriteLine("Server Stopted...");
            StopButton.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Server.StartOption.NoGUI = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Server.StartOption.Demo = checkBox2.Checked;
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (Server.IsRunning)
            {
                Text = string.Format("서버 버킷 (실행중, 실행 횟수 : {0})", Server.ServerStartCount);
            } else
            {
                Text = string.Format("서버 버킷 (중지, 실행 횟수 : {0})", Server.ServerStartCount);
            }
        }

        private void ServerOptionButton_Click(object sender, EventArgs e)
        {
            if (Server.IsRunning)
            {
                MessageBox.Show("서버가 실행 중에는 설정을 변경할 수 없습니다.", "서버 실행 중", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                if (!Server.ServerProperties.Loaded)
                {
                    if (!System.IO.File.Exists(Server.ServerProperties.PropertiesFileName))
                    {
                        MessageBox.Show("서버 폴더 내에서 server.properties 파일을 찾을 수 없습니다.", "server.properties 파일 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    } else
                    {
                        Server.ServerProperties.Load();
                    }
                }

                ServerOptionForm form = new ServerOptionForm();
                form.MCProperties = Server.ServerProperties;
                form.ShowDialog();
            }
        }
    }
}