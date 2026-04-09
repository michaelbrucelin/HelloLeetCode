using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0117
{
    public class Solution0117_2 : Interface0117
    {
        /// <summary>
        /// disjoint
        /// 感觉会TLE
        /// 
        /// 提交竟然通过了，没有TLE...
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int NumSimilarGroups(string[] strs)
        {
            HashSet<string> set = [];
            List<string> list = [];
            foreach (string str in strs) if (set.Add(str)) list.Add(str);
            Dictionary<string, string> uf = new Dictionary<string, string>();
            Dictionary<string, int> rank = new Dictionary<string, int>();
            foreach (string str in list) { uf.Add(str, str); rank.Add(str, 0); }
            int cnt = list.Count, len = strs[0].Length;
            for (int i = 0, _cnt; i < cnt; i++) for (int j = i + 1; j < cnt; j++) if (find(list[i]) != find(list[j]))
                    {
                        _cnt = 0;
                        for (int k = 0; k < len && _cnt < 3; k++) if (list[i][k] != list[j][k]) _cnt++;
                        if (_cnt < 3) union(list[i], list[j]);
                    }

            // set.Clear();
            // foreach (string str in strs) set.Add(find(str));
            // return set.Count;
            int result = 0;
            foreach (string key in uf.Keys) if (uf[key] == key) result++;
            return result;

            void union(string s1, string s2)
            {
                s1 = find(s1); s2 = find(s2);
                if (rank[s1] == rank[s2])
                {
                    uf[s2] = s1; rank[s1]++;
                }
                else
                {
                    if (rank[s1] > rank[s2]) uf[s2] = s1; else uf[s1] = s2;
                }
            }

            string find(string s)
            {
                if (uf[s] != s) uf[s] = find(uf[s]);
                return uf[s];
            }
        }
    }
}
