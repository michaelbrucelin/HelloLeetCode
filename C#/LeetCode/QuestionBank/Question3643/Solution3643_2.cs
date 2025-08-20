using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3643
{
    public class Solution3643_2 : Interface3643
    {
        /// <summary>
        /// 模拟
        /// 原地交换
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
        {
            int rsum = x + x + k - 1, temp;
            for (int c = y; c < y + k; c++) for (int r = x; r < x + (k >> 1); r++)
                {
                    temp = grid[r][c]; grid[r][c] = grid[rsum - r][c]; grid[rsum - r][c] = temp;
                }

            return grid;
        }
    }
}
