using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2435
{
    public class Solution2435 : Interface2435
    {
        /// <summary>
        /// DP
        /// k = 1时的排列组合结果怎么计算？
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumberOfPaths(int[][] grid, int k)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            const int MOD = (int)1e9 + 7;
            // if (k == 1) { return (rcnt + ccnt - 2)! / (rcnt - 1)! / (ccnt - 1)!; }
            if (rcnt == 1) { int result = 0; int sum = 0; for (int c = 0; c < ccnt; c++) if ((sum += grid[0][c]) % k == 0) result++; }
            if (ccnt == 1) { int result = 0; int sum = 0; for (int r = 0; r < rcnt; r++) if ((sum += grid[r][0]) % k == 0) result++; }

            int[,,] dp = new int[rcnt + 1, ccnt + 1, k];
            dp[1, 1, grid[0][0] % k] = 1;
            for (int r = 0, rem; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    rem = grid[r][c] % k;
                    for (int i = 0, j; i < k; i++)
                    {
                        j = (i + k - rem) % k;
                        dp[r + 1, c + 1, i] += (dp[r, c + 1, j] + dp[r + 1, c, j]) % MOD;
                    }
                }

            return dp[rcnt, ccnt, 0];
        }
    }
}
