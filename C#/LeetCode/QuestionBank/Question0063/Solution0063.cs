using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0063
{
    public class Solution0063 : Interface0063
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid[0][0] == 1 || obstacleGrid[^1][^1] == 1) return 0;

            int rcnt = obstacleGrid.Length, ccnt = obstacleGrid[0].Length;
            int[,] dp = new int[rcnt, ccnt];
            dp[0, 0] = 1;
            for (int c = 1; c < ccnt; c++) dp[0, c] = dp[0, c - 1] == 1 && obstacleGrid[0][c] == 0 ? 1 : 0;
            for (int r = 1; r < rcnt; r++)
            {
                dp[r, 0] = obstacleGrid[r][0] != 0 ? 0 : dp[r - 1, 0];
                for (int c = 1; c < ccnt; c++) dp[r, c] = obstacleGrid[r][c] != 0 ? 0 : dp[r, c - 1] + dp[r - 1, c];
            }

            return dp[rcnt - 1, ccnt - 1];
        }

        /// <summary>
        /// 逻辑同UniquePathsWithObstacles()，滚动数组优化空间
        /// 还可以先判断行与列的大小，选择“滚动”的方向来进一步优化空间，这里就不那样做了
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles2(int[][] obstacleGrid)
        {
            if (obstacleGrid[0][0] == 1 || obstacleGrid[^1][^1] == 1) return 0;

            int rcnt = obstacleGrid.Length, ccnt = obstacleGrid[0].Length;
            int[] dp = new int[ccnt], _dp = new int[ccnt];
            dp[0] = 1;
            for (int c = 1; c < ccnt; c++) dp[c] = dp[c - 1] == 1 && obstacleGrid[0][c] == 0 ? 1 : 0;
            for (int r = 1; r < rcnt; r++)
            {
                _dp[0] = obstacleGrid[r][0] != 0 ? 0 : dp[0];
                for (int c = 1; c < ccnt; c++) _dp[c] = obstacleGrid[r][c] != 0 ? 0 : _dp[c - 1] + dp[c];
                Array.Copy(_dp, dp, ccnt);
            }

            return dp[ccnt - 1];
        }
    }
}
