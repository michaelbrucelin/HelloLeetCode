using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2846
{
    public class Solution2846 : Interface2846
    {
        /// <summary>
        /// BFS
        /// 只要找出两个节点之间的路径，那么将全部权值改为出现频次最高的那个权值即可
        /// 先暴力BFS查找，看看时间复杂度，大概率会TLE
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例03、04
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
                result[i] = count_bfs(n, tree, weight, queries[i][0], queries[i][1]);

            return result;
        }

        private int count_bfs(int n, Dictionary<int, HashSet<int>> tree, Dictionary<(int n1, int n2), int> weights, int u, int v)
        {
            Queue<(int node, Dictionary<int, int> weights)> queue = new Queue<(int node, Dictionary<int, int> weights)>();
            queue.Enqueue((u, new Dictionary<int, int>()));
            bool[] visited = new bool[n]; visited[u] = true;
            int weight; (int node, Dictionary<int, int> weights) item = (-1, new Dictionary<int, int>());
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                if (tree[item.node].Contains(v))
                {
                    weight = weights[(item.node, v)];
                    if (item.weights.ContainsKey(weight)) item.weights[weight]++; else item.weights.Add(weight, 1);
                    break;
                }
                else
                {
                    foreach (int _v in tree[item.node]) if (!visited[_v])
                        {
                            Dictionary<int, int> _weights = new Dictionary<int, int>(item.weights);
                            weight = weights[(item.node, _v)];
                            if (_weights.ContainsKey(weight)) _weights[weight]++; else _weights.Add(weight, 1);
                            queue.Enqueue((_v, _weights));
                            visited[_v] = true;
                        }
                }
            }

            int cnt = 0, max = 0;
            foreach (int _cnt in item.weights.Values)
            {
                cnt += _cnt; max = Math.Max(max, _cnt);
            }

            return cnt - max;
        }
    }
}
