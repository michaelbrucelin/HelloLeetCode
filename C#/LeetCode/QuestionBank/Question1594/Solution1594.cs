using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1594
{
    public class Solution1594 : Interface1594
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxProductPath(int[][] grid)
        {
            const int MOD = (int)1e9 + 7;
            int rcnt = grid.Length, ccnt = grid[0].Length;
            long[,,] dp = new long[rcnt, ccnt, 2];
            dp[0, 0, 0] = dp[0, 0, 1] = grid[0][0];
            for (int r = 1; r < rcnt; r++) dp[r, 0, 0] = dp[r, 0, 1] = grid[r][0] * dp[r - 1, 0, 0];
            for (int c = 1; c < ccnt; c++) dp[0, c, 0] = dp[0, c, 1] = grid[0][c] * dp[0, c - 1, 0];
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    dp[r, c, 0] = Math.Min(Math.Min(grid[r][c] * dp[r - 1, c, 0], grid[r][c] * dp[r - 1, c, 1]), Math.Min(grid[r][c] * dp[r, c - 1, 0], grid[r][c] * dp[r, c - 1, 1]));
                    dp[r, c, 1] = Math.Max(Math.Max(grid[r][c] * dp[r - 1, c, 0], grid[r][c] * dp[r - 1, c, 1]), Math.Max(grid[r][c] * dp[r, c - 1, 0], grid[r][c] * dp[r, c - 1, 1]));
                }

            long result = Math.Max(dp[rcnt - 1, ccnt - 1, 0], dp[rcnt - 1, ccnt - 1, 1]);
            return result < 0 ? -1 : (int)(result % MOD);
        }

        /// <summary>
        /// 逻辑同MaxProductPath()，滚动数组
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxProductPath2(int[][] grid)
        {
            const int MOD = (int)1e9 + 7;
            int rcnt = grid.Length, ccnt = grid[0].Length;
            long[] dpmin = new long[ccnt], dpmax = new long[ccnt], _dpmin = new long[ccnt], _dpmax = new long[ccnt];
            dpmin[0] = dpmax[0] = grid[0][0];
            for (int c = 1; c < ccnt; c++) dpmin[c] = dpmax[c] = grid[0][c] * dpmin[c - 1];
            for (int r = 1; r < rcnt; r++)
            {
                _dpmin[0] = _dpmax[0] = grid[r][0] * dpmin[0];
                for (int c = 1; c < ccnt; c++)
                {
                    _dpmin[c] = Math.Min(Math.Min(grid[r][c] * dpmin[c], grid[r][c] * dpmax[c]), Math.Min(grid[r][c] * _dpmin[c - 1], grid[r][c] * _dpmax[c - 1]));
                    _dpmax[c] = Math.Max(Math.Max(grid[r][c] * dpmin[c], grid[r][c] * dpmax[c]), Math.Max(grid[r][c] * _dpmin[c - 1], grid[r][c] * _dpmax[c - 1]));
                }
                Array.Copy(_dpmin, dpmin, ccnt);
                Array.Copy(_dpmax, dpmax, ccnt);
            }

            long result = Math.Max(dpmin[ccnt - 1], dpmax[ccnt - 1]);
            return result < 0 ? -1 : (int)(result % MOD);
        }
    }
}
