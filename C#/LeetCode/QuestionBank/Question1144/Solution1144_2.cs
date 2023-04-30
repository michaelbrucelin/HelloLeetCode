using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1144
{
    public class Solution1144_2 : Interface1144
    {
        public int MovesToMakeZigzag(int[] nums)
        {
            int result1 = 0, result2 = 0, len = nums.Length;

            // 第1种可能：/\/\/\
            for (int i = 0, adjust = 0; i < len; i += 2, adjust = 0)
            {
                if (i - 1 >= 0) adjust = Math.Max(adjust, nums[i] - nums[i - 1] + 1);
                if (i + 1 < len) adjust = Math.Max(adjust, nums[i] - nums[i + 1] + 1);
                result1 += adjust;
            }

            // 第2种可能：\/\/\/
            for (int i = 1, adjust = 0; i < len; i += 2, adjust = 0)
            {
                if (i - 1 >= 0) adjust = Math.Max(adjust, nums[i] - nums[i - 1] + 1);
                if (i + 1 < len) adjust = Math.Max(adjust, nums[i] - nums[i + 1] + 1);
                result2 += adjust;
                if (result2 > result1) break;
            }

            return Math.Min(result1, result2);
        }
    }
}
