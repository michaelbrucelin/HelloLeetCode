using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2006
{
    public class Solution2006_2 : Interface2006
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountKDifference(int[] nums, int k)
        {
            int result = 0, len = nums.Length;
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (freq.ContainsKey(num - k)) result += freq[num - k];
                if (freq.ContainsKey(num + k)) result += freq[num + k];
                if (freq.ContainsKey(num)) freq[num]++; else freq.Add(num, 1);
            }

            return result;
        }
    }
}
