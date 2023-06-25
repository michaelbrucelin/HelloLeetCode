using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2190
{
    public class Solution2190 : Interface2190
    {
        /// <summary>
        /// 哈希计数
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int MostFrequent(int[] nums, int key)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length - 1; i++) if (nums[i] == key)
                {
                    if (freq.ContainsKey(nums[i + 1])) freq[nums[i + 1]]++; else freq.Add(nums[i + 1], 1);
                }

            int _key = freq.First().Key;
            int _cnt = freq[_key];
            foreach (var kv in freq) if (kv.Value > _cnt)
                {
                    _key = kv.Key; _cnt = kv.Value;
                }
            return _key;
        }
    }
}
