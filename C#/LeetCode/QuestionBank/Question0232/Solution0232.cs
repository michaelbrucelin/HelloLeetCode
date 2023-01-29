using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0232
{
    public class Solution0232
    {
    }

    public class MyQueue : Interface0232
    {
        public MyQueue()
        {
            stack = new Stack<int>();
            buffer = new Stack<int>();
        }

        private Stack<int> stack;
        private Stack<int> buffer;

        public bool Empty()
        {
            return stack.Count == 0;
        }

        public int Peek()
        {
            return stack.Peek();
        }

        public int Pop()
        {
            return stack.Pop();
        }

        public void Push(int x)
        {
            while (stack.Count > 0) buffer.Push(stack.Pop());
            stack.Push(x);
            while (buffer.Count > 0) stack.Push(buffer.Pop());
        }
    }
}
