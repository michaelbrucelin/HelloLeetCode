using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1984
{
    public class Solution1984 : Interface1984
    {
        public int MinimumDifference(int[] nums, int k)
        {
            if (k == 1) return 0;

            Array.Sort(nums);
            int len = nums.Length; int result = nums[len - 1] - nums[0];
            for (int i = 0; i <= len - k; i++)
            {
                result = Math.Min(result, nums[i + k - 1] - nums[i]);
                if (result == 0) return 0;
            }

            return result;
        }
    }
}
