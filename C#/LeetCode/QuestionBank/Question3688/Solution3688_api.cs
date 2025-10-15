using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3688
{
    public class Solution3688_api : Interface3688
    {
        public int EvenNumberBitwiseORs(int[] nums)
        {
            return nums.Where(x => (x & 1) == 0).Aggregate(0, (x, y) => x | y);
        }
    }
}
