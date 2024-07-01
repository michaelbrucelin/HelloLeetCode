using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2065
{
    public class Solution2065_3 : Interface2065
    {
        /// <summary>
        /// BFS + 状态压缩
        /// 由于BFS无法回溯，所以需要记录状态，这里使用8个Int128来记录状态
        /// </summary>
        /// <param name="values"></param>
        /// <param name="edges"></param>
        /// <param name="maxTime"></param>
        /// <returns></returns>
        public int MaximalPathQuality(int[] values, int[][] edges, int maxTime)
        {
            int n = values.Length, N = (int)Math.Ceiling(n / 128M);
            List<(int next, int time)>[] graph = new List<(int next, int time)>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<(int next, int time)>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2])); graph[edge[1]].Add((edge[0], edge[2]));
            }

            int result = 0, I1, I2;
            Int128[] stat = new Int128[N]; Int128 ONE;
            Queue<(int position, int point, int maxTime, Int128[] stat)> queue = new Queue<(int position, int point, int maxTime, Int128[] stat)>();
            queue.Enqueue((0, 0, maxTime, stat));
            int _position, _point, _maxTime; Int128[] _stat;
            while (queue.Count > 0)
            {
                (_position, _point, _maxTime, _stat) = queue.Dequeue();
                (I1, I2) = (_position / 128, _position % 128);
                if (((_stat[I1] >> I2) & 1) != 1)
                {
                    _point += values[_position]; _stat[I1] |= (ONE = 1) << I2;
                }
                if (_position == 0) result = Math.Max(result, _point);

                foreach (var info in graph[_position]) if (info.time <= _maxTime)
                    {
                        queue.Enqueue((info.next, _point, _maxTime - info.time, _stat.ToArray()));
                    }
            }

            return result;
        }
    }
}
