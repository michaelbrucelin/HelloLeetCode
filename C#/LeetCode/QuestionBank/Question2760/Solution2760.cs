using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2760
{
    public class Solution2760 : Interface2760
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public int LongestAlternatingSubarray(int[] nums, int threshold)
        {
            int result = 0, len = nums.Length, ptr_l = 0, ptr_r;
            while (ptr_l < len)
            {
                if ((nums[ptr_l] & 1) != 0 || nums[ptr_l] > threshold) { ptr_l++; continue; }
                ptr_r = ptr_l + 1;
                while (ptr_r < len)
                {
                    if ((nums[ptr_r] & 1) != (nums[ptr_r - 1] & 1) && nums[ptr_r] <= threshold) ptr_r++; else break;
                }
                result = Math.Max(result, ptr_r - ptr_l);
                ptr_l = ptr_r;
            }

            return result;
        }
    }
}
