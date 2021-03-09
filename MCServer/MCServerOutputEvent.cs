using System;

namespace MCServerLib
{
    public delegate void MCServerOutputEventHandler(object sender, MCServerOutputEventArgs e);

    public class MCServerOutputEventArgs : EventArgs
    {
        /// <summary>
        /// 로그 내용 (예: [XX:XX:XX INFO] Test)
        /// </summary>
        public string TextOutput { private set; get; }

        /// <summary>
        /// 로그 출력 시간
        /// </summary>
        public DateTime OutputTime { private set; get; }

        public MCServerOutputEventArgs(string Data)
        {
            TextOutput = Data;
            OutputTime = DateTime.Now;
        }
    }
}