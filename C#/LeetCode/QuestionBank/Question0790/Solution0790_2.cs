using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0790
{
    public class Solution0790_2 : Interface0790
    {
        /// <summary>
        /// DP
        /// F(N)  = F(N-1)  + F(N-2) + F'(N-1)  长度为N，末端是对齐的
        /// F'(N) = F'(N-1) + F(N-2)*2          长度为N，末端是错开的
        /// 
        /// 可以优化为滚动数组，没太大意义，这里就不写了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumTilings(int n)
        {
            if (n < 3) return n;

            const int MOD = (int)1e9 + 7;
            long[] dp1 = new long[n + 1];
            long[] dp2 = new long[n + 1];
            dp1[0] = 1; dp1[1] = 1; dp1[2] = 2;
            dp2[0] = 0; dp2[1] = 0; dp2[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp1[i] = (dp1[i - 1] + dp1[i - 2] + dp2[i - 1]) % MOD;
                dp2[i] = (dp2[i - 1] + (dp1[i - 2] << 1)) % MOD;
            }

            return (int)dp1[n];
        }

        /// <summary>
        /// 逻辑与NumTilings()完全相同，将F'(N)化简掉
        /// F'(N) = 2(F(N-2)+F(N-3)+...+F(0)) + F'(1)
        /// F(N)  = F(N-1) + F(N-2) + F'(N-1)
        ///       = F(N-1) + F(N-2) + 2(F(N-3)+F(N-4)+...+F(0))
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumTilings2(int n)
        {
            if (n < 3) return n;

            const int MOD = (int)1e9 + 7;
            long[] dp = new long[n + 1];
            dp[0] = 1; dp[1] = 1; dp[2] = 2;
            long sum = 2;                     // 前缀和
            for (int i = 3; i <= n; i++)
            {
                dp[i] = (dp[i - 1] + dp[i - 2] + sum) % MOD;
                sum = (sum + (dp[i - 2] << 1)) % MOD;
            }

            return (int)dp[n];
        }
    }
}
