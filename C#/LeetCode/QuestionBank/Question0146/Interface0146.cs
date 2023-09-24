using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0146
{
    /// <summary>
    /// Your LRUCache object will be instantiated and called as such:
    /// LRUCache obj = new LRUCache(capacity);
    /// int param_1 = obj.Get(key);
    /// obj.Put(key,value);
    /// </summary>
    public interface Interface0146
    {
        public int Get(int key);

        public void Put(int key, int value);
    }
}
