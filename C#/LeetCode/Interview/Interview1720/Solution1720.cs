using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1720
{
    public class Solution1720
    {
    }

    /// <summary>
    /// 堆
    /// 使用一个大顶堆 + 一个小顶堆模拟
    /// </summary>
    public class MedianFinder
    {
        public MedianFinder()
        {
            maxpq = new PriorityQueue<int, int>();
            minpq = new PriorityQueue<int, int>();
        }

        private PriorityQueue<int, int> maxpq, minpq;

        public void AddNum(int num)
        {
            if (maxpq.Count == 0) { maxpq.Enqueue(num, -num); return; }
            if (num <= maxpq.Peek()) maxpq.Enqueue(num, -num); else minpq.Enqueue(num, num);
            if (maxpq.Count > minpq.Count + 1)
            {
                int x = maxpq.Dequeue(); minpq.Enqueue(x, x);
            }
            else if (minpq.Count > maxpq.Count)
            {
                int x = minpq.Dequeue(); maxpq.Enqueue(x, -x);
            }
        }

        public double FindMedian()
        {
            if (maxpq.Count > minpq.Count) return maxpq.Peek();
            return (0D + maxpq.Peek() + minpq.Peek()) / 2;
        }
    }
}
