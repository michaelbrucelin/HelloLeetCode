using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0304
{
    /// <summary>
    /// Your MyQueue object will be instantiated and called as such:
    /// MyQueue obj = new MyQueue();
    /// obj.Push(x);
    /// int param_2 = obj.Pop();
    /// int param_3 = obj.Peek();
    /// bool param_4 = obj.Empty();
    /// </summary>
    public interface Interface0304
    {
        /** Initialize your data structure here. */
        // public MyQueue();

        /** Push element x to the back of queue. */
        public void Push(int x);

        /** Removes the element from in front of queue and returns that element. */
        public int Pop();

        /** Get the front element. */
        public int Peek();

        /** Returns whether the queue is empty. */
        public bool Empty();
    }
}
