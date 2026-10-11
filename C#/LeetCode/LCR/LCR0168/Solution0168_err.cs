using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0168
{
    public class Solution0168_err : Interface0168
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber(int n)
        {
            if (n == 1) return 1;

            HashSet<int> set = [1];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            while (set.Count < n) for (int i = queue.Count, x, y; i > 0; i--)
                {
                    x = queue.Dequeue();
                    if (set.Add(y = x * 2)) queue.Enqueue(y);
                    if (set.Add(y = x * 3)) queue.Enqueue(y);
                    if (set.Add(y = x * 5)) queue.Enqueue(y);
                }

            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            foreach (int x in set)
            {
                maxpq.Enqueue(x, -x);
                if (maxpq.Count > n) maxpq.Dequeue();
            }

            return maxpq.Peek();
        }
    }
}
