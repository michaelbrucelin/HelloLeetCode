using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1696
{
    public class Solution1696 : Interface1696
    {
        /// <summary>
        /// DP + 优先级队列
        /// 1. 数组的第一个与最后一个元素必须获取
        /// 2. 假定nums[0..n]的结果已知，则nums[0..(n+1)]的结果是nums[n+1] + Max(nums[0..n], nums[0..(n-1)], ..., nums[0..(n-k+1)])
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxResult(int[] nums, int k)
        {
            int len = nums.Length;
            if (len <= 2 || k == 1) return nums.Sum();
            if (k >= len) return nums[0] + nums[^1] + nums.Skip(1).Take(len - 2).Where(i => i > 0).Sum();

            PriorityQueue<(int r, int idx), int> maxpq = new PriorityQueue<(int r, int idx), int>();
            maxpq.Enqueue((nums[0], 0), -nums[0]);
            for (int i = 1, r; i < len - 1; i++)
            {
                while (maxpq.Peek().idx < i - k) maxpq.Dequeue();
                r = nums[i] + maxpq.Peek().r;
                maxpq.Enqueue((r, i), -r);
            }
            while (maxpq.Peek().idx < len - 1 - k) maxpq.Dequeue();

            return nums[len - 1] + maxpq.Peek().r;
        }
    }
}
