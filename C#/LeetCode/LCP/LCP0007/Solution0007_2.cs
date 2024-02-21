using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0007
{
    public class Solution0007_2 : Interface0007
    {
        /// <summary>
        /// 有向图 + DFS
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

            int result = 0;
            dfs(n, graph, 0, k, ref result);

            return result;
        }

        private void dfs(int n, List<int>[] graph, int curr, int k, ref int result)
        {
            if (k == 0) { if (curr == n - 1) result++; return; }

            k--;
            foreach (int next in graph[curr]) dfs(n, graph, next, k, ref result);
        }
    }
}
