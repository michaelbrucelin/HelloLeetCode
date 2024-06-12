using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0048
{
    public class Solution0048_3 : Interface0048
    {
        /// <summary>
        /// 两次翻转
        /// 先水平翻转，再沿着对角线翻转即可
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int r1 = 0, r2 = n - 1; r1 < r2; r1++, r2--) for (int c = 0; c < n; c++)
                {
                    (matrix[r1][c], matrix[r2][c]) = (matrix[r2][c], matrix[r1][c]);
                }
            for (int r = 0; r < n; r++) for (int c = r + 1; c < n; c++)
                {
                    (matrix[r][c], matrix[c][r]) = (matrix[c][r], matrix[r][c]);
                }
        }
    }
}
