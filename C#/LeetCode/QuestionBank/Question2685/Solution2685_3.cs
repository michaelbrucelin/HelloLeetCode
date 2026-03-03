using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2685
{
    public class Solution2685_3 : Interface2685
    {
        /// <summary>
        /// 并查集
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int CountCompleteComponents(int n, int[][] edges)
        {
            int[] uf = new int[n], uf_h = new int[n];
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) { uf[i] = i; graph[i] = []; }
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]); graph[edge[1]].Add(edge[0]); union(edge[0], edge[1]);
            }

            Dictionary<int, List<int>> group = new Dictionary<int, List<int>>();
            for (int i = 0, key; i < n; i++)
            {
                key = find(i);
                if (group.TryGetValue(key, out var list)) list.Add(i); else group.Add(key, [i]);
            }

            int result = 0;
            foreach (var list in group.Values)
            {
                foreach (int i in list) if (graph[i].Count != list.Count - 1) goto CONTINUE;
                result++;
            CONTINUE:;
            }

            return result;

            void union(int x, int y)
            {
                x = find(x); y = find(y);
                switch (uf_h[x] - uf_h[y])
                {
                    case < 0: uf[x] = y; break;
                    case > 0: uf[y] = x; break;
                    default: uf[y] = x; uf_h[x]++; break;
                }
            }

            int find(int x)
            {
                if (uf[x] != x) uf[x] = find(uf[x]);
                return uf[x];
            }
        }
    }
}
