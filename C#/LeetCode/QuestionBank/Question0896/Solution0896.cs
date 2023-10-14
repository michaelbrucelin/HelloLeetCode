using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0896
{
    public class Solution0896 : Interface0896
    {
        public bool IsMonotonic(int[] nums)
        {
            if (nums.Length <= 2) return true;

            int sign = 0, ptr = 1, len = nums.Length;
            for (; ptr < len; ptr++) if ((sign = Math.Sign(nums[ptr] - nums[ptr - 1])) != 0) break;
            for (; ptr < len; ptr++) if (Math.Sign(nums[ptr] - nums[ptr - 1]) * sign < 0) return false;

            return true;
        }
    }
}
