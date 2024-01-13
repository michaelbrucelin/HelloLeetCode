using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2182
{
    public class Solution2182 : Interface2182
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <param name="repeatLimit"></param>
        /// <returns></returns>
        public string RepeatLimitedString(string s, int repeatLimit)
        {
            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++) freq[s[i] - 'a']++;

            StringBuilder result = new StringBuilder();
            int p1 = 25, p2 = 25;
            while (p1 >= 0)
            {
                while (p1 >= 0 && freq[p1] == 0) p1--;
                if (p1 == -1) break;

                if (freq[p1] <= repeatLimit)
                {
                    result.Append(new string((char)('a' + p1), freq[p1]));
                    p1--;
                }
                else
                {
                    result.Append(new string((char)('a' + p1), repeatLimit));
                    freq[p1] -= repeatLimit;

                    if (p2 >= p1) p2 = p1 - 1;
                    while (p2 >= 0 && freq[p2] == 0) p2--;
                    if (p2 == -1) break;

                    result.Append((char)('a' + p2));
                    freq[p2]--;
                }
            }

            return result.ToString();
        }
    }
}
