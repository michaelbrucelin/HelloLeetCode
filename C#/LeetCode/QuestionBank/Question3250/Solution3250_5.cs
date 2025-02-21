using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3250
{
    public class Solution3250_5 : Interface3250
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution3250_4，这里改为DP，Solution_4中的DFS是自顶向下，这里的DP是自底向上
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int max = nums.Max(), len = nums.Length;
            int[,,] dp = new int[len, max + 1, max + 1];
            for (int i = 0; i <= max; i++) for (int j = 0; j <= max; j++) dp[len - 1, i, j] = 1;
            for (int id = len - 2; id >= 0; id--)
            {
                for (int i = 0, j = 0, sum = nums[id], cnt = 0; i <= sum; i++)
                {
                    j = sum - i;
                    if (j < 0) break;
                    cnt = 0;
                    for (int _i = i, _j = 0, _sum = nums[id + 1]; _i <= _sum; _i++)
                    {
                        _j = _sum - _i;
                        if (_j > j) continue;
                        if (_j < 0) break;
                        cnt += dp[id + 1, _i, _j];
                        cnt %= MOD;
                    }
                    dp[id, i, j] = cnt;
                }
            }

            int result = 0;
            for (int i = 0; i <= nums[0]; i++) result = (result + dp[0, i, nums[0] - i]) % MOD;
            return result;
        }

        /// <summary>
        /// 逻辑同CountOfPairs()，dp可以是2维数组，第3维是没有意义的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs2(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int max = nums.Max(), len = nums.Length;
            int[,] dp = new int[len, max + 1];
            for (int i = 0; i <= max; i++) dp[len - 1, i] = 1;
            for (int id = len - 2; id >= 0; id--)
            {
                for (int i = 0, j = 0, sum = nums[id], cnt = 0; i <= sum; i++)
                {
                    j = sum - i;
                    if (j < 0) break;
                    cnt = 0;
                    for (int _i = i, _j = 0, _sum = nums[id + 1]; _i <= _sum; _i++)
                    {
                        _j = _sum - _i;
                        if (_j > j) continue;
                        if (_j < 0) break;
                        cnt += dp[id + 1, _i];
                        cnt %= MOD;
                    }
                    dp[id, i] = cnt;
                }
            }

            int result = 0;
            for (int i = 0; i <= nums[0]; i++) result = (result + dp[0, i]) % MOD;
            return result;
        }
    }
}
