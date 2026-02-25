using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0797
{
    public class Solution0797 : Interface0797
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            // if (graph.Length < 2) return [];  // 题目限定图不少于两个节点

            int n = graph.Length;
            IList<IList<int>> result = [];
            dfs([0]);
            return result;

            void dfs(List<int> path)
            {
                if (path[^1] == n - 1) { result.Add(path); return; }
                foreach (int next in graph[path[^1]]) dfs([.. path, next]);
            }
        }

        /// <summary>
        /// 逻辑同AllPathsSourceTarget()，改为回溯
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTarget2(int[][] graph)
        {
            // if (graph.Length < 2) return [];  // 题目限定图不少于两个节点

            int n = graph.Length;
            IList<IList<int>> result = [];
            List<int> path = [0];
            backtrack();
            return result;

            void backtrack()
            {
                if (path[^1] == n - 1) { result.Add([.. path]); return; }
                foreach (int next in graph[path[^1]])
                {
                    path.Add(next);
                    backtrack();
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}
