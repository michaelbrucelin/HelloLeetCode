using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1309
{
    public class Solution1309 : Interface1309
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FreqAlphabets(string s)
        {
            StringBuilder sb = new StringBuilder();
            int p = 0, len = s.Length;
            while (p < len)
            {
                if (p + 2 < len && s[p + 2] == '#')
                {
                    sb.Append((char)('a' - 1 + 10 * (s[p] - '0') + 1 * (s[p + 1] - '0')));
                    p += 3;
                }
                else
                {
                    sb.Append((char)('a' - 1 + 1 * (s[p] - '0')));
                    p++;
                }
            }

            return sb.ToString();
        }
    }
}
