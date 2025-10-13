using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3186
{
    public class Solution3186 : Interface3186
    {
        /// <summary>
        /// DP
        /// 可以使用滚动数组优化空间复杂度，这里就不做这个优化了
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public long MaximumTotalDamage(int[] power)
        {
            int len = power.Length;
            Array.Sort(power);
            List<long[]> freq = [[power[0], power[0]]];
            for (int i = 1; i < len; i++) if (power[i] == freq[^1][0]) freq[^1][1] += power[i]; else freq.Add([power[i], power[i]]);
            len = freq.Count;

            long[] dp = new long[len];
            dp[0] = freq[0][1];
            for (int i = 1; i < len; i++)
            {
                dp[i] = Math.Max(dp[i - 1], freq[i][1]);
                for (int j = 1; j < 4; j++) if (i - j >= 0 && freq[i][0] > freq[i - j][0] + 2)
                    {
                        dp[i] = Math.Max(dp[i], dp[i - j] + freq[i][1]); break;
                    }
            }

            return dp[^1];
        }
    }
}
