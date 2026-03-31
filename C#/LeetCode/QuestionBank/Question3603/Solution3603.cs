using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3603
{
    public class Solution3603 : Interface3603
    {
        /// <summary>
        /// DP
        /// 阅读理解题，除了pos[0][0]与pos[m-1][n-1]之外，都同时累加进入成本与等待成本，而pos[0][0]与pos[m-1][n-1]只有进入成本
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="waitCost"></param>
        /// <returns></returns>
        public long MinCost(int m, int n, int[][] waitCost)
        {
            long[][] dp = new long[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new long[n];
                for (int j = 0; j < n; j++) dp[i][j] = (i + 1) * (j + 1) + waitCost[i][j];
            }
            dp[0][0] = 1; dp[m - 1][n - 1] = m * n;

            for (int j = 1; j < n; j++) dp[0][j] += dp[0][j - 1];
            for (int i = 1; i < m; i++) dp[i][0] += dp[i - 1][0];
            for (int i = 1; i < m; i++) for (int j = 1; j < n; j++) dp[i][j] += Math.Min(dp[i - 1][j], dp[i][j - 1]);

            return dp[m - 1][n - 1];
        }

        /// <summary>
        /// 逻辑同MinCost()，滚动数组
        /// 
        /// 错了，参考测试用例04，没看出哪里错了（配置为溢出会抛异常，但是没有抛异常），先不管了
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="waitCost"></param>
        /// <returns></returns>
        public long MinCost2(int m, int n, int[][] waitCost)
        {
            long[] dp = new long[n], _dp = new long[n];
            Array.Fill(_dp, int.MaxValue, 1, n - 1);
            for (int i = 0; i < m; i++)
            {
                dp[0] = _dp[0] + (i + 1) + waitCost[i][0];
                for (int j = 1; j < n; j++) dp[j] = Math.Min(_dp[j], dp[j - 1]) + (i + 1) * (j + 1) + waitCost[i][j];
                Array.Copy(dp, _dp, n);
            }

            return dp[n - 1] - waitCost[0][0] - waitCost[m - 1][n - 1];
        }
    }
}
