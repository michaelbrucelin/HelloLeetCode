using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2593
{
    public class Solution2593 : Interface2593
    {
        /// <summary>
        /// 模拟
        /// 使用小顶堆+懒删除模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long FindScore(int[] nums)
        {
            long result = 0; int len = nums.Length;
            Comparer<(int, int)> comparer = Comparer<(int, int)>.Create((x, y) => x.Item1 != y.Item1 ? x.Item1 - y.Item1 : x.Item2 - y.Item2);
            PriorityQueue<(int, int), (int, int)> minpq = new PriorityQueue<(int, int), (int, int)>(comparer);
            for (int i = 0; i < len; i++) minpq.Enqueue((nums[i], i), (nums[i], i));
            bool[] mask = new bool[len];
            int num, idx;
            while (minpq.Count > 0)
            {
                (num, idx) = minpq.Dequeue();
                if (mask[idx]) continue;
                result += num;
                if (idx > 0) mask[idx - 1] = true;
                if (idx < len - 1) mask[idx + 1] = true;
            }

            return result;
        }
    }
}
