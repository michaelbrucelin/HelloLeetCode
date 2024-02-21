using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0007
{
    public class Solution0007_2_2 : Interface0007
    {
        /// <summary>
        /// 有向图 + DFS
        /// 逻辑同Solution0007_2，只是将无返回值版改为了有返回值版
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

            return dfs(n, graph, 0, k);
        }

        private int dfs(int n, List<int>[] graph, int curr, int k)
        {
            if (k == 0) return curr == n - 1 ? 1 : 0;

            int result = 0;
            foreach (int next in graph[curr]) result += dfs(n, graph, next, k - 1);

            return result;
        }
    }
}
