using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0047
{
    public class Solution0047_4 : Interface0047
    {
        /// <summary>
        /// DP
        /// 滚动数组
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxValue(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dp = new int[ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    dp[c + 1] = grid[r][c] + Math.Max(dp[c], dp[c + 1]);
                }

            return dp[ccnt];
        }

        /// <summary>
        /// DP
        /// 原地更改
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxValue2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 1; r < rcnt; r++) grid[r][0] += grid[r - 1][0];
            for (int c = 1; c < ccnt; c++) grid[0][c] += grid[0][c - 1];
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    grid[r][c] += Math.Max(grid[r - 1][c], grid[r][c - 1]);
                }

            return grid[rcnt - 1][ccnt - 1];
        }
    }
}
