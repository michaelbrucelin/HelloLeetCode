using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1984
{
    public class Solution1984_api : Interface1984
    {
        public int MinimumDifference(int[] nums, int k)
        {
            if (k == 1) return 0;

            Array.Sort(nums);
            return Enumerable.Range(0, nums.Length - k + 1)
                             .Select(i => nums[i + k - 1] - nums[i])
                             .Min();
        }
    }
}
