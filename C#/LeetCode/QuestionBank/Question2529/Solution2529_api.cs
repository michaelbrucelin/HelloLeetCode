using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2529
{
    public class Solution2529_api : Interface2529
    {
        public int MaximumCount(int[] nums)
        {
            return Math.Max(nums.Count(i => i < 0), nums.Count(i => i > 0));
        }
    }
}
