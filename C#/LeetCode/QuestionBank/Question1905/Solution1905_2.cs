using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1905
{
    public class Solution1905_2 : Interface1905
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid1"></param>
        /// <param name="grid2"></param>
        /// <returns></returns>
        public int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            int result = 0, rcnt = grid1.Length, ccnt = grid1[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            int[] dirs = [-1, 0, 1, 0, -1];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid2[r][c] != 0 && !visited[r, c])
                    {
                        if (bfs(r, c)) result++;
                    }

            return result;

            bool bfs(int r, int c)
            {
                bool flag = true;
                queue.Enqueue((r, c));
                while (queue.Count > 0)
                {
                    (r, c) = queue.Dequeue();
                    if (visited[r, c]) continue;
                    flag = flag && grid1[r][c] == 1;
                    visited[r, c] = true;
                    for (int i = 0, _r, _c; i < 4; i++)
                    {
                        _r = r + dirs[i]; _c = c + dirs[i + 1];
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid2[_r][_c] != 0 && !visited[_r, _c]) queue.Enqueue((_r, _c));
                    }
                }

                return flag;
            }
        }
    }
}
