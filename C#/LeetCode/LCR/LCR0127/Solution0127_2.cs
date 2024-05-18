using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0127
{
    public class Solution0127_2 : Interface0127
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int TrainWays(int num)
        {
            if (num == 0) return 1; else if (num < 3) return num;

            const int MOD = (int)1e9 + 7;
            int[] dp = new int[num + 1];
            dp[1] = 1; dp[2] = 2;
            for (int i = 3; i <= num; i++) dp[i] = dp[i - 1] % MOD + dp[i - 2] % MOD;

            return dp[num] % MOD;
        }
    }
}
