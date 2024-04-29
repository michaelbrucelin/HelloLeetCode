using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0088
{
    public class Solution0088 : Interface0088
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length == 2) return Math.Min(cost[0], cost[1]);

            int len = cost.Length;
            int[] dp = new int[len]; dp[0] = cost[0]; dp[1] = cost[1];
            for (int i = 2; i < len; i++) dp[i] = cost[i] + Math.Min(dp[i - 2], dp[i - 1]);

            return Math.Min(dp[len - 2], dp[len - 1]);
        }

        /// <summary>
        /// DP，滚动数组
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs2(int[] cost)
        {
            if (cost.Length == 2) return Math.Min(cost[0], cost[1]);

            int len = cost.Length;
            int dp1 = cost[0], dp2 = cost[1];
            for (int i = 2; i < len; i++) (dp1, dp2) = (dp2, cost[i] + Math.Min(dp1, dp2));

            return Math.Min(dp1, dp2);
        }
    }
}
