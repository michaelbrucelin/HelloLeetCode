using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2527
{
    public class Solution2527_api : Interface2527
    {
        public int XorBeauty(int[] nums)
        {
            return nums.Aggregate(0, (x, y) => x ^ y);
        }
    }
}
