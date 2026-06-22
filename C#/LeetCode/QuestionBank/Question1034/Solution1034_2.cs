using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1034
{
    public class Solution1034_2 : Interface1034
    {
        /// <summary>
        /// BFS
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
            Queue<(int, int)> queue = new Queue<(int, int)>();
            int[] dirs = [-1, 0, 1, 0, -1];
            bool[,] visited = new bool[rcnt, ccnt];
            queue.Enqueue((row, col));
            int r, c, _r, _c, COLOR = grid[row][col];
            while (queue.Count > 0)
            {
                (r, c) = queue.Dequeue();
                if (visited[r, c]) continue; visited[r, c] = true;
                for (int i = 0; i < 4; i++)
                {
                    (_r, _c) = (r + dirs[i], c + dirs[i + 1]);
                    if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt || grid[_r][_c] != COLOR)
                    {
                        buffer.Add((r, c));
                    }
                    else
                    {
                        if (!visited[_r, _c]) queue.Enqueue((_r, _c));
                    }
                }
            }

            foreach (var p in buffer) grid[p.Item1][p.Item2] = color;
            return grid;
        }
    }
}
