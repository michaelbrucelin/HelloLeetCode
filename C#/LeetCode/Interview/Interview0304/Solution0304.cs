using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0304
{
    public class Solution0304
    {
    }

    public class MyQueue : Interface0304
    {
        public MyQueue()
        {
            queue = new Stack<int>();
            stack = new Stack<int>();
        }

        private Stack<int> queue, stack;

        public bool Empty()
        {
            Switch();
            return queue.Count == 0;
        }

        public int Peek()
        {
            Switch();
            return queue.Peek();
        }

        public int Pop()
        {
            Switch();
            return queue.Pop();
        }

        public void Push(int x)
        {
            stack.Push(x);
        }

        private void Switch()
        {
            if (queue.Count == 0) while (stack.Count > 0) queue.Push(stack.Pop());
        }
    }
}
