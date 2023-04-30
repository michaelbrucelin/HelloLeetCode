using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0463
{
    public class Solution0463 : Interface0463
    {
        /// <summary>
        /// 暴力解
        /// 从上向下，从左到右逐个方格遍历
        ///     如果方格为1，结果+4
        ///         如果上方方格为1，结果-2，如果左侧方格为1，结果-2
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int IslandPerimeter(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        result += 4;
                        if (r > 0 && grid[r - 1][c] == 1) result -= 2;
                        if (c > 0 && grid[r][c - 1] == 1) result -= 2;
                    }
                }

            return result;
        }

        /// <summary>
        /// 与IslandPerimeter()逻辑一样
        /// 但是先判断第一个方格，然后遍历第一行，然后遍历第一列，最后遍历其余的方格
        /// 这样不用判断越界问题
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int IslandPerimeter2(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            if (grid[0][0] == 1) result += 4;
            for (int c = 1; c < ccnt; c++) if (grid[0][c] == 1) result += grid[0][c - 1] != 1 ? 4 : 2;
            for (int r = 1; r < rcnt; r++) if (grid[r][0] == 1) result += grid[r - 1][0] != 1 ? 4 : 2;
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        result += 4;
                        if (grid[r - 1][c] == 1) result -= 2;
                        if (grid[r][c - 1] == 1) result -= 2;
                    }
                }

            return result;
        }
    }
}
