using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0060
{
    public class Solution0060 : Interface0060
    {
        /// <summary>
        /// 小顶堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int num in nums) if (freq.TryGetValue(num, out int cnt)) freq[num] = ++cnt; else freq.Add(num, cnt);
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            foreach (int key in freq.Keys)
            {
                minpq.Enqueue(key, freq[key]);
                if (minpq.Count > k) minpq.Dequeue();
            }

            return [.. minpq.UnorderedItems.Select(x => x.Element)];
        }
    }
}
