using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0147
{
    public class Solution0147_3
    {
    }

    /// <summary>
    /// 双栈，栈 + 单调栈
    /// </summary>
    public class MinStack_3 : Interface0147
    {
        public MinStack_3()
        {
            stack = new Stack<int>();
            _stack = new Stack<int>();
        }

        private Stack<int> stack, _stack;

        public int GetMin()
        {
            return _stack.Peek();
        }

        public void Pop()
        {
            if (_stack.Peek() == stack.Pop()) _stack.Pop();
        }

        public void Push(int x)
        {
            stack.Push(x);
            if (_stack.Count == 0 || x <= _stack.Peek()) _stack.Push(x);
        }

        public int Top()
        {
            return stack.Peek();
        }
    }
}
