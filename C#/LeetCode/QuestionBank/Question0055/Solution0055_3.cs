using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0055
{
    public class Solution0055_3 : Interface0055
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            if (nums.Length == 1) return true;

            int len = nums.Length;
            bool[] dp = new bool[len];
            dp[0] = true;
            for (int i = 0; i < len; i++) if (dp[i])
                {
                    if (i + nums[i] >= len - 1) return true;
                    Array.Fill(dp, true, i + 1, nums[i]);
                }

            return false;
        }
    }
}
