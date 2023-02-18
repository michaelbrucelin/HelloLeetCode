using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0240
{
    public class Solution0240_3 : Interface0240
    {
        /// <summary>
        /// 二分法
        /// 与Solution0240_2一样，但是把内部循环的y--改为了二分法，加速查找
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            for (int row = 0, left = 0, right = matrix[0].Length - 1, col; row < matrix.Length && right >= 0; row++, left = 0)
            {
                while (left <= right)
                {
                    col = left + ((right - left) >> 1);
                    if (matrix[row][col] == target) return true;
                    else if (matrix[row][col] > target) right = col - 1;
                    else left = col + 1;
                }
            }

            return false;
        }
    }
}
