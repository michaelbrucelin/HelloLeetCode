using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3264
{
    public class Solution3264_2 : Interface3264
    {
        /// <summary>
        /// 优先级队列
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public int[] GetFinalState(int[] nums, int k, int multiplier)
        {
            Comparer<(int val, int id)> comparer = Comparer<(int val, int id)>.Create((t1, t2) => t1.val != t2.val ? t1.val - t2.val : t1.id - t2.id);
            PriorityQueue<int, (int val, int id)> minpq = new PriorityQueue<int, (int val, int id)>(comparer);
            int len = nums.Length;
            for (int i = 0; i < len; i++) minpq.Enqueue(i, (nums[i], i));
            for (int i = 0, id; i < k; i++)
            {
                id = minpq.Dequeue();
                nums[id] *= multiplier;
                minpq.Enqueue(id, (nums[id], id));
            }

            return nums;
        }
    }
}
