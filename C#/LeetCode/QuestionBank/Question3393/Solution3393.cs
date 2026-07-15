using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3393
{
    public class Solution3393 : Interface3393
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountPathsWithXorValue(int[][] grid, int k)
        {
            int max = -1, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) max = Math.Max(max, grid[r][c]);
            max = (1 << (BitOperations.Log2((uint)max) + 1)) - 1;
            if (max < k) return 0;

            int[,,] dp = new int[rcnt, ccnt, max + 1];
            int MOD = (int)1e9 + 7;
            dp[0, 0, grid[0][0]] = 1;
            for (int c = 1; c < ccnt; c++) for (int x = 0; x <= max; x++) dp[0, c, x ^ grid[0][c]] = dp[0, c - 1, x];
            for (int r = 1; r < rcnt; r++) for (int x = 0; x <= max; x++) dp[r, 0, x ^ grid[r][0]] = dp[r - 1, 0, x];
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++) for (int x = 0; x <= max; x++)
                    {
                        dp[r, c, x ^ grid[r][c]] = (dp[r - 1, c, x] + dp[r, c - 1, x]) % MOD;
                    }

            return dp[rcnt - 1, ccnt - 1, k];
        }
    }
}
