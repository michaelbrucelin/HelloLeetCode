using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0743
{
    public class Solution0743_2 : Interface0743
    {
        /// <summary>
        /// Dijkstra
        /// </summary>
        /// <param name="times"></param>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            List<(int vid, int weight)>[] graph = new List<(int vid, int weight)>[++n];
            for (int i = 1; i < n; i++) graph[i] = new List<(int vid, int weight)>();
            foreach (int[] edge in times) graph[edge[0]].Add((edge[1], edge[2]));

            (bool visit, int time)[] visited = new (bool visit, int time)[n];
            PriorityQueue<(int u, int v, int w), int> minpq = new PriorityQueue<(int u, int v, int w), int>();
            foreach (var next in graph[k]) minpq.Enqueue((k, next.vid, next.weight), next.weight);
            visited[k] = (true, 0);
            (int u, int v, int w) item;
            while (minpq.Count > 0)
            {
                item = minpq.Dequeue();
                if (visited[item.v].visit) continue;
                visited[item.v] = (true, item.w);
                foreach (var next in graph[item.v]) minpq.Enqueue((item.v, next.vid, item.w + next.weight), item.w + next.weight);
            }

            int result = 0;
            for (int i = 1; i < n; i++)
            {
                if (!visited[i].visit) return -1;
                result = Math.Max(result, visited[i].time);
            }
            return result;
        }
    }
}
