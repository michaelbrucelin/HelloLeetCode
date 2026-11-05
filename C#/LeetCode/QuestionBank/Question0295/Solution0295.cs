using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0295
{
    public class Solution0295
    {
    }

    /// <summary>
    /// 构造
    /// 使用两个堆存储，大顶堆存储小的一半数据，小顶堆存储大的一半数据
    /// </summary>
    public class MedianFinder : Interface0295
    {
        public MedianFinder()
        {
            maxpq = new PriorityQueue<int, int>();
            minpq = new PriorityQueue<int, int>();
        }

        private PriorityQueue<int, int> maxpq, minpq;

        public void AddNum(int num)
        {
            if (maxpq.Count == 0)
            {
                maxpq.Enqueue(num, -num);
            }
            else if (maxpq.Count != minpq.Count)
            {
                if (num >= maxpq.Peek())
                {
                    minpq.Enqueue(num, num);
                }
                else
                {
                    int x = maxpq.Dequeue();
                    maxpq.Enqueue(num, -num);
                    minpq.Enqueue(x, x);
                }
            }
            else  // if (maxpq.Count == minpq.Count)
            {
                if (num <= minpq.Peek())
                {
                    maxpq.Enqueue(num, -num);
                }
                else
                {
                    int x = minpq.Dequeue();
                    minpq.Enqueue(num, num);
                    maxpq.Enqueue(x, -x);
                }
            }
        }

        public double FindMedian()
        {
            return maxpq.Count != minpq.Count ? maxpq.Peek() : (0D + maxpq.Peek() + minpq.Peek()) / 2;
        }
    }
}
