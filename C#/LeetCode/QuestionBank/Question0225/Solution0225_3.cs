using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0225
{
    public class Solution0225_3
    {
    }

    public class MyStack_3 : Interface0225
    {
        public MyStack_3()
        {
            queue = new Queue<int>();
        }

        private Queue<int> queue = new Queue<int>();

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
            int cnt = queue.Count();
            queue.Enqueue(x);
            while (cnt-- > 0) queue.Enqueue(queue.Dequeue());
        }

        public int Top()
        {
            return queue.Peek();
        }
    }
}
