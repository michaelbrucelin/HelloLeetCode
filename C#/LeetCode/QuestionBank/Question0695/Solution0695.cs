using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0695
{
    public class Solution0695 : Interface0695
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxAreaOfIsland(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            int[] dirs = [-1, 0, 1, 0, -1];
            int area;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] != 0 && !visited[r, c])
                    {
                        area = 0;
                        dfs(r, c, ref area);
                        result = Math.Max(result, area);
                    }

            return result;

            void dfs(int r, int c, ref int area)
            {
                if (grid[r][c] == 0 || visited[r, c]) return;
                area++;
                visited[r, c] = true;
                for (int i = 0, _r, _c; i < 4; i++)
                {
                    _r = r + dirs[i]; _c = c + dirs[i + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt) dfs(_r, _c, ref area);
                }
            }
        }
    }
}
