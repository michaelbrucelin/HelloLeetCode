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
            Disjoint disjoint = new Disjoint(n);
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = [];
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]); graph[edge[1]].Add(edge[0]); disjoint.union(edge[0], edge[1]);
            }

            Dictionary<int, List<int>> group = new Dictionary<int, List<int>>();
            for (int i = 0, key; i < n; i++)
            {
                key = disjoint.find(i);
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
        }

        public class Disjoint
        {
            public Disjoint(int n)
            {
                uf = new int[n];
                rank = new int[n];
                for (int i = 0; i < n; i++) uf[i] = i;
            }

            private int[] uf;
            private int[] rank;

            public void union(int x, int y)
            {
                x = find(x); y = find(y);
                if (x == y) return;
                switch (rank[x] - rank[y])
                {
                    case < 0: uf[x] = y; break;
                    case > 0: uf[y] = x; break;
                    default: uf[y] = x; rank[x]++; break;
                }
            }

            public int find(int x)
            {
                if (uf[x] != x) uf[x] = find(uf[x]);
                return uf[x];
            }
        }
    }
}
