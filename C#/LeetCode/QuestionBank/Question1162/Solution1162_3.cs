using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1162
{
    public class Solution1162_3 : Interface1162
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxDistance(int[][] grid)
        {
            int n = grid.Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) if (grid[r][c] == 1) queue.Enqueue((r, c));
            if (queue.Count == 0 || queue.Count == n * n) return -1;

            int result = 0, cnt, _r, _c;
            bool flag;
            (int r, int c) point;
            while ((cnt = queue.Count) > 0)
            {
                flag = false;
                for (int i = 0; i < cnt; i++)
                {
                    point = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        _r = point.r + dirs[j]; _c = point.c + dirs[j + 1];
                        if (_r >= 0 && _r < n && _c >= 0 && _c < n && grid[_r][_c] == 0)
                        {
                            flag = true;
                            grid[_r][_c] = 2;
                            queue.Enqueue((_r, _c));
                        }
                    }
                }
                if (flag) result++;
            }

            return result;
        }
    }
}
