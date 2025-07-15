using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0200
{
    public class Solution0200 : Interface0200
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];                     // 可以直接将grid中的 1 更新为 0，这样就不需要使用visited了
            int[] dirs = [-1, 0, 1, 0, -1];
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] != '0' && !visited[r, c])
                    {
                        result++;
                        queue.Enqueue((r, c));
                        bfs();
                    }

            return result;

            void bfs()
            {
                int _r, _c; (int r, int c) item;
                while (queue.Count > 0)
                {
                    item = queue.Dequeue();
                    if (visited[item.r, item.c]) continue;
                    visited[item.r, item.c] = true;
                    for (int j = 0; j < 4; j++)
                    {
                        _r = item.r + dirs[j]; _c = item.c + dirs[j + 1];
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt)
                        {
                            if (grid[_r][_c] != '0' && !visited[_r, _c]) queue.Enqueue((_r, _c));
                        }
                    }
                }
            }
        }
    }
}
