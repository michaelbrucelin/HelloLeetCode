using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3028
{
    public class Solution3028 : Interface3028
    {
        public int ReturnToBoundaryCount(int[] nums)
        {
            int result = 0;
            for (int i = 0, dist = 0; i < nums.Length; i++)
                if ((dist += nums[i]) == 0) result++;

            return result;
        }
    }
}
