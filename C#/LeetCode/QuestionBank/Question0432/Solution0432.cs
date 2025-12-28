using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0432
{
    public class Solution0432
    {
    }

    /// <summary>
    /// 两个字典
    /// </summary>
    public class AllOne : Interface0432
    {
        public AllOne()
        {
            map1 = new Dictionary<string, int>();
            map2 = new SortedDictionary<int, HashSet<string>>();
        }

        private Dictionary<string, int> map1;
        private SortedDictionary<int, HashSet<string>> map2;

        public void Inc(string key)
        {
            if (map1.ContainsKey(key))
            {
                int cnt = map1[key]++;
                if (map2[cnt].Count > 1) map2[cnt].Remove(key); else map2.Remove(cnt);
                cnt++;
                if (map2.TryGetValue(cnt, out var set)) set.Add(key); else map2.Add(cnt, [key]);
            }
            else
            {
                map1.Add(key, 1);
                if (map2.TryGetValue(1, out var set)) set.Add(key); else map2.Add(1, [key]);
            }
        }

        public void Dec(string key)
        {
            int cnt = map1[key];
            if (cnt > 1) map1[key]--; else map1.Remove(key);
            if (map2[cnt].Count > 1) map2[cnt].Remove(key); else map2.Remove(cnt);
            cnt--;
            if (cnt > 0)
            {
                if (map2.TryGetValue(cnt, out var set)) set.Add(key); else map2.Add(cnt, [key]);
            }
        }

        public string GetMaxKey()
        {
            return map1.Count != 0 ? map2.Last().Value.First() : "";
        }

        public string GetMinKey()
        {
            return map1.Count != 0 ? map2.First().Value.First() : "";
        }
    }
}
