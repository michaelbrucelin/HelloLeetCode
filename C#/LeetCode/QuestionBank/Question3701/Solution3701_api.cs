using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3701
{
    public class Solution3701_api : Interface3701
    {
        public int AlternatingSum(int[] nums)
        {
            return nums.Select((val, idx) => val * (1 - (idx & 1) * 2)).Sum();
        }
    }
}
