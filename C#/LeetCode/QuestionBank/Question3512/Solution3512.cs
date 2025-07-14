using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3512
{
    public class Solution3512 : Interface3512
    {
        public int MinOperations(int[] nums, int k)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++) sum += nums[i];

            return sum % k;
        }
    }
}
