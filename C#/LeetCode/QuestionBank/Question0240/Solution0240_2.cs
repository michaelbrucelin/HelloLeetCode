using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0240
{
    public class Solution0240_2 : Interface0240
    {
        /// <summary>
        /// 双指针
        /// 使用两个指针，row, col
        /// row从第一行开始，逐行向下遍历，col从最后一列逐列向前遍历
        ///     如果matrix[row_i][col_i] > target && matrix[row_i][col_i-1] < target
        ///     那么遍历第row_i+1行时，col直接从col_i-1开始向前遍历
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int row = -1, col = matrix[0].Length - 1;
            while (++row < matrix.Length && col >= 0)
            {
                while (col >= 0 && matrix[row][col] > target) col--;
                if (col >= 0 && matrix[row][col] == target) return true;
            }

            return false;
        }
    }
}
