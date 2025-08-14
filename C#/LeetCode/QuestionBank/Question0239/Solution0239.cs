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
        /// 优先级队列 + 懒标记删除
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k == 1) return nums;
            if (k == nums.Length) return [nums.Max()];

            int len = nums.Length;
            int[] result = new int[len - k + 1];

            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < k - 1; i++) maxpq.Enqueue(nums[i], -nums[i]);
            for (int i = k - 1; i < len; i++)
            {
                maxpq.Enqueue(nums[i], -nums[i]);
                while (map.ContainsKey(maxpq.Peek()))
                {
                    if (--map[maxpq.Peek()] == 0) map.Remove(maxpq.Peek());
                    maxpq.Dequeue();
                }
                result[i - k + 1] = maxpq.Peek();
                if (map.ContainsKey(nums[i - k + 1])) map[nums[i - k + 1]]++; else map.Add(nums[i - k + 1], 1);
            }

            return result;
        }

        /// <summary>
        /// 逻辑与MaxSlidingWindow()一样，直接使用索引做为懒删除的标记
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow2(int[] nums, int k)
        {
            if (k == 1) return nums;
            if (k == nums.Length) return [nums.Max()];

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
