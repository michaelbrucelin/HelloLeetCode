using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2368
{
    public class Solution2368_off_2 : Interface2368
    {
        public int ReachableNodes(int n, int[][] edges, int[] restricted)
        {
            HashSet<int> set = new HashSet<int>(restricted);
            if (set.Contains(0)) return 0;

            UnionFind uf = new UnionFind(n);
            foreach (var edge in edges)
            {
                if (set.Contains(edge[0]) || set.Contains(edge[1])) continue;
                uf.Union(edge[0], edge[1]);
            }

            return uf.GetSize(uf.Find(0));
        }

        public class UnionFind
        {
            public UnionFind(int n)
            {
                parents = new int[n];
                for (int i = 0; i < n; i++) parents[i] = i;
                sizes = new int[n];
                Array.Fill(sizes, 1);
            }

            private int[] parents;
            private int[] sizes;

            public int Find(int x)
            {
                if (parents[x] == x)
                {
                    return x;
                }
                else
                {
                    parents[x] = Find(parents[x]);
                    return parents[x];
                }
            }

            public void Union(int x, int y)
            {
                int rx = Find(x), ry = Find(y);
                if (rx != ry)
                {
                    if (sizes[rx] > sizes[ry])
                    {
                        parents[ry] = rx;
                        sizes[rx] += sizes[ry];
                    }
                    else
                    {
                        parents[rx] = ry;
                        sizes[ry] += sizes[rx];
                    }
                }
            }

            public int GetSize(int x)
            {
                return sizes[x];
            }
        }
    }
}
