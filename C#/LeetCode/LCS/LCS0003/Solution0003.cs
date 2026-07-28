using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCS.LCS0003
{
    public class Solution0003 : Interface0003
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int LargestArea(string[] grid)
        {
            if (grid.Length < 3 || grid[0].Length < 3) return 0;

            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            bool[,] visited = new bool[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] != '0' && !visited[r, c])
                    {
                        (bool, int) info = dfs(r, c);
                        if (info.Item1) result = Math.Max(result, info.Item2);
                    }

            return result;

            (bool, int) dfs(int r, int c)
            {
                if (visited[r, c]) return (true, 0);
                visited[r, c] = true;
                bool flag = true; int cnt = 1;
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt || grid[_r][_c] == '0')
                    {
                        flag = false;
                    }
                    else if (grid[_r][_c] == grid[r][c])
                    {
                        (bool, int) info = dfs(_r, _c);
                        if (!info.Item1) flag = false;
                        cnt += info.Item2;
                    }
                }

                return (flag, cnt);
            }
        }
    }
}
