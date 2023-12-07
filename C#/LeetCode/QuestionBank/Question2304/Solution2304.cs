using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2304
{
    public class Solution2304 : Interface2304
    {
        /// <summary>
        /// DP
        /// 1. 如果grid只有1行，那么以任意位置为终点的最短路径，就是其自身
        /// 2. 如果grid从第1行到第k行的每个位置的最短路径都已知
        ///     那么到第k+1行的每一个位置的最短路径，都可以通过枚举两行的全部可能性得到结果
        /// 时间复杂度：O(m^2*n)
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="moveCost"></param>
        /// <returns></returns>
        public int MinPathCost(int[][] grid, int[][] moveCost)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dp = new int[ccnt], _dp = new int[ccnt];
            Array.Copy(grid[0], dp, ccnt);

            int minCost;
            for (int r = 1; r < rcnt; r++)
            {
                for (int c = 0; c < ccnt; c++)
                {
                    minCost = dp[0] + moveCost[grid[r - 1][0]][c];
                    for (int _c = 1; _c < ccnt; _c++) minCost = Math.Min(minCost, dp[_c] + moveCost[grid[r - 1][_c]][c]);
                    _dp[c] = minCost + grid[r][c];
                }
                Array.Copy(_dp, dp, ccnt);
            }

            int result = dp[0];
            for (int i = 1; i < ccnt; i++) result = Math.Min(result, dp[i]);
            return result;
        }
    }
}
