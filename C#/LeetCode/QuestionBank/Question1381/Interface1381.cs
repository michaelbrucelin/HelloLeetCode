using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1381
{
    /// <summary>
    /// Your CustomStack object will be instantiated and called as such:
    /// CustomStack obj = new CustomStack(maxSize);
    /// obj.Push(x);
    /// int param_2 = obj.Pop();
    /// obj.Increment(k,val);
    /// </summary>
    public interface Interface1381
    {
        // public CustomStack(int maxSize){ }

        public void Push(int x);

        public int Pop();

        public void Increment(int k, int val);
    }
}
