using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0059
{
    public class Solution0059 : Interface0059
    {
        private readonly static int[] dirs = [0, 1, 0, -1, 0];                                              // 方向增量
        private readonly static int[][] bors = [[1, 0, 0, 0], [0, 0, 0, -1], [0, -1, 0, 0], [0, 0, 1, 0]];  // 左右边界的增量

        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++) result[i] = new int[n];
            int r = 0, c = -1, val = 1, ptr = 0, _r, _c, r1 = 0, r2 = n - 1, c1 = 0, c2 = n - 1, limit = n * n;
            while (val <= limit)
            {
                _r = dirs[ptr]; _c = dirs[ptr + 1];
                while (true)
                {
                    if (r + _r < r1 || r + _r > r2 || c + _c < c1 || c + _c > c2) break;
                    result[r += _r][c += _c] = val++;
                }

                r1 += bors[ptr][0]; r2 += bors[ptr][1]; c1 += bors[ptr][2]; c2 += bors[ptr][3];
                ptr = ++ptr & 3;
            }

            return result;
        }
    }
}
