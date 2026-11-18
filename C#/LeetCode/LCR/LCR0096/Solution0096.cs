using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0096
{
    public class Solution0096 : Interface0096
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            int m = s1.Length, n = s2.Length;
            bool[,] dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;
            for (int i = 1; i <= m; i++) dp[i, 0] = dp[i - 1, 0] && (s1[i - 1] == s3[i - 1]);
            for (int j = 1; j <= n; j++) dp[0, j] = dp[0, j - 1] && (s2[j - 1] == s3[j - 1]);
            for (int i = 1; i <= m; i++) for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = (dp[i - 1, j] && (s1[i - 1] == s3[i + j - 1])) || (dp[i, j - 1] && (s2[j - 1] == s3[i + j - 1]));
                }

            return dp[m, n];
        }
    }
}
