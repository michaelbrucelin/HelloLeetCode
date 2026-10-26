using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0695
{
    public class Solution0695_2 : Interface0695
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxAreaOfIsland(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            int[] dirs = [-1, 0, 1, 0, -1];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] != 0 && !visited[r, c])
                    {
                        result = Math.Max(result, bfs(r, c));
                    }

            return result;

            int bfs(int r, int c)
            {
                int area = 0;
                queue.Enqueue((r, c));
                while (queue.Count > 0)
                {
                    (r, c) = queue.Dequeue();
                    if (visited[r, c]) continue;
                    visited[r, c] = true;
                    area++;
                    for (int i = 0, _r, _c; i < 4; i++)
                    {
                        _r = r + dirs[i]; _c = c + dirs[i + 1];
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] != 0 && !visited[_r, _c]) queue.Enqueue((_r, _c));
                    }
                }

                return area;
            }
        }
    }
}
