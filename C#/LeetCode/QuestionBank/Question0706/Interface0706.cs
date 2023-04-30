using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0706
{
    /// <summary>
    /// Your MyHashMap object will be instantiated and called as such:
    /// MyHashMap obj = new MyHashMap();
    /// obj.Put(key,value);
    /// int param_2 = obj.Get(key);
    /// obj.Remove(key);
    /// </summary>
    public interface Interface0706
    {
        public void Put(int key, int value);

        public int Get(int key);

        public void Remove(int key);
    }
}
