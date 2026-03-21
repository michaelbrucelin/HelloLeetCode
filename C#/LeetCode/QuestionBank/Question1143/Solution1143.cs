using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1143
{
    public class Solution1143 : Interface1143
    {
        /// <summary>
        /// DP
        /// 经典DP
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int rcnt = text1.Length, ccnt = text2.Length;
            int[,] dp = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    dp[r + 1, c + 1] = text1[r] == text2[c] ? dp[r, c] + 1 : Math.Max(dp[r + 1, c], dp[r, c + 1]);
                }

            return dp[rcnt, ccnt];
        }
    }
}
