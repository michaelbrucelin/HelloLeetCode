using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0381
{
    /// <summary>
    /// Your RandomizedCollection object will be instantiated and called as such:
    /// RandomizedCollection obj = new RandomizedCollection();
    /// bool param_1 = obj.Insert(val);
    /// bool param_2 = obj.Remove(val);
    /// int param_3 = obj.GetRandom();
    /// </summary>
    public interface Interface0381
    {
        // public RandomizedCollection(){ }

        public bool Insert(int val);

        public bool Remove(int val);

        public int GetRandom();
    }
}
