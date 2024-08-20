using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0552
{
    public class Solution0552 : Interface0552
    {
        /// <summary>
        /// DP，状态机
        /// 令F(N)表示长度为N的结果，其中，    则
        ///     F(N,0) -> 有A，结尾为 A        F(N+1,0) = F(N,4) + F(N,5) + F(N,6)
        ///     F(N,1) -> 有A，结尾为 P        F(N+1,1) = F(N,0) + F(N,1) + F(N,2) + F(N,3)
        ///     F(N,2) -> 有A，结尾为?L        F(N+1,2) = F(N,0) + F(N,1)
        ///     F(N,3) -> 有A，结尾为LL        F(N+1,3) = F(N,2)
        ///     F(N,4) -> 无A，结尾为 P        F(N+1,4) = F(N,4) + F(N,5) + F(N,6)
        ///     F(N,5) -> 无A，结尾为?L        F(N+1,5) = F(N,4)
        ///     F(N,6) -> 无A，结尾为LL        F(N+1,6) = F(N,5)
        /// 参考图Solution0552.jpg
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CheckRecord(int n)
        {
            if (n == 1) return 3;

            const int MOD = (int)1e9 + 7;
            long[] dp = { 1, 0, 0, 0, 1, 1, 0 }, _dp = new long[7];
            while (n-- > 1)
            {
                _dp[0] = (dp[4] + dp[5] + dp[6]) % MOD;
                _dp[1] = (dp[0] + dp[1] + dp[2] + dp[3]) % MOD;
                _dp[2] = (dp[0] + dp[1]) % MOD;
                _dp[3] = (dp[2]) % MOD;
                _dp[4] = (dp[4] + dp[5] + dp[6]) % MOD;
                _dp[5] = (dp[4]) % MOD;
                _dp[6] = (dp[5]) % MOD;
                Array.Copy(_dp, dp, 7);
            }

            return (int)(dp.Sum() % MOD);
        }

        /// <summary>
        /// 逻辑与CheckRecord()完全一样，只是从3开始计算
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CheckRecord2(int n)
        {
            if (n == 1) return 3;
            if (n == 2) return 8;

            const int MOD = (int)1e9 + 7;
            long[] dp = { 2, 1, 1, 0, 2, 1, 1 }, _dp = new long[7];
            while (n-- > 2)
            {
                _dp[0] = (dp[4] + dp[5] + dp[6]) % MOD;
                _dp[1] = (dp[0] + dp[1] + dp[2] + dp[3]) % MOD;
                _dp[2] = (dp[0] + dp[1]) % MOD;
                _dp[3] = (dp[2]) % MOD;
                _dp[4] = (dp[4] + dp[5] + dp[6]) % MOD;
                _dp[5] = (dp[4]) % MOD;
                _dp[6] = (dp[5]) % MOD;
                Array.Copy(_dp, dp, 7);
            }

            return (int)(dp.Sum() % MOD);
        }
    }
}
