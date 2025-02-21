using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3112
{
    public class Solution3112 : Interface3112
    {
        /// <summary>
        /// Dijkstra
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="disappear"></param>
        /// <returns></returns>
        public int[] MinimumTime(int n, int[][] edges, int[] disappear)
        {
            Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>() { { 0, new Dictionary<int, int>() } };
            for (int i = 0, _u = 0, _v = 0, _length = 0; i < edges.Length; i++) if (edges[i][0] != edges[i][1])
                {
                    (_u, _v, _length) = (edges[i][0], edges[i][1], edges[i][2]);
                    if (!graph.ContainsKey(_u))
                    {
                        graph.Add(_u, new Dictionary<int, int>() { { _v, _length } });
                    }
                    else
                    {
                        if (graph[_u].ContainsKey(_v)) graph[_u][_v] = Math.Min(graph[_u][_v], _length); else graph[_u].Add(_v, _length);
                    }
                    if (!graph.ContainsKey(_v))
                    {
                        graph.Add(_v, new Dictionary<int, int>() { { _u, _length } });
                    }
                    else
                    {
                        if (graph[_v].ContainsKey(_u)) graph[_v][_u] = Math.Min(graph[_v][_u], _length); else graph[_v].Add(_u, _length);
                    }
                }

            int[] result = Dijkstra();
            for (int i = 0; i < n; i++) if (result[i] == int.MaxValue) result[i] = -1;

            return result;

            int[] Dijkstra()
            {
                int[] weights = new int[n]; Array.Fill(weights, int.MaxValue);
                bool[] visited = new bool[n]; int visitcnt = 0;
                PriorityQueue<(int weight, int vid), int> minpq = new PriorityQueue<(int weight, int vid), int>();
                weights[0] = 0; minpq.Enqueue((0, 0), 0);

                (int weight, int vid) next;
                while (visitcnt < n && minpq.Count > 0)
                {
                    while (minpq.Count > 0 && visited[minpq.Peek().vid]) minpq.Dequeue();
                    if (minpq.Count == 0) break;
                    next = minpq.Dequeue();
                    visited[next.vid] = true; visitcnt++; if (visitcnt == n) break;
                    foreach (var kv in graph[next.vid]) if (!visited[kv.Key])
                        {
                            int _weight = weights[next.vid] + kv.Value;
                            if (_weight < disappear[kv.Key] && _weight < weights[kv.Key])
                            {
                                weights[kv.Key] = _weight; minpq.Enqueue((_weight, kv.Key), _weight);
                            }
                        }
                }

                return weights;
            }
        }
    }
}
