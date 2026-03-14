using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2658
{
    public class Solution2658_2 : Interface2658
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int FindMaxFish(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            bool[,] mask = new bool[rcnt, ccnt];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            int _result, R, C, _r, _c;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (grid[r][c] > 0 && !mask[r, c])
                    {
                        _result = 0;
                        queue.Enqueue((r, c));
                        while (queue.Count > 0)
                        {
                            (R, C) = queue.Dequeue();
                            if (mask[R, C]) continue;
                            _result += grid[R][C]; mask[R, C] = true;
                            for (int i = 0; i < 4; i++)
                            {
                                _r = R + dirs[i]; _c = C + dirs[i + 1];
                                if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && grid[_r][_c] > 0 && !mask[_r, _c]) queue.Enqueue((_r, _c));
                            }
                        }

                        result = Math.Max(result, _result);
                    }

            return result;
        }
    }
}
