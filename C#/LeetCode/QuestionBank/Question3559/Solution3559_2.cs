using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3559
{
    public class Solution3559_2 : Interface3559
    {
        /// <summary>
        /// 倒置的树的遍历
        /// 逻辑与Solution3559完全一样，添加了记忆化
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
        {
            int n = edges.Length + 1;
            List<int>[] graph = new List<int>[n + 1];
            for (int i = 1; i <= n; i++) graph[i] = [];
            foreach (int[] edge in edges) { graph[edge[0]].Add(edge[1]); graph[edge[1]].Add(edge[0]); }

            int[] fa = new int[n + 1]; fa[1] = -1;
            int[] rank = new int[n + 1];            // 记录节点的深度，后面找两个节点的最近公共祖先时，方便小驱动大
            int depth = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            while (queue.Count > 0)
            {
                depth++;
                for (int i = queue.Count, node; i > 0; i--)
                {
                    node = queue.Dequeue();
                    foreach (int next in graph[node])
                    {
                        if (fa[next] != 0) continue;
                        fa[next] = node; rank[next] = depth;
                        queue.Enqueue(next);
                    }
                }
            }

            int cnt, len = queries.Length;
            int[] result = new int[len];
            Dictionary<int, int> path = new Dictionary<int, int>();
            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();
            int[] quicksearch = new int[n + 1];
            for (int i = 0, u, v, _u, _v; i < len; i++)
            {
                if ((u = queries[i][0]) == (v = queries[i][1])) continue;
                if (rank[v] < rank[u]) (u, v) = (v, u);
                if (memory.TryGetValue((u, v), out int value)) { result[i] = value; continue; }
                (_u, _v) = (u, v); path.Clear(); depth = 0;
                path.Add(_u, 0);
                while (fa[_u] != -1) { path.Add(fa[_u], ++depth); _u = fa[_u]; }
                depth = 1;
                while (!path.ContainsKey(fa[_v])) { _v = fa[_v]; depth++; }
                cnt = path[fa[_v]] + depth - 1;
                if (quicksearch[cnt] == 0) quicksearch[cnt] = quickpow(cnt);
                memory.Add((u, v), quicksearch[cnt]);
                result[i] = quicksearch[cnt];
            }

            return result;

            static int quickpow(int x)
            {
                long result = 1, pow = 2;
                const int MOD = (int)1e9 + 7;
                while (x > 0)
                {
                    if ((x & 1) != 0) result = result * pow % MOD;
                    pow = pow * pow % MOD;
                    x >>= 1;
                }
                return (int)result;
            }
        }
    }
}
