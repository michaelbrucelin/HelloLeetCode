using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3321
{
    public class Solution3321 : Interface3321
    {
        /// <summary>
        /// 字典 + 堆
        /// 逻辑没问题，TLE，参考测试用例05
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public long[] FindXSum(int[] nums, int k, int x)
        {
            int len = nums.Length;
            long[] result = new long[len - k + 1];

            if (x == k)
            {
                for (int i = k - 1; i >= 0; i--) result[0] += nums[i];
                for (int i = k; i < len; i++) result[i - k + 1] = result[i - k] - nums[i - k] + nums[i];
            }
            else
            {
                Dictionary<int, int> freq = new Dictionary<int, int>();
                Comparer<(int, int)> comparer = Comparer<(int, int)>.Create((t1, t2) => t1.Item1 != t2.Item1 ? t2.Item1 - t1.Item1 : t2.Item2 - t1.Item2);
                PriorityQueue<long, (int, int)> maxpq = new PriorityQueue<long, (int, int)>(comparer);
                for (int i = k - 1; i >= 0; i--) if (freq.ContainsKey(nums[i])) freq[nums[i]]++; else freq.Add(nums[i], 1);
                foreach (var kv in freq) maxpq.Enqueue(1L * kv.Key * kv.Value, (kv.Value, kv.Key));
                for (int j = 0; j < x && maxpq.Count > 0; j++) result[0] += maxpq.Dequeue();
                for (int i = k; i < len; i++)
                {
                    if (freq[nums[i - k]] > 1) freq[nums[i - k]]--; else freq.Remove(nums[i - k]);
                    if (freq.ContainsKey(nums[i])) freq[nums[i]]++; else freq.Add(nums[i], 1);
                    maxpq.Clear();
                    foreach (var kv in freq) maxpq.Enqueue(1L * kv.Key * kv.Value, (kv.Value, kv.Key));
                    for (int j = 0; j < x && maxpq.Count > 0; j++) result[i - k + 1] += maxpq.Dequeue();
                }
            }

            return result;
        }
    }
}
