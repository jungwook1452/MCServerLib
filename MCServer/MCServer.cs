using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using static MCServerLib.MCServerInternal;
using MCServerLib.Exceptions;

namespace MCServerLib
{
    /// <summary>
    /// 서버를 시작하고 중지하고 이벤트를 통해 실시간으로 서버로부터 데이터(로그, 오류 등)를 받습니다.
    /// </summary>
    public class MCServer
    {
        /// <summary>
        /// 서버를 실행하는데 필요한 정보입니다.
        /// </summary>
        public MCServerStartOption StartOption;

        /// <summary>
        /// 마인크래프트 서버 구동기가 있는 폴더 경로
        /// </summary>
        public string ServerRootPath { private set; get; }

        /// <summary>
        /// 서버 실행 중인 여부를 가져옵니다.
        /// </summary>
        public bool IsRunning { private set; get; } = false;

        /// <summary>
        /// 서버 시작 완료 여부를 가져옵니다.
        /// <para>참고: 출력 로그에서 Done 및 For help, type "help" (이)가 발견되었을 경우 true로 설정됩니다. 서버가 종료될 시 false으로 변경됩니다.</para>
        /// </summary>
        public bool IsDone { private set; get; } = false;

        /// <summary>
        /// 서버 설정
        /// </summary>
        public MCServerProperties ServerProperties { private set; get; }

        /// <summary>
        /// 서버 플러그인
        /// </summary>
        public Dictionary<string, MCPluginInfo> Plugins { private set; get; }

        /// <summary>
        /// 오피, 밴/밴아이피, 화이트리스트 JSON 정보
        /// </summary>
        public MCServerJson ServerJson { private set; get; }

        /// <summary>
        /// 서버 프로세스 종료 코드를 가져옵니다.
        /// </summary>
        public int ServerExitCode { private set; get; } = 0;

        /// <summary>
        /// 서버 프로세스
        /// </summary>
        private Process ServerProcess;

        /// <summary>
        /// <see cref="Start(int, int, bool)"/> 메서드로 서버를 실행한 횟수
        /// </summary>
        public uint StartCount { private set; get; }

        /// <summary>
        /// 서버의 시작 과정이 완료될 때 발생하는 이벤트
        /// </summary>
        public event EventHandler Done;
        /// <summary>
        /// 서버로부터 출력한 로그를 받는 이벤트
        /// </summary>
        public event MCServerOutputEventHandler OutputReceived;
        /// <summary>
        /// 서버로부터 출력한 오류 로그를 받는 이벤트
        /// </summary>
        public event MCServerOutputEventHandler ErrorDataReceived;
        /// <summary>
        /// 서버가 종료되면 발생하는 이벤트
        /// </summary>
        public event EventHandler Exited;

        /// <summary>
        /// 서버를 시작하고 중지하고 명령어 전송 및 이벤트를 통해 실시간으로 서버로부터 데이터(로그, 오류 등)를 받습니다.
        /// </summary>
        /// <param name="ServerCoreFileName">서버 JAR 파일 이름 또는 경로 (예 : craftbukkit.jar)</param>
        public MCServer(string ServerCoreFileName)
        {
            Init(ServerCoreFileName, GetJavaInstallPath());
        }

        /// <summary>
        /// 서버를 시작하고 중지하고 명령어 전송 및 이벤트를 통해 실시간으로 서버로부터 데이터(로그, 오류 등)를 받습니다.
        /// </summary>
        /// <param name="ServerCoreFileName">서버 JAR 파일 이름 또는 경로 (예 : craftbukkit.jar)</param>
        /// <param name="JavaSetupPath">자바가 설치되어 있는 경로 (예 : %ProgramFiles%\Java\jre1.8.0_261)</param>
        public MCServer(string ServerCoreFileName, string JavaSetupPath)
        {
            Init(ServerCoreFileName, JavaSetupPath);
        }

