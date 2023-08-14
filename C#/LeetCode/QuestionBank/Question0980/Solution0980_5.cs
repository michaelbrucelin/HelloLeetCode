using LeetCode.QuestionBank.Question0001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0980
{
    public class Solution0980_5 : Interface0980
    {
        private static readonly int[] dirs = new int[] { -1, 0, 1, 0, -1 };

        /// <summary>
        /// 回溯，DFS，记忆化搜索
        /// 同Solution0980_4，借助状态压缩实现记忆化搜索（棋盘中最多有20个格子）
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int UniquePathsIII(int[][] grid)
        {
            int step = 0, start_r = -1, start_c = -1, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] == 0) step++; if (grid[r][c] == 1) { start_r = r; start_c = c; }
                }
            Dictionary<(int state, int r, int c), int> cache = new Dictionary<(int state, int r, int c), int>();

            return dfs(grid, step, 0, start_r, start_c, rcnt, ccnt, cache);
        }

        private int dfs(int[][] grid, int step, int state, int r, int c, int rcnt, int ccnt, Dictionary<(int state, int r, int c), int> cache)
        {
            if (cache.ContainsKey((state, r, c))) return cache[(state, r, c)];

            int result = 0, _r, _c, _state;
            if (step > 0) for (int i = 0; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 0)
                    {
                        _state = state | (1 << (_r * ccnt + _c));
                        grid[_r][_c] = -1;
                        result += dfs(grid, step - 1, _state, _r, _c, rcnt, ccnt, cache);
                        grid[_r][_c] = 0;
                    }
                }
            else for (int i = 0; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 2)
                    {
                        result = 1; break;
                    }
                }
            cache.Add((state, r, c), result);

            return result;
        }
    }
}
