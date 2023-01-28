using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0217
{
    public class Solution0217_2 : Interface0217
    {
        public bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length == 1) return false;

            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++) if (nums[i] == nums[i - 1]) return true;

            return false;
        }
    }
}