        /// <summary>
        /// 서버를 시작하고 중지하고 명령어 전송 및 이벤트를 통해 실시간으로 서버로부터 데이터(로그, 오류 등)를 받습니다.
        /// </summary>
        /// <param name="Option">서버 시작 정보</param>
        public MCServer(MCServerStartOption Option)
        {
            // JarPath가 null 인지 확인합니다.
            if (Option.JarPath == null)
            {
                throw new Exception("StartOption.JarPath가 null 입니다.");
            }

            // JavaPath가 null 인지 확인합니다.
            if (Option.JavaPath == null)
            {
                throw new Exception("StartOption.JavaPath가 null 입니다.");
            }

            if (Option.JavaPath == null)
                Init(Option.JarPath, GetJavaInstallPath(), Option);
            else
                Init(Option.JarPath, Option.JavaPath, Option);
        }

        private void Init(string ServerCoreFileName, string JavaSetupPath, MCServerStartOption option = null)
        {
            // MCServerStartOption 초기화
            if (option == null)
                StartOption = new MCServerStartOption();
            else
                StartOption = option;

            // 자바 경로를 찾을 수 없거나 비어있으면 예외 발생!
            if (JavaSetupPath != null)
            {
                if (!Directory.Exists(JavaSetupPath))
                    throw new JavaNotFound();

                if (!File.Exists(Path.Combine(JavaSetupPath, "bin\\java.exe")))
                    throw new JavaNotFound("자바 설치 폴더에서 java.exe를 찾을 수 없습니다.");

                StartOption.JavaPath = JavaSetupPath;
            }
            else
            {
                throw new JavaNotFound("캄퓨터에 설치된 자바를 찾을 수 없습니다!");
            }
            
            if (!File.Exists(ServerCoreFileName))
            {
                throw new ServerJARNotFound($"'{ServerCoreFileName}' 서버 코어 파일을 찾을 수 없습니다.");
            }

            ServerRootPath = Path.GetDirectoryName(ServerCoreFileName);

            StartOption.JarPath = Path.Combine(ServerRootPath, Path.GetFileName(ServerCoreFileName));

            ServerProperties = new MCServerProperties(ServerRootPath);
            ServerJson = new MCServerJson(ServerRootPath);
            LoadPlugins();
        }

