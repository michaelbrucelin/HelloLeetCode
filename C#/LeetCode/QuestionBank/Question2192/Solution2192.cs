using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2192
{
    public class Solution2192 : Interface2192
    {
        /// <summary>
        /// DFS
        /// 反向构建图，然后dfs查找即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public IList<IList<int>> GetAncestors(int n, int[][] edges)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            foreach (var edge in edges) graph[edge[1]].Add(edge[0]);

            HashSet<int>[] cache = new HashSet<int>[n];
            for (int i = 0; i < n; i++) dfs(graph, i, cache);

            List<int>[] result = new List<int>[n];
            for (int i = 0; i < n; i++) result[i] = cache[i].OrderBy(x => x).ToList();
            return result;
        }

        private void dfs(List<int>[] graph, int v, HashSet<int>[] cache)
        {
            if (cache[v] != null) return;
            cache[v] = new HashSet<int>();
            foreach (int _v in graph[v])
            {
                cache[v].Add(_v);
                if (cache[_v] == null) dfs(graph, _v, cache);
                cache[v].UnionWith(cache[_v]);
            }
        }
    }
}
