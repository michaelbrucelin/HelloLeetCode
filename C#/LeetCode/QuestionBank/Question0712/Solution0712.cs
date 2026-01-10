using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0712
{
    public class Solution0712 : Interface0712
    {
        /// <summary>
        /// DP
        /// 与计算字符串的编辑距离（Solution0072）相似
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public int MinimumDeleteSum(string s1, string s2)
        {
            int m = s1.Length, n = s2.Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int r = 1; r <= m; r++) dp[r, 0] = dp[r - 1, 0] + s1[r - 1];
            for (int c = 1; c <= n; c++) dp[0, c] = dp[0, c - 1] + s2[c - 1];
            for (int r = 1; r <= m; r++) for (int c = 1; c <= n; c++)
                {
                    dp[r, c] = s1[r - 1] == s2[c - 1] ? dp[r - 1, c - 1] : Math.Min(s1[r - 1] + s2[c - 1] + dp[r - 1, c - 1], Math.Min(s2[c - 1] + dp[r, c - 1], s1[r - 1] + dp[r - 1, c]));
                }

            return dp[m, n];
        }

        public int MinimumDeleteSum2(string s1, string s2)
        {
            int m = s1.Length, n = s2.Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int r = 1; r <= m; r++) dp[r, 0] = dp[r - 1, 0] + s1[r - 1];
            for (int c = 1; c <= n; c++) dp[0, c] = dp[0, c - 1] + s2[c - 1];
            for (int r = 1; r <= m; r++) for (int c = 1; c <= n; c++)
                {
                    dp[r, c] = s1[r - 1] == s2[c - 1] ? dp[r - 1, c - 1] : Math.Min(s2[c - 1] + dp[r, c - 1], s1[r - 1] + dp[r - 1, c]);
                }

            return dp[m, n];
        }
    }
}
