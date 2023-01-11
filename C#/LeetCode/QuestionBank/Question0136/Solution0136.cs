using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0136
{
    public class Solution0136 : Interface0136
    {
        public int SingleNumber(int[] nums)
        {
            int result = nums[0];
            for (int i = 1; i < nums.Length; i++) result ^= nums[i];

            return result;
        }
    }
}
