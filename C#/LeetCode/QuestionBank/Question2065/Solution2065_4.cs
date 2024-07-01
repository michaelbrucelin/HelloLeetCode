using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2065
{
    public class Solution2065_4 : Interface2065
    {
        /// <summary>
        /// BFS
        /// 由于BFS无法回溯，所以需要记录状态，这里使用直接使用Hash表来记录状态，用数组也可以
        /// </summary>
        /// <param name="values"></param>
        /// <param name="edges"></param>
        /// <param name="maxTime"></param>
        /// <returns></returns>
        public int MaximalPathQuality(int[] values, int[][] edges, int maxTime)
        {
            int n = values.Length;
            List<(int next, int time)>[] graph = new List<(int next, int time)>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<(int next, int time)>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2])); graph[edge[1]].Add((edge[0], edge[2]));
            }

            int result = 0;
            HashSet<int> stat = new HashSet<int>();
            Queue<(int position, int point, int maxTime, HashSet<int> stat)> queue = new Queue<(int position, int point, int maxTime, HashSet<int> stat)>();
            queue.Enqueue((0, 0, maxTime, stat));
            int _position, _point, _maxTime; HashSet<int> _stat;
            while (queue.Count > 0)
            {
                (_position, _point, _maxTime, _stat) = queue.Dequeue();
                if (!_stat.Contains(_position))
                {
                    _point += values[_position]; _stat.Add(_position);
                }
                if (_position == 0) result = Math.Max(result, _point);

                foreach (var info in graph[_position]) if (info.time <= _maxTime)
                    {
                        queue.Enqueue((info.next, _point, _maxTime - info.time, new HashSet<int>(_stat)));
                    }
            }

            return result;
        }

        /// <summary>
        /// 同MaximalPathQuality()，只不过将Hash表改为数组，Hash很慢，试试数组
        /// 
        /// OLE, ... ...，参看测试用例06
        /// </summary>
        /// <param name="values"></param>
        /// <param name="edges"></param>
        /// <param name="maxTime"></param>
        /// <returns></returns>
        public int MaximalPathQuality2(int[] values, int[][] edges, int maxTime)
        {
            int n = values.Length;
            List<(int next, int time)>[] graph = new List<(int next, int time)>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<(int next, int time)>();
            foreach (var edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2])); graph[edge[1]].Add((edge[0], edge[2]));
            }

            int result = 0;
            bool[] stat = new bool[n];
            Queue<(int position, int point, int maxTime, bool[] stat)> queue = new Queue<(int position, int point, int maxTime, bool[] stat)>();
            queue.Enqueue((0, 0, maxTime, stat));
            int _position, _point, _maxTime; bool[] _stat;
            while (queue.Count > 0)
            {
                (_position, _point, _maxTime, _stat) = queue.Dequeue();
                if (!_stat[_position])
                {
                    _point += values[_position]; _stat[_position] = true;
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
