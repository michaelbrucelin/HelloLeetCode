using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2699
{
    public class Solution2699_err : Interface2699
    {
        /// <summary>
        /// 迪杰斯特拉
        /// 1. 重构边集数组，[a, b, w]
        ///     w != -1  -->  [a, b, w, false]
        ///     w ==  1  -->  [a, b, 1, true]
        /// 2. 使用迪杰斯特拉算法找出原点到目标的最短路径，并计算权重w
        /// 3. 分类讨论
        ///     w > target，无解
        ///     w = target，这条路径就是一个解
        ///     w < target
        ///         路径中存在可以调整（原始权重为-1）的边，调整任意一条边即可
        ///         路径中不存在可以调整（原始权重为-1）的边，无解
        /// 这里使用邻接表的形式解决
        /// 
        /// 逻辑是错误的，原因在于，如果有两条路径都的权重都小于target，
        /// 那么下面的代码只将最小的那条路径的权重调整到target，而题目的意思是全部权重小于target的路径都需要调整为大于等于target，且至少有一条等于target
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target)
        {
            Dictionary<int, Dictionary<int, (int weight, bool _if)>> _edges = new Dictionary<int, Dictionary<int, (int weight, bool _if)>>();
            for (int i = 0, s1 = 0, e1 = 0, s2 = 0, e2 = 0, w = 0; i < edges.Length; i++)
            {
                s1 = edges[i][0]; e1 = edges[i][1]; s2 = edges[i][1]; e2 = edges[i][0]; w = edges[i][2];
                if (!_edges.ContainsKey(s1)) _edges.Add(s1, new Dictionary<int, (int weight, bool _if)>());
                if (!_edges.ContainsKey(s2)) _edges.Add(s2, new Dictionary<int, (int weight, bool _if)>());
                if (w != -1)
                {
                    _edges[s1].Add(e1, (w, false)); _edges[s2].Add(e2, (w, false));
                }
                else
                {
                    _edges[s1].Add(e1, (1, true)); _edges[s2].Add(e2, (1, true)); edges[i][2] = 1;
                }
            }

            var info = Dijkstra(n, _edges, source, destination);
            if (info.weight > target) return new int[0][];
            if (info.weight == target) return edges;
            // if (info.weight < target)
            bool flag = true;  // true, 没有调整, false, 调整完毕
            int ptr = destination, _ptr;
            while (ptr != source)
            {
                _ptr = info.paths[ptr];
                if (_edges[_ptr][ptr]._if)
                {
                    for (int i = 0; i < edges.Length; i++)
                    {
                        if ((edges[i][0] == _ptr && edges[i][1] == ptr) || (edges[i][1] == _ptr && edges[i][0] == ptr))
                        {
                            edges[i][2] += target - info.weight; break;
                        }
                    }
                    flag = false; break;
                }
                ptr = _ptr;
            }
            if (flag) return new int[0][];
            return edges;
        }

        private (int weight, int[] paths) Dijkstra(int n, Dictionary<int, Dictionary<int, (int weight, bool _if)>> edges, int source, int destination)
        {
            int[] weights = new int[n]; Array.Fill(weights, -1);
            int[] paths = new int[n]; Array.Fill(paths, -1);
            bool[] visited = new bool[n];
            PriorityQueue<(int weight, int vid), int> minpq = new PriorityQueue<(int weight, int vid), int>();

            weights[source] = 0; paths[source] = source; minpq.Enqueue((0, source), 0);
            while (!visited[destination])
            {
                while (minpq.Count > 0 && visited[minpq.Peek().vid]) minpq.Dequeue();
                if (minpq.Count == 0) break;
                var next = minpq.Dequeue();
                visited[next.vid] = true;
                if (!edges.ContainsKey(next.vid)) continue;
                foreach (var kv in edges[next.vid])
                {
                    if (!visited[kv.Key])
                    {
                        int _weight = weights[next.vid] + kv.Value.weight;
                        if (weights[kv.Key] == -1 || _weight < weights[kv.Key])
                        {
                            weights[kv.Key] = _weight; paths[kv.Key] = next.vid; minpq.Enqueue((_weight, kv.Key), _weight);
                        }
                    }
                }
            }

            return (weights[destination], paths);
        }
    }
}
