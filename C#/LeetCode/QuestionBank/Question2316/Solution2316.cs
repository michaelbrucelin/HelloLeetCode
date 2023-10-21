using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2316
{
    public class Solution2316 : Interface2316
    {
        /// <summary>
        /// DFS
        /// 本质上就是找出各个连通子图中的顶点数量
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public long CountPairs(int n, int[][] edges)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            foreach (var arr in edges)
            {
                if (graph.ContainsKey(arr[0])) graph[arr[0]].Add(arr[1]); else graph.Add(arr[0], new List<int>() { arr[1] });
                if (graph.ContainsKey(arr[1])) graph[arr[1]].Add(arr[0]); else graph.Add(arr[1], new List<int>() { arr[0] });
            }

            bool[] visited = new bool[n];
            List<int> group = new List<int>();
            for (int i = 0, cnt; i < n; i++)
                if ((cnt = dfs(i, graph, visited)) > 0) group.Add(cnt);

            long result = 0;
            for (int i = 0; i < group.Count; i++) result += ((long)group[i]) * (n - group[i]);
            return result >> 1;
        }

        private int dfs(int start, Dictionary<int, List<int>> graph, bool[] visited)
        {
            if (visited[start]) return 0; visited[start] = true;
            if (!graph.ContainsKey(start)) return 1;

            int result = 1;
            foreach (int vid in graph[start]) if (!visited[vid])
                {
                    result += dfs(vid, graph, visited);
                }

            return result;
        }
    }
}
