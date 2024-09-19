using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2414
{
    public class Solution2414 : Interface2414
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestContinuousSubstring(string s)
        {
            int result = 1, dp = 1, len = s.Length;
            for (int i = 1; i < len; i++)
            {
                if (s[i] - s[i - 1] == 1)
                {
                    dp++;
                    result = Math.Max(result, dp);
                    if (result == 26) break;
                }
                else
                {
                    dp = 1;
                }
            }

            return result;
        }
    }
}
