using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3363
{
    public class Solution3363 : Interface3363
    {
        /// <summary>
        /// DP
        /// 假定是 n+1 * n+1 的表格，由于表格中没有负值，所以很容易得出下面几条结论
        /// 1. 位于(0,0)的小朋友只能沿着对角线移动
        /// 2. 位于(n,0)的小朋友
        ///     不可能越过对角线，一旦越过对角线就不会在到达右下角
        ///     不可能到达对角线，一旦到达了对角线，余下的就只能沿着对角线移动了，这样就与第1位小朋友重合了
        ///     一旦到达了与对角线相邻的位置，就只能沿着对角线方向，即(r+1,c+1)方向移动
        /// 3. 位于(0,n)的小朋友与第2位小朋友是镜像关系，同理       |\    /|
        ///                                                         | \  / |
        /// 下面描述如何使用DP计算第2位小朋友的最大“成绩”         |  \/  |
        /// 1. 可能的路径只能在是右图的阴影区域内                   |  /\  |
        /// 2. 每个位置的值等于左侧（最多）3个值中最大值与自身的和  | /**\ |
        /// 3. DP的过程就是遍历阴影区域的过程                       |/****\|
        /// 
        /// 可以使用滚动数组优化空间复杂度，这里就不做了
        /// </summary>
        /// <param name="fruits"></param>
        /// <returns></returns>
        public int MaxCollectedFruits(int[][] fruits)
        {
            int n = fruits.Length;
            if (n == 2) return fruits[0][0] + fruits[1][1] + fruits[1][0] + fruits[0][1];
            if (n == 3) return fruits[0][0] + fruits[1][1] + fruits[2][2] + fruits[2][0] + fruits[2][1] + fruits[0][2] + fruits[1][2];

            int[,] dp = new int[n, n];
            dp[n - 1, 0] = fruits[n - 1][0];
            for (int c = 1, _val; c < n; c++) for (int r = Math.Max(c + 1, n - c - 1); r < n; r++)
                {
                    _val = Math.Max(dp[r - 1, c - 1], dp[r, c - 1]);
                    if (r + 1 < n) _val = Math.Max(_val, dp[r + 1, c - 1]);
                    dp[r, c] = fruits[r][c] + _val;
                }
            dp[0, n - 1] = fruits[0][n - 1];
            for (int r = 1, _val; r < n; r++) for (int c = Math.Max(r + 1, n - r - 1); c < n; c++)
                {
                    _val = Math.Max(dp[r - 1, c - 1], dp[r - 1, c]);
                    if (c + 1 < n) _val = Math.Max(_val, dp[r - 1, c + 1]);
                    dp[r, c] = fruits[r][c] + _val;
                }

            int result = dp[n - 1, n - 2] + dp[n - 2, n - 1];
            for (int i = 0; i < n; i++) result += fruits[i][i];
            return result;
        }
    }
}
