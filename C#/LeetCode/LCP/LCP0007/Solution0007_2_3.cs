using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0007
{
    public class Solution0007_2_3 : Interface0007
    {
        /// <summary>
        /// 有向图 + DFS
        /// 逻辑同Solution0007_2_2，只是添加了记忆化搜索
        /// </summary>
        /// <param name="n"></param>
        /// <param name="relation"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumWays(int n, int[][] relation, int k)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            foreach (var arr in relation) graph[arr[0]].Add(arr[1]);
            Dictionary<(int curr, int k), int> cache = new Dictionary<(int curr, int k), int>();

            return dfs(n, graph, 0, k, cache);
        }

        private int dfs(int n, List<int>[] graph, int curr, int k, Dictionary<(int curr, int k), int> cache)
        {
            if (k == 0) return curr == n - 1 ? 1 : 0;

            if (!cache.ContainsKey((curr, k)))
            {
                int result = 0;
                foreach (int next in graph[curr]) result += dfs(n, graph, next, k - 1, cache);
                cache.Add((curr, k), result);
            }

            return cache[(curr, k)];
        }
    }
}
