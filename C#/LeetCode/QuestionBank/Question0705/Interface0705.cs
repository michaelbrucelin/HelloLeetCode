using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0705
{
    /// <summary>
    /// Your MyHashSet object will be instantiated and called as such:
    /// MyHashSet obj = new MyHashSet();
    /// obj.Add(key);
    /// obj.Remove(key);
    /// bool param_3 = obj.Contains(key);
    /// </summary>
    public interface Interface0705
    {
        public void Add(int key);

        public void Remove(int key);

        public bool Contains(int key);
    }
}
