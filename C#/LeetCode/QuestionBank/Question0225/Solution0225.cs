using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0225
{
    public class Solution0225
    {
    }

    public class MyStack : Interface0225
    {

        public MyStack()
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
            while (queue.Count > 1) buffer.Enqueue(queue.Dequeue());
            int value = queue.Dequeue();
            temp = buffer; buffer = queue; queue = temp;

            return value;
        }

        public void Push(int x)
        {
            queue.Enqueue(x);
        }

        public int Top()
        {
            while (queue.Count > 1) buffer.Enqueue(queue.Dequeue());
            int value = queue.Peek();
            buffer.Enqueue(queue.Dequeue());
            temp = buffer; buffer = queue; queue = temp;

            return value;
        }
    }
}
