using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1765
{
    public class Solution1765 : Interface1765
    {
        /// <summary>
        /// BFS
        /// 直接原地操作了
        /// </summary>
        /// <param name="isWater"></param>
        /// <returns></returns>
        public int[][] HighestPeak(int[][] isWater)
        {
            int rcnt = isWater.Length, ccnt = isWater[0].Length;
            int[] dirs = [-1, 0, 1, 0, -1];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    isWater[r][c]--;
                    if (isWater[r][c] == 0) queue.Enqueue((r, c));
                }

            int height = 0, cnt, R, C, _R, _C;
            while ((cnt = queue.Count) > 0)
            {
                height++;
                for (int i = 0; i < cnt; i++)
                {
                    (R, C) = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        _R = R + dirs[j]; _C = C + dirs[j + 1];
                        if (_R >= 0 && _R < rcnt && _C >= 0 && _C < ccnt && isWater[_R][_C] == -1)
                        {
                            isWater[_R][_C] = height;
                            queue.Enqueue((_R, _C));
                        }
                    }
                }
            }

            return isWater;
        }
    }
}
