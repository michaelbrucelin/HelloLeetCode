using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0042
{
    public class Solution0042
    {
    }

    /// <summary>
    /// 队列
    /// </summary>
    public class RecentCounter : Interface0042
    {
        public RecentCounter()
        {
            queue = new Queue<int>();
        }

        private Queue<int> queue;

        public int Ping(int t)
        {
            queue.Enqueue(t);
            while (queue.Peek() < t - 3000) queue.Dequeue();

            return queue.Count;
        }
    }
}
