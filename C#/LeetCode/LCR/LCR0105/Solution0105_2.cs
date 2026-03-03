using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0105
{
    public class Solution0105_2 : Interface0105
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxAreaOfIsland(int[][] grid)
        {
            int result = 0, _result, rcnt = grid.Length, ccnt = grid[0].Length;
            // if (rcnt == 1 && ccnt == 1) || if (rcnt == 1) || if (ccnt == 1)

            int[] dirs = [-1, 0, 1, 0, -1];
            bool[,] visited = new bool[rcnt, ccnt];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            int R, C;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1 && !visited[r, c])
                    {
                        _result = 0;
                        queue.Enqueue((r, c));
                        while (queue.Count > 0)
                        {
                            (R, C) = queue.Dequeue();
                            if (visited[R, C]) continue;
                            _result++; visited[R, C] = true;
                            for (int i = 0, _r, _c; i < 4; i++)
                            {
                                _r = R + dirs[i]; _c = C + dirs[i + 1];
                                if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 1 && !visited[_r, _c]) queue.Enqueue((_r, _c));
                            }
                        }
                        result = Math.Max(result, _result);
                    }

            return result;
        }
    }
}
