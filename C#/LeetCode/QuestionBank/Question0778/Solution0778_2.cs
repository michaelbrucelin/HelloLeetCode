using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0778
{
    public class Solution0778_2 : Interface0778
    {
        /// <summary>
        /// BFS
        /// 逻辑同Solution0778，每次不在BFS全部现有的区域，而是新探索的区域，即“边”
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int SwimInWater(int[][] grid)
        {
            if (grid.Length == 1) return 0;

            int n = grid.Length, m = grid.Length * grid.Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            HashSet<(int, int)> from = [(0, 0)], border = [(0, 0)];
            int result = Math.Max(n * 2 - 2, Math.Max(grid[0][0], grid[^1][^1])) - 1;
            while (++result < m)
            {
                HashSet<(int, int)> _border = [.. border];
                foreach ((int r, int c) in border) rec(_border, r, c);
                border = _border;
                if (border.Contains((n - 1, n - 1))) break;

                // 整理“边”
                bool flag;
                foreach ((int r, int c) item in border)
                {
                    flag = true;
                    for (int i = 0, _r, _c; i < 4; i++)
                    {
                        _r = item.r + dirs[i]; _c = item.c + dirs[i + 1];
                        if (!from.Contains((_r, _c)) && _r >= 0 && _r < n && _c >= 0 && _c < n) { flag = false; break; }
                    }
                    if (flag) border.Remove(item);
                }
            }

            return result;

            void rec(HashSet<(int, int)> set, int r, int c)
            {
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (!set.Contains((_r, _c)) && _r >= 0 && _r < n && _c >= 0 && _c < n && grid[_r][_c] <= result)
                    {
                        if (from.Add((_r, _c)))
                        {
                            set.Add((_r, _c));
                            rec(set, _r, _c);
                        }
                    }
                }
            }
        }
    }
}
