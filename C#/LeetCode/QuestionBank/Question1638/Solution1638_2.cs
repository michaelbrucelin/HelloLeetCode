using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1638
{
    public class Solution1638_2 : Interface1638
    {
        /// <summary>
        /// 贡献值
        /// 具体见Solution1638_2.md
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int CountSubstrings(string s, string t)
        {
            int result = 0, len1 = s.Length, len2 = t.Length;
            for (int i = 0, lcnt, rcnt; i < len1; i++) for (int j = 0; j < len2; j++)
                {
                    if (s[i] != t[j])
                    {
                        lcnt = 0; rcnt = 0;
                        for (int k = 1; k <= i && k <= j; k++) if (s[i - k] == t[j - k]) lcnt++; else break;
                        for (int k = 1; k < len1 - i && k < len2 - j; k++) if (s[i + k] == t[j + k]) rcnt++; else break;
                        result += (lcnt + 1) * (rcnt + 1);
                    }
                }

            return result;
        }
    }
}
