using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1262
{
    public class Solution1262_4 : Interface1262
    {
        /// <summary>
        /// DP
        /// 假定前n项，对3取余的最大和分别为Max0, Max1, Max2
        /// 那么对于第n+1项(Val)，考虑其对3的模mod：
        ///    mod = 0
        ///         Max0 = Max0 + Val
        ///         Max1 = Max1 + Val
        ///         Max2 = Max2 + Val
        ///    mod = 1
        ///         Max0 = Max(Max0, Max2+Val)
        ///         Max1 = Max(Max1, Max0+Val)
        ///         Max2 = Max(Max2, Max1+Val)
        ///    mod = 2
        ///         Max0 = Max(Max0, Max1+Val)
        ///         Max1 = Max(Max1, Max2+Val)
        ///         Max2 = Max(Max2, Max0+Val)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSumDivThree(int[] nums)
        {
            int[] dp = new int[3];
            for (int i = 0; i < nums.Length; i++)
            {
                int[] buffer = new int[3];
                if (nums[i] % 3 == 0)
                {
                    buffer[0] = dp[0] + nums[i];
                    buffer[1] = dp[1] > 0 ? dp[1] + nums[i] : 0;
                    buffer[2] = dp[2] > 0 ? dp[2] + nums[i] : 0;
                }
                else if (nums[i] % 3 == 1)
                {
                    buffer[0] = Math.Max(dp[0], dp[2] > 0 ? dp[2] + nums[i] : 0);
                    buffer[1] = Math.Max(dp[1], dp[0] > 0 ? dp[0] + nums[i] : nums[i]);
                    buffer[2] = Math.Max(dp[2], dp[1] > 0 ? dp[1] + nums[i] : 0);
                }
                else
                {
                    buffer[0] = Math.Max(dp[0], dp[1] > 0 ? dp[1] + nums[i] : 0);
                    buffer[1] = Math.Max(dp[1], dp[2] > 0 ? dp[2] + nums[i] : 0);
                    buffer[2] = Math.Max(dp[2], dp[0] > 0 ? dp[0] + nums[i] : nums[i]);
                }

                dp = buffer;
            }

            return dp[0];
        }

        /// <summary>
        /// 对上面的DP化简
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSumDivThree2(int[] nums)
        {
            int[] dp = [0, int.MinValue, int.MinValue], _dp = new int[3];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                    _dp[(nums[i] + j) % 3] = Math.Max(dp[(nums[i] + j) % 3], dp[j] + nums[i]);
                Array.Copy(_dp, dp, 3);
            }

            return dp[0];
        }
    }
}
