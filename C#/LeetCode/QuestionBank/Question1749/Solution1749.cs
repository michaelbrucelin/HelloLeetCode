using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1749
{
    public class Solution1749 : Interface1749
    {
        /// <summary>
        /// DP
        /// 具体见Solution1749.md
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxAbsoluteSum(int[] nums)
        {
            int len = nums.Length;
            int[,] dp = new int[len + 1, 2];
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (num > 0)
                {
                    dp[i + 1, 0] = dp[i, 0] + num; dp[i + 1, 1] = Math.Min(dp[i, 1] + num, 0);
                }
                else if (num < 0)
                {
                    dp[i + 1, 0] = Math.Max(dp[i, 0] + num, 0); dp[i + 1, 1] = dp[i, 1] + num;
                }
                else  // if (num == 0)
                {
                    dp[i + 1, 0] = dp[i, 0]; dp[i + 1, 1] = dp[i, 1];
                }
            }

            int result = 0;
            for (int i = 1; i <= len; i++) result = Math.Max(result, dp[i, 0]);
            for (int i = 1; i <= len; i++) result = Math.Max(result, -dp[i, 1]);

            return result;
        }

        /// <summary>
        /// DP
        /// 滚动数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxAbsoluteSum2(int[] nums)
        {
            int result = 0, positive = 0, negative = 0, len = nums.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (num > 0)
                {
                    positive += num; negative = Math.Min(negative + num, 0);
                    result = Math.Max(result, positive);
                }
                else if (num < 0)
                {
                    positive = Math.Max(positive + num, 0); negative += num;
                    result = Math.Max(result, -negative);
                }
            }

            return result;
        }
    }
}
