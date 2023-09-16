using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0198
{
    public class Solution0198 : Interface0198
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            int len = nums.Length;
            int[,] dp = new int[len, 2];   // dp[i,0]，取nums[i]，dp[i,1]，不取nums[i]
            dp[0, 0] = nums[0];
            for (int i = 1; i < len; i++)
            {
                dp[i, 0] = dp[i - 1, 1] + nums[i];
                dp[i, 1] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
            }

            return Math.Max(dp[len - 1, 0], dp[len - 1, 1]);
        }

        /// <summary>
        /// DP
        /// 滚动数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob2(int[] nums)
        {
            int dp0 = nums[0], dp1 = 0;               // dp0，取nums[i]，dp1，不取nums[i]
            for (int i = 1, _; i < nums.Length; i++)
            {
                _ = dp0;
                dp0 = dp1 + nums[i];
                dp1 = Math.Max(_, dp1);
            }

            return Math.Max(dp0, dp1);
        }
    }
}
