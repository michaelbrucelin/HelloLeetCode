using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0089
{
    public class Solution0089 : Interface0089
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            int len = nums.Length;
            int[,] dp = new int[len, 2];
            dp[0, 0] = 0; dp[0, 1] = nums[0];
            for (int i = 1; i < len; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
                dp[i, 1] = dp[i - 1, 0] + nums[i];
            }

            return Math.Max(dp[len - 1, 0], dp[len - 1, 1]);
        }

        /// <summary>
        /// 逻辑与Rob()完全相同，改为滚动数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob2(int[] nums)
        {
            int len = nums.Length, dp0 = 0, dp1 = nums[0];
            for (int i = 1; i < len; i++) (dp0, dp1) = (Math.Max(dp0, dp1), dp0 + nums[i]);

            return Math.Max(dp0, dp1);
        }
    }
}
