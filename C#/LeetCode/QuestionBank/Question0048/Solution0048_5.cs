using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0048
{
    public class Solution0048_5 : Interface0048
    {
        /// <summary>
        /// 两轮反转
        /// 先延主对角线反转，再左右反转
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int r = 0, t; r < n; r++) for (int c = r + 1; c < n; c++)
                {
                    t = matrix[r][c]; matrix[r][c] = matrix[c][r]; matrix[c][r] = t;
                }
            for (int r = 0, t; r < n; r++) for (int c1 = 0, c2 = n - 1; c1 < c2; c1++, c2--)
                {
                    t = matrix[r][c1]; matrix[r][c1] = matrix[r][c2]; matrix[r][c2] = t;
                }
        }
    }
}
