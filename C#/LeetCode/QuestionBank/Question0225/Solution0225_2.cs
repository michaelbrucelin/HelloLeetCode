using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0225
{
    public class Solution0225_2
    {
    }

    public class MyStack_2 : Interface0225
    {
        public MyStack_2()
        {
            buffer = new Queue<int>();
            queue = new Queue<int>();
        }

        private Queue<int> queue;
        private Queue<int> buffer;
        private Queue<int> temp;

        public bool Empty()
        {
            return queue.Count == 0;
        }

        public int Pop()
        {
            return queue.Dequeue();
        }

        public void Push(int x)
        {
            buffer.Enqueue(x);
            while (queue.Count > 0) buffer.Enqueue(queue.Dequeue());
            temp = buffer; buffer = queue; queue = temp;
        }

        public int Top()
        {
            return queue.Peek();
        }
    }
}
