using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3494
{
    public class Solution3494 : Interface3494
    {
        /// <summary>
        /// DP
        /// 带修正的DP，具体解释见Solution3494.md
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="mana"></param>
        /// <returns></returns>
        public long MinTime(int[] skill, int[] mana)
        {
            int n = skill.Length, m = mana.Length;
            long[,] dp = new long[m + 1, n + 1];
            for (int r = 1; r <= m; r++)
            {
                for (int c = 1; c <= n; c++) dp[r, c] = Math.Max(dp[r, c - 1], dp[r - 1, c]) + mana[r - 1] * skill[c - 1];
                for (int c = n - 1; c > 0; c--) dp[r, c] = dp[r, c + 1] - mana[r - 1] * skill[c];
            }

            return dp[m, n];
        }

        /// <summary>
        /// 逻辑同MinTime()，改为锯齿数组
        /// 至少在这里案例中，锯齿数组比二维数组的速度要快
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="mana"></param>
        /// <returns></returns>
        public long MinTime2(int[] skill, int[] mana)
        {
            int n = skill.Length, m = mana.Length;
            long[][] dp = new long[m + 1][];
            dp[0] = new long[n + 1];
            for (int r = 1; r <= m; r++)
            {
                dp[r] = new long[n + 1];
                for (int c = 1; c <= n; c++) dp[r][c] = Math.Max(dp[r][c - 1], dp[r - 1][c]) + mana[r - 1] * skill[c - 1];
                for (int c = n - 1; c > 0; c--) dp[r][c] = dp[r][c + 1] - mana[r - 1] * skill[c];
            }

            return dp[m][n];
        }

        /// <summary>
        /// 逻辑同MinTime()，改为滚动数组
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="mana"></param>
        /// <returns></returns>
        public long MinTime3(int[] skill, int[] mana)
        {
            int n = skill.Length, m = mana.Length;
            long[] dp = new long[n + 1], _dp = new long[n + 1];
            for (int r = 1; r <= m; r++)
            {
                for (int c = 1; c <= n; c++) _dp[c] = Math.Max(_dp[c - 1], dp[c]) + mana[r - 1] * skill[c - 1];
                for (int c = n - 1; c > 0; c--) _dp[c] = _dp[c + 1] - mana[r - 1] * skill[c];
                Array.Copy(_dp, dp, n + 1);
            }

            return dp[n];
        }
    }
}
