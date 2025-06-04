using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2558
{
    public class Solution2558 : Interface2558
    {
        /// <summary>
        /// 优先级队列，最大堆
        /// </summary>
        /// <param name="gifts"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long PickGifts(int[] gifts, int k)
        {
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            for (int i = 0; i < gifts.Length; i++) maxpq.Enqueue(gifts[i], -gifts[i]);
            for (int i = 0, num; i < k; i++)
            {
                if (maxpq.Peek() == 1) break;
                num = maxpq.Dequeue();
                num = (int)Math.Floor(Math.Sqrt(num));
                maxpq.Enqueue(num, -num);
            }

            long result = 0L;
            while (maxpq.Count > 0) result += maxpq.Dequeue();
            return result;
        }
    }
}
