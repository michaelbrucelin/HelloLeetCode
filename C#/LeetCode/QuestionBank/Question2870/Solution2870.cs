using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2870
{
    public class Solution2870 : Interface2870
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            int result = 0, len = nums.Length;
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0, num; i < len; i++) if (freq.TryGetValue(num = nums[i], out int cnt)) freq[num] = ++cnt; else freq.Add(num, 1);

            foreach (int cnt in freq.Values) if (cnt == 1) return -1; else result += cnt / 3 + ((cnt % 3 + 1) >> 1);
            return result;
        }
    }
}
