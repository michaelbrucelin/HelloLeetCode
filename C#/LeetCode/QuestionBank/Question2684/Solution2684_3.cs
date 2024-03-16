using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2684
{
    public class Solution2684_3 : Interface2684
    {
        /// <summary>
        /// BFS
        /// 没写完，心情不好，实在不想继续写了
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxMoves(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < rcnt; i++) queue.Enqueue(i);
            bool[] visited = new bool[rcnt];
            int[] offset = new int[] { -1, 0, 1 };
            int cnt, c = 0;
            while ((cnt = queue.Count) > 0)
            {
                if (++c >= ccnt) break;
                Array.Fill(visited, false);
                for (int i = 0, r; i < cnt; i++)
                {
                    r = queue.Dequeue();
                    for (int j = 0, _r; j < 3; j++)
                    {
                        _r = r + offset[j];
                        if (_r >= 0 && _r < rcnt && !visited[_r] && grid[_r][c - 1] < grid[r][c])
                        {
                            queue.Enqueue(r); visited[r] = true;
                        }
                    }
                }
            }

            return c - 1;
        }
    }
}
