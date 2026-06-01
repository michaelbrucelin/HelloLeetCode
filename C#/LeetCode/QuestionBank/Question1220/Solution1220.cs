using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1220
{
    public class Solution1220 : Interface1220
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountVowelPermutation(int n)
        {
            const int MOD = (int)1e9 + 7;
            int[,] dp = new int[n, 5];
            for (int i = 0; i < 5; i++) dp[0, i] = 1;
            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = ((dp[i - 1, 1] + dp[i - 1, 2]) % MOD + dp[i - 1, 4]) % MOD;
                dp[i, 1] = (dp[i - 1, 0] + dp[i - 1, 2]) % MOD;
                dp[i, 2] = (dp[i - 1, 1] + dp[i - 1, 3]) % MOD;
                dp[i, 3] = dp[i - 1, 2];
                dp[i, 4] = (dp[i - 1, 2] + dp[i - 1, 3]) % MOD;
            }

            int result = dp[n - 1, 0];
            for (int i = 1; i < 5; i++) result = (result + dp[n - 1, i]) % MOD;
            return result;
        }

        /// <summary>
        /// DP
        /// 逻辑同CountVowelPermutation()，改为滚动数组
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountVowelPermutation2(int n)
        {
            const int MOD = (int)1e9 + 7;
            int[] dp = new int[5], _dp = new int[5];
            for (int i = 0; i < 5; i++) dp[i] = 1;
            for (int i = 1; i < n; i++)
            {
                _dp[0] = ((dp[1] + dp[2]) % MOD + dp[4]) % MOD;
                _dp[1] = (dp[0] + dp[2]) % MOD;
                _dp[2] = (dp[1] + dp[3]) % MOD;
                _dp[3] = dp[2];
                _dp[4] = (dp[2] + dp[3]) % MOD;
                Array.Copy(_dp, dp, 5);
            }

            int result = dp[0];
            for (int i = 1; i < 5; i++) result = (result + dp[i]) % MOD;
            return result;
        }
    }
}
