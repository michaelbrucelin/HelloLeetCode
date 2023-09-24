using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0146
{
    public class Solution0146
    {
    }

    /// <summary>
    /// 有事，先不做了，有时间再说
    /// </summary>
    public class LRUCache : Interface0146
    {
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            cache = new Dictionary<int, int>();
            order = new Dictionary<int, int>();
        }

        private Dictionary<int, int> cache;
        private Dictionary<int, int> order;
        private int capacity;
        private int minid = 0, maxid = -1;

        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {

                return cache[key];
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            throw new NotImplementedException();
        }
    }
}
