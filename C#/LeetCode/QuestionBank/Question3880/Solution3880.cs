using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3880
{
    public class Solution3880 : Interface3880
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinAbsoluteDifference(int[] nums)
        {
            int result = nums.Length, len = nums.Length;
            int val = -1, idx = 0, ptr;
            while (idx < len && nums[idx] == 0) idx++;
            if (idx >= len - 1) return -1;
            val = nums[idx]; ptr = idx;
            while (++ptr < len) if (nums[ptr] != 0)
                {
                    if (nums[ptr] != nums[idx]) result = Math.Min(result, ptr - idx);
                    idx = ptr;
                }

            return result != nums.Length ? result : -1;
        }
    }
}
