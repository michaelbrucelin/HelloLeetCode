using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0074
{
    public class Solution0074_2 : Interface0074
    {
        /// <summary>
        /// 一次二分法
        /// 1. 将二维数组的索引映射为一个一维数组的索引
        ///     例如：int[row][col]:(row, col) --> row*width+col, id --> row=id/width, col=id%width
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int low = 0, high = matrix.Length * matrix[0].Length - 1, width = matrix[0].Length;
            int row, col, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                row = mid / width; col = mid % width;
                if (matrix[row][col] == target) return true;
                else if (matrix[row][col] < target) low = mid + 1;
                else high = mid - 1;
            }

            return false;
        }
    }
}
