using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0048
{
    public class Solution0048_2 : Interface0048
    {
        /// <summary>
        /// 位运算
        /// 本质上就是开辟了另一个空间，但是借助位运算，可以“原地”开辟另一个空间
        /// 1. 由于 -1000 <= matrix[i][j] <= 1000, matrix[i][j] += 1000  -->  [0, 2000], 11个二进制位可以容纳
        /// 2. 将每个位置的新值存放在原值的第12-23位
        /// 3. 将每个位置的值右移11位，即变更为新值
        /// 4. 将每个位置的值 -= 1000
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) matrix[r][c] += 1000;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) matrix[r][c] |= (matrix[n - 1 - c][r] & 2047) << 11;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) matrix[r][c] >>= 11;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) matrix[r][c] -= 1000;
        }
    }
}
