using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0072
{
    public class Solution0072 : Interface0072
    {
        /// <summary>
        /// DP
        /// 经典问题，编辑距离
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length, n = word2.Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++) dp[i, 0] = i;
            for (int j = 1; j <= n; j++) dp[0, j] = j;
            for (int i = 1; i <= m; i++) for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = word1[i - 1] == word2[j - 1] ? dp[i - 1, j - 1] : Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1])) + 1;
                }

            return dp[m, n];
        }
    }
}
