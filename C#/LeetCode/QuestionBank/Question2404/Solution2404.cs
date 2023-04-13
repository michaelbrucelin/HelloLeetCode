using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2404
{
    public class Solution2404 : Interface2404
    {
        /// <summary>
        /// 字典
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MostFrequentEven(int[] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0, val; i < nums.Length; i++)
            {
                if (((val = nums[i]) & 1) != 1)
                {
                    if (freq.ContainsKey(val)) freq[val]++; else freq.Add(val, 1);
                }
            }

            int result = -1, cnt = 0;
            foreach (var kv in freq)
            {
                if (kv.Value > cnt || (kv.Value == cnt && kv.Key < result))
                {
                    result = kv.Key; cnt = kv.Value;
                }
            }

            return result;
        }
    }
}
