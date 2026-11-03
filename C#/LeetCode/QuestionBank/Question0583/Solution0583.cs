using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0583
{
    public class Solution0583 : Interface0583
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            int len1 = word1.Length, len2 = word2.Length;
            int[,] dp = new int[len1 + 1, len2 + 1];
            for (int c = 1; c <= len2; c++) dp[0, c] = c;
            for (int r = 1; r <= len1; r++) dp[r, 0] = r;
            for (int r = 1; r <= len1; r++) for (int c = 1; c <= len2; c++)
                {
                    if (word1[r - 1] != word2[c - 1])
                        dp[r, c] = Math.Min(dp[r - 1, c - 1] + 2, Math.Min(dp[r - 1, c], dp[r, c - 1]) + 1);
                    else
                        dp[r, c] = Math.Min(dp[r - 1, c - 1] + 0, Math.Min(dp[r - 1, c], dp[r, c - 1]) + 1);
                }

            return dp[len1, len2];
        }
    }
}
