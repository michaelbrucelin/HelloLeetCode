using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2467
{
    public class Solution2467_2 : Interface2467
    {
        /// <summary>
        /// 模拟
        /// 逻辑完全同Solution2467，Solution2467原则上操作的是图，这里先给还原为树，然后再处理
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="bob"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int MostProfitablePath(int[][] edges, int bob, int[] amount)
        {
            int n = edges.Length + 1;
            HashSet<int>[] tree = new HashSet<int>[n];
            for (int i = 0; i < n; i++) tree[i] = [];
            foreach (int[] edge in edges) { tree[edge[0]].Add(edge[1]); tree[edge[1]].Add(edge[0]); }
            int[] fa = new int[n];  // 记录父节点
            dfs(0);

            int result = int.MinValue, cnt, node, score, _score, pbob = bob; bool isleaf;
            Queue<(int, int)> queue = new Queue<(int, int)>(); queue.Enqueue((0, 0));
            while ((cnt = queue.Count) > 0)
            {
                amount[pbob] >>= 1;
                for (int i = 0; i < cnt; i++)
                {
                    (node, score) = queue.Dequeue();
                    _score = score + amount[node];
                    isleaf = true;
                    foreach (int next in tree[node])
                    {
                        queue.Enqueue((next, _score));
                        isleaf = false;
                    }
                    if (isleaf) result = Math.Max(result, _score);
                }
                amount[pbob] = 0; pbob = fa[pbob];
            }

            return result;

            void dfs(int node)
            {
                foreach (int next in tree[node])  // if (next != fa[node])
                {
                    fa[next] = node; tree[next].Remove(node); dfs(next);
                }
            }
        }
    }
}
