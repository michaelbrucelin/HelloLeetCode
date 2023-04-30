using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2016
{
    public class Solution2016 : Interface2016
    {
        public int MaximumDifference(int[] nums)
        {
            int result = -1, ptr1 = 0, ptr2, dist, len = nums.Length;  // 题目保证数组至少有2个元素
            while (ptr1 < len)
            {
                ptr2 = ptr1 + 1;
                while (ptr2 < len && (dist = nums[ptr2] - nums[ptr1]) >= 0)
                {
                    if (dist > 0) result = Math.Max(result, dist);
                    ptr2++;
                }
                ptr1 = ptr2;
            }

            return result;
        }
    }
}
