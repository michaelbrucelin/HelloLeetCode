using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3065
{
    public class Solution3065 : Interface3065
    {
        public int MinOperations(int[] nums, int k)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++) if (nums[i] < k) result++;

            return result;
        }
    }
}
