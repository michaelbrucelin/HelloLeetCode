using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0076
{
    public class Solution0076 : Interface0076
    {
        /// <summary>
        /// 小顶堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            if (k == 1) return nums.Max();
            if (k == nums.Length) return nums.Min();

            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            foreach (int num in nums)
            {
                minpq.Enqueue(num, num);
                if (minpq.Count > k) minpq.Dequeue();
            }

            return minpq.Peek();
        }
    }
}
