using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0302
{
    /// <summary>
    /// Your MinStack object will be instantiated and called as such:
    /// MinStack obj = new MinStack();
    /// obj.Push(x);
    /// obj.Pop();
    /// int param_3 = obj.Top();
    /// int param_4 = obj.GetMin();
    /// </summary>
    public interface Interface0302
    {
        /** initialize your data structure here. */
        // public MinStack();

        public void Push(int x);

        public void Pop();

        public int Top();

        public int GetMin();
    }
}
