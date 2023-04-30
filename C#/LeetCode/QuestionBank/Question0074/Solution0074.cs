using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0074
{
    public class Solution0074 : Interface0074
    {
        /// <summary>
        /// 两次二分法
        /// 1. 二分法找出目标元素可能所在的行
        /// 2. 二分法在可能的行中查找
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int low = 0, high = matrix.Length - 1, mid, row = -1;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (matrix[mid][0] == target) return true;
                else if (matrix[mid][0] < target) { row = mid; low = mid + 1; }
                else high = mid - 1;
            }
            if (row == -1) return false;

            low = 0; high = matrix[0].Length - 1;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (matrix[row][mid] == target) return true;
                else if (matrix[row][mid] < target) low = mid + 1;
                else high = mid - 1;
            }

            return false;
        }
    }
}
