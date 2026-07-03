using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3970
{
    public class Solution3970 : Interface3970
    {
        /// <summary>
        /// Dijkstra
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="labels"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int ShortestPath(int n, int[][] edges, string labels, int k)
        {
            List<(int, int)>[] graph = new List<(int, int)>[n];
            for (int i = 0; i < n; i++) graph[i] = [];
            foreach (int[] edge in edges) graph[edge[0]].Add((edge[1], edge[2]));

            int[,] shorts = new int[n, k + 1];
            for (int i = 0; i < n; i++) for (int j = 0; j <= k; j++) shorts[i, j] = -1;
            // node, weight, lastchar, lastchar count
            PriorityQueue<(int, int, char, int), int> minpq = new PriorityQueue<(int, int, char, int), int>();
            minpq.Enqueue((0, 0, labels[0], 1), 0);
            int node, weight; char c; int cnt;
            while (minpq.Count > 0)
            {
                (node, weight, c, cnt) = minpq.Dequeue();
                if (shorts[node, cnt] != -1) continue; shorts[node, cnt] = weight;
                if (node == n - 1) return weight;
                foreach ((int next, int w) in graph[node])
                {
                    if (labels[next] == c)
                    {
                        if (cnt + 1 <= k && shorts[next, cnt + 1] == -1) minpq.Enqueue((next, weight + w, c, cnt + 1), weight + w);
                    }
                    else
                    {
                        if (shorts[next, 1] == -1) minpq.Enqueue((next, weight + w, labels[next], 1), weight + w);
                    }
                }
            }

            return -1;
        }
    }
}
