using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2057
{
    public class Solution2057 : Interface2057
    {
        public int SmallestEqual(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++) if (i % 10 == nums[i]) return i;

            return -1;
        }
    }
}
