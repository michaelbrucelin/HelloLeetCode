using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0381
{
    public class Solution0381
    {
    }

    /// <summary>
    /// 逻辑同Solution0380
    /// </summary>
    public class RandomizedCollection : Interface0381
    {
        public RandomizedCollection()
        {
            map = new Dictionary<int, HashSet<int>>();
            list = new List<int>();
            random = new Random();
        }

        private Dictionary<int, HashSet<int>> map;
        private List<int> list;
        private Random random;

        public int GetRandom()
        {
            int idx = random.Next(0, list.Count);
            return list[idx];
        }

        public bool Insert(int val)
        {
            int idx = list.Count;
            list.Add(val);
            if (map.TryGetValue(val, out HashSet<int> ids))
            {
                ids.Add(idx);
                return false;
            }
            else
            {
                map.Add(val, [idx]);
                return true;
            }
        }

        public bool Remove(int val)
        {
            if (list.Count == 0) return false;
            if (list[^1] == val)
            {
                list.RemoveAt(list.Count - 1);
                if (map[val].Count == 1) map.Remove(val); else map[val].Remove(list.Count);
                return true;
            }

            if (map.TryGetValue(val, out HashSet<int> ids))
            {
                int idx = ids.Last(), last = list.Count - 1;
                list[idx] = list[last];
                map[list[last]].Remove(last); map[list[last]].Add(idx);
                list.RemoveAt(last);
                if (ids.Count == 1) map.Remove(val); else ids.Remove(idx);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
