using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0053
{
    public class Solution0053 : Interface0053
    {
        /// <summary>
        /// DP
        /// 思路同官解中的DP方案
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int result = nums[0], len = nums.Length;
            int[] dp = new int[len]; dp[0] = nums[0];
            for (int i = 1; i < len; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
                result = Math.Max(result, dp[i]);
            }

            return result;
        }

        /// <summary>
        /// DP
        /// 同MaxSubArray()，滚动数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray2(int[] nums)
        {
            int result = nums[0], dp = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++)
            {
                dp = Math.Max(dp + nums[i], nums[i]);
                result = Math.Max(result, dp);
            }

            return result;
        }
    }
}
