using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3240
{
    public class Solution3240_err : Interface3240
    {
        /// <summary>
        /// 分类讨论
        /// 易错题，具体分析见Solution3240_err.md
        /// 
        /// 逻辑没错，理解错了，题目要求所有行和列都回文，这里的逻辑是所有行回文或所有列回文。
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinFlips(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int result_r = 0, cnt_r = 0, result_c = 0, cnt_c = 0, cnt_m;  // cnt_m, cnt_middle

            // 保证所有行回文
            for (int r = 0, limit = ccnt >> 1; r < rcnt; r++) for (int c = 0; c < limit; c++)
                {
                    if (grid[r][c] != grid[r][ccnt - c - 1]) result_r++;
                    cnt_r += grid[r][c] + grid[r][ccnt - c - 1];
                }
            cnt_m = 0;
            if ((ccnt & 1) == 1) for (int r = 0; r < rcnt; r++) cnt_m += grid[r][ccnt >> 1];
            cnt_r %= 4; cnt_m %= 4;
            switch ((cnt_m, result_r, cnt_r))
            {
                case (0, > 0, _): break;
                case (0, 0, 0): break;
                case (0, 0, _): result_r = 2; break;
                case (1, > 0, _): result_r++; break;
                case (1, 0, 0): result_r = 1; break;
                case (1, 0, _): result_r = 3; break;
                case (2, > 0, _): break;
                case (2, 0, 0): result_r = 2; break;
                case (2, 0, _): break;
                case (3, > 0, _): result_r += rcnt > 3 ? 1 : 3; break;
                case (3, 0, 0): result_r = rcnt > 3 ? 1 : 3; break;
                case (3, 0, _): result_r = 1; break;
                default: throw new Exception("logic error.");
            }

            // 保证所有列回文
            for (int c = 0, limit = rcnt >> 1; c < ccnt; c++) for (int r = 0; r < limit; r++)
                {
                    if (grid[r][c] != grid[rcnt - r - 1][c]) result_c++;
                    cnt_c += grid[r][c] + grid[rcnt - r - 1][c];
                }
            cnt_m = 0;
            if ((rcnt & 1) == 1) for (int c = 0; c < ccnt; c++) cnt_m += grid[rcnt >> 1][c];
            cnt_c %= 4; cnt_m %= 4;
            switch ((cnt_m, result_c, cnt_c))
            {
                case (0, > 0, _): break;
                case (0, 0, 0): break;
                case (0, 0, _): result_c = 2; break;
                case (1, > 0, _): result_c++; break;
                case (1, 0, 0): result_c = 1; break;
                case (1, 0, _): result_c = 3; break;
                case (2, > 0, _): break;
                case (2, 0, 0): result_c = 2; break;
                case (2, 0, _): break;
                case (3, > 0, _): result_c += ccnt > 3 ? 1 : 3; break;
                case (3, 0, 0): result_c = rcnt > 3 ? 1 : 3; break;
                case (3, 0, _): result_c = 1; break;
                default: throw new Exception("logic error.");
            }

            return Math.Min(result_r, result_c);
        }
    }
}
