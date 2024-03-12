using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0801
{
    public class Solution0801 : Interface0801
    {
        /// <summary>
        /// DP
        /// 本质上就是递归，F(n) = F(n-1) + F(n-2) + F(n-3)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int WaysToStep(int n)
        {
            if (n < 4) return 1 << (n - 1);

            const int MOD = (int)1e9 + 7;
            int[] dp = new int[4] { 0, 1, 2, 4 };
            for (int i = 3; i < n; i++)
            {
                dp[0] = dp[1]; dp[1] = dp[2]; dp[2] = dp[3];
                dp[3] = ((dp[0] + dp[1]) % MOD + dp[2]) % MOD;
            }

            return dp[3];
        }
    }
}
