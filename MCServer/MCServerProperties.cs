using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using static MCServerLib.MCServerInternal;

namespace MCServerLib
{
    /// <summary>
    /// 마인크래프트 서버 설정입니다.
    /// </summary>
    public class MCServerProperties
    {
        /// <summary>
        /// 서버 설정 파일 (server.properties)
        /// </summary>
        public string PropertiesFileName;

        /// <summary>
        /// 서버 설정 값 정보
        /// </summary>
        public Dictionary<string, string> Properties = new Dictionary<string, string>();

        /// <summary>
        /// 서버 설정 불러오기 여부
        /// </summary>
        public bool Loaded { private set; get; } = false;

        #region 서버 설정

        /// <summary>
        /// server-ip : 서버 아이피를 설정하거나 가져옵니다. 기본적으로 비어있습니다.
        /// </summary>
        public string PropServerIP
        {
            set
            {
                Properties["server-ip"] = value;
            }
            get
            {
                return Properties["server-ip"];
            }
        }

        /// <summary>
        /// server-port : 서버 포트를 설정하거나 가져옵니다. (기본값 : 25565)
        /// </summary>
        public int PropServerPort
        {
            set
            {
                Properties["server-port"] = value.ToString();
            }
            get
            {
                return StringToInt(Properties["server-port"], 25565);
            }
        }

        /// <summary>
        /// hardcore : 하드코어 여부를 설정하거나 가져옵니다. 하드코어를 활성화할 경우 difficulty 설정을 무시하고 어려움 난이도로 고정됩니다. (기본값 : false)
        /// </summary>
        public bool PropHardcore
        {
            set
            {
                Properties["hardcore"] = value.ToString().ToLower();
            }
            get
            {
                return StringToBool(Properties["hardcore"], false);
            }
        }

        /// <summary>
        /// level-seed : 생성될 서버 맵의 시드를 설정하거나 가져옵니다. 비어있으면 자동으로 랜덤으로 시드가 설정됩니다.
        /// </summary>
        public string PropLevelSeed
        {
            set
            {
                Properties["level-seed"] = value.ToString();
            }
            get
            {
                return Properties["level-seed"];
            }
        }

        /// <summary>
        /// online-mode : 서버의 마인크래프트 계정 데이터베이스 연결 여부를 설정하거나 가져옵니다. (기본값 : true)
        /// </summary>
        public bool PropOnlineMode
        {
            set
            {
                Properties["online-mode"] = value.ToString().ToLower();
            }
            get
            {
                return StringToBool(Properties["online-mode"], true);
            }
        }

        /// <summary>
        /// motd : 서버의 메시지(서버 목록에서 표시될 문자)를 설정하거나 가져옵니다. 최대 59자까지 설정할 수 있습니다.(기본값 : A Minecraft Server)
        ///<para>참고 : 영어 외의 문자(한글 포함)는 유니코드 문자열로 써야합니다. 또한 포매팅 코드(§, u00A7)로 색을 설정할 수 있습니다.</para>
        ///<para>motd를 쉽게 쓰려면 https://minecraft.tools/en/motd.php 에서 하실 수 있습니다.</para>
        /// </summary>
        public string PropMotd
        {
            set
            {
                Properties["motd"] = value;
            }
            get
            {
                return Properties["motd"];
            }
        }

        /// <summary>
        /// max-players : 서버의 최대 인원 수를 설정하거나 가져옵니다. (기본값 : 20)
        /// </summary>
        public int PropMaxPlayers
        {
            set
            {
                Properties["max-players"] = value.ToString();
            }
            get
            {
                return StringToInt(Properties["max-players"], 20);
            }
        }

        #endregion

        /// <summary>
        /// 지정된 서버 경로에서 server.properties 파일을 불러옵니다.
        /// </summary>
        /// <param name="ServerPath">마인크래프트 서버 폴더</param>
        public MCServerProperties(string ServerPath)
        {
            PropertiesFileName = Path.Combine(ServerPath, "server.properties");
            Load();
        }

        /// <summary>
        /// server.properties 파일에서 서버 설정들을 가져옵니다.
        /// </summary>
        public void Load()
        {
            Properties.Clear();

            if (File.Exists(PropertiesFileName))
            {
                using (FileStream fs = new FileStream(PropertiesFileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        int Remarks = 0;

                        while (!sr.EndOfStream)
                        {
                            string ReadText = sr.ReadLine();

                            if (ReadText[0] != '#')
                            {
                                try
                                {
                                    string[] value = ReadText.Split('=');
                                    Properties.Add(value[0], value[1]);
                                } catch (IndexOutOfRangeException)
                                {
                                    Properties.Add("__remark" + Remarks, ReadText);
                                    Remarks++;
                                }
                            } else
                            {
                                Properties.Add("__remark" + Remarks, ReadText);
                                Remarks++;
                            }
                        }
                    }
                }
                Loaded = true;
            } else { Loaded = false; }
        }

        /// <summary>
        /// 서버 설정을 저장합니다. 서버 설정이 불러온 상태에서만 실행합니다.
        /// <para>주의 : 설정을 저장한 후 Load 메서드를 호출합니다.</para>
        /// </summary>
        public void Save()
        {
            if (!Loaded)
                return;

            using (FileStream fs = new FileStream(PropertiesFileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    foreach (var pair in Properties)
                    {
                        if (Regex.IsMatch(pair.Key, "__remark"))
                        {
                            sw.WriteLine(pair.Value);
                        } else
                        {
                            sw.WriteLine("{0}={1}", pair.Key, pair.Value);
                        }
                    }
                }
            }
        }
    }
}
