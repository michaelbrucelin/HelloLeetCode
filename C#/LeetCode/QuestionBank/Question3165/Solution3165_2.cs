using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3165
{
    public class Solution3165_2 : Interface3165
    {
        /// <summary>
        /// 逻辑与Solution3165完全一样，做了如下优化
        /// 如果下一轮查询，改变的值，改之前与改之后都小于0，或相等，这一轮的最大值不变
        /// 否则，如果更改的元素位置是x，那么
        ///     x之前不需要重新dp
        ///     x之后如果出现小于等于0的值，那么后面也不需要dp了，因为一定不相邻，所以后面值与上一轮dp的值的差不变
        ///         这一点代码中没有实现，没有太大的意义
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int MaximumSumSubsequence(int[] nums, int[][] queries)
        {
            const int MOD = (int)1e9 + 7;
            long result = 0; int len = nums.Length;

            if (len == 1)
            {
                foreach (int[] query in queries) if (query[1] > 0) result += query[1];
            }
            else if (len == 2)
            {
                foreach (int[] query in queries)
                {
                    nums[query[0]] = query[1];
                    result += Math.Max(0, Math.Max(nums[0], nums[1]));
                }
            }
            else
            {
                long[] dp = new long[len];
                dp[0] = Math.Max(0, nums[0]);
                dp[1] = Math.Max(0, Math.Max(nums[0], nums[1]));
                for (int i = 2; i < len; i++) dp[i] = Math.Max(dp[i - 1], dp[i - 2] + Math.Max(0, nums[i]));
                foreach (int[] query in queries)
                {
                    if ((nums[query[0]] > 0 || query[1] > 0) && nums[query[0]] != query[1])
                    {
                        // Array.Fill(dp, 0);
                        nums[query[0]] = query[1];
                        if (query[0] < 2)
                        {
                            dp[0] = Math.Max(0, nums[0]);
                            dp[1] = Math.Max(0, Math.Max(nums[0], nums[1]));
                        }
                        for (int i = Math.Max(2, query[0]); i < len; i++) dp[i] = Math.Max(dp[i - 1], dp[i - 2] + Math.Max(0, nums[i]));
                    }
                    result = (result + dp[^1]) % MOD;
                }
            }

            return (int)(result % MOD);
        }
    }
}
