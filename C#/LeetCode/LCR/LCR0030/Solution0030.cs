using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0030
{
    public class Solution0030
    {
    }

    /// <summary>
    /// Hash
    /// 使用Hash记录值的位置
    /// </summary>
    public class RandomizedSet : Interface0030
    {
        public RandomizedSet()
        {
            list = [];
            map = new Dictionary<int, int>();
            cnt = 0;
            random = new Random();
        }

        private List<int> list;
        private Dictionary<int, int> map;
        private int cnt;
        private Random random;

        public bool Insert(int val)
        {
            if (map.ContainsKey(val)) return false;

            if (cnt < list.Count) list[cnt] = val; else list.Add(val);
            map.Add(val, cnt++);

            return true;
        }

        public bool Remove(int val)
        {
            if (map.TryGetValue(val, out int idx))
            {
                list[idx] = list[--cnt];
                map[list[idx]] = idx;
                map.Remove(val);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetRandom()
        {
            return list[random.Next(cnt)];
        }
    }
}
