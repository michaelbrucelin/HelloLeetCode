using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1219
{
    public class Solution1219 : Interface1219
    {
        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int GetMaximumGold(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] != 0) backtrack(r, c, 0);

            return result;

            void backtrack(int r, int c, int total)
            {
                total += grid[r][c];
                int bt = grid[r][c];
                grid[r][c] = 0;
                bool flag = true;
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] != 0)
                    {
                        backtrack(_r, _c, total);
                    }
                }
                grid[r][c] = bt;
                if (flag) result = Math.Max(result, total);
            }
        }
    }
}
