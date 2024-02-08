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
        /// 预处理每个节点到根节点的路径，那么从根开始沿着预处理好的路径向下找节点u, v，最后一个相同的节点，就是u, v的最近公共祖先
        /// 
        /// 更好的方式是找到更好的当作“根”的节点，使“根”到“每个叶子”节点都很近，这里没做这个优化
        /// 
        /// 速度快了很多，但是提交依然TLE，参考测试用例05
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
            List<int>[] paths = bfs(n, tree);

            int[] result = new int[queries.Length];
            Dictionary<int, int> path = new Dictionary<int, int>();
            for (int i = 0, j, u, v; i < queries.Length; i++)
            {
                j = 0; u = queries[i][0]; v = queries[i][1];
                path.Clear();
                while (j + 1 < paths[u].Count && j + 1 < paths[v].Count && paths[u][j + 1] == paths[v][j + 1]) j++;
                for (int k = j, _weight; k < paths[u].Count - 1; k++)
                {
                    _weight = weight[(paths[u][k], paths[u][k + 1])]; path.TryAdd(_weight, 0); path[_weight]++;
                }
                for (int k = j, _weight; k < paths[v].Count - 1; k++)
                {
                    _weight = weight[(paths[v][k], paths[v][k + 1])]; path.TryAdd(_weight, 0); path[_weight]++;
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

        private List<int>[] bfs(int n, Dictionary<int, HashSet<int>> tree)
        {
            List<int>[] paths = new List<int>[n];

            List<int> path = new List<int>() { 0 };
            Queue<(int v, List<int> path)> queue = new Queue<(int v, List<int> path)>();
            queue.Enqueue((0, path));
            bool[] visited = new bool[n]; (int v, List<int> path) item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                paths[item.v] = item.path; visited[item.v] = true;
                foreach (int _v in tree[item.v]) if (!visited[_v])
                    {
                        queue.Enqueue((_v, new List<int>(item.path) { _v }));
                    }
            }

            return paths;
        }
    }
}
