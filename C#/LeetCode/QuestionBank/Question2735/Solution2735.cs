using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2735
{
    public class Solution2735 : Interface2735
    {
        /// <summary>
        /// 枚举，DP
        /// 最少可以操作0次，最多可以操作n-1次，
        ///     移动k次的成本是每个位置可能的最小值的和 + x * k
        /// 可以依据移动的次数k来DP
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public long MinCost(int[] nums, int x)
        {
            long result = 0, _result; int len = nums.Length;
            int[] dp = new int[len];
            for (int i = 0; i < len; i++)
            {
                dp[i] = nums[i]; result += dp[i];
            }

            for (int k = 1; k < len; k++)  // 移动k轮
            {
                _result = 0;
                for (int i = 0, j; i < len; i++)
                {
                    j = i - k;
                    dp[i] = Math.Min(dp[i], nums[j < 0 ? j + len : j]);
                    _result += dp[i];
                }
                result = Math.Min(result, _result + ((long)x) * k);
            }

            return result;
        }
    }
}
