using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0072
{
    public class Solution0072_2 : Interface0072
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length, n = word2.Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int r = 1; r <= m; r++) dp[r, 0] = r;
            for (int c = 1; c <= n; c++) dp[0, c] = c;
            for (int r = 1; r <= m; r++) for (int c = 1; c <= n; c++)
                {
                    dp[r, c] = word1[r - 1] == word2[c - 1] ? dp[r - 1, c - 1] : Math.Min(dp[r - 1, c - 1], Math.Min(dp[r - 1, c], dp[r, c - 1])) + 1;
                }

            return dp[m, n];
        }
    }
}
