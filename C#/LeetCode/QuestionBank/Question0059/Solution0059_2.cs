using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0059
{
    public class Solution0059_2 : Interface0059
    {
        private readonly static int[] dirs = [0, 1, 0, -1, 0];

        /// <summary>
        /// 模拟
        /// 逻辑与Solution0059完全一样，不需要维护左右边界，通过矩阵对应位置是否为0就知道边界了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++) result[i] = new int[n];
            int r = 0, c = -1, val = 1, ptr = 0, _r, _c, limit = n * n;
            while (val <= limit)
            {
                _r = dirs[ptr]; _c = dirs[ptr + 1];
                while (true)
                {
                    if (r + _r < 0 || r + _r >= n || c + _c < 0 || c + _c >= n) break;
                    if (result[r + _r][c + _c] > 0) break;
                    result[r += _r][c += _c] = val++;
                }

                ptr = ++ptr & 3;
            }

            return result;
        }
    }
}
