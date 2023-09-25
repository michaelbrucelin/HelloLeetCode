using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0460
{
    /// <summary>
    /// Your LFUCache object will be instantiated and called as such:
    /// LFUCache obj = new LFUCache(capacity);
    /// int param_1 = obj.Get(key);
    /// obj.Put(key,value);
    /// </summary>
    public interface Interface0460
    {
        public int Get(int key);

        public void Put(int key, int value);
    }
}
