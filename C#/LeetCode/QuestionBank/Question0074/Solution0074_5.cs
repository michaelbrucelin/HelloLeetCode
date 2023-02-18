using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0074
{
    public class Solution0074_5 : Interface0074
    {
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
