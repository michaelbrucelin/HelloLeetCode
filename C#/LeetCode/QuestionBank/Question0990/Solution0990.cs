using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0990
{
    public class Solution0990 : Interface0990
    {
        /// <summary>
        /// 并查集
        /// </summary>
        /// <param name="equations"></param>
        /// <returns></returns>
        public bool EquationsPossible(string[] equations)
        {
            int len = equations.Length;
            Disjoint disjoint = new Disjoint(26);
            List<int> list = [];
            for (int i = 0; i < len; i++) switch (equations[i][1])
                {
                    case '=': disjoint.Union(equations[i][0] - 'a', equations[i][3] - 'a'); break;
                    case '!': if (equations[i][0] == equations[i][3]) return false; else list.Add(i); break;
                    default: break;
                }
            for (int i = list.Count - 1; i >= 0; i--)
                if (disjoint.Find(equations[list[i]][0] - 'a') == disjoint.Find(equations[list[i]][3] - 'a')) return false;

            return true;
        }

        public class Disjoint
        {
            public Disjoint(int n)
            {
                father = new int[n];
                rank = new int[n];
                for (int i = 0; i < n; i++) father[i] = i;
            }

            private int[] father, rank;

            public int Find(int x)
            {
                int _x = x;
                while (father[_x] != _x) _x = father[_x];
                int fa = _x;
                while (father[x] != fa)
                {
                    _x = father[x]; father[x] = fa; x = _x;
                }

                return fa;
            }

            public bool Union(int x, int y)
            {
                x = Find(x); y = Find(y);
                if (x == y) return false;
                switch (rank[x] - rank[y])
                {
                    case > 0: father[y] = x; break;
                    case < 0: father[x] = y; break;
                    default: father[y] = x; rank[x]++; break;
                }

                return true;
            }
        }
    }
}
