using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0547
{
    public class Solution0547 : Interface0547
    {
        /// <summary>
        /// 并查集
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            Disjoint disjoint = new Disjoint(n);
            for (int i = 0; i < n; i++) for (int j = i + 1; j < n; j++) if (isConnected[i][j] == 1) disjoint.Union(i, j);
            return disjoint.Count;
        }

        public class Disjoint
        {
            public Disjoint(int n)
            {
                uf = new int[n];
                rank = new int[n];
                for (int i = 1; i < n; i++) uf[i] = i;
                count = n;
            }

            private int[] uf, rank;
            private int count;
            public int Count { get { return count; } }

            public bool Union(int x, int y)
            {
                if ((x = Find(x)) == (y = Find(y))) return false;
                switch (rank[x] - rank[y])
                {
                    case > 0: uf[y] = x; break;
                    case < 0: uf[x] = y; break;
                    default: uf[y] = x; rank[x]++; break;
                }

                count--;
                return true;
            }

            public int Find(int x)
            {
                int fa = x;
                while (uf[fa] != fa) fa = uf[fa];
                int _x = x;
                while (uf[x] != fa) { _x = uf[x]; uf[x] = fa; x = _x; }

                return fa;
            }
        }
    }
}
