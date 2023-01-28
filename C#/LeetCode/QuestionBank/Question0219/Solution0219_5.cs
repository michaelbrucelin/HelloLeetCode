using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0219
{
    public class Solution0219_5 : Interface0219
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (k == 0 || nums.Length == 1) return false;

            HashSet<int> buffer = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > k) buffer.Remove(nums[i - k - 1]);
                if (!buffer.Add(nums[i])) return true;
            }

            return false;
        }
    }
}
