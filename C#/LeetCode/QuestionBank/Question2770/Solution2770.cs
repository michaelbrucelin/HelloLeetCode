using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2770
{
    public class Solution2770 : Interface2770
    {
        /// <summary>
        /// BFS
        /// O(n^2)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MaximumJumps(int[] nums, int target)
        {
            if (nums.Length < 2) return 0;

            int result = -1, cnt, step = 0, idx, len = nums.Length;
            Queue<int> queue = new Queue<int>();
            HashSet<int> set = new HashSet<int>();
            queue.Enqueue(0);
            while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    idx = queue.Dequeue();
                    if (idx == len - 1) result = step;
                    for (int j = idx + 1; j < len; j++) if (Math.Abs(nums[j] - nums[idx]) <= target && set.Add(j)) queue.Enqueue(j);
                }
                step++;
                set.Clear();
            }

            return result;
        }
    }
}
