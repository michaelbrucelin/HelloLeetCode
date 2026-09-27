using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2104
{
    public class Solution2104 : Interface2104
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long SubArrayRanges(int[] nums)
        {
            long result = 0;
            int min, max, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                min = max = nums[i];
                for (int j = i + 1; j < len; j++)
                {
                    min = Math.Min(min, nums[j]);
                    max = Math.Max(max, nums[j]);
                    result += max - min;
                }
            }

            return result;
        }
    }
}
