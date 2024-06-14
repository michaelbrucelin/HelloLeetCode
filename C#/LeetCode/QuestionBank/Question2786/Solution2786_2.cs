using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2786
{
    public class Solution2786_2 : Interface2786
    {
        /// <summary>
        /// 逻辑与Solution2786一样，只是将其中的奇偶判断的if-else换成了位运算，可读性不好，写着玩的
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public long MaxScore(int[] nums, int x)
        {
            int len = nums.Length;
            long[,] dp = new long[len, 2];  // dp[,0] even, dp[,1] odd
            dp[0, nums[0] & 1] = nums[0]; dp[0, 1 - (nums[0] & 1)] = -1;
            for (int i = 1, j, num; i < len; i++)
            {
                num = nums[i]; j = num & 1;
                dp[i, j ^ 1] = dp[i - 1, j ^ 1];
                if (dp[i - 1, j] == -1)
                {
                    dp[i, j] = dp[i - 1, j ^ 1] + num - x;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j] + num, dp[i - 1, j ^ 1] + num - x);
                }
            }

            return Math.Max(dp[len - 1, 0], dp[len - 1, 1]);
        }

        /// <summary>
        /// 逻辑同MaxScore()，改为滚动数组优化空间复杂度
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public long MaxScore2(int[] nums, int x)
        {
            int len = nums.Length;
            long[] dp = new long[2];
            dp[nums[0] & 1] = nums[0]; dp[1 - (nums[0] & 1)] = -1;
            for (int i = 1, j, num; i < len; i++)
            {
                num = nums[i]; j = num & 1;
                if (dp[j] == -1)
                {
                    dp[j] = dp[j ^ 1] + num - x;
                }
                else
                {
                    dp[j] = Math.Max(dp[j] + num, dp[j ^ 1] + num - x);
                }
            }

            return Math.Max(dp[0], dp[1]);
        }
    }
}
