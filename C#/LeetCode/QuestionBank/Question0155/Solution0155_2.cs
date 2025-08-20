using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0155
{
    public class Solution0155_2
    {
    }

    /// <summary>
    /// 栈 + 单调栈
    /// </summary>
    public class MinStack_2 : Interface0155
    {
        public MinStack_2()
        {
            stack = new Stack<int>();
            min_stack = new Stack<int>();
        }

        private Stack<int> stack;
        private Stack<int> min_stack;

        public int GetMin()
        {
            return min_stack.Peek();
        }

        public void Pop()
        {
            int key = stack.Pop();
            if (min_stack.Peek() == key) min_stack.Pop();
        }

        public void Push(int val)
        {
            stack.Push(val);
            if (min_stack.Count == 0 || val <= min_stack.Peek()) min_stack.Push(val);
        }

        public int Top()
        {
            return stack.Peek();
        }
    }
}
