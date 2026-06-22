using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0305
{
    /// <summary>
    /// Your SortedStack object will be instantiated and called as such:
    /// SortedStack obj = new SortedStack();
    /// obj.Push(val);
    /// obj.Pop();
    /// int param_3 = obj.Peek();
    /// bool param_4 = obj.IsEmpty();
    /// </summary>
    public interface Interface0305
    {
        // public SortedStack(){ }

        public void Push(int val);

        public void Pop();

        public int Peek();

        public bool IsEmpty();
    }
}
