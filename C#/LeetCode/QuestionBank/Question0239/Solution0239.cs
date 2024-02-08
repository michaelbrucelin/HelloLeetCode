using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0239
{
    public class Solution0239 : Interface0239
    {
        /// <summary>
        /// 优先级队列
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k == 1) return nums;
            if (k == nums.Length) return new int[] { nums.Max() };

            int len = nums.Length;
            int[] result = new int[len - k + 1];
            PriorityQueue<(int num, int idx), int> maxpq = new PriorityQueue<(int num, int idx), int>();
            for (int i = 0; i < k - 1; i++) maxpq.Enqueue((nums[i], i), -nums[i]);
            for (int i = k - 1; i < len; i++)
            {
                maxpq.Enqueue((nums[i], i), -nums[i]);
                while (maxpq.Peek().idx < i - k + 1) maxpq.Dequeue();
                result[i - k + 1] = maxpq.Peek().num;
            }

            return result;
        }
    }
}
