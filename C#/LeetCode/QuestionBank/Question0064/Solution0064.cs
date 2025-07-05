using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0064
{
    public class Solution0064 : Interface0064
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[,] dp = new int[rcnt, ccnt];
            dp[0, 0] = grid[0][0];
            for (int c = 1; c < ccnt; c++) dp[0, c] = dp[0, c - 1] + grid[0][c];
            for (int r = 1; r < rcnt; r++) dp[r, 0] = dp[r - 1, 0] + grid[r][0];
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    dp[r, c] = Math.Min(dp[r - 1, c], dp[r, c - 1]) + grid[r][c];
                }

            return dp[rcnt - 1, ccnt - 1];
        }

        /// <summary>
        /// DP，滚动数组
        /// 还可以比较行和列的数量，来决定哪个方向上滚动，进一步减少空间复杂度，这里就不展开了
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dp = new int[ccnt], _dp = new int[ccnt];
            dp[0] = grid[0][0];
            for (int c = 1; c < ccnt; c++) dp[c] = dp[c - 1] + grid[0][c];
            for (int r = 1; r < rcnt; r++)
            {
                Array.Fill(_dp, 0);
                _dp[0] = dp[0] + grid[r][0];
                for (int c = 1; c < ccnt; c++)
                {
                    _dp[c] = Math.Min(dp[c], _dp[c - 1]) + grid[r][c];
                }
                Array.Copy(_dp, dp, ccnt);
            }

            return dp[ccnt - 1];
        }
    }
}
