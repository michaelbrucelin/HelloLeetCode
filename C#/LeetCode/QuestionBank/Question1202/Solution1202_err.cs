using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1202
{
    public class Solution1202_err : Interface1202
    {
        /// <summary>
        /// 并查集 + 自定义排序
        /// 
        /// 逻辑不对，索引变了，不能保证原有的分组了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            int len = s.Length;
            Disjoint disjoint = new Disjoint(len);
            foreach (List<int> pair in pairs) disjoint.Union(pair[0], pair[1]);

            char[] result = new char[len];
            int[] idxs = new int[len];
            for (int i = 0; i < len; i++) idxs[i] = i;
            Comparer<int> comparer = Comparer<int>.Create((x, y) => disjoint.Find(x) == disjoint.Find(y) ? s[x] - s[y] : x - y);
            Array.Sort(idxs, comparer);
            for (int i = 0; i < len; i++) result[i] = s[idxs[i]];

            return new string(result);
        }

        public class Disjoint
        {
            public Disjoint(int n)
            {
                this.n = n;
                father = new int[n];
                rank = new int[n];
                for (int i = 0; i < n; i++) father[i] = i;
            }

            private int n;
            private int[] father, rank;

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

            public int Find(int x)
            {
                int _x = x;
                while (father[_x] != _x) _x = father[_x];
                int fa = _x;
                while (father[x] != x)
                {
                    _x = father[x]; father[x] = fa; x = _x;
                }

                return fa;
            }
        }
    }
}
