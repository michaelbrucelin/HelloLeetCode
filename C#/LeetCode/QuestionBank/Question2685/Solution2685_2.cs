using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2685
{
    public class Solution2685_2 : Interface2685
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int CountCompleteComponents(int n, int[][] edges)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = [];
            foreach (int[] edge in edges) { graph[edge[0]].Add(edge[1]); graph[edge[1]].Add(edge[0]); }
            bool[] visited = new bool[n];

            int result = 0, ncnt, ecnt;
            Queue<int> queue = new Queue<int>();
            for (int i = 0, j; i < n; i++) if (!visited[i])
                {
                    queue.Enqueue(i);
                    ncnt = ecnt = 0;
                    while (queue.Count > 0)
                    {
                        j = queue.Dequeue();
                        if (visited[j]) continue;
                        visited[j] = true;
                        ncnt++; ecnt += graph[j].Count;
                        foreach (int next in graph[j]) if (!visited[next]) queue.Enqueue(next);
                    }
                    if (ncnt * (ncnt - 1) == ecnt) result++;
                }

            return result;
        }
    }
}
