using System;
using System.Collections.Generic;
using System.Linq;

namespace MCServerLib
{
    public class MCServerStartOption
    {
        /// <summary>
        /// 서버를 실행할 자바 경로 (예 : %ProgramFiles%\Java\jre1.8.0_261)
        /// </summary>
        public string JavaPath;

        /// <summary>
        /// 서버 JAR 파일 이름 또는 경로 (예 : craftbukkit.jar)
        /// </summary>
        public string JarPath;

        /// <summary>
        /// 서버 코어의 자체 GUI 사용 안함 여부, true로 설정할 경우 GUI가 나오지 않습니다.
        /// <para>참고 : 서버 코어가 자체 GUI를 지원하지 않을 경우는 <see cref="NoWindow"/>를 대신 설정하십시오.</para>
        /// </summary>
        public bool NoGUI = false;

        /// <summary>
        /// 서버 코어가 자체 GUI를 지원하지 않을 경우에 <see cref="NoGUI"/> 대신 이를 true로 설정하십시오.
        /// <para>참고 : true로 설정할 경우 <see cref="NoGUI"/> 설정은 무시됩니다.</para>
        /// </summary>
        public bool NoWindow = false;

        /// <summary>
        /// 체험판 사용 여부, true로 설정할 경우 서버에 접속하는 모든 플레이어는 데모 메시지를 보게됩니다.
        /// </summary>
        public bool Demo = false;

        /// <summary>
        /// 서버 최대 메모리 용량
        /// </summary>
        public int MaxMemory = 1024;

        /// <summary>
        /// 서버 최소 메모리 용량
        /// </summary>
        public int MinMemory = 256;

        /// <summary>
        /// 최소/최대 메모리 용량에서 기가바이트 단위를 사용합니다. (M -> G)
        /// </summary>
        public bool MemoryGB = false;
    }
}
