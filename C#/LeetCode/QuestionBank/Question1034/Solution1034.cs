using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1034
{
    public class Solution1034 : Interface1034
    {
        /// <summary>
        /// DFS
        /// 原地更改
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public int[][] ColorBorder(int[][] grid, int row, int col, int color)
        {
            if (grid[row][col] == color) return grid;

            int rcnt = grid.Length, ccnt = grid[0].Length;
            List<(int, int)> buffer = new List<(int, int)>();
            int[] dirs = [-1, 0, 1, 0, -1];
            bool[,] visited = new bool[rcnt, ccnt];
            int COLOR = grid[row][col];
            dfs(row, col);

            foreach (var p in buffer) grid[p.Item1][p.Item2] = color;
            return grid;

            void dfs(int r, int c)
            {
                int _r, _c;
                if (visited[r, c]) return; visited[r, c] = true;
                for (int i = 0; i < 4; i++)
                {
                    (_r, _c) = (r + dirs[i], c + dirs[i + 1]);
                    if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt || grid[_r][_c] != COLOR)
                    {
                        buffer.Add((r, c));
                    }
                    else
                    {
                        if (!visited[_r, _c]) dfs(_r, _c);
                    }
                }
            }
        }
    }
}
