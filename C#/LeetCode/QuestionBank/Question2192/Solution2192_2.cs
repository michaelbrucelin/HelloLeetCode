using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2192
{
    public class Solution2192_2 : Interface2192
    {
        /// <summary>
        /// DFS
        /// 逻辑与Solution2192一样，只是将HashSet换成了基础的数组
        ///     这样做稀疏图的话会严重增加空间复杂度，但是会优化排序带来的时间复杂度
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public IList<IList<int>> GetAncestors(int n, int[][] edges)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            foreach (var edge in edges) graph[edge[1]].Add(edge[0]);

            bool[] visited = new bool[n];
            bool[,] cache = new bool[n, n];
            for (int i = 0; i < n; i++) dfs(graph, n, i, cache, visited);

            List<int>[] result = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = new List<int>();
                for (int j = 0; j < n; j++) if (cache[i, j]) result[i].Add(j);
            }
            return result;
        }

        private void dfs(List<int>[] graph, int n, int v, bool[,] cache, bool[] visited)
        {
            if (visited[v]) return;
            foreach (int _v in graph[v])
            {
                cache[v, _v] = true;
                if (!visited[_v]) dfs(graph, n, _v, cache, visited);
                for (int i = 0; i < n; i++) if (cache[_v, i]) cache[v, i] = true;
            }
            visited[v] = true;
        }
    }
}
