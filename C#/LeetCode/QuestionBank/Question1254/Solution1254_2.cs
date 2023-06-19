using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1254
{
    public class Solution1254_2 : Interface1254
    {
        private static readonly (int r, int c)[] dirs = new (int r, int c)[] { (-1, 0), (0, 1), (1, 0), (0, -1) };

        /// <summary>
        /// DFS
        /// 封闭岛，即岛没有到达二维数组的边界
        /// 通过DFS来识别每个岛，识别过的位置改为-1
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ClosedIsland(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] != 0) continue;
                    if (DFS(grid, rcnt, ccnt, r, c)) result++;
                }

            return result;
        }

        private bool DFS(int[][] grid, int rcnt, int ccnt, int r, int c)
        {
            bool result = true;
            grid[r][c] = -1;
            if (r == 0 || r == rcnt - 1 || c == 0 || c == ccnt - 1) result = false;
            int _r, _c;
            for (int i = 0; i < 4; i++)
            {
                _r = r + dirs[i].r; _c = c + dirs[i].c;
                if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 0)
                {
                    if (!DFS(grid, rcnt, ccnt, _r, _c)) result = false;
                }
            }

            return result;
        }
    }
}
