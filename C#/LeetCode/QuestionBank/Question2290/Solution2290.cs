using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2290
{
    public class Solution2290 : Interface2290
    {
        /// <summary>
        /// 贪心，BFS
        /// 1. 从起点起，可以走过的位置，结果全部为0，如果达到终点，结束
        /// 2. 所有为0相邻的位置，结果全部为1
        /// 3. 所有可以直接走过的位置，结果全部为1，  如果达到终点，结束
        /// 4. 所有为1相邻的位置，结果全部为2
        /// 5. ... ...
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumObstacles(int[][] grid)
        {
            int step = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            if (rcnt == 1)
            {
                for (int c = 1; c < ccnt; c++) step += grid[0][c];
                return step;
            }
            if (ccnt == 1)
            {
                for (int r = 1; r < rcnt; r++) step += grid[r][0];
                return step;
            }

            int[] dirs = [-1, 0, 1, 0, -1];
            int[,] dp = new int[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) dp[r, c] = -1;
            dp[0, 0] = dp[rcnt - 1, ccnt - 1] = 0;
            Queue<(int, int)> curr = new Queue<(int, int)>([(0, 0)]), next = new Queue<(int, int)>();
            int R, C, _r, _c;
            while (true)
            {
                while (curr.Count > 0)
                {
                    (R, C) = curr.Dequeue();
                    for (int i = 0; i < 4; i++)
                    {
                        _r = R + dirs[i]; _c = C + dirs[i + 1];
                        if (_r == rcnt - 1 && _c == ccnt - 1) goto END;
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && dp[_r, _c] == -1)
                        {
                            if (grid[_r][_c] == 0) { dp[_r, _c] = step; curr.Enqueue((_r, _c)); } else { dp[_r, _c] = step + 1; next.Enqueue((_r, _c)); }
                        }
                    }
                }
                step++;
                while (next.Count > 0) curr.Enqueue(next.Dequeue());
            }

        END:
            return step;
        }
    }
}
