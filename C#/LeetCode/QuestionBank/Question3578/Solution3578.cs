using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3578
{
    public class Solution3578 : Interface3578
    {
        /// <summary>
        /// DP
        /// F(N)表示以N结尾的方案数，那么F(N+1)=F(N)+F(N-1)+...+F(X)，nums[X-1]是第一个使nums[X-1..N+1]的差值大于k的元素
        /// 如果元素全部为1，时间复杂度会达到O(n^2)
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountPartitions(int[] nums, int k)
        {
            int len = nums.Length;
            const int MOD = (int)1e9 + 7;
            int[] dp = new int[len];
            dp[0] = 1;
            for (int i = 1, min, max; i < len; i++)
            {
                dp[i] = dp[i - 1];
                min = max = nums[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    min = Math.Min(min, nums[j]);
                    max = Math.Max(max, nums[j]);
                    if (max - min > k) break;
                    dp[i] = (dp[i] + (j > 0 ? dp[j - 1] : 1)) % MOD;
                }
            }

            return dp[len - 1];
        }
    }
}
