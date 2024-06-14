using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2786
{
    public class Solution2786 : Interface2786
    {
        /// <summary>
        /// DP
        /// 令F(n)记录数组截至为arr[n]时，最后选择偶数的最大值与奇数的最大值，这样，F(n+1)就可以由F(n)得到结果
        /// 注意数组的第一个元素必选
        /// 例如：nums = [2,3,6,1,9,2], x = 5
        ///         数组：2  3  6  1  9  2
        /// 最后选择偶数：0  2  8  8  8  10
        /// 最后选择奇数：_  0  0  4  13 13
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public long MaxScore(int[] nums, int x)
        {
            int len = nums.Length;
            long[,] dp = new long[len, 2];  // dp[,0] even, dp[,1] odd
            if (int.IsEvenInteger(nums[0]))
            {
                dp[0, 0] = nums[0]; dp[0, 1] = -1;
            }
            else
            {
                dp[0, 0] = -1; dp[0, 1] = nums[0];
            }

            for (int i = 1, num; i < len; i++)
            {
                num = nums[i];
                if (int.IsEvenInteger(num))
                {
                    dp[i, 1] = dp[i - 1, 1];
                    if (dp[i - 1, 0] == -1)
                    {
                        dp[i, 0] = dp[i - 1, 1] + num - x;
                    }
                    else
                    {
                        dp[i, 0] = Math.Max(dp[i - 1, 0] + num, dp[i - 1, 1] + num - x);
                    }
                }
                else
                {
                    dp[i, 0] = dp[i - 1, 0];
                    if (dp[i - 1, 1] == -1)
                    {
                        dp[i, 1] = dp[i - 1, 0] + num - x;
                    }
                    else
                    {
                        dp[i, 1] = Math.Max(dp[i - 1, 1] + num, dp[i - 1, 0] + num - x);
                    }
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
            long dp_even, dp_odd;
            if (int.IsEvenInteger(nums[0]))
            {
                dp_even = nums[0]; dp_odd = -1;
            }
            else
            {
                dp_even = -1; dp_odd = nums[0];
            }

            for (int i = 1, num; i < len; i++)
            {
                num = nums[i];
                if (int.IsEvenInteger(num))
                {
                    if (dp_even == -1)
                    {
                        dp_even = dp_odd + num - x;
                    }
                    else
                    {
                        dp_even = Math.Max(dp_even + num, dp_odd + num - x);
                    }
                }
                else
                {
                    if (dp_odd == -1)
                    {
                        dp_odd = dp_even + num - x;
                    }
                    else
                    {
                        dp_odd = Math.Max(dp_odd + num, dp_even + num - x);
                    }
                }
            }

            return Math.Max(dp_even, dp_odd);
        }
    }
}
