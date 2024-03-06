using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3065
{
    public class Solution3065_api : Interface3065
    {
        public int MinOperations(int[] nums, int k)
        {
            return nums.Count(i => i < k);
        }
    }
}
