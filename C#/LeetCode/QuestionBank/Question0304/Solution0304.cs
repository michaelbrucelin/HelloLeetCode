using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0304
{
    public class Solution0304
    {
    }

    public class NumMatrix : Interface0304
    {
        public NumMatrix(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            pre = new int[rcnt + 1][];
            for (int i = 0; i <= rcnt; i++) pre[i] = new int[ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    pre[r + 1][c + 1] = pre[r][c + 1] + pre[r + 1][c] - pre[r][c] + matrix[r][c];
                }
        }

        private int[][] pre;

        /// <summary>
        /// 二维前缀和
        /// </summary>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        /// <returns></returns>
        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            return pre[row2 + 1][col2 + 1] - pre[row1][col2 + 1] - pre[row2 + 1][col1] + pre[row1][col1];
        }
    }
}
