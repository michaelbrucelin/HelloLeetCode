using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0232
{
    public class Solution0232_2
    {
    }

    public class MyQueue_2 : Interface0232
    {
        public MyQueue_2()
        {
            stack = new Stack<int>();
            buffer = new Stack<int>();
        }

        private Stack<int> stack;
        private Stack<int> buffer;

        public bool Empty()
        {
            return stack.Count + buffer.Count == 0;
        }

        public int Peek()
        {
            if (stack.Count == 0) while (buffer.Count > 0) stack.Push(buffer.Pop());
            return stack.Peek();
        }

        public int Pop()
        {
            if (stack.Count == 0) while (buffer.Count > 0) stack.Push(buffer.Pop());
            return stack.Pop();
        }

        public void Push(int x)
        {
            buffer.Push(x);
        }
    }
}
