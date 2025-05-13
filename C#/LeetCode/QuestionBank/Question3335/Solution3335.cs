using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3335
{
    public class Solution3335 : Interface3335
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int LengthAfterTransformations(string s, int t)
        {
            const int MOD = (int)1e9 + 7;
            int[,] dp = new int[t + 1, 26];
            foreach (char c in s) dp[0, c - 'a']++;
            for (int _t = 1; _t <= t; _t++)
            {
                for (int i = 1; i < 26; i++) dp[_t, i] = dp[_t - 1, i - 1];
                dp[_t, 0] = dp[_t - 1, 25]; ;
                dp[_t, 1] = (dp[_t, 1] + dp[_t - 1, 25]) % MOD;
            }

            int result = 0;
            for (int i = 0; i < 26; i++) result = (result + dp[t, i]) % MOD;
            return result;
        }

        /// <summary>
        /// 逻辑同LengthAfterTransformations()，dp改为滚动数组
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int LengthAfterTransformations2(string s, int t)
        {
            const int MOD = (int)1e9 + 7;
            int result = s.Length;
            int[] dp = new int[26], _dp = new int[26];
            foreach (char c in s) dp[c - 'a']++;
            for (int _t = 1; _t <= t; _t++)
            {
                Array.Fill(_dp, 0);
                for (int i = 1; i < 26; i++) _dp[i] = dp[i - 1];
                _dp[0] = dp[25];
                _dp[1] = (_dp[1] + dp[25]) % MOD;
                result = (result + dp[25]) % MOD;
                Array.Copy(_dp, dp, 26);
            }

            return result;
        }
    }
}
