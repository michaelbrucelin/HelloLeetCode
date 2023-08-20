using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2778
{
    public class Solution2778 : Interface2778
    {
        public int SumOfSquares(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len; i++)
                if (len % (i + 1) == 0) result += nums[i] * nums[i];

            return result;
        }
    }
}
