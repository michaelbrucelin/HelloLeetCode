using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0305
{
    public class Solution0305
    {
    }

    public class SortedStack : Interface0305
    {
        /// <summary>
        /// 模拟
        /// </summary>
        public SortedStack()
        {
            stack = new Stack<int>();
            _stack = new Stack<int>();
        }

        private Stack<int> stack, _stack;

        public void Push(int val)
        {
            while (stack.Count > 0 && val > stack.Peek()) _stack.Push(stack.Pop());
            stack.Push(val);
            while (_stack.Count > 0) stack.Push(_stack.Pop());
        }

        public void Pop()
        {
            if (stack.Count > 0) stack.Pop();
        }

        public int Peek()
        {
            return stack.Count > 0 ? stack.Peek() : -1;
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }
    }
}
