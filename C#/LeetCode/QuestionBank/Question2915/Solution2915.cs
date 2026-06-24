using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2915
{
    public class Solution2915 : Interface2915
    {
        /// <summary>
        /// DP
        /// 可以使用滚动数组的方式优化空间复杂度，这里就不做了
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int LengthOfLongestSubsequence(IList<int> nums, int target)
        {
            int len = nums.Count;
            int[,] dp = new int[len, target + 1];
            if (nums[0] <= target) dp[0, nums[0]] = 1;
            for (int i = 1, j, num; i < len; i++)
            {
                if ((num = nums[i]) > target)
                {
                    for (j = 1; j <= target; j++) dp[i, j] = dp[i - 1, j];
                }
                else
                {
                    for (j = 1; j < num; j++) dp[i, j] = dp[i - 1, j];
                    dp[i, num] = Math.Max(dp[i - 1, num], 1);
                    for (j = num + 1; j <= target; j++) dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - num] != 0 ? dp[i - 1, j - num] + 1 : 0);
                }
            }

            return dp[len - 1, target] != 0 ? dp[len - 1, target] : -1;
        }
    }
}
