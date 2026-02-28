using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0677
{
    /// <summary>
    /// * Your MapSum object will be instantiated and called as such:
    /// * MapSum obj = new MapSum();
    /// * obj.Insert(key, val);
    /// * int param_2 = obj.Sum(prefix);
    /// </summary>
    public interface Interface0677
    {
        // public MapSum(){ }

        public void Insert(string key, int val);

        public int Sum(string prefix);
    }
}
