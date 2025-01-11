using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1608
{
    public class Solution1608 : Interface1608
    {
        /// <summary>
        /// 排序 + 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SpecialArray(int[] nums)
        {
            Array.Sort(nums);
            int ptr = nums.Length, x, len = nums.Length;
            while (--ptr >= 0)
            {
                if (ptr > 0)
                {
                    if (nums[ptr] != nums[ptr - 1])
                    {
                        x = len - ptr;
                        if (x <= nums[ptr] && x > nums[ptr - 1]) return x;
                        if (x >= nums[ptr - 1]) return -1;
                    }
                }
                else
                {
                    if (len <= nums[0]) return len;
                }
            }

            return -1;
        }
    }
}
