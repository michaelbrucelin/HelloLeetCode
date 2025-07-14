using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0095
{
    public class Solution0095 : Interface0095
    {
        /// <summary>
        /// DP
        /// 经典问题，LCS
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int m = text1.Length, n = text2.Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++) for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = text1[i - 1] == text2[j - 1] ? dp[i - 1, j - 1] + 1 : Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }

            return dp[m, n];
        }
    }
}
