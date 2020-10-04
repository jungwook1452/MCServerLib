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
        public string OPJsonFileName { private set; get; }
        public string BanJsonFileName { private set; get; }
        public string BanIPJsonFileName { private set; get; }
        public string WhitelistFileName { private set; get; }

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
        /// <para>참고 : LoadAll 메서드가 자동으로 호출됩니다.</para>
        /// </summary>
        /// <param name="ServerPath">서버 파일이 있는 경로</param>
        public MCServerJson(string ServerPath)
        {
            OPJsonFileName = Path.Combine(ServerPath, "ops.json");
            BanJsonFileName = Path.Combine(ServerPath, "banned-players.json");
            BanIPJsonFileName = Path.Combine(ServerPath, "banned-ips.json");
            WhitelistFileName = Path.Combine(ServerPath, "whitelist.json");

            if (!File.Exists(OPJsonFileName))
                File.WriteAllBytes(OPJsonFileName, Properties.Resources.EmptyServerJson);
            if (!File.Exists(BanJsonFileName))
                File.WriteAllBytes(BanJsonFileName, Properties.Resources.EmptyServerJson);
            if (!File.Exists(BanIPJsonFileName))
                File.WriteAllBytes(BanIPJsonFileName, Properties.Resources.EmptyServerJson);
            if (!File.Exists(WhitelistFileName))
                File.WriteAllBytes(WhitelistFileName, Properties.Resources.EmptyServerJson);

            Ops = new Dictionary<int, MCOpPlayerInfo>();
            BanPlayers = new Dictionary<int, MCBanPlayerInfo>();
            BanIPs = new Dictionary<int, MCBanIPInfo>();
            WhitelistPlayers = new Dictionary<int, MCWhitelistPlayerInfo>();

            LoadAll();
        }

        /// <summary>
        /// 서버의 오피, 밴/아이피 차단, 화이트리스트 정보를 가져옵니다.
        /// </summary>
        public void LoadAll()
        {
            LoadOps();
            LoadBanPlayers();
            LoadBanIPs();
            LoadWhitelistPlayers();
        }

        /// <summary>
        /// ops.json를 로드하여 <see cref="Ops"/>의 구성요소들을 업데이트합니다.
        /// </summary>
        public void LoadOps()
        {
            if (!File.Exists(OPJsonFileName))
                return;

            OPJsonObj = JArray.Parse(File.ReadAllText(OPJsonFileName));

            Ops.Clear();

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
                }
                catch { }
            }
        }

        /// <summary>
        /// banned-players.json를 로드하여 <see cref="BanPlayers"/>의 구성요소들을 업데이트합니다.
        /// </summary>
        public void LoadBanPlayers()
        {
            if (!File.Exists(BanJsonFileName))
                return;

            BanJsonObj = JArray.Parse(File.ReadAllText(BanJsonFileName));

            BanPlayers.Clear();

            int ID = 0;

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
        }

        /// <summary>
        /// banned-ips.json를 로드하여 <see cref="BanIPs"/>의 구성요소들을 업데이트합니다.
        /// </summary>
        public void LoadBanIPs()
        {
            if (!File.Exists(BanIPJsonFileName))
                return;

            BanIPJsonObj = JArray.Parse(File.ReadAllText(BanIPJsonFileName));

            BanIPs.Clear();

            int ID = 0;

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
        }

        /// <summary>
        /// whitelist.json를 로드하여 <see cref="WhitelistPlayers"/>의 구성요소들을 업데이트합니다.
        /// </summary>
        public void LoadWhitelistPlayers()
        {
            if (!File.Exists(WhitelistFileName))
                return;

            WhitelistJsonObj = JArray.Parse(File.ReadAllText(WhitelistFileName));

            WhitelistPlayers.Clear();

            int ID = 0;

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
