using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2846
{
    public class Solution2846_2 : Interface2846
    {
        /// <summary>
        /// 与Solution2846逻辑一样，时间复杂度也一样，只是将bfs改为了dfs+回溯
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] MinOperationsQueries(int n, int[][] edges, int[][] queries)
        {
            Dictionary<int, HashSet<int>> tree = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; i++) tree.Add(i, new HashSet<int>());
            Dictionary<(int n1, int n2), int> weight = new Dictionary<(int n1, int n2), int>();
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]); weight.Add((edge[0], edge[1]), edge[2]);
                tree[edge[1]].Add(edge[0]); weight.Add((edge[1], edge[0]), edge[2]);
            }

            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                result[i] = count_dfs(n, tree, weight, queries[i][0], queries[i][1]);

            return result;
        }

        private int count_dfs(int n, Dictionary<int, HashSet<int>> tree, Dictionary<(int n1, int n2), int> weights, int u, int v)
        {
            Dictionary<int, int> path = new Dictionary<int, int>();
            bool flag = false;
            dfs(n, tree, weights, -1, u, v, path, ref flag);

            int cnt = 0, max = 0;
            foreach (int _cnt in path.Values)
            {
                cnt += _cnt; max = Math.Max(max, _cnt);
            }

            return cnt - max;
        }

        private void dfs(int n, Dictionary<int, HashSet<int>> tree, Dictionary<(int n1, int n2), int> weights, int last, int curr, int v, Dictionary<int, int> path, ref bool flag)
        {
            int weight;
            foreach (int _v in tree[curr]) if (_v != last)
                {
                    weight = weights[(curr, _v)];
                    if (path.ContainsKey(weight)) path[weight]++; else path.Add(weight, 1);
                    if (_v == v) { flag = true; return; }
                    dfs(n, tree, weights, curr, _v, v, path, ref flag);
                    if (flag) return;
                    path[weight]--;
                }
        }
    }
}
