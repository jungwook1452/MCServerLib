using System;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace MCServerLib
{
    /// <summary>
    /// MCServerLib 내부 클래스입니다. 이 클래스는 외부 어셈블리에서 접근할 수 없습니다.
    /// </summary>
    internal class MCServerInternal
    {
        /// <summary>
        /// 숫자 문자열을 32비트 부호 있는 정수로 변환합니다.
        /// </summary>
        /// <param name="number">변환할 숫자 문자열</param>
        /// <param name="default">변환 실패 시 대체할 정수값</param>
        /// <returns></returns>
        internal static int StringToInt(string number, int @default = 0)
        {
            int result;

            if (int.TryParse(number, out result))
            {
                return result;
            }
            return @default;
        }

        /// <summary>
        /// 논리값이나 bool 문자열을 bool으로 변환합니다.
        /// </summary>
        /// <param name="boolTxt">변환할 논리값 또는 bool 문자열</param>
        /// <param name="default">변환 실패 시 대체할 bool 값</param>
        /// <returns></returns>
        internal static bool StringToBool(string boolTxt, bool @default = false)
        {
            bool result;

            if (bool.TryParse(boolTxt, out result))
            {
                return result;
            }
            return @default;
        }

        /// <summary>
        /// 컴퓨터에 설치된 Java를 확인하고 Java 설치 경로를 가져옵니다.
        /// </summary>
        /// <returns>설치된 자바 경로, 자바가 설치되어 있지 않다면 null 입니다.</returns>
        internal static string GetJavaInstallPath()
        {
            string JavaHome = null;

            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey key = hklm.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment", false))
                {
                    if (key == null)
                    {
                        return null;
                    }

                    foreach (string Subkey in key.GetSubKeyNames())
                    {
                        using (RegistryKey key2 = key.OpenSubKey(Subkey, false))
                        {
                            JavaHome = (string)key2.GetValue("JavaHome");
                            if (JavaHome != null)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return JavaHome;
        }

        internal static string GetLogInfoSplit(string query)
        {
            if (query == null)
                return null;

            var matches = Regex.Matches(query, @"\[(.*?)\]");

            foreach (Match m in matches)
            {
                return m.Groups[0].ToString();
            }

            return null;
        }

        internal static string GetLogInfoNoOutput(string output)
        {
            string Loginfo = GetLogInfoSplit(output);

            if (Loginfo != null)
            {
                string Result = output.Replace(string.Format("{0}: ", Loginfo), "");

                if (Result == output)
                    Result = output.Replace(string.Format("{0} ", Loginfo), "");
                if (Result == output)
                    Result = output.Replace(string.Format("{0}", Loginfo), "");

                return Result;
            }
            return null;
        }
    }
}
