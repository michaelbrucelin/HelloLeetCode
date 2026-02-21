
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3818
{
    public class Solution3818 : Interface3818
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumPrefixLength(int[] nums)
        {
            int len = nums.Length, ptr = len - 1;
            while (ptr > 0 && nums[ptr] > nums[ptr - 1]) ptr--;

            return ptr;
        }
    }
}
