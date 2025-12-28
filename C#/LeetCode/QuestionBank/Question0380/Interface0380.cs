using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0380
{
    /// <summary>
    /// Your RandomizedSet object will be instantiated and called as such:
    /// RandomizedSet obj = new RandomizedSet();
    /// bool param_1 = obj.Insert(val);
    /// bool param_2 = obj.Remove(val);
    /// int param_3 = obj.GetRandom();
    /// </summary>
    public interface Interface0380
    {
        // public RandomizedSet(){ }

        public bool Insert(int val);

        public bool Remove(int val);

        public int GetRandom();
    }
}
