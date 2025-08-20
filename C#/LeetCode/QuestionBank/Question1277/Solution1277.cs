using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1277
{
    public class Solution1277 : Interface1277
    {
        /// <summary>
        /// 枚举
        /// 1. 枚举全部的1*1, 2*2, ... n*n
        /// 2. 借助二维前缀和可以加速判断每一个小的正方形
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int CountSquares(int[][] matrix)
        {
            int result = 0, rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[,] sums = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    sums[r + 1, c + 1] = sums[r + 1, c] + sums[r, c + 1] - sums[r, c] + matrix[r][c];
                }

            int max = Math.Min(rcnt, ccnt);
            for (int i = 1, j = 1; i <= max; i++, j = i * i) for (int r = i - 1; r < rcnt; r++) for (int c = i - 1; c < ccnt; c++)
                    {
                        if (sums[r + 1, c + 1] - sums[r + 1, c - i + 1] - sums[r - i + 1, c + 1] + sums[r - i + 1, c - i + 1] == j) result++;
                    }

            return result;
        }
    }
}
