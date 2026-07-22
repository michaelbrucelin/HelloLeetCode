using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3976
{
    public class Solution3976_err : Interface3976
    {
        /// <summary>
        /// DP + 分类讨论
        /// dp找出nums中和最大的子数组的和是sum，如果sum>=0，结果是sum*k，否则是sum/k
        /// 
        /// 思路有误，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxSubarraySum(int[] nums, int k)
        {
            int len = nums.Length;
            long[] dp = new long[len];
            dp[0] = nums[0];
            for (int i = 1; i < len; i++) dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);

            long result = dp[0];
            for (int i = 1; i < len; i++) result = Math.Max(result, dp[i]);
            return result >= 0 ? result * k : result / k;
        }
    }
}
