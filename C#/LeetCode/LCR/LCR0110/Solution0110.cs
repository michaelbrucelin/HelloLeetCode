using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0110
{
    public class Solution0110 : Interface0110
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int n = graph.Length;
            dfs(0, [0]);

            return result;

            void dfs(int node, List<int> path)
            {
                if (node == n - 1) { result.Add(path); return; }
                foreach (int next in graph[node]) dfs(next, [.. path, next]);
            }
        }

        /// <summary>
        /// 逻辑完全同AllPathsSourceTarget()，改为回溯
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTarget2(int[][] graph)
        {
            IList<IList<int>> result = new List<IList<int>>();
            int n = graph.Length;
            List<int> path = [0];
            backtrack(0);

            return result;

            void backtrack(int node)
            {
                if (node == n - 1) { result.Add([.. path]); return; }
                foreach (int next in graph[node])
                {
                    path.Add(next);
                    backtrack(next);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}
