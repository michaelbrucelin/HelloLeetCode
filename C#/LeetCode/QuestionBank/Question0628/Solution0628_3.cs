using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0628
{
    public class Solution0628_3 : Interface0628
    {
        public int MaximumProduct(int[] nums)
        {
            if (nums.Length == 3) return nums[0] * nums[1] * nums[2];

            int len = nums.Length;
            Array.Sort(nums);

            return Math.Max(nums[0] * nums[1] * nums[len - 1], nums[len - 1] * nums[len - 2] * nums[len - 3]);
        }
    }
}
