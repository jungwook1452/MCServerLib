using System;

namespace MCServerLib
{
    public delegate void MCServerOutputEventHandler(object sender, MCServerOutputEventArgs e);

    public class MCServerOutputEventArgs : EventArgs
    {
        private object _lockObj = new object();
        private object _lockObj2 = new object();

        private string _LogInfoNoOutput;
        private string _LogInfo;

        /// <summary>
        /// 로그 전체 내용 (예: [XX:XX:XX INFO] Test)
        /// </summary>
        public string LogOutput { private set; get; }

        /// <summary>
        /// 로그 전체 내용에서 로그 정보를 뺀 내용 (예: [XX:XX:XX INFO] Test -> Test)
        /// </summary>
        public string LogInfoNoOutput
        {
            get
            {
                if (_LogInfoNoOutput == null && _LogInfo != null)
                {
                    lock (_lockObj)
                    {
                        if (_LogInfoNoOutput == null && _LogInfo != null)
                        {
                            _LogInfoNoOutput = MCServerInternal.GetLogInfoNoOutput(LogOutput);
                        }
                    }
                }
                return _LogInfoNoOutput;
            }
        }

        /// <summary>
        /// 로그 정보 (예: [XX:XX:XX INFO])
        /// </summary>
        public string LogInfo
        {
            get
            {
                if (_LogInfo == null)
                {
                    lock (_lockObj2)
                    {
                        if (_LogInfo == null)
                            _LogInfo = MCServerInternal.GetLogInfoSplit(LogOutput);
                    }
                }
                return _LogInfo;
            }
        }

        /// <summary>
        /// 로그 출력 시간
        /// </summary>
        public DateTime OutputTime { private set; get; }

        public MCServerOutputEventArgs(string Data)
        {
            LogOutput = Data;
            OutputTime = DateTime.Now;
        }
    }
}