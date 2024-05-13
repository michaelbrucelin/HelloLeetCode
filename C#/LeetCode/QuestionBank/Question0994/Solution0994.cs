using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0994
{
    public class Solution0994 : Interface0994
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int OrangesRotting(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length, freshCnt = 0;
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] == 1) freshCnt++; else if (grid[r][c] == 2) queue.Enqueue((r, c));
                }
            if (freshCnt == 0) return 0;
            if (queue.Count == 0) return -1;

            int[] dirs = [-1, 0, 1, 0, -1];
            int result = 0, cnt, _r, _c; (int r, int c) item; bool flag;
            while ((cnt = queue.Count) > 0)
            {
                flag = false;
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        _r = item.r + dirs[j]; _c = item.c + dirs[j + 1];
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] == 1)
                        {
                            grid[_r][_c] = 2; freshCnt--; queue.Enqueue((_r, _c)); flag = true;
                        }
                    }
                }
                if (flag) result++;
            }

            return freshCnt == 0 ? result : -1;
        }
    }
}
