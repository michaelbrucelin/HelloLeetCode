using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2770
{
    public class Solution2770_2 : Interface2770
    {
        /// <summary>
        /// DP
        /// 底层逻辑与Solution2770一致
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MaximumJumps(int[] nums, int target)
        {
            if (nums.Length < 2) return 0;

            int len = nums.Length;
            int[] dp = new int[len];
            Array.Fill(dp, -1);
            dp[0] = 0;
            for (int i = 1; i < len; i++) for (int j = i - 1; j >= 0; j--)
                {
                    if (dp[j] != -1 && Math.Abs(nums[i] - nums[j]) <= target) dp[i] = Math.Max(dp[i], dp[j] + 1);
                }

            return dp[len - 1];
        }
    }
}
