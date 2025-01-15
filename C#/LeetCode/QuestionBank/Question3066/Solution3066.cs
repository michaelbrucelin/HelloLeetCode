using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3066
{
    public class Solution3066 : Interface3066
    {
        /// <summary>
        ///  小顶堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums, int k)
        {
            int result = 0;
            PriorityQueue<long, long> minpq = new PriorityQueue<long, long>();
            foreach (int num in nums) minpq.Enqueue(num, num);
            long min1, min2;
            while (minpq.Peek() < k)
            {
                min1 = minpq.Dequeue();
                min2 = minpq.Dequeue();
                min1 = (min1 << 1) + min2;
                minpq.Enqueue(min1, min1);
                result++;
            }

            return result;
        }
    }
}
