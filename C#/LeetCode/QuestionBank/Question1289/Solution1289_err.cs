using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1289
{
    public class Solution1289_err : Interface1289
    {
        /// <summary>
        /// DP
        /// 这里的题解是相邻行选择的值列是紧挨着的，而题目只要求列不可以相同，但是没要求列紧挨着，题目理解错的
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinFallingPathSum(int[][] grid)
        {
            int len = grid.Length;
            if (len == 1) return grid[0][0];
            if (len == 2) return Math.Min(grid[0][0] + grid[1][1], grid[0][1] + grid[1][0]);

            int[,] dp = new int[len + 1, len];
            for (int r = len - 1; r >= 0; r--)
            {
                dp[r, 0] = grid[r][0] + dp[r + 1, 1];
                for (int c = 1; c < len - 1; c++) dp[r, c] = grid[r][c] + Math.Min(dp[r + 1, c - 1], dp[r + 1, c + 1]);
                dp[r, len - 1] = grid[r][len - 1] + dp[r + 1, len - 2];
            }

            int result = dp[0, 0];
            for (int i = 1; i < len; i++) result = Math.Min(result, dp[0, i]);
            return result;
        }
    }
}
