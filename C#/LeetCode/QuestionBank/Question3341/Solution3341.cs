using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3341
{
    public class Solution3341 : Interface3341
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="moveTime"></param>
        /// <returns></returns>
        public int MinTimeToReach(int[][] moveTime)
        {
            int rcnt = moveTime.Length, ccnt = moveTime[0].Length;
            int[] dir = [0, 1, 0, -1, 0];
            int[,] time = new int[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) time[r, c] = int.MaxValue;
            time[0, 0] = 0;
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            queue.Enqueue((0, 0));
            (int r, int c) item;
            int _r, _c, _time;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    _r = item.r + dir[i]; _c = item.c + dir[i + 1];
                    if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt) continue;
                    _time = Math.Max(time[item.r, item.c], moveTime[_r][_c]) + 1;
                    if (_time < time[_r, _c])
                    {
                        time[_r, _c] = _time;
                        queue.Enqueue((_r, _c));
                    }
                }
            }

            return time[rcnt - 1, ccnt - 1];
        }
    }
}
