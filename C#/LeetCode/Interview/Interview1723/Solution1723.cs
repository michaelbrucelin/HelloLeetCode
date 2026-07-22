using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1723
{
    public class Solution1723 : Interface1723
    {
        /// <summary>
        /// DP + 暴力枚举
        /// DP预处理出每个位置向右及向下连续0的数量，然后从大到小枚举可能的黑方阵
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[] FindSquare(int[][] matrix)
        {
            int n = matrix.Length;
            int[,,] dp = new int[n, n, 2];
            for (int r = 0; r < n; r++) dp[r, n - 1, 0] = 1 - matrix[r][n - 1];
            // for (int c = n - 2; c >= 0; c--) for (int r = 0; r < n; r++) dp[r, c, 0] = matrix[r][c] == 0 ? dp[r, c + 1, 0] + 1 : 0;
            for (int c = n - 2; c >= 0; c--) for (int r = 0; r < n; r++) dp[r, c, 0] = (1 - matrix[r][c]) * (dp[r, c + 1, 0] + 1);
            for (int c = 0; c < n; c++) dp[n - 1, c, 1] = 1 - matrix[n - 1][c];
            for (int r = n - 2; r >= 0; r--) for (int c = 0; c < n; c++) dp[r, c, 1] = (1 - matrix[r][c]) * (dp[r + 1, c, 1] + 1);

            int size = n + 1, reach;
            while (--size > 0)
            {
                reach = n - size;
                for (int r = 0; r <= reach; r++) for (int c = 0; c <= reach; c++)
                    {
                        if (dp[r, c, 0] >= size && dp[r, c, 1] >= size && dp[r, c + size - 1, 1] >= size && dp[r + size - 1, c, 0] >= size) return [r, c, size];
                    }
            }

            return [];
        }
    }
}
