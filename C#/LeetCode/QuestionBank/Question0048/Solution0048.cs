using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0048
{
    public class Solution0048 : Interface0048
    {
        /// <summary>
        /// 模拟，找规律
        /// 由外向内一层一层的旋转，假定某一圈边长为n，则 (r,c) 位置的值是原 (n-c, r) 位置的值
        /// 只需要旋转这些位置（X）即可，假定是一个 6*6 的矩阵
        /// X  X  X  X  X  _
        /// _  X  X  X  _  _
        /// _  _  X  _  _  _
        /// _  _  _  _  _  _
        /// _  _  _  _  _  _
        /// _  _  _  _  _  _
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length, layer = (matrix.Length - 1) >> 1, r, c, temp;
            for (int i = 0; i <= layer; i++) for (int j = i; j < n - i - 1; j++)  // 由外向内的第i层
                {
                    r = i; c = j; temp = matrix[i][j];
                    for (int k = 0; k < 3; k++)
                    {
                        matrix[r][c] = matrix[n - 1 - c][r]; (r, c) = (n - 1 - c, r);
                    }
                    matrix[r][c] = temp;
                }
        }
    }
}
