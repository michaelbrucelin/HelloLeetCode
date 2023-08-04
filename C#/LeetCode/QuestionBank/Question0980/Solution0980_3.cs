using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0980
{
    public class Solution0980_3 : Interface0980
    {
        private static readonly int[] dirs = new int[] { -1, 0, 1, 0, -1 };

        /// <summary>
        /// 回溯，DFS，无返回值
        /// 看了官解才发现不复制数组这么简单，还是没理解透回溯，这里再实现一下
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int UniquePathsIII(int[][] grid)
        {
            int result = 0, step = 0, start_r = -1, start_c = -1, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] == 0) step++; if (grid[r][c] == 1) { start_r = r; start_c = c; }
                }
            dfs(grid, step, start_r, start_c, rcnt, ccnt, ref result);

            return result;
        }

        private void dfs(int[][] grid, int step, int r, int c, int rcnt, int ccnt, ref int result)
        {
            int _r, _c;
            if (step > 0) for (int i = 0; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 0)
                    {
                        grid[_r][_c] = -1;
                        dfs(grid, step - 1, _r, _c, rcnt, ccnt, ref result);
                        grid[_r][_c] = 0;
                    }
                }
            else for (int i = 0; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 2)
                    {
                        result++; break;
                    }
                }
        }
    }
}
