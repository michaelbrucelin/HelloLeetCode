using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3567
{
    public class Solution3567 : Interface3567
    {
        /// <summary>
        /// 暴力
        /// 这道题有太多可以优化的点，但是看看数据量，感觉没必要，果然暴力就“双百”了
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] MinAbsDiff(int[][] grid, int k)
        {
            int rcnt = grid.Length - k + 1, ccnt = grid[0].Length - k + 1;
            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            if (k == 1) return result;

            int K = k * k;
            int[] buffer = new int[K];
            for (int r = 0, idx; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    idx = 0;
                    for (int _r = r, R = r + k; _r < R; _r++) for (int _c = c, C = c + k; _c < C; _c++) buffer[idx++] = grid[_r][_c];
                    Array.Sort(buffer);
                    if (buffer[0] == buffer[K - 1]) { result[r][c] = 0; continue; }
                    result[r][c] = int.MaxValue;
                    for (int i = 1; i < K; i++)
                    {
                        if (buffer[i] != buffer[i - 1]) result[r][c] = Math.Min(result[r][c], buffer[i] - buffer[i - 1]);
                    }
                }

            return result;
        }
    }
}
