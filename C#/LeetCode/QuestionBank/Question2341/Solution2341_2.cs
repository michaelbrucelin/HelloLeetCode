using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2341
{
    public class Solution2341_2 : Interface2341
    {
        /// <summary>
        /// 排序统计
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NumberOfPairs(int[] nums)
        {
            int len = nums.Length;
            Array.Sort(nums);
            int[] result = new int[] { 0, len };
            int ptr1 = 0, ptr2, cnt;
            while (ptr1 < len)
            {
                ptr2 = ptr1 + 1;
                while (ptr2 < len && nums[ptr2] == nums[ptr1]) ptr2++;
                if ((cnt = (ptr2 - ptr1) >> 1) > 0)
                {
                    result[0] += cnt; result[1] -= cnt << 1;
                }
                ptr1 = ptr2;
            }

            return result;
        }

        /// <summary>
        /// 哈希表统计
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NumberOfPairs2(int[] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (freq.ContainsKey(nums[i])) freq[nums[i]]++; else freq.Add(nums[i], 1);
            }

            int[] result = new int[2];
            foreach (int value in freq.Values)
            {
                result[0] += value >> 1; result[1] += value & 1;
            }

            return result;
        }

        /// <summary>
        /// Linq
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NumberOfPairs3(int[] nums)
        {
            var freq = nums.GroupBy(i => i).Select(g => g.Count());
            return new int[] { freq.Sum(i => i >> 1), freq.Sum(i => i & 1) };
        }
    }
}
