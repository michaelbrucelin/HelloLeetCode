using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0867
{
    public class Solution0867 : Interface0867
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[][] Transpose(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[][] result = new int[ccnt][];
            for (int c = 0; c < ccnt; c++)
            {
                result[c] = new int[rcnt];
                for (int r = 0; r < rcnt; r++) result[c][r] = matrix[r][c];
            }

            return result;
        }
    }
}
