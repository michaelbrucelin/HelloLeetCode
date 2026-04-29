using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2492
{
    public class Solution2492_3 : Interface2492
    {
        /// <summary>
        /// 并查集
        /// 逻辑同Solution2492，将DFS改为并查集
        /// </summary>
        /// <param name="n"></param>
        /// <param name="roads"></param>
        /// <returns></returns>
        public int MinScore(int n, int[][] roads)
        {
            List<(int, int)>[] graph = new List<(int, int)>[n + 1];
            int[] uf = new int[n + 1];
            int[] rank = new int[n + 1];
            for (int i = 1; i <= n; i++) { graph[i] = []; uf[i] = i; }
            foreach (int[] road in roads)
            {
                graph[road[0]].Add((road[1], road[2])); graph[road[1]].Add((road[0], road[2]));
                union(road[0], road[1]);
            }

            int result = int.MaxValue, fa = find(1);
            for (int i = 1; i <= n; i++) if (find(i) == fa)
                {
                    for (int j = 0, cnt = graph[i].Count; j < cnt; j++) result = Math.Min(result, graph[i][j].Item2);
                }

            return result;

            int find(int x)
            {
                if (uf[x] != x) uf[x] = find(uf[x]);
                return uf[x];
            }

            void union(int x, int y)
            {
                x = find(x); y = find(y);
                if (x == y) return;
                switch (rank[x] - rank[y])
                {
                    case > 0: uf[y] = x; break;
                    case < 0: uf[x] = y; break;
                    default: uf[y] = x; rank[x]++; break;
                }
            }
        }
    }
}
