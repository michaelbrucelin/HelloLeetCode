using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0778
{
    public class Solution0778 : Interface0778
    {
        /// <summary>
        /// BFS
        /// 由于每个单元格的值都不同，分布为[0..n*n-1]，所以结果至少为2n-2
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int SwimInWater(int[][] grid)
        {
            if (grid.Length == 1) return 0;

            int n = grid.Length, m = grid.Length * grid.Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            HashSet<(int, int)> from = [(0, 0)];
            int result = Math.Max(n * 2 - 2, Math.Max(grid[0][0], grid[^1][^1])) - 1;
            while (++result < m)
            {
                HashSet<(int, int)> _from = [.. from];
                foreach ((int r, int c) in from) rec(_from, r, c);
                from = _from;
                if (from.Contains((n - 1, n - 1))) break;
            }

            return result;

            void rec(HashSet<(int, int)> set, int r, int c)
            {
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (!set.Contains((_r, _c)) && _r >= 0 && _r < n && _c >= 0 && _c < n && grid[_r][_c] <= result)
                    {
                        set.Add((_r, _c));
                        rec(set, _r, _c);
                    }
                }
            }
        }
    }
}
