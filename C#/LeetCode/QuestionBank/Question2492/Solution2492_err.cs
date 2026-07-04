using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2492
{
    public class Solution2492_err : Interface2492
    {
        /// <summary>
        /// Dijkstra
        /// 
        /// 都错题了，不是要总权重最小，而是路径中最小的权重
        /// </summary>
        /// <param name="n"></param>
        /// <param name="roads"></param>
        /// <returns></returns>
        public int MinScore(int n, int[][] roads)
        {
            List<(int, int)>[] graph = new List<(int, int)>[n + 1];
            for (int i = 1; i <= n; i++) graph[i] = [];
            foreach (int[] road in roads) { graph[road[0]].Add((road[1], road[2])); graph[road[1]].Add((road[0], road[2])); }

            int[] dij = new int[n + 1];
            Array.Fill(dij, -1);
            PriorityQueue<(int, int), int> minpq = new PriorityQueue<(int, int), int>();
            minpq.Enqueue((1, 0), 0);
            int node, dist;
            while (minpq.Count > 0)
            {
                (node, dist) = minpq.Dequeue();
                if (dij[node] != -1) continue; dij[node] = dist;
                if (node == n) break;
                foreach ((int next, int _dist) in graph[node])
                {
                    if (dij[next] != -1) continue;
                    minpq.Enqueue((next, dist + _dist), dist + _dist);
                }
            }

            return dij[n];
        }
    }
}
