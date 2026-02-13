using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0099
{
    public class Solution0099 : Interface0099
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            if (rcnt == 0)
            {
                for (int c = 0; c < ccnt; c++) result += grid[0][c];
                return result;
            }
            if (ccnt == 0)
            {
                for (int r = 0; r < rcnt; r++) result += grid[r][0];
                return result;
            }

            int[,] dp = new int[rcnt, ccnt];
            dp[0, 0] = grid[0][0];
            for (int c = 1; c < ccnt; c++) dp[0, c] = dp[0, c - 1] + grid[0][c];
            for (int r = 1; r < rcnt; r++) dp[r, 0] = dp[r - 1, 0] + grid[r][0];
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++) dp[r, c] = Math.Min(dp[r - 1, c], dp[r, c - 1]) + grid[r][c];

            return dp[rcnt - 1, ccnt - 1];
        }

        /// <summary>
        /// 滚动数组
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum2(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            if (rcnt == 0)
            {
                for (int c = 0; c < ccnt; c++) result += grid[0][c];
                return result;
            }
            if (ccnt == 0)
            {
                for (int r = 0; r < rcnt; r++) result += grid[r][0];
                return result;
            }

            int[] dp, _dp;
            if (ccnt <= rcnt)
            {
                dp = new int[ccnt]; _dp = new int[ccnt];
                dp[0] = grid[0][0];
                for (int c = 1; c < ccnt; c++) dp[c] = dp[c - 1] + grid[0][c];
                for (int r = 1; r < rcnt; r++)
                {
                    _dp[0] = dp[0] + grid[r][0];
                    for (int c = 1; c < ccnt; c++) _dp[c] = Math.Min(dp[c], _dp[c - 1]) + grid[r][c];
                    Array.Copy(_dp, dp, ccnt);
                }
            }
            else
            {
                dp = new int[rcnt]; _dp = new int[rcnt];
                dp[0] = grid[0][0];
                for (int r = 1; r < rcnt; r++) dp[r] = dp[r - 1] + grid[r][0];
                for (int c = 1; c < ccnt; c++)
                {
                    _dp[0] = dp[0] + grid[0][c];
                    for (int r = 1; r < rcnt; r++) _dp[r] = Math.Min(dp[r], _dp[r - 1]) + grid[r][c];
                    Array.Copy(_dp, dp, rcnt);
                }
            }

            return dp[dp.Length - 1];
        }
    }
}
