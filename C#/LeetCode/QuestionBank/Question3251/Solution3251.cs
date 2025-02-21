using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3251
{
    public class Solution3251 : Interface3251
    {
        /// <summary>
        /// DP + 前缀和
        /// 思路过程见Solution3250 - Solution3250_7
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int max = nums.Max(), len = nums.Length;
            int[] dp = new int[max + 2], _dp = new int[max + 2];
            for (int i = 1; i < max + 2; i++) dp[i] = i;
            for (int id = len - 2; id >= 0; id--)
            {
                Array.Fill(_dp, 0);
                for (int i = 0, j = 0, sum = nums[id], left = 0, right = 0; i <= sum; i++)
                {
                    j = sum - i;
                    if (j < 0) break;
                    left = Math.Max(i, nums[id + 1] - j);
                    right = nums[id + 1];
                    _dp[i + 1] = _dp[i];
                    if (right >= left) _dp[i + 1] = (_dp[i] + dp[right + 1] - dp[left]) % MOD;
                    if (_dp[i + 1] < 0) _dp[i + 1] += MOD;  // dp[right + 1] - dp[left] 有可能小于0
                }
                Array.Copy(_dp, dp, max + 2);
            }

            return dp[nums[0] + 1];
        }
    }
}
