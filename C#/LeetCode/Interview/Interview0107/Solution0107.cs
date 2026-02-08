using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0107
{
    public class Solution0107 : Interface0107
    {
        /// <summary>
        /// 原地逐步替换
        /// 在纸上画一下就可以看出来 (r,c) 旋转后在 (c,n-r-1)
        /// 一圈一圈替换即可，假设起点是(r,c)，一圈的4个点分别为：(r,c) -> (c,n-r-1) -> (n-r-1,n-c-1) -> (n-c-1,r)
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length, cycle = matrix.Length >> 1;
            for (int r = 0, c1 = 0, c2 = n - 1, t; r <= cycle; r++, c1++, c2--) for (int c = c1; c < c2; c++)
                {
                    t = matrix[r][c];
                    matrix[r][c] = matrix[n - c - 1][r];
                    matrix[n - c - 1][r] = matrix[n - r - 1][n - c - 1];
                    matrix[n - r - 1][n - c - 1] = matrix[c][n - r - 1];
                    matrix[c][n - r - 1] = t;
                }
        }
    }
}
