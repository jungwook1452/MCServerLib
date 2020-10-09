using System;

namespace MCServerLib
{
    /// <summary>
    /// 플레이어 정보입니다.
    /// </summary>
    public class MCPlayerInfo
    {
        /// <summary>
        /// 플레이어 닉네임
        /// </summary>
        public string Name { protected set; get; }

        /// <summary>
        /// 플레이어 식별번호 (UUID)
        /// </summary>
        public string UUID { protected set; get; }
    }

    /// <summary>
    /// 관리자(OP) 플레이어 정보입니다.
    /// </summary>
    public class MCOpPlayerInfo : MCPlayerInfo
    {
        /// <summary>
        /// 관리자 권한 레벨
        /// </summary>
        public int OPLevel { private set; get; }

        /// <summary>
        /// true로 설정하면 해당 관리자는 서버 인원 수가 꽉 차더라도 접속할 수 있습니다.
        /// </summary>
        public bool OPBypassesPlayerLimit { private set; get; }

        public MCOpPlayerInfo(string name, string uuid, int level, bool bypassesPlayerLimit)
        {
            Name = name;
            UUID = uuid;
            OPLevel = level;
            OPBypassesPlayerLimit = bypassesPlayerLimit;
        }
    }

    /// <summary>
    /// 밴 플레이어 정보입니다.
    /// </summary>
    public class MCBanPlayerInfo : MCPlayerInfo
    {
        /// <summary>
        /// 밴 날짜
        /// </summary>
        public DateTime BanDateTime { private set; get; }

        /// <summary>
        /// 밴을 시킨 플레이어 닉네임 (서버 콘솔로 제재할 경우 Server)
        /// </summary>
        public string BanSource { private set; get; }

        /// <summary>
        /// 밴 차단 유효 기간 (영구적인 경우 forever)
        /// </summary>
        public string BanExpires { private set; get; }

        /// <summary>
        /// 밴 사유
        /// </summary>
        public string BanReason { private set; get; }

        public MCBanPlayerInfo(string name, string uuid, string dateTime, string source, string expires, string reason)
        {
            Name = name;
            UUID = uuid;
            BanDateTime = DateTime.Parse(dateTime);
            BanSource = source;
            BanExpires = expires;
            BanReason = reason;
        }
    }

    /// <summary>
    /// 아이피 차단 정보입니다.
    /// </summary>
    public class MCBanIPInfo
    {
        /// <summary>
        /// 차단된 아이피 주소
        /// </summary>
        public string BanIP { private set; get; }
        /// <summary>
        /// 아이피 차단 날짜
        /// </summary>
        public DateTime BanDateTime { private set; get; }
        /// <summary>
        /// 아이피 차단을 시킨 플레이어 닉네임 (서버 콘솔로 제재할 경우 Server)
        /// </summary>
        public string BanSource { private set; get; }
        /// <summary>
        /// 아이피 차단 유효 기간 (영구적인 경우 forever)
        /// </summary>
        public string BanExpires { private set; get; }
        /// <summary>
        /// 아이피 차단 사유
        /// </summary>
        public string BanReason { private set; get; }

        public MCBanIPInfo(string IP, string dateTime, string source, string expires, string reason)
        {
            BanIP = IP;
            BanDateTime = DateTime.Parse(dateTime);
            BanSource = source;
            BanExpires = expires;
            BanReason = reason;
        }
    }

    /// <summary>
    /// 화이트리스트 플레이어 정보입니다.
    /// </summary>
    public class MCWhitelistPlayerInfo
    {
        /// <summary>
        /// 플레이어 닉네임
        /// </summary>
        public string Name { private set; get; }
        /// <summary>
        /// 플레이어 식별번호 (UUID)
        /// </summary>
        public string UUID { private set; get; }

        public MCWhitelistPlayerInfo(string name, string uuid)
        {
            Name = name;
            UUID = uuid;
        }
    }
}