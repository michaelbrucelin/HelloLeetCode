using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2395
{
    public class Solution2395 : Interface2395
    {
        public bool FindSubarrays(int[] nums)
        {
            if (nums.Length <= 2) return false;
            if (nums.Length == 3) return nums[0] == nums[2];

            HashSet<int> set = new HashSet<int>();
            for (int i = 1; i < nums.Length; i++)
                if (set.Contains(nums[i - 1] + nums[i])) return true; else set.Add(nums[i - 1] + nums[i]);

            return false;
        }
    }
}
