using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2475
{
    public class Solution2475_2 : Interface2475
    {
        /// <summary>
        /// 哈希 + 枚举
        /// 本质上依然是暴力枚举，先Hash计数，再枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int UnequalTriplets(int[] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int num in nums)
                if (freq.ContainsKey(num)) freq[num]++; else freq.Add(num, 1);
            var _freq = freq.Values.ToArray();

            int result = 0, len = _freq.Length;
            for (int i = 0; i < len - 2; i++) for (int j = i + 1; j < len - 1; j++) for (int k = j + 1; k < len; k++)
                        result += _freq[i] * _freq[j] * _freq[k];

            return result;
        }
    }
}
