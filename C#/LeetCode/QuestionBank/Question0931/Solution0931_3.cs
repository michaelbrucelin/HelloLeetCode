using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0931
{
    public class Solution0931_3 : Interface0931
    {
        /// <summary>
        /// DP
        /// 自底向上DP，本质上就是Solution0931_2的dfs+记忆化搜索
        /// dp[r,c]表示以matrix[r][c]为起点的最小值，所以dp[r,c] = Min(dp[r+1,c-1], dp[r+1,c], dp[r+1,c+1])
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MinFallingPathSum(int[][] matrix)
        {
            int n = matrix.Length;
            int[,] dp = new int[n, n];
            for (int c = 0; c < n; c++) dp[n - 1, c] = matrix[n - 1][c];
            for (int r = n - 2; r >= 0; r--) for (int c = 0; c < n; c++)
                {
                    dp[r, c] = matrix[r][c] + dp[r + 1, c];
                    if (c - 1 >= 0) dp[r, c] = Math.Min(dp[r, c], matrix[r][c] + dp[r + 1, c - 1]);
                    if (c + 1 < n) dp[r, c] = Math.Min(dp[r, c], matrix[r][c] + dp[r + 1, c + 1]);
                }

            int result = dp[0, 0];
            for (int c = 1; c < n; c++) result = Math.Min(result, dp[0, c]);
            return result;
        }

        /// <summary>
        /// DP
        /// 同MinFallingPathSum()，改为原地
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MinFallingPathSum2(int[][] matrix)
        {
            int n = matrix.Length;
            for (int r = n - 2, temp; r >= 0; r--) for (int c = 0; c < n; c++)
                {
                    temp = matrix[r][c];
                    matrix[r][c] += matrix[r + 1][c];
                    if (c - 1 >= 0) matrix[r][c] = Math.Min(matrix[r][c], temp + matrix[r + 1][c - 1]);
                    if (c + 1 < n) matrix[r][c] = Math.Min(matrix[r][c], temp + matrix[r + 1][c + 1]);
                }

            int result = matrix[0][0];
            for (int c = 1; c < n; c++) result = Math.Min(result, matrix[0][c]);
            return result;
        }
    }
}
