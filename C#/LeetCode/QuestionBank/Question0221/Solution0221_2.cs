using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0221
{
    public class Solution0221_2 : Interface0221
    {
        /// <summary>
        /// DP
        /// dp[r,c,0]表示以dp[r,c]为右下角的最大全是1的正方形的边长
        /// dp[r,c,1]表示以dp[r,c]为最右的全是1的长度
        /// dp[r,c,2]表示以dp[r,c]为最下的全是1的长度
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalSquare(char[][] matrix)
        {
            int result = 0, rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[,,] dp = new int[rcnt + 1, ccnt + 1, 3];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (matrix[r][c] != '0')
                    {
                        dp[r + 1, c + 1, 0] = Math.Min(dp[r, c, 0], Math.Min(dp[r + 1, c, 1], dp[r, c + 1, 2])) + 1;
                        dp[r + 1, c + 1, 1] = dp[r + 1, c, 1] + 1;
                        dp[r + 1, c + 1, 2] = dp[r, c + 1, 2] + 1;
                        result = Math.Max(result, dp[r + 1, c + 1, 0]);
                    }

            return result * result;
        }
    }
}
