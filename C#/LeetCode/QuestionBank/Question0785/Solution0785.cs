using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0785
{
    public class Solution0785 : Interface0785
    {
        /// <summary>
        /// BFS + 集合
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite(int[][] graph)
        {
            int n = graph.Length;
            List<int>[] _graph = new List<int>[n];
            for (int i = 0; i < n; i++) _graph[i] = [];
            for (int i = 0; i < n; i++) foreach (int j in graph[i]) { _graph[i].Add(j); _graph[j].Add(i); }

            int[] group = new int[n];                                // 0 未分组, 1 1组, 2 2组
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++) if (group[i] == 0)
                {
                    queue.Enqueue(i);
                    while (queue.Count > 0)
                    {
                        for (int j = queue.Count, node; j > 0; j--)
                        {
                            node = queue.Dequeue();
                            if (group[node] == 0) group[node] = 1;   // 新的连通分量
                            foreach (int next in _graph[node])
                            {
                                if (group[next] == group[node]) return false;
                                if (group[next] == 3 - group[node]) continue;
                                group[next] = 3 - group[node];
                                queue.Enqueue(next);
                            }
                        }
                    }
                }

            return true;
        }
    }
}
