using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3361
{
    public class Solution3361 : Interface3361
    {
        /// <summary>
        /// 模拟
        /// 使用前缀和优化
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="nextCost"></param>
        /// <param name="previousCost"></param>
        /// <returns></returns>
        public long ShiftDistance(string s, string t, int[] nextCost, int[] previousCost)
        {
            long[] nextSum = new long[27], prevSum = new long[27];
            for (int i = 0; i < 26; i++) { nextSum[i + 1] = nextSum[i] + nextCost[i]; prevSum[i + 1] = prevSum[i] + previousCost[i]; }

            long result = 0;
            for (int i = 0, l, r, len = s.Length; i < len; i++)
            {
                l = s[i] - 'a'; r = t[i] - 'a';
                switch (l - r)
                {
                    case < 0: result += Math.Min(nextSum[r] - nextSum[l], prevSum[l + 1] + prevSum[26] - prevSum[r + 1]); break;
                    case > 0: result += Math.Min(nextSum[26] - nextSum[l] + nextSum[r], prevSum[l + 1] - prevSum[r + 1]); break;
                    default: break;
                }
            }

            return result;
        }
    }
}
