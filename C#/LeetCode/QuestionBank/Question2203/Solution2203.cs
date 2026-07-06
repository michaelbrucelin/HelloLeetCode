using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2203
{
    public class Solution2203 : Interface2203
    {
        /// <summary>
        /// 枚举 + Dijkstra
        /// 枚举图中每个顶点V，答案一定在：(src1 -> V) + (src2 -> V) + (V -> dest) 中
        /// Dijkstra 计算 src1, src2, dest 为起点的所有最短路，注意计算 dest 为起点时，用的是反向图
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="src1"></param>
        /// <param name="src2"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public long MinimumWeight(int n, int[][] edges, int src1, int src2, int dest)
        {
            List<(int, int)>[] graph = new List<(int, int)>[n], graph2 = new List<(int, int)>[n];
            for (int i = 0; i < n; i++) { graph[i] = []; graph2[i] = []; }
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add((edge[1], edge[2])); graph2[edge[1]].Add((edge[0], edge[2]));
            }

            long[] s1 = dijkstra(n, graph, src1);
            long[] s2 = dijkstra(n, graph, src2);
            long[] dt = dijkstra(n, graph2, dest);
            if (s1[dest] == -1 || s2[dest] == -1) return -1;

            long result = s1[dest] + s2[dest];
            for (int i = 0; i < n; i++) if (s1[i] != -1 && s2[i] != -1 && dt[i] != -1) result = Math.Min(result, s1[i] + s2[i] + dt[i]);
            return result;

            static long[] dijkstra(int n, List<(int, int)>[] graph, int src)
            {
                long[] result = new long[n];
                Array.Fill(result, -1);
                PriorityQueue<(int, long), long> minpq = new PriorityQueue<(int, long), long>();
                minpq.Enqueue((src, 0), 0);
                int node; long weight;
                while (minpq.Count > 0)
                {
                    (node, weight) = minpq.Dequeue();
                    if (result[node] != -1) continue; result[node] = weight;
                    foreach ((int _node, int _weight) in graph[node]) if (result[_node] == -1) minpq.Enqueue((_node, weight + _weight), weight + _weight);
                }

                return result;
            }
        }
    }
}
