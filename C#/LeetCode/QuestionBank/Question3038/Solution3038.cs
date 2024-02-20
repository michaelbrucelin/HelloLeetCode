using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3038
{
    public class Solution3038 : Interface3038
    {
        public int MaxOperations(int[] nums)
        {
            int result = 1, add = nums[0] + nums[1], len = nums.Length;
            for (int i = 3; i < len; i += 2)
            {
                if (nums[i - 1] + nums[i] != add) break;
                result++;
            }

            return result;
        }
    }
}
