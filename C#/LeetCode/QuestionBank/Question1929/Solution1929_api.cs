using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1929
{
    public class Solution1929_api : Interface1929
    {
        public int[] GetConcatenation(int[] nums)
        {
            return nums.Concat(nums).ToArray();
        }
    }
}
