using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MCServerLib
{
    /// <summary>
    /// 오피, 밴/밴아이피, 화이트리스트 JSON 정보입니다.
    /// <para>참고 : TXT 파일 방식(1.7.5 이하)은 지원되지 않습니다.</para>
    /// </summary>
    public class MCServerJson
    {
        private string _OPJsonFileName;
        private string _BanJsonFileName;
        private string _BanIPJsonFileName;
        private string _WhitelistFileName;

        private JArray OPJsonObj;
        private JArray BanJsonObj;
        private JArray BanIPJsonObj;
        private JArray WhitelistJsonObj;

        /// <summary>
        /// 관리자(OP) 목록
        /// </summary>
        public Dictionary<int, MCOpPlayerInfo> Ops { private set; get; }
        /// <summary>
        /// 밴 플레이어 목록
        /// </summary>
        public Dictionary<int, MCBanPlayerInfo> BanPlayers { private set; get; }
        /// <summary>
        /// 차단 아이피 목록
        /// </summary>
        public Dictionary<int, MCBanIPInfo> BanIPs { private set; get; }
        /// <summary>
        /// 화이트리스트 플레이어 목록
        /// </summary>
        public Dictionary<int, MCWhitelistPlayerInfo> WhitelistPlayers { private set; get; }

        /// <summary>
        /// JSON가 제대로 불러왔지는지 가져옵니다.
        /// </summary>
        public bool Loaded { private set; get; } = false;

        /// <summary>
        /// 관리자(OP) 수
        /// </summary>
        public int OpCount
        {
            get
            {
                return Ops.Count;
            }
        }

        /// <summary>
        /// 밴 플레이어 수
        /// </summary>
        public int BanCount
        {
            get
            {
                return BanPlayers.Count;
            }
        }

        /// <summary>
        /// 차단 아이피 수
        /// </summary>
        public int BanIPCount
        {
            get
            {
                return BanIPs.Count;
            }
        }

        /// <summary>
        /// 화이트리스트 플레이어 수
        /// </summary>
        public int WhitelistCount
        {
            get
            {
                return WhitelistPlayers.Count;
            }
        }

        /// <summary>
        /// 서버의 오피, 밴/아이피 차단, 화이트리스트 정보를 가져옵니다.
        /// <para>참고 : Load 메서드가 자동으로 호출됩니다.</para>
        /// </summary>
        /// <param name="ServerPath">서버 파일이 있는 경로</param>
        public MCServerJson(string ServerPath)
        {
            _OPJsonFileName = Path.Combine(ServerPath, "ops.json");
            _BanJsonFileName = Path.Combine(ServerPath, "banned-players.json");
            _BanIPJsonFileName = Path.Combine(ServerPath, "banned-ips.json");
            _WhitelistFileName = Path.Combine(ServerPath, "whitelist.json");

            Ops = new Dictionary<int, MCOpPlayerInfo>();
            BanPlayers = new Dictionary<int, MCBanPlayerInfo>();
            BanIPs = new Dictionary<int, MCBanIPInfo>();
            WhitelistPlayers = new Dictionary<int, MCWhitelistPlayerInfo>();

            Load();
        }

        /// <summary>
        /// 서버의 오피, 밴/아이피 차단, 화이트리스트 정보를 로드합니다.
        /// </summary>
        public void Load()
        {
            if (!File.Exists(_OPJsonFileName) || !File.Exists(_BanJsonFileName) || !File.Exists(_BanIPJsonFileName) || !File.Exists(_WhitelistFileName))
            {
                Loaded = false;
                return;
            }

            Loaded = true;

            OPJsonObj = JArray.Parse(File.ReadAllText(_OPJsonFileName));
            BanJsonObj = JArray.Parse(File.ReadAllText(_BanJsonFileName));
            BanIPJsonObj = JArray.Parse(File.ReadAllText(_BanIPJsonFileName));
            WhitelistJsonObj = JArray.Parse(File.ReadAllText(_WhitelistFileName));

            Ops.Clear();
            BanPlayers.Clear();
            BanIPs.Clear();
            WhitelistPlayers.Clear();

            int ID = 0;

            foreach (JObject Obj in OPJsonObj.Children())
            {
                try
                {
                    var info = new MCOpPlayerInfo(
                        (string)Obj["name"],
                        (string)Obj["uuid"],
                        (int)Obj["level"],
                        (bool)Obj["bypassesPlayerLimit"]
                        );
                    Ops.Add(ID, info);
                    ID++;
                } catch { }
            }

            ID = 0;

            foreach (JObject Obj in BanJsonObj.Children())
            {
                try
                {
                    var info = new MCBanPlayerInfo(
                        (string)Obj["name"],
                        (string)Obj["uuid"],
                        (string)Obj["created"],
                        (string)Obj["source"],
                        (string)Obj["expires"],
                        (string)Obj["reason"]
                        );

                    BanPlayers.Add(ID, info);
                    ID++;
                }
                catch { }
            }

            ID = 0;

            foreach (JObject Obj in BanIPJsonObj.Children())
            {
                try
                {
                    var info = new MCBanIPInfo(
                            (string)Obj["name"],
                            (string)Obj["created"],
                            (string)Obj["source"],
                            (string)Obj["expires"],
                            (string)Obj["reason"]
                        );
                    BanIPs.Add(ID, info);
                    ID++;
                }
                catch { }
            }

            ID = 0;

            foreach (JObject Obj in WhitelistJsonObj.Children())
            {
                try
                {
                    var info = new MCWhitelistPlayerInfo(
                        (string)Obj["name"], 
                        (string)Obj["uuid"]
                        );
                    WhitelistPlayers.Add(ID, info);
                    ID++;
                }
                catch { }
            }
        }
    }
}
