using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3239
{
    public class Solution3239 : Interface3239
    {
        /// <summary>
        /// 暴力枚举
        /// 这题只要暴力枚举一种方式吧？那样就是简单题
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinFlips(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int result_r = 0, result_c = 0;

            // 保证所有行回文
            for (int r = 0, limit = ccnt >> 1; r < rcnt; r++) for (int c = 0; c < limit; c++)
                {
                    if (grid[r][c] != grid[r][ccnt - c - 1]) result_r++;
                }

            // 保证所有列回文
            for (int c = 0, limit = rcnt >> 1; c < ccnt; c++) for (int r = 0; r < limit; r++)
                {
                    if (grid[r][c] != grid[rcnt - r - 1][c]) result_c++;
                }

            return Math.Min(result_r, result_c);
        }
    }
}
