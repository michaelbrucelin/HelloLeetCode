using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0013
{
    public class Solution0013
    {
    }

    public class NumMatrix : Interface0013
    {
        public NumMatrix(int[][] matrix)
        {
            rcnt = matrix.Length; ccnt = matrix[0].Length;
            sums = new int[rcnt + 1, ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    sums[r + 1, c + 1] = sums[r + 1, c] + sums[r, c + 1] - sums[r, c] + matrix[r][c];
                }
        }

        private int rcnt, ccnt;
        private int[,] sums;

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return sums[row2 + 1, col2 + 1] - sums[row2 + 1, col1] - sums[row1, col2 + 1] + sums[row1, col1];
        }
    }
}
