using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0347
{
    public class Solution0347 : Interface0347
    {
        /// <summary>
        /// 哈希 + 堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int num in nums) if (freq.ContainsKey(num)) freq[num]++; else freq.Add(num, 1);
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            foreach (int key in freq.Keys)
            {
                minpq.Enqueue(key, freq[key]);
                if (minpq.Count > k) minpq.Dequeue();
            }

            int[] result = new int[k];
            for (int i = 0; i < k; i++) result[i] = minpq.Dequeue();
            return result;
        }
    }
}
