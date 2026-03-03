using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2685
{
    public class Solution2685 : Interface2685
    {
        /// <summary>
        /// DFS
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
            for (int i = 0; i < n; i++) if (!visited[i])
                {
                    (ncnt, ecnt) = dfs(i);
                    if (ncnt * (ncnt - 1) == ecnt) result++;
                }

            return result;

            (int, int) dfs(int x)
            {
                int ncnt = 1, ecnt = graph[x].Count;
                visited[x] = true;
                int _ncnt, _ecnt;
                foreach (int y in graph[x]) if (!visited[y])
                    {
                        (_ncnt, _ecnt) = dfs(y);
                        ncnt += _ncnt; ecnt += _ecnt;
                    }

                return (ncnt, ecnt);
            }
        }
    }
}
