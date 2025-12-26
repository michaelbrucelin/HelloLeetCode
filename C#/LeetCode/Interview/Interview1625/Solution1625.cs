using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1625
{
    public class Solution1625
    {
    }

    /// <summary>
    /// 1. Hash，记录key对应的value
    /// 2. Queue，记录每个key的操作记录，相当于日志
    /// 3. Hash，记录key对应的操作次数，即queue中有几条记录
    /// 当需要删除最早的记录时，诸条日志分析即可
    ///     如果日志第一条的key对应的条数只有1条，这个key应该被删除
    ///     如果日志第一条的key对应的条数大于1条，条数减1
    /// </summary>
    public class LRUCache : Interface1625
    {
        public LRUCache(int capacity)
        {
            Capacity = capacity;
            cache = new Dictionary<int, int[]>();
            log = new Queue<int>();
        }

        private int Capacity { get; }
        private Dictionary<int, int[]> cache;
        private Queue<int> log;

        public int Get(int key)
        {
            if (!cache.ContainsKey(key)) return -1;
            cache[key][1]++;
            log.Enqueue(key);
            return cache[key][0];
        }

        public void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                cache[key][0] = value;
                cache[key][1]++;
                log.Enqueue(key);
            }
            else
            {
                int _key;
                while (cache.Count == Capacity)
                {
                    _key = log.Dequeue();
                    if (cache[_key][1] > 1) cache[_key][1]--; else cache.Remove(_key);
                }
                cache.Add(key, [value, 1]);
                log.Enqueue(key);
            }
        }
    }
}
