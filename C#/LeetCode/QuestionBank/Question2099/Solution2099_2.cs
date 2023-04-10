using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2099
{
    public class Solution2099_2 : Interface2099
    {
        /// <summary>
        /// topk
        /// 本质上这是个topk问题，如果全排序，就做了无用功
        /// 利用堆实现topk
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSubsequence(int[] nums, int k)
        {
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>(Comparer<int>.Create((i1, i2) => i2 - i1));
            for (int i = 0; i < nums.Length; i++) maxpq.Enqueue(i, nums[i]);
            bool[] mask = new bool[nums.Length];
            for (int i = 0; i < k; i++) mask[maxpq.Dequeue()] = true;

            int[] result = new int[k];
            for (int i = 0, j = 0; j < k; i++) if (mask[i]) result[j++] = nums[i];

            return result;
        }

        /// <summary>
        /// topk
        /// MaxSubsequence()不完善，这里控制堆的大小始终是k
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSubsequence2(int[] nums, int k)
        {
            PriorityQueue<(int val, int id), int> maxpq = new PriorityQueue<(int, int), int>();
            for (int i = 0; i < k; i++) maxpq.Enqueue((nums[i], i), nums[i]);
            for (int i = k; i < nums.Length; i++)
            {
                if (nums[i] > maxpq.Peek().val)
                {
                    maxpq.Dequeue(); maxpq.Enqueue((nums[i], i), nums[i]);
                }
            }
            bool[] mask = new bool[nums.Length];
            for (int i = 0; i < k; i++) mask[maxpq.Dequeue().id] = true;

            int[] result = new int[k];
            for (int i = 0, j = 0; j < k; i++) if (mask[i]) result[j++] = nums[i];

            return result;
        }
    }
}
