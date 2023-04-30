using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1664
{
    public class Solution1664_3 : Interface1664
    {
        public int WaysToMakeFair(int[] nums)
        {
            int len = nums.Length;
            if (len == 1) return 1; else if (len == 2) return 0;

            int[] dp = new int[len + 1];
            for (int i = 0; i < len; i++) dp[i + 1] = dp[i] + ((i & 1) == 1 ? -nums[i] : nums[i]);

            int result = 0;
            for (int i = 1; i <= len; i++) if (dp[i - 1] == dp[len] - dp[i]) result++;

            return result;
        }

        /// <summary>
        /// 与WaysToMakeFair()逻辑一样，使用滚动数组优化空间复杂度
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int WaysToMakeFair2(int[] nums)
        {
            int len = nums.Length;
            if (len == 1) return 1; else if (len == 2) return 0;

            int total = 0;
            for (int i = 0; i < len; i++) total += ((i & 1) == 1 ? -nums[i] : nums[i]);

            int result = 0, dp = 0;
            for (int i = 0; i < len; i++)
            {
                int _dp = dp + ((i & 1) == 1 ? -nums[i] : nums[i]);
                if (dp == total - _dp) result++;
                dp = _dp;
            }

            return result;
        }
    }
}
