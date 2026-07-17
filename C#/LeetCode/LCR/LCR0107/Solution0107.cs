using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0107
{
    public class Solution0107 : Interface0107
    {
        /// <summary>
        /// 多源BFS
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[][] UpdateMatrix(int[][] mat)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            int[][] result = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) result[r] = new int[ccnt];
            int[] dirs = [-1, 0, 1, 0, -1];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    result[r][c] = -1;
                    if (mat[r][c] == 0) queue.Enqueue((r, c));
                }
            int step = 0, pr, pc;
            while (queue.Count > 0)
            {
                for (int i = queue.Count; i > 0; i--)
                {
                    (pr, pc) = queue.Dequeue();
                    if (result[pr][pc] != -1) continue;
                    result[pr][pc] = step;
                    for (int j = 0, _r, _c; j < 4; j++)
                    {
                        _r = pr + dirs[j]; _c = pc + dirs[j + 1];
                        if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt || result[_r][_c] != -1) continue;
                        queue.Enqueue((_r, _c));
                    }
                }
                step++;
            }

            return result;
        }
    }
}
