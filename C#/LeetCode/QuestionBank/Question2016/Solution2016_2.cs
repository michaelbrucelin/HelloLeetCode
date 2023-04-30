using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2016
{
    public class Solution2016_2 : Interface2016
    {
        public int MaximumDifference(int[] nums)
        {
            int result = -1, premin = nums[0];
            for (int i = 1; i < nums.Length; i++)  // 题目保证数组至少有2个元素
            {
                if (nums[i] > premin)
                    result = Math.Max(result, nums[i] - premin);
                else
                    premin = nums[i];
            }

            return result;
        }
    }
}
