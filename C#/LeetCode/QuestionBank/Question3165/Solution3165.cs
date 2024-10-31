using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3165
{
    public class Solution3165 : Interface3165
    {
        /// <summary>
        /// DP
        /// 对于每一次查询，都执行一次DP，O(n^2)，大概率会TLE，但是直觉上下一次DP可以提前剪枝，所以先把这版写出来，然后再优化
        /// DP, 对于nums[0..N]的最大值是F(N)，那么F(N)，不用nums[N]的话是F(N-1)，用的话，是F(N-2)+MAX(nums[N],0)
        /// 
        /// 逻辑没问题，TLE，参考测试用例04
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
                foreach (int[] query in queries)
                {
                    Array.Fill(dp, 0);
                    nums[query[0]] = query[1];
                    dp[0] = Math.Max(0, nums[0]);
                    dp[1] = Math.Max(0, Math.Max(nums[0], nums[1]));
                    for (int i = 2; i < len; i++) dp[i] = Math.Max(dp[i - 1], dp[i - 2] + Math.Max(0, nums[i]));
                    result = (result + dp[^1]) % MOD;
                }
            }

            return (int)(result % MOD);
        }
    }
}
