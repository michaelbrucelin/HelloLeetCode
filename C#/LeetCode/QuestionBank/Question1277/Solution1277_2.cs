using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1277
{
    public class Solution1277_2 : Interface1277
    {
        /// <summary>
        /// DP
        /// 令F(x,y)是以matrix[x,y]为右下角的全是1的正方形数量
        /// 则F(x,y) = matrix[x,y]==1 ? Min(F(x-1,y-1), 上面连续1的数量, 左侧连续1的数量) + 1 : 0
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int CountSquares(int[][] matrix)
        {
            int result = 0, rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[,,] dp = new int[rcnt, ccnt, 3];  // 0: dp值, 1: 上方连续1的数量, 2: 左侧连续1的数量
            for (int c = 0; c < ccnt; c++) if (matrix[0][c] == 1) result += dp[0, c, 0] = dp[0, c, 1] = dp[0, c, 2] = 1;
            for (int r = 1; r < rcnt; r++) if (matrix[r][0] == 1) result += dp[r, 0, 0] = dp[r, 0, 1] = dp[r, 0, 2] = 1;
            int _result;
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++) if (matrix[r][c] == 1)
                    {
                        _result = Math.Min(dp[r - 1, c - 1, 0], Math.Min(dp[r - 1, c, 1], dp[r, c - 1, 2])) + 1;
                        result += _result;
                        dp[r, c, 0] = _result;
                        dp[r, c, 1] = dp[r - 1, c, 1] + 1;
                        dp[r, c, 2] = dp[r, c - 1, 2] + 1;
                    }

            return result;
        }

        /// <summary>
        /// 逻辑与CountSquares()一样，将3维数组改为数组的数组试一下性能，没有看出性能差异
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int CountSquares2(int[][] matrix)
        {
            int result = 0, rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[][][] dp = new int[rcnt][][];
            for (int r = 0; r < rcnt; r++)
            {
                dp[r] = new int[ccnt][];
                for (int c = 0; c < ccnt; c++) dp[r][c] = new int[3];  // 0: dp值, 1: 上方连续1的数量, 2: 左侧连续1的数量
            }

            for (int c = 0; c < ccnt; c++) if (matrix[0][c] == 1) result += dp[0][c][0] = dp[0][c][1] = dp[0][c][2] = 1;
            for (int r = 1; r < rcnt; r++) if (matrix[r][0] == 1) result += dp[r][0][0] = dp[r][0][1] = dp[r][0][2] = 1;
            int _result;
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++) if (matrix[r][c] == 1)
                    {
                        _result = Math.Min(dp[r - 1][c - 1][0], Math.Min(dp[r - 1][c][1], dp[r][c - 1][2])) + 1;
                        result += _result;
                        dp[r][c][0] = _result;
                        dp[r][c][1] = dp[r - 1][c][1] + 1;
                        dp[r][c][2] = dp[r][c - 1][2] + 1;
                    }

            return result;
        }
    }
}
