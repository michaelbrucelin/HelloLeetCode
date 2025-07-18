using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2163
{
    public class Solution2163 : Interface2163
    {
        /// <summary>
        /// 堆
        /// 反向思考，在 n - 2n 项间，选一个边界，左边最小的 n 项的和减去右边最大的 n 项的和，就是一个结果
        /// 所以只需要计算前缀数组的最小的 n 项的和与后缀数组最大的 n 项的和即可
        /// 用堆可以解决上面的问题
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MinimumDifference(int[] nums)
        {
            if (nums.Length == 3) return Math.Min(nums[0] - Math.Max(nums[1], nums[2]), nums[1] - nums[2]);

            int n = nums.Length / 3, n2 = (nums.Length / 3) << 1, len = nums.Length;
            PriorityQueue<int, int> heap = new PriorityQueue<int, int>();
            // 前缀数组
            long[] prefix = new long[n + 1];
            for (int i = 0; i < n; i++) { prefix[0] += nums[i]; heap.Enqueue(nums[i], -nums[i]); }
            for (int i = n, num, tmp; i < n2; i++)
            {
                num = nums[i];
                if (num >= heap.Peek())
                {
                    prefix[i - n + 1] = prefix[i - n];
                }
                else
                {
                    tmp = heap.Dequeue();
                    heap.Enqueue(num, -num);
                    prefix[i - n + 1] = prefix[i - n] + num - tmp;
                }
            }
            // 后缀数组
            heap.Clear();
            long[] suffix = new long[n + 1];
            for (int i = len - 1; i >= n2; i--) { suffix[n] += nums[i]; heap.Enqueue(nums[i], nums[i]); }
            for (int i = n2 - 1, num, tmp; i >= n; i--)
            {
                num = nums[i];
                if (num <= heap.Peek())
                {
                    suffix[i - n] = suffix[i - n + 1];
                }
                else
                {
                    tmp = heap.Dequeue();
                    heap.Enqueue(num, num);
                    suffix[i - n] = suffix[i - n + 1] + num - tmp;
                }
            }

            long result = prefix[0] - suffix[0];
            for (int i = 1; i <= n; i++) result = Math.Min(result, prefix[i] - suffix[i]);
            return result;
        }
    }
}
