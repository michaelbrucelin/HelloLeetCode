using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3674
{
    public class Solution3674_api : Interface3674
    {
        public int MinOperations(int[] nums)
        {
            return nums.Any(x => x != nums[0]) ? 1 : 0;
        }
    }
}
