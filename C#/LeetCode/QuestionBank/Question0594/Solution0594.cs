using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0594
{
    public class Solution0594 : Interface0594
    {
        /// <summary>
        /// 分析
        /// 统计每个元素的数量，找出相邻元素对中数目最多的那对
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindLHS(int[] nums)
        {
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                if (buffer.ContainsKey(nums[i])) buffer[nums[i]]++; else buffer.Add(nums[i], 1);

            int result = 0;
            foreach (var kv in buffer)
            {
                if (buffer.ContainsKey(kv.Key - 1)) result = Math.Max(result, kv.Value + buffer[kv.Key - 1]);
                // if (buffer.ContainsKey(kv.Key + 1)) result = Math.Max(result, kv.Value + buffer[kv.Key + 1]);
            }

            return result;
        }
    }
}
