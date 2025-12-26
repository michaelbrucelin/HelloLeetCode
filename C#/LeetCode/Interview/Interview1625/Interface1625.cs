using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1625
{
    /// <summary>
    /// Your LRUCache object will be instantiated and called as such:
    /// LRUCache obj = new LRUCache(capacity);
    /// int param_1 = obj.Get(key);
    /// obj.Put(key,value);
    /// </summary>
    public interface Interface1625
    {
        // public LRUCache(int capacity){ }

        public int Get(int key);

        public void Put(int key, int value);
    }
}
