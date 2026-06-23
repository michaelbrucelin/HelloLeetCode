using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2039
{
    public class Solution2039 : Interface2039
    {
        /// <summary>
        /// BFS
        /// BFS找出节点0到其余节点的距离，然后分别计算每个节点的时间即可
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="patience"></param>
        /// <returns></returns>
        public int NetworkBecomesIdle(int[][] edges, int[] patience)
        {
            int n = patience.Length;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = [];
            foreach (int[] edge in edges) { graph[edge[0]].Add(edge[1]); graph[edge[1]].Add(edge[0]); }

            int[] distances = new int[n];
            Array.Fill(distances, -1);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            int node, distance = 0;
            while (queue.Count > 0)
            {
                for (int i = queue.Count; i > 0; i--)
                {
                    node = queue.Dequeue();
                    if (distances[node] != -1) continue;
                    distances[node] = distance;
                    foreach (int next in graph[node]) queue.Enqueue(next);
                }
                distance++;
            }

            int result = 0;
            for (int i = 1, dist; i < n; i++)
            {
                dist = distances[i] << 1;
                int last = ((dist - 1) / patience[i]) * patience[i];
                result = Math.Max(result, last + dist + 1);
            }

            return result;
        }
    }
}
