using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1043
{
    public class Solution1043_2 : Interface1043
    {
        /// <summary>
        /// DP
        /// 1. dp[i]表示dp[0]到dp[i]的结果
        /// 2. dp[0] = arr[0]
        /// 3. dp[i]是下面k个值中的最大值
        ///     dp[i-1] + arr[i]
        ///     dp[i-2] + Max(arr[i-1], arr[i]) * 2
        ///     ... ...
        ///     dp[i-k] + Max(arr[i-k+1], ... arr[i]) * k
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxSumAfterPartitioning(int[] arr, int k)
        {
            int len = arr.Length;
            if (len <= k) return arr.Max() * len;

            int[] dp = new int[len];
            for (int i = 0; i < k; i++) dp[i] = arr[0..(i + 1)].Max() * (i + 1);
            for (int i = k; i < len; i++) for (int j = 0; j < k; j++)
                {
                    dp[i] = Math.Max(dp[i], dp[i - j - 1] + arr[(i - j)..(i + 1)].Max() * (j + 1));
                }

            return dp[len - 1];
        }

        /// <summary>
        /// DP
        /// 同MaxSumAfterPartitioning()，优化了求分段最大值的过程
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxSumAfterPartitioning2(int[] arr, int k)
        {
            int len = arr.Length;
            if (len <= k) return arr.Max() * len;

            int[] dp = new int[len];
            for (int i = 0, max = arr[0]; i < k; i++)
            {
                max = Math.Max(max, arr[i]);
                dp[i] = max * (i + 1);
            }
            for (int i = k; i < len; i++) for (int j = 0, max = arr[i]; j < k; j++)
                {
                    max = Math.Max(max, arr[i - j]);
                    dp[i] = Math.Max(dp[i], dp[i - j - 1] + max * (j + 1));
                }

            return dp[len - 1];
        }
    }
}
