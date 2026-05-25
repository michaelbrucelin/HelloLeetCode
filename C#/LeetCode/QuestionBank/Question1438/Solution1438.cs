using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1438
{
    public class Solution1438 : Interface1438
    {
        /// <summary>
        /// 滑动窗口（双指针） + 堆 + 懒删除
        /// 用滑动窗口（双指针）来维护子数组
        /// 用堆来维护子数组中的最大值及最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int LongestSubarray(int[] nums, int limit)
        {
            int result = 1, p1 = 0, p2 = -1, len = nums.Length;
            PriorityQueue<(int, int), int> minpq = new(), maxpq = new();
            while (++p2 < len)
            {
                minpq.Enqueue((nums[p2], p2), nums[p2]); maxpq.Enqueue((nums[p2], p2), -nums[p2]);
                if (maxpq.Peek().Item1 - minpq.Peek().Item1 > limit)
                {
                    result = Math.Max(result, p2 - p1);
                    while (maxpq.Peek().Item1 - minpq.Peek().Item1 > limit)
                    {
                        p1++;
                        while (minpq.Peek().Item2 < p1) minpq.Dequeue();
                        while (maxpq.Peek().Item2 < p1) maxpq.Dequeue();
                    }
                }
            }
            result = Math.Max(result, len - p1);

            return result;
        }
    }
}
