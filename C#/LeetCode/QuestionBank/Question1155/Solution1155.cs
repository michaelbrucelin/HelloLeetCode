using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1155
{
    public class Solution1155 : Interface1155
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int NumRollsToTarget(int n, int k, int target)
        {
            if (target < n || target > n * k) return 0;

            const int MOD = 1000000007;
            int[,] dp = new int[n + 1, target + 1];
            for (int t = 0; t <= target; t++) dp[0, t] = 1;
            for (int i = 1, min_t = 0, max_t = 0; i <= n; i++)                                                // 掷第i个骰子，还余n-i个骰子，余下骰子范围是[n-i,k*(n-i)]
            {
                min_t = Math.Max(0, target - k * (n - i)); max_t = Math.Max(0, target - (n - i));     // 掷完第i个骰子后应该达到的范围
                for (int t = min_t, cnt = 0, min_j = 0, max_j = 0; t <= max_t; t++)
                {
                    cnt = 0; min_j = Math.Max(1, t - k * (i - 1)); max_j = Math.Min(k, t - (i - 1));  // 第i个骰子的可掷范围
                    for (int j = min_j; j <= max_j; j++)
                    {
                        cnt = (cnt + dp[i - 1, t - j]) % MOD;
                    }
                    dp[i, t] = cnt;
                }
            }

            return dp[n, target];
        }

        /// <summary>
        /// DP
        /// 滚动数组
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int NumRollsToTarget2(int n, int k, int target)
        {
            if (target < n || target > n * k) return 0;

            const int MOD = 1000000007;
            int[] dp = new int[target + 1], _dp = new int[target + 1];
            Array.Fill(dp, 1);
            for (int i = 1, min_t = 0, max_t = 0; i <= n; i++)                                                // 掷第i个骰子，还余n-i个骰子，余下骰子范围是[n-i,k*(n-i)]
            {
                min_t = Math.Max(0, target - k * (n - i)); max_t = Math.Max(0, target - (n - i));     // 掷完第i个骰子后应该达到的范围
                for (int t = min_t, cnt = 0, min_j = 0, max_j = 0; t <= max_t; t++)
                {
                    cnt = 0; min_j = Math.Max(1, t - k * (i - 1)); max_j = Math.Min(k, t - (i - 1));  // 第i个骰子的可掷范围
                    for (int j = min_j; j <= max_j; j++)
                    {
                        cnt = (cnt + dp[t - j]) % MOD;
                    }
                    _dp[t] = cnt;
                }
                Array.Copy(_dp, dp, target + 1);
            }

            return dp[target];
        }
    }
}
