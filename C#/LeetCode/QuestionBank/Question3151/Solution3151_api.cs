using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3151
{
    public class Solution3151_api : Interface3151
    {
        public bool IsArraySpecial(int[] nums)
        {
            return Enumerable.Range(1, nums.Length - 1).All(i => (nums[i - 1] & 1) + (nums[i] & 1) == 1);
        }
    }
}
