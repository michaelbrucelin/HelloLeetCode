using LeetCode.QuestionBank.Question0001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2846
{
    public class Solution2846_3 : Interface2846
    {
        /// <summary>
        /// BFS
        /// 本质上依然与Solution2846逻辑一样，但是在Solution2846中有大量重复的运算，
        /// 这里随便找一个点做为“根”，预处理出来“根”到每个“叶子”节点的信息。
        /// 数据结构，每个节点，预处理：1. 该节点的父节点，HashSet<int>
        ///                             2. 根到该节点路径的权值及其频次，Dictionary<int, int>
        /// 
        /// 更好的方式是找到更好的当作“根”的节点，使“根”到“每个叶子”节点都很近，这里没做这个优化
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

            HashSet<int>[] parents = new HashSet<int>[n];
            Dictionary<int, int>[] paths = new Dictionary<int, int>[n];
            bfs(n, tree, weight, parents, paths);

            int[] result = new int[queries.Length];
            Dictionary<int, int> path = new Dictionary<int, int>();
            for (int i = 0, u, v; i < queries.Length; i++)
            {
                u = queries[i][0]; v = queries[i][1];
                path.Clear();
                if (parents[u].Contains(v))
                {
                    foreach (var kv in paths[u]) path.Add(kv.Key, kv.Value);
                    foreach (var kv in paths[v]) path[kv.Key] -= kv.Value;
                }
                else if (parents[v].Contains(u))
                {
                    foreach (var kv in paths[v]) path.Add(kv.Key, kv.Value);
                    foreach (var kv in paths[u]) path[kv.Key] -= kv.Value;
                }
                else
                {
                    foreach (var kv in paths[u]) path.Add(kv.Key, kv.Value);
                    foreach (var kv in paths[v])
                        if (path.ContainsKey(kv.Key)) path[kv.Key] += kv.Value; else path.Add(kv.Key, kv.Value);
                }

                int cnt = 0, max = 0;
                foreach (int _cnt in path.Values)
                {
                    cnt += _cnt; max = Math.Max(max, _cnt);
                }

                result[i] = cnt - max;
            }

            return result;
        }

        private void bfs(int n, Dictionary<int, HashSet<int>> tree, Dictionary<(int n1, int n2), int> weight, HashSet<int>[] parents, Dictionary<int, int>[] paths)
        {
            HashSet<int> parent = new HashSet<int>();
            Dictionary<int, int> path = new Dictionary<int, int>();
            Queue<(int v, HashSet<int> parent, Dictionary<int, int> path)> queue = new Queue<(int v, HashSet<int> parent, Dictionary<int, int> path)>();
            queue.Enqueue((0, parent, path));
            bool[] visited = new bool[n];
            int _weight; (int v, HashSet<int> parent, Dictionary<int, int> path) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                parents[item.v] = item.parent; paths[item.v] = item.path; visited[item.v] = true;
                foreach (int _v in tree[item.v]) if (!visited[_v])
                    {
                        HashSet<int> _parent = new HashSet<int>(item.parent) { item.v };
                        Dictionary<int, int> _path = new Dictionary<int, int>(item.path);
                        _weight = weight[(item.v, _v)];
                        if (_path.ContainsKey(_weight)) _path[_weight]++; else _path.Add(_weight, 1);
                        queue.Enqueue((_v, _parent, _path));
                    }
            }
        }
    }
}
