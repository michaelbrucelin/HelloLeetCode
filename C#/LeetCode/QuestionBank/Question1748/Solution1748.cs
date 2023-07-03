using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1748
{
    public class Solution1748 : Interface1748
    {
        /// <summary>
        /// 哈希计数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumOfUnique(int[] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int i in nums)
                if (freq.ContainsKey(i)) freq[i]++; else freq.Add(i, 1);

            int result = 0;
            foreach (var kv in freq) if (kv.Value == 1) result += kv.Key;

            return result;
        }
    }
}
