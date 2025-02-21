using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2617
{
    public class Solution2617 : Interface2617
    {
        /// <summary>
        /// BFS
        /// 逻辑没问题，但是TLE，参考测试用例06
        /// 
        /// 思考：为什么会TLE？
        ///       grid的每一项都会操作一次，事件复杂度为O(m*n)，每一项都需要向右与向下“走”，所以时间复杂度为O(m*n*(m+n))
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumVisitedCells(int[][] grid)
        {
            if (grid.Length == 1 && grid[0].Length == 1) return 1;

            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            queue.Enqueue((0, 0)); visited[0, 0] = true;
            int cnt; (int r, int c) item;
            while ((cnt = queue.Count) > 0)
            {
                result++;
                for (int i = 0, rlimit = 0, climit = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    rlimit = item.r + grid[item.r][item.c]; climit = item.c + grid[item.r][item.c];
                    if (rlimit >= rcnt - 1) { if (item.c == ccnt - 1) return result + 1; else rlimit = rcnt - 1; }
                    if (climit >= ccnt - 1) { if (item.r == rcnt - 1) return result + 1; else climit = ccnt - 1; }
                    for (int r = item.r + 1; r <= rlimit; r++) if (!visited[r, item.c])
                        {
                            visited[r, item.c] = true; if (grid[r][item.c] > 0) queue.Enqueue((r, item.c));
                        }
                    for (int c = item.c + 1; c <= climit; c++) if (!visited[item.r, c])
                        {
                            visited[item.r, c] = true; if (grid[item.r][c] > 0) queue.Enqueue((item.r, c));
                        }
                }
            }

            return -1;
        }
    }
}
