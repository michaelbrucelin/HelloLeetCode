using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0091
{
    public class Solution0091 : Interface0091
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int MinCost(int[][] costs)
        {
            int len = costs.Length;

            int[,] dp = new int[len + 1, 3];
            for (int i = 0; i < len; i++)
            {
                dp[i + 1, 0] = Math.Min(dp[i, 1], dp[i, 2]) + costs[i][0];
                dp[i + 1, 1] = Math.Min(dp[i, 0], dp[i, 2]) + costs[i][1];
                dp[i + 1, 2] = Math.Min(dp[i, 0], dp[i, 1]) + costs[i][2];
            }

            return Math.Min(Math.Min(dp[len, 0], dp[len, 1]), dp[len, 2]);
        }
    }
}
