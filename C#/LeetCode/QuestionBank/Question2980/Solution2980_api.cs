using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2980
{
    public class Solution2980_api : Interface2980
    {
        public bool HasTrailingZeros(int[] nums)
        {
            return nums.Count(i => (i & 1) == 0) >= 2;
        }

        public bool HasTrailingZeros2(int[] nums)
        {
            return nums.Sum(i => 1 - (i & 1)) >= 2;
        }
    }
}
