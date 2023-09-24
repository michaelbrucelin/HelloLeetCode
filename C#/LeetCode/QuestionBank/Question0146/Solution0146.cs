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

        public int Get(int key)
        {
            throw new NotImplementedException();
        }

        public void Put(int key, int value)
        {
            throw new NotImplementedException();
        }
    }
}
