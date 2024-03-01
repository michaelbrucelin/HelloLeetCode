using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2369
{
    public class Solution2369_3 : Interface2369
    {
        /// <summary>
        /// DP
        /// 使用dp[n]表示nums[0..n]的结果，则dp[n+1]的结果可以由 dp[n-1] + nums[n..(n+1)] 或 dp[n-2] + nums[(n-1)..(n+1)] 得出
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ValidPartition(int[] nums)
        {
            int len = nums.Length;
            if (len < 2) return false; else if (len == 2) return nums[0] == nums[1];

            bool[] dp = new bool[len];
            dp[0] = false;
            dp[1] = nums[0] == nums[1];
            dp[2] = (nums[0] == nums[1] && nums[0] == nums[2]) || (nums[0] + 1 == nums[1] && nums[0] + 2 == nums[2]);
            for (int i = 3; i < len; i++)
            {
                if (dp[i - 2])
                {
                    if (nums[i - 1] == nums[i]) dp[i] = true;
                }
                if (!dp[i] && dp[i - 3])
                {
                    if (nums[i - 2] == nums[i] && nums[i - 1] == nums[i]) dp[i] = true;
                    else if (nums[i - 2] + 2 == nums[i] && nums[i - 1] + 1 == nums[i]) dp[i] = true;
                }
            }

            return dp[^1];
        }

        /// <summary>
        /// DP
        /// 逻辑同ValidPartition()，滚动数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ValidPartition2(int[] nums)
        {
            int len = nums.Length;
            if (len < 2) return false;

            bool[] dp = new bool[4];
            dp[0] = false;
            dp[1] = nums[0] == nums[1];
            if (len == 2) return dp[1];
            dp[2] = (nums[0] == nums[1] && nums[0] == nums[2]) || (nums[0] + 1 == nums[1] && nums[0] + 2 == nums[2]);
            if (len == 3) return dp[2];
            for (int i = 3; i < len; i++)
            {
                dp[3] = false;
                if (dp[1])
                {
                    if (nums[i - 1] == nums[i]) dp[3] = true;
                }
                if (!dp[3] && dp[0])
                {
                    if (nums[i - 2] == nums[i] && nums[i - 1] == nums[i]) dp[3] = true;
                    else if (nums[i - 2] + 2 == nums[i] && nums[i - 1] + 1 == nums[i]) dp[3] = true;
                }
                for (int j = 0; j < 3; j++) dp[j] = dp[j + 1];
            }

            return dp[3];
        }
    }
}
