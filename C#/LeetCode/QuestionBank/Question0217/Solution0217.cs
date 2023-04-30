using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0217
{
    public class Solution0217 : Interface0217
    {
        public bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length == 1) return false;

            HashSet<int> buffer = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (buffer.Contains(nums[i])) return true;
                buffer.Add(nums[i]);
            }

            return false;
        }

        public bool ContainsDuplicate2(int[] nums)
        {
            if (nums.Length == 1) return false;

            return !(nums.Length == nums.Distinct().Count());
        }
    }
}
