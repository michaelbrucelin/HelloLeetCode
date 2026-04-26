using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1559
{
    public class Solution1559 : Interface1559
    {
        /// <summary>
        /// DFS
        /// DFS找出相连的相同字母，顺便找圈
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool ContainsCycle(char[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            bool[,] visited = new bool[rcnt, ccnt];
            HashSet<(int, int)> group = new HashSet<(int, int)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (!visited[r, c])
                    {
                        group.Clear();
                        if (dfs(grid[r][c], r, c, -1, -1)) return true;
                    }

            return false;

            bool dfs(char C, int r, int c, int _r, int _c)  // (_r,_c)记录(r,c)前一个位置，不往回走
            {
                if (r < 0 || r >= rcnt || c < 0 || c >= ccnt || grid[r][c] != C) return false;
                visited[r, c] = true;
                if (group.Contains((r, c))) return true;
                group.Add((r, c));
                for (int i = 0; i < 4; i++) if (r + dirs[i] != _r || c + dirs[i + 1] != _c)
                    {
                        if (dfs(C, r + dirs[i], c + dirs[i + 1], r, c)) return true;
                    }
                return false;
            }
        }
    }
}
