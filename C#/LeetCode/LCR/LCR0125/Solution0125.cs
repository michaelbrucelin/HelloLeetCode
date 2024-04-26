using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0125
{
    public class Solution0125
    {
    }

    /// <summary>
    /// 阅读理解题，没明白官解要用两个栈来模拟队列，而不是直接使用队列
    /// </summary>
    public class CQueue : Interface0125
    {
        public CQueue()
        {
            queue = new Queue<int>();
        }

        private Queue<int> queue;

        public void AppendTail(int value)
        {
            queue.Enqueue(value);
        }

        public int DeleteHead()
        {
            if (queue.Count == 0) return -1;
            return queue.Dequeue();
        }
    }
}