        /// <summary>
        /// 지정된 이름의 플러그인이 서버에 설치되어 있는지 확인합니다.
        /// </summary>
        /// <param name="pluginName">플러그인 이름</param>
        /// <returns>지정된 플러그인이 있을 경우 true, 없으면 false 입니다.</returns>
        public bool PluginExists(string pluginName)
        {
            foreach (var pair in Plugins)
            {
                MCPluginInfo info = pair.Value;
                if (string.Compare(info.Name, pluginName) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 서버 폴더 내의 plugins 폴더에서 플러그인들의 정보를 가져옵니다.
        /// </summary>
        public void LoadPlugins()
        {
            if (Plugins == null)
                Plugins = new Dictionary<string, MCPluginInfo>();

            if (!Directory.Exists(Path.Combine(ServerRootPath, @"plugins")))
                return;

            Plugins.Clear();

            foreach (string filename in Directory.GetFiles(Path.Combine(ServerRootPath, @"plugins"), "*.jar"))
            {
                string yml = GetPluginInfo(filename);

                if (yml != null)
                {
                    using (StringReader reader = new StringReader(yml))
                    {
                        try
                        {
                            YamlDotNet.RepresentationModel.YamlStream ys = new YamlDotNet.RepresentationModel.YamlStream();
                            ys.Load(reader);

                            var RootNode = (YamlDotNet.RepresentationModel.YamlMappingNode)ys.Documents[0].RootNode;

                            string plugin_name = RootNode.Children["name"].ToString();
                            string plugin_version = RootNode.Children["version"].ToString();
                            string plugin_description;

                            if (string.IsNullOrWhiteSpace(plugin_name) || string.IsNullOrWhiteSpace(plugin_version))
                                throw new Exception("Failed to get the required information for the plugin.");

                            if (RootNode.Children.ContainsKey("description"))
                                plugin_description = RootNode.Children["description"].ToString();
                            else
                                plugin_description = string.Empty;

                            MCPluginInfo info = new MCPluginInfo(filename, plugin_name, plugin_version, plugin_description, false);
                            Plugins.Add(Path.GetFileName(filename), info);
                        } catch
                        {
                            MCPluginInfo info = new MCPluginInfo(filename, Path.GetFileNameWithoutExtension(filename), null, string.Empty, true);
                            Plugins.Add(Path.GetFileName(filename), info);
                        }
                    }
                }
            }

            /*
            foreach (var pair in Plugins)
            {
                MCPluginInfo info = pair.Value;
                Debug.Print("{0} = {1}, {2}, {3}", pair.Key, info.Name, info.Version, info.Description);
            }*/
        }

        /// <summary>
        /// 해당 플러그인의 plugin.yml 파일 내용을 가져옵니다.
        /// </summary>
        /// <param name="PluginFileName">플러그인 파일 (JAR)</param>
        /// <returns>해당 플러그인의 plugin.yml 파일 내용, 실패할 경우 null입니다.</returns>
        private string GetPluginInfo(string PluginFileName)
        {
            try
            {
                using (System.IO.Compression.ZipArchive archive = System.IO.Compression.ZipFile.OpenRead(PluginFileName))
                {
                    System.IO.Compression.ZipArchiveEntry entry = archive.GetEntry("plugin.yml");

                    if (entry != null)
                    {
                        using (StreamReader reader = new StreamReader(entry.Open()))
                        {
                            return reader.ReadToEnd();
                        }
                    } else
                    {
                        return null;
                    }
                }
            } catch
            {
                return null;
            }
        }

        /// <summary>
        /// 서버를 시작합니다.
        /// <para>참고 : 한번 실행한 이후 다시 실행하면 서버 JSON 파일들(관리자(OP), 밴, 차단 아이피, 등) 및 플러그인 정보 목록을 다시 불러옵니다.</para>
        /// </summary>
        /// <param name="Xms">최소 메모리 할당량</param>
        /// <param name="Xmx">최대 메모리 할당량</param>
        /// <param name="MemoryGB">기가바이트 단위 사용</param>
        public void Start()
        {
            if (IsRunning)
                return;

            CheckValidation();

            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = Path.Combine(StartOption.JavaPath, "bin\\java.exe"),
                WorkingDirectory = ServerRootPath,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = false,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            if (!StartOption.MemoryGB)
                info.Arguments += $"-Xmx{StartOption.MaxMemory}M -Xms{StartOption.MinMemory}M";
            else
                info.Arguments += $"-Xmx{StartOption.MaxMemory}G -Xms{StartOption.MinMemory}G";

            info.Arguments += $" -jar \"{StartOption.JarPath}\"";

            if (!StartOption.NoWindow)
            {
                if (StartOption.NoGUI)
                {
                    info.Arguments += " --nogui";
                    info.CreateNoWindow = true;
                }
            } else
            {
                info.CreateNoWindow = true;
            }

            if (StartOption.Demo)
                info.Arguments += " --demo";

            Debug.Print("[MCServer.Start] Process Start : {0} {1}", info.FileName, info.Arguments);

            ServerProcess = new Process();
            ServerProcess.StartInfo = info;
            ServerProcess.EnableRaisingEvents = true;

            ServerProcess.OutputDataReceived += ServerProcess_OutputDataReceived;
            ServerProcess.ErrorDataReceived += ServerProcess_ErrorDataReceived;
            ServerProcess.Exited += ServerProcess_Exited;

            ServerProcess.Start();
            ServerProcess.BeginOutputReadLine();
            ServerProcess.BeginErrorReadLine();

            if (StartCount >= 1)
            {
                ServerJson.LoadAll();
                LoadPlugins();
            }

            StartCount++;
            IsRunning = true;
        }

        /// <summary>
        /// 서버에 stop 명령어를 보내 중료 절차를 실행하도록 합니다.
        /// </summary>
        public void Stop()
        {
            if (!IsRunning)
                return;

            SendCommand("stop");
        }

        #region Server Commands

        /// <summary>
        /// 서버에 명령어를 전송합니다. 서버가 실행 중일때만 작동합니다.
        /// </summary>
        /// <param name="command">서버에 전달할 명령어</param>
        /// <param name="NoReload">true로 설정 시 op, ban 등의 JSON 변경 관련 명령어를 받았을 때 해당 JSON 파일을 재로딩하지 않습니다.</param>
        public void SendCommand(string command, bool NoReload = false)
        {
            if (IsRunning)
            {
                Debug.Print("Send Command : {0}", command);

                ServerProcess.StandardInput.WriteLine(command);

                if (!NoReload)
                {
                    System.Threading.Thread.Sleep(100);

                    string[] CmdArgs = command.Split(' ');

                    switch (CmdArgs[0].ToLower())
                    {
                        case "reload":
                            LoadPlugins();
                            ServerJson.LoadAll();
                            break;
                        case "op":
                        case "deop":
                            if (CmdArgs.Length > 1)
                                ServerJson.LoadOps();
                            break;
                        case "ban":
                            if (CmdArgs.Length > 1)
                                ServerJson.LoadBanPlayers();
                            break;
                        case "ban-ip":
                            if (CmdArgs.Length > 1)
                                ServerJson.LoadBanIPs();
                            break;
                        case "pardon":
                            if (CmdArgs.Length > 1)
                                ServerJson.LoadBanPlayers();
                            break;
                        case "pardon-ip":
                            if (CmdArgs.Length > 1)
                                ServerJson.LoadBanIPs();
                            break;
                        case "whitelist":
                            if (CmdArgs.Length > 2)
                            {
                                if (CmdArgs[1] == "add" || CmdArgs[1] == "remove")
                                {
                                    ServerJson.LoadWhitelistPlayers();
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 지정된 플레이어에게 OP(관리자) 권한을 부여합니다. (서버에 op 명령어 전송)
        /// </summary>
        /// <param name="username">대상 플레이어 닉네임</param>
        public void AddOP(string username)
        {
            SendCommand($"op {username}");
        }

        /// <summary>
        /// 지정된 플레이어의 OP(관리자) 권한을 박탈합니다. (서버에 deop 명령어 전송)
        /// </summary>
        /// <param name="username">대상 플레이어 닉네임</param>
        public void DeleteOP(string username)
        {
            SendCommand($"deop {username}");
        }

        /// <summary>
        /// 지정된 플레이어를 영구적으로 서버에서 추방시킵니다. (서버에 ban 명령어 전송)
        /// </summary>
        /// <param name="username">대상 플레이어 닉네임</param>
        /// <param name="reason">추방 사유 (필수 아님)</param>
        public void AddBan(string username, string reason = null)
        {
            if (reason == null)
                SendCommand($"ban {username}");
            else
                SendCommand($"ban {username} {reason}");
        }

        /// <summary>
        /// 지정된 아이피 주소를 차단하여 해당 아이피에서 서버에 접속할 수 없게 합니다. 플레이어 닉네임으로 쓰면 그 플레이어의 아이피를 차단합니다. (서버에 ban-ip 명령어 전송)
        /// </summary>
        /// <param name="usernameOrip">대상 플레이어 닉네임 또는 대상 아이피</param>
        public void AddBanIP(string usernameOrip)
        {
            SendCommand($"ban-ip {usernameOrip}");
        }

        /// <summary>
        /// 지정된 플레이어의 추방을 해제합니다. (서버에 pardon 명령어 전송)
        /// </summary>
        /// <param name="username">대상 추방 플레이어 닉네임</param>
        public void DeleteBan(string username)
        {
            SendCommand($"pardon {username}");
        }

        /// <summary>
        /// 지정된 아이피 차단을 해제합니다. (서버에 pardon-ip 명령어 전송)
        /// </summary>
        /// <param name="ip">차단된 대상 아이피</param>
        public void DeleteBanIP(string ip)
        {
            SendCommand($"pardon-ip {ip}");
        }

        /// <summary>
        /// 화이트리스트에 지정된 플레이어를 추가합니다. 화이트리스트를 사용하려면 server.properties 파일에서 white-list가 true로 되어 있어야 합니다. (서버에 whitelist add 명령어 전송)
        /// <para>참고 : 관리자(OP)는 자동으로 화이트리스트에 등록됩니다.</para>
        /// </summary>
        /// <param name="username">대상 플레이어 닉네임</param>
        public void WhitelistAdd(string username)
        {
            SendCommand($"whitelist add {username}");
        }

        /// <summary>
        /// 화이트리스트에서 지정된 플레이어를 제거합니다. (서버에 whitelist remove 명령어 전송)
        /// </summary>
        /// <param name="username">화이트리스트에 추가된 대상 플레이어 닉네임</param>
        public void WhitelistRemove(string username)
        {
            SendCommand($"whitelist remove {username}");
        }

        #endregion

        /// <summary>
        /// <see cref="StartOption"/>를 체크하여 잘못되어 있을 경우 예외를 발생시킵니다.
        /// </summary>
        private void CheckValidation()
        {
            // JarPath가 null 인지 확인합니다.
            if (StartOption.JarPath == null)
            {
                throw new Exception("StartOption.JarPath가 null 입니다.");
            }

            // JavaPath가 null 인지 확인합니다.
            if (StartOption.JavaPath == null)
            {
                throw new Exception("StartOption.JavaPath가 null 입니다.");
            }

            // 최소 및 최대 램 용량의 음수 여부
            if (StartOption.MinMemory < 0 || StartOption.MaxMemory < 0)
            {
                throw new Exception("최소 또는 최대 활당 메모리 용량이 음수로 되어 있습니다.");
            }

            // 최소 램 용량이 최대 램 용량보다 큰지 확인
            if (StartOption.MinMemory > StartOption.MaxMemory)
            {
                throw new Exception("최소 활당 메모리 용량이 최대 활당 메모리 용량을 넘었습니다. ");
            }
        }

        // 서버 종료 이벤트
        private void ServerProcess_Exited(object sender, EventArgs e)
        {
            IsRunning = false;
            IsDone = false;
            ServerExitCode = ServerProcess.ExitCode;

            ServerProcess.Dispose();

            if (Exited != null)
                RaiseEventOnUIThread(Exited, new object[] { sender, e });
        }

        // 서버 오류 이벤트
        private void ServerProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Task.Run(() => ErrorDataReceived?.Invoke(this, new MCServerOutputEventArgs(e.Data)));
        }

        // 서버 출력 이벤트
        private void ServerProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            var OutputEventArgs = new MCServerOutputEventArgs(e.Data);

            if (!IsDone)
            {
                string output = OutputEventArgs.LogOutput;

                if (System.Text.RegularExpressions.Regex.IsMatch(output, "Done", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(output, "For help, type \"help\"", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        // 출력된 로그에서 Done 및 For help, type "help" (이)가 발견되었을 경우 시작 과정이 완료됨으로 판단됨

                        IsDone = true;
                        if (Done != null)
                        {
                            RaiseEventOnUIThread(Done, new object[] { this, new EventArgs() });
                        }
                    }
                }
            }

            Task.Run(() => OutputReceived?.Invoke(this, OutputEventArgs));
        }

        private void RaiseEventOnUIThread(Delegate theEvent, object[] args)
        {
            foreach (Delegate d in theEvent.GetInvocationList())
            {
                ISynchronizeInvoke syncer = d.Target as ISynchronizeInvoke;
                if (syncer == null)
                {
                    d.DynamicInvoke(args);
                }
                else
                {
                    syncer.BeginInvoke(d, args);  // cleanup omitted
                }
            }
        }
    }
}
