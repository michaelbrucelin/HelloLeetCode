using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0697
{
    public class Solution0697 : Interface0697
    {
        /// <summary>
        /// 哈希
        /// 遍历数组
        ///     1. 记录每个值第1次出现和最后1次的索引
        ///     2. 记录每个值出现的频次以及不同频次都有哪些值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindShortestSubArray(int[] nums)
        {
            Dictionary<int, int[]> range = new Dictionary<int, int[]>();
            Dictionary<int, int> freq1 = new Dictionary<int, int>();
            Dictionary<int, HashSet<int>> freq2 = new Dictionary<int, HashSet<int>>() { { 1, new HashSet<int>() } };

            for (int i = 0, val, freq; i < nums.Length; i++)
            {
                val = nums[i];
                if (range.ContainsKey(val))
                {
                    range[val][1] = i;
                    freq1[val]++;
                    freq = freq1[val];
                    freq2[freq - 1].Remove(val);
                    if (freq2.ContainsKey(freq)) freq2[freq].Add(val); else freq2.Add(freq, new HashSet<int>() { val });
                }
                else
                {
                    range.Add(val, new int[] { i, i });
                    freq1.Add(val, 1);
                    freq2[1].Add(val);
                }
            }

            int result = nums.Length, max = 0;
            foreach (int key in freq2.Keys) max = Math.Max(max, key);
            foreach (int key in freq2[max]) result = Math.Min(result, range[key][1] - range[key][0]);

            return result + 1;
        }
    }
}
