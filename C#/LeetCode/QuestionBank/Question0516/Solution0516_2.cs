using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0516
{
    public class Solution0516_2 : Interface0516
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestPalindromeSubseq(string s)
        {
            if (s.Length == 1) return 1;

            int len = s.Length;
            int[,] dp = new int[len, len];
            for (int i = 0; i < len; i++) dp[i, i] = 1;
            for (int span = 2; span <= len; span++) for (int l = 0, r = l + span - 1; r < len; l++, r++)
                {
                    dp[l, r] = s[l] == s[r] ? dp[l + 1, r - 1] + 2 : Math.Max(dp[l + 1, r], dp[l, r - 1]);
                }

            return dp[0, len - 1];
        }
    }
}
