using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3643
{
    public class Solution3643 : Interface3643
    {
        /// <summary>
        /// 模拟
        /// 扫描一次
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length, rsum = x + x + k - 1;
            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++)
            {
                result[r] = new int[ccnt];
                for (int c = 0; c < ccnt; c++)
                {
                    result[r][c] = (r >= x && r < x + k && c >= y && c < y + k) ? grid[rsum - r][c] : grid[r][c];
                }
            }

            return result;
        }
    }
}
