using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0468
{
    public class Solution0468 : Interface0468
    {
        /// <summary>
        /// 一层一层过滤
        /// </summary>
        /// <param name="queryIP"></param>
        /// <returns></returns>
        public string ValidIPAddress(string queryIP)
        {
            int len = queryIP.Length;
            if (len > 39) return "Neither";
            switch ((queryIP.Contains('.'), queryIP.Contains(':')))
            {
                case (true, false): return ValidIPV4(queryIP);
                case (false, true): return ValidIPV6(queryIP);
                default: return "Neither";
            }

            static string ValidIPV4(string str)
            {
                string[] split = str.Split('.');
                if (split.Length != 4) return "Neither";
                foreach (string s in split)
                {
                    if (s == "0") continue;
                    if (s.Length == 0 || s[0] == '0' || s[0] == '-' || s.Length > 3) return "Neither";
                    if (!int.TryParse(s, out int v) || v > 255) return "Neither";
                }
                return "IPv4";
            }

            static string ValidIPV6(string str)
            {
                string[] split = str.Split(':');
                if (split.Length != 8) return "Neither";
                foreach (string s in split)
                {
                    if (s.Length == 0 || s[0] == '-' || s.Length > 4) return "Neither";
                    if (!int.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int v) || v > 65535) return "Neither";
                }
                return "IPv6";
            }
        }
    }
}
