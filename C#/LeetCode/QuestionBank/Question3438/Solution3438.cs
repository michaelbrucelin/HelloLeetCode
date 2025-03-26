using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3438
{
    public class Solution3438 : Interface3438
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FindValidPair(string s)
        {
            int len = s.Length;
            int[] freq = new int[10];
            for (int i = 0; i < len; i++) freq[s[i] & 15]++;
            for (int i = 1; i < len; i++) if (s[i] != s[i - 1])
                {
                    if ((freq[s[i] & 15] == (s[i] & 15)) && (freq[s[i - 1] & 15] == (s[i - 1] & 15)))
                        return s[(i - 1)..(i + 1)];
                }

            return "";
        }
    }
}
