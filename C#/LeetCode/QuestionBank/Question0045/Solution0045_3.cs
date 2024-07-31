using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0045
{
    public class Solution0045_3 : Interface0045
    {
        /// <summary>
        /// DP
        /// 将Solution0045_2 1:1翻译为DP
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int len = nums.Length;
            int[] dp = new int[len];
            Array.Fill(dp, len + 1); dp[^1] = 0;
            for (int i = len - 2, step; i >= 0; i--)
            {
                step = len + 1;
                for (int j = Math.Min(len - 1, i + nums[i]); j >= i + 1; j--)
                    if ((step = Math.Min(step, dp[j])) == 0) break;
                dp[i] = step + 1;
            }

            return dp[0];
        }
    }
}
