using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3112
{
    public class Solution3112_err : Interface3112
    {
        /// <summary>
        /// BFS
        /// 
        /// 错误的，这属于暴力解，没理解好题意，这道题就是一个单源最短路问题，直接Dijkstra即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="disappear"></param>
        /// <returns></returns>
        public int[] MinimumTime(int n, int[][] edges, int[] disappear)
        {
            Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>() { { 0, new Dictionary<int, int>() } };
            for (int i = 0, _u = 0, _v = 0, _length; i < edges.Length; i++) if (edges[i][0] != edges[i][1])
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

            int[] result = new int[n]; Array.Fill(result, int.MaxValue);
            Queue<(int vertex, int time)> queue = new Queue<(int vertex, int time)>(); queue.Enqueue((0, 0));
            bool[] visited = new bool[n]; visited[0] = true;
            (int vertex, int time) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                if (item.time < disappear[item.vertex])
                {
                    result[item.vertex] = Math.Min(result[item.vertex], item.time);
                    visited[item.vertex] = true;
                    foreach (var kv in graph[item.vertex]) if (!visited[kv.Key])     // 能进来就能回去，顶点0已经做了预处理，所以不需要判断key是否存在
                        {
                            queue.Enqueue((kv.Key, item.time + kv.Value));
                        }
                }
            }
            for (int i = 0; i < n; i++) if (result[i] == int.MaxValue) result[i] = -1;

            return result;
        }
    }
}
