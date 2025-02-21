using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2846
{
    public class Solution2846_4 : Interface2846
    {
        /// <summary>
        /// 逻辑同Solution2846_3，这里预处理了根到每个节点的路径的边的权重分布情况，用来继续加速查询
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
            List<int>[] paths = new List<int>[n];
            Dictionary<int, int>[] pinfo = new Dictionary<int, int>[n];
            bfs(n, tree, weight, paths, pinfo);

            int[] result = new int[queries.Length];
            Dictionary<int, int> path = new Dictionary<int, int>();
            for (int i = 0, j = 0, u = 0, v = 0, p = 0; i < queries.Length; i++)
            {
                j = 0; u = queries[i][0]; v = queries[i][1];
                path.Clear();
                while (j + 1 < paths[u].Count && j + 1 < paths[v].Count && paths[u][j + 1] == paths[v][j + 1]) j++;
                foreach (int k in pinfo[u].Keys) { path.TryAdd(k, 0); path[k] += pinfo[u][k]; }
                foreach (int k in pinfo[v].Keys) { path.TryAdd(k, 0); path[k] += pinfo[v][k]; }
                foreach (int k in pinfo[p = paths[u][j]].Keys) { path[k] -= pinfo[p][k] << 1; }

                int cnt = 0, max = 0;
                foreach (int _cnt in path.Values)
                {
                    cnt += _cnt; max = Math.Max(max, _cnt);
                }

                result[i] = cnt - max;
            }

            return result;
        }

        private void bfs(int n, Dictionary<int, HashSet<int>> tree, Dictionary<(int n1, int n2), int> weight, List<int>[] paths, Dictionary<int, int>[] pinfo)
        {
            List<int> path = new List<int>() { 0 };
            Dictionary<int, int> info = new Dictionary<int, int>();
            Queue<(int v, List<int> path, Dictionary<int, int> info)> queue = new Queue<(int v, List<int> path, Dictionary<int, int> info)>();
            queue.Enqueue((0, path, info));
            bool[] visited = new bool[n]; (int v, List<int> path, Dictionary<int, int> info) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                paths[item.v] = item.path; pinfo[item.v] = item.info; visited[item.v] = true;
                foreach (int _v in tree[item.v]) if (!visited[_v])
                    {
                        List<int> _path = new List<int>(item.path) { _v };
                        Dictionary<int, int> _info = new Dictionary<int, int>(item.info);
                        int _weight = weight[(item.v, _v)]; _info.TryAdd(_weight, 0); _info[_weight]++;
                        queue.Enqueue((_v, _path, _info));
                    }
            }
        }
    }
}
