using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0059
{
    public class Solution0059
    {
    }

    /// <summary>
    /// 小顶堆
    /// </summary>
    public class KthLargest : Interface0059
    {
        public KthLargest(int k, int[] nums)
        {
            minpq = new PriorityQueue<int, int>();
            minpq.Enqueue(int.MinValue, int.MinValue);
            for (int i = 0; i < k - 1; i++) minpq.Enqueue(nums[i], nums[i]);
            for (int i = k - 1; i < nums.Length; i++) minpq.EnqueueDequeue(nums[i], nums[i]);
        }

        private PriorityQueue<int, int> minpq;

        public int Add(int val)
        {
            minpq.EnqueueDequeue(val, val);

            return minpq.Peek();
        }
    }
}
