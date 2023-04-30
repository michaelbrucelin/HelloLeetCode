using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0240
{
    public class Solution0240 : Interface0240
    {
        /// <summary>
        /// BST
        /// 把二维数组看成一个二叉搜索树，根使矩阵的右上角
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            for (int row = 0, col = matrix[0].Length - 1; row < matrix.Length && col >= 0;)
            {
                if (matrix[row][col] == target) return true;
                else if (matrix[row][col] < target) row++;
                else col--;
            }

            return false;
        }
    }
}
