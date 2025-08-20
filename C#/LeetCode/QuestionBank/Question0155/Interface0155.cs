using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0155
{
    /// <summary>
    /// Your MinStack object will be instantiated and called as such:
    /// MinStack obj = new MinStack();
    /// obj.Push(val);
    /// obj.Pop();
    /// int param_3 = obj.Top();
    /// int param_4 = obj.GetMin();
    /// </summary>
    public interface Interface0155
    {
        // public MinStack() { }

        public void Push(int val);

        public void Pop();

        public int Top();

        public int GetMin();
    }
}
