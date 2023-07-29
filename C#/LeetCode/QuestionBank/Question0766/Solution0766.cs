using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0766
{
    public class Solution0766 : Interface0766
    {
        /// <summary>
        /// 模拟
        /// 先遍历第一列，再遍历第一行
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public bool IsToeplitzMatrix(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            for (int r = rcnt - 1; r > 0; r--) for (int k = 1; r + k < rcnt && k < ccnt; k++)
                {
                    if (matrix[r + k][k] != matrix[r][0]) return false;
                }
            for (int c = 0; c < ccnt; c++) for (int k = 1; k < rcnt && c + k < ccnt; k++)
                {
                    if (matrix[k][c + k] != matrix[0][c]) return false;
                }

            return true;
        }

        /// <summary>
        /// 模拟
        /// 逐行遍历，每个元素都与左上角的元素相同即可
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public bool IsToeplitzMatrix2(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    if (matrix[r][c] != matrix[r - 1][c - 1]) return false;
                }

            return true;
        }
    }
}
