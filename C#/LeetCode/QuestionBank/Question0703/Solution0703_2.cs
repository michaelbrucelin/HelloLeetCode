using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0703
{
    public class Solution0703_2
    {
    }

    public class KthLargest_2 : Interface0703
    {
        /// <summary>
        /// 最小堆
        /// </summary>
        /// <param name="k"></param>
        /// <param name="nums"></param>
        public KthLargest_2(int k, int[] nums)
        {
            minpq = new PriorityQueue<int, int>();
            minpq.Enqueue(int.MinValue, int.MinValue);  // 哨兵
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
