using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1202
{
    public class Solution1202 : Interface1202
    {
        /// <summary>
        /// 并查集 + 分组排序
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            int len = s.Length;
            Disjoint disjoint = new Disjoint(len);
            foreach (List<int> pair in pairs) disjoint.Union(pair[0], pair[1]);
            Dictionary<int, List<int>> groups = disjoint.Groups();

            char[] result = new char[len];
            List<char> group = [];
            foreach (List<int> idxs in groups.Values)
            {
                group.Clear();
                foreach (int idx in idxs) group.Add(s[idx]);
                group.Sort();
                idxs.Sort();
                for (int i = 0, cnt = idxs.Count; i < cnt; i++) result[idxs[i]] = group[i];
            }

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

            public Dictionary<int, List<int>> Groups()
            {
                Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();
                for (int i = 0, key; i < n; i++)
                {
                    key = Find(i);
                    if (result.TryGetValue(key, out List<int> list)) list.Add(i); else result.Add(key, [i]);
                }

                return result;
            }
        }
    }
}
