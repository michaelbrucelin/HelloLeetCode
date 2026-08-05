using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1707
{
    public class Solution1707 : Interface1707
    {
        /// <summary>
        /// Hash(离散)版并查集
        /// </summary>
        /// <param name="names"></param>
        /// <param name="synonyms"></param>
        /// <returns></returns>
        public string[] TrulyMostPopular(string[] names, string[] synonyms)
        {
            Disjoint disjoint = new Disjoint();
            Dictionary<string, int> map = new Dictionary<string, int>();
            int idx = -1, len; string name;
            foreach (string str in names)
            {
                len = str.Length;
                for (int i = 1; i < len; i++) if (str[i] == '(') { idx = i; break; }
                name = str[0..idx];
                disjoint.Add(name);
                map.Add(name, int.Parse(str[(idx + 1)..(len - 1)]));
            }
            foreach (string str in synonyms)
            {
                len = str.Length;
                for (int i = 2; i < len; i++) if (str[i] == ',') { idx = i; break; }
                disjoint.Union(str[1..idx], str[(idx + 1)..(len - 1)]);
            }

            Dictionary<string, int> buffer = new Dictionary<string, int>();
            foreach (var kv in map)
            {
                name = disjoint.Find(kv.Key);
                if (buffer.TryGetValue(name, out int val)) buffer[name] += kv.Value; else buffer.Add(name, kv.Value);
            }

            string[] result = new string[buffer.Count];
            idx = 0;
            foreach (var kv in buffer) result[idx++] = $"{kv.Key}({kv.Value})";
            return result;
        }

        public class Disjoint
        {
            public Disjoint()
            {
                uf = new Dictionary<string, string>();
            }

            private Dictionary<string, string> uf;

            public void Add(string s)
            {
                if (!uf.ContainsKey(s)) uf.Add(s, s);
            }

            public void Union(string x, string y)
            {
                Add(x); Add(y);                       // 仅限于本题
                x = Find(x); y = Find(y);
                switch (string.CompareOrdinal(x, y))
                {
                    case > 0: uf[x] = y; break;
                    case < 0: uf[y] = x; break;
                    default: break;
                }
            }

            public string Find(string x)
            {
                string _x = x, fa;
                while (_x != uf[_x]) _x = uf[_x];
                fa = _x;
                while (uf[x] != fa)
                {
                    _x = x; x = uf[x]; uf[_x] = fa;
                }

                return fa;
            }
        }
    }
}
