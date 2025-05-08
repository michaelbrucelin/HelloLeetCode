using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3342
{
    public class Solution3342 : Interface3342
    {
        /// <summary>
        /// BFS
        /// 逻辑同Solution3341
        /// 
        /// 提交竟然通过了，以为会TLE，需要改成Dijkstra来实现呢
        /// </summary>
        /// <param name="moveTime"></param>
        /// <returns></returns>
        public int MinTimeToReach(int[][] moveTime)
        {
            int rcnt = moveTime.Length, ccnt = moveTime[0].Length;
            int[,] time = new int[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) time[r, c] = int.MaxValue;
            time[0, 0] = 0;
            int[] dirs = [0, 1, 0, -1, 0];

            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            queue.Enqueue((0, 0));
            (int r, int c) item;
            int cnt, _r, _c, _time, x = 1, y;
            while ((cnt = queue.Count) > 0)
            {
                x *= -1; y = (x + 3) >> 1;
                for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        _r = item.r + dirs[j]; _c = item.c + dirs[j + 1];
                        if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt) continue;
                        _time = Math.Max(time[item.r, item.c], moveTime[_r][_c]) + y;
                        if (_time < time[_r, _c])
                        {
                            time[_r, _c] = _time;
                            queue.Enqueue((_r, _c));
                        }
                    }
                }
            }

            return time[rcnt - 1, ccnt - 1];
        }
    }
}
