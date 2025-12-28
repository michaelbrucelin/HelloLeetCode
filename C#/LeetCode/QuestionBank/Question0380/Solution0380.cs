using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0380
{
    public class Solution0380
    {
    }

    /// <summary>
    /// Hash + 列表
    /// Hash可以使Insert()与Remove()的时间复杂度为O(1)，列表可以使Random()的时间复杂度为O(1)
    /// 问题是怎样使Remove()在列表中的时间复杂度为O(1)，不难理解，看代码即可
    /// </summary>
    public class RandomizedSet : Interface0380
    {
        public RandomizedSet()
        {
            map = new Dictionary<int, int>();
            list = new List<int>();
            random = new Random();
        }

        private Dictionary<int, int> map;
        private List<int> list;
        private Random random;

        public int GetRandom()
        {
            int id = random.Next(0, list.Count);
            return list[id];
        }

        public bool Insert(int val)
        {
            if (map.ContainsKey(val)) return false;
            int idx = list.Count;
            list.Add(val);
            map.Add(val, idx);

            return true;
        }

        public bool Remove(int val)
        {
            if (!map.ContainsKey(val)) return false;
            if (list.Count == 1)
            {
                list.Clear(); map.Clear(); return true;
            }

            int idx = map[val], last = list.Count - 1;
            list[idx] = list[last];
            map[list[idx]] = idx;
            list.RemoveAt(last);
            map.Remove(val);

            return true;
        }
    }
}
