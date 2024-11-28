using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3250
{
    public class Solution3250_6 : Interface3250
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution3250_5，改为了滚动数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int max = nums.Max(), len = nums.Length;
            int[] dp = new int[max + 1], _dp = new int[max + 1];
            Array.Fill(dp, 1);
            for (int id = len - 2; id >= 0; id--)
            {
                Array.Fill(_dp, 0);
                for (int i = 0, j, sum = nums[id], cnt; i <= sum; i++)
                {
                    j = sum - i;
                    if (j < 0) break;
                    cnt = 0;
                    for (int _i = i, _j, _sum = nums[id + 1]; _i <= _sum; _i++)
                    {
                        _j = _sum - _i;
                        if (_j > j) continue;
                        if (_j < 0) break;
                        cnt += dp[_i];
                        cnt %= MOD;
                    }
                    _dp[i] = cnt;
                }
                Array.Copy(_dp, dp, max + 1);
            }

            int result = 0;
            for (int i = 0; i <= nums[0]; i++) result = (result + dp[i]) % MOD;
            return result;
        }

        /// <summary>
        /// 逻辑同CountOfPairs()，将DP过程中的计算改为先定“左右边界”，为使用前缀和优化做准备
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs2(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int max = nums.Max(), len = nums.Length;
            int[] dp = new int[max + 1], _dp = new int[max + 1];
            Array.Fill(dp, 1);
            for (int id = len - 2; id >= 0; id--)
            {
                Array.Fill(_dp, 0);
                for (int i = 0, j, sum = nums[id], cnt, _sum; i <= sum; i++)
                {
                    j = sum - i;
                    if (j < 0) break;
                    cnt = 0;
                    _sum = nums[id + 1];
                    for (int _i = Math.Max(i, _sum - j); _i <= _sum; _i++)
                    {
                        cnt += dp[_i];
                        cnt %= MOD;
                    }
                    _dp[i] = cnt;
                }
                Array.Copy(_dp, dp, max + 1);
            }

            int result = 0;
            for (int i = 0; i <= nums[0]; i++) result = (result + dp[i]) % MOD;
            return result;
        }
    }
}
