using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2762
{
    public class Solution2762_2 : Interface2762
    {
        /// <summary>
        /// 双指针（滑动窗口） + 堆 + 懒删除
        /// 逻辑同Solution2762，改用堆+懒删除的方式快速查找一个子数组的最大值与最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long ContinuousSubarrays(int[] nums)
        {
            long result = 0;
            Comparer<(int, int)> comparer = Comparer<(int, int)>.Create((x, y) => x.Item1 != y.Item1 ? x.Item1 - y.Item1 : x.Item2 - y.Item2);  // (int, int) -> (val, idx)
            PriorityQueue<(int, int), (int, int)> minpq = new PriorityQueue<(int, int), (int, int)>();
            PriorityQueue<(int, int), (int, int)> maxpq = new PriorityQueue<(int, int), (int, int)>();
            int pl = 0, pr = 0, len = nums.Length;
            minpq.Enqueue((nums[0], 0), (nums[0], 0));
            maxpq.Enqueue((nums[0], 0), (-nums[0], 0));
            while (pl < len)
            {
                while (pr + 1 < len
                    && (minpq.Count == 0 || Math.Abs(nums[pr + 1] - minpq.Peek().Item1) < 3)
                    && (maxpq.Count == 0 || Math.Abs(nums[pr + 1] - maxpq.Peek().Item1) < 3))
                {
                    pr++;
                    minpq.Enqueue((nums[pr], pr), (nums[pr], pr));
                    maxpq.Enqueue((nums[pr], pr), (-nums[pr], pr));
                }
                result += pr - pl + 1;
                if (++pl == len) break;
                while (minpq.Count > 0 && minpq.Peek().Item2 < pl) minpq.Dequeue();
                while (maxpq.Count > 0 && maxpq.Peek().Item2 < pl) maxpq.Dequeue();
            }

            return result;
        }
    }
}
