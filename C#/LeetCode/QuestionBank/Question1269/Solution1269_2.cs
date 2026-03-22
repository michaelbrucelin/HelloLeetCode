using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1269
{
    public class Solution1269_2 : Interface1269
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution1269，改为DP
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="arrLen"></param>
        /// <returns></returns>
        public int NumWays(int steps, int arrLen)
        {
            const int MOD = (int)1e9 + 7;
            int limit = Math.Min(steps >> 1, arrLen - 1);  // 最远走到limit位置，含limit
            int[,] dp = new int[steps + 1, limit + 1];
            dp[0, 0] = 1;
            for (int step = 1; step <= steps; step++) for (int pos = 0; pos <= limit; pos++)
                {
                    dp[step, pos] = (dp[step, pos] + dp[step - 1, pos]) % MOD;
                    if (pos - 1 >= 0) dp[step, pos] = (dp[step, pos] + dp[step - 1, pos - 1]) % MOD;
                    if (pos + 1 <= limit) dp[step, pos] = (dp[step, pos] + dp[step - 1, pos + 1]) % MOD;
                }

            return dp[steps, 0];
        }

        /// <summary>
        /// 逻辑同NumWays()，改为滚动数组
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="arrLen"></param>
        /// <returns></returns>
        public int NumWays2(int steps, int arrLen)
        {
            const int MOD = (int)1e9 + 7;
            int limit = Math.Min(steps >> 1, arrLen - 1);  // 最远走到limit位置，含limit
            int[] dp = new int[limit + 1], _dp = new int[limit + 1];
            dp[0] = 1;
            for (int step = 1; step <= steps; step++)
            {
                Array.Fill(_dp, 0);
                for (int pos = 0; pos <= limit; pos++)
                {
                    _dp[pos] = (_dp[pos] + dp[pos]) % MOD;
                    if (pos - 1 >= 0) _dp[pos] = (_dp[pos] + dp[pos - 1]) % MOD;
                    if (pos + 1 <= limit) _dp[pos] = (_dp[pos] + dp[pos + 1]) % MOD;
                }
                Array.Copy(_dp, dp, dp.Length);
            }

            return dp[0];
        }
    }
}
