using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3493
{
    public class Solution3493 : Interface3493
    {
        /// <summary>
        /// 并查集
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumberOfComponents(int[][] properties, int k)
        {
            int n = properties.Length;
            DisjointSet disjoint = new DisjointSet(n);
            HashSet<int>[] sets = new HashSet<int>[n];
            for (int i = 0; i < n; i++) sets[i] = [.. properties[i]];
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++)
                {
                    if (sets[i].Intersect(sets[j]).Count() >= k) disjoint.Union(i, j);
                }

            return disjoint.Count;
        }

        public class DisjointSet
        {
            public DisjointSet(int n)
            {
                Count = n;
                uf = new int[n];
                rank = new int[n];
                for (int i = 0; i < n; i++) uf[i] = i;
            }

            public int Count;
            private int[] uf, rank;

            public bool Union(int x, int y)
            {
                x = Find(x); y = Find(y);
                if (x == y) return false;
                Count--;
                switch (rank[x] - rank[y])
                {
                    case > 0: uf[y] = x; break;
                    case < 0: uf[x] = y; break;
                    default: uf[y] = x; rank[x]++; break;
                }

                return true;
            }

            public int Find(int x)
            {
                int fa = x;
                while (uf[fa] != fa) fa = uf[fa];
                int tmp;
                while (uf[x] != fa) { tmp = uf[x]; uf[x] = fa; x = tmp; }
                return fa;
            }
        }
    }
}
