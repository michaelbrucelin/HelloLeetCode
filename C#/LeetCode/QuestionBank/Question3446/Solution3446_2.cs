using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3446
{
    public class Solution3446_2 : Interface3446
    {
        /// <summary>
        /// 原地插入排序
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] SortMatrix(int[][] grid)
        {
            if (grid.Length == 1) return grid;

            int n = grid.Length, t;
            for (int i = n - 2; i > 0; i--)
            {
                for (int c = i + 1, _c; c < n; c++)
                {
                    t = grid[c - i][c];
                    for (_c = c - 1; _c >= i && t < grid[_c - i][_c]; _c--) grid[_c - i + 1][_c + 1] = grid[_c - i][_c];
                    grid[_c - i + 1][_c + 1] = t;
                }
                for (int r = i + 1, _r; r < n; r++)
                {
                    t = grid[r][r - i];
                    for (_r = r - 1; _r >= i && t > grid[_r][_r - i]; _r--) grid[_r + 1][_r - i + 1] = grid[_r][_r - i];
                    grid[_r + 1][_r - i + 1] = t;
                }
            }
            for (int i = 1, _i; i < n; i++)
            {
                t = grid[i][i];
                for (_i = i - 1; _i >= 0 && t > grid[_i][_i]; _i--) grid[_i + 1][_i + 1] = grid[_i][_i];
                grid[_i + 1][_i + 1] = t;
            }

            return grid;
        }
    }
}
