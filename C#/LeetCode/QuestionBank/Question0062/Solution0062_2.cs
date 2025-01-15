using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0062
{
    public class Solution0062_2 : Interface0062
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1) return 1;

            int[,] dp = new int[m, n];
            for (int c = 0; c < n; c++) dp[0, c] = 1;
            for (int r = 1; r < m; r++) dp[r, 0] = 1;
            for (int r = 1; r < m; r++) for (int c = 1; c < n; c++) dp[r, c] = dp[r - 1, c] + dp[r, c - 1];

            return dp[m - 1, n - 1];
        }

        /// <summary>
        /// 逻辑同UniquePaths()，滚动数组优化空间
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths2(int m, int n)
        {
            if (m == 1 || n == 1) return 1;
            if (m < n) { m ^= n; n ^= m; m ^= n; }  // 让 m >= n

            int[] dp = new int[n], _dp = new int[n];
            Array.Fill(dp, 1);
            for (int i = 1; i < m; i++)
            {
                _dp[0] = 1;
                for (int j = 1; j < n; j++) _dp[j] = dp[j] + _dp[j - 1];
                Array.Copy(_dp, dp, n);
            }

            return dp[n - 1];
        }
    }
}
