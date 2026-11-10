using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3693
{
    public class Solution3693 : Interface3693
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="n"></param>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int ClimbStairs(int n, int[] costs)
        {
            if (n == 1) return costs[0] + 1;
            if (n == 2) return costs[1] + Math.Min(costs[0] + 2, 4);

            int[] dp = new int[n + 1];
            dp[1] = costs[0] + 1;
            dp[2] = costs[1] + Math.Min(dp[1] + 1, 4);
            for (int i = 3; i <= n; i++)
            {
                dp[i] = costs[i - 1] + Math.Min(Math.Min(dp[i - 1] + 1, dp[i - 2] + 4), dp[i - 3] + 9);
            }

            return dp[n];
        }
    }
}
