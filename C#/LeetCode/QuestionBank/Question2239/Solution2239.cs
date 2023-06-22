using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2239
{
    public class Solution2239 : Interface2239
    {
        public int FindClosestNumber(int[] nums)
        {
            int result = int.MaxValue;
            for (int i = 0, num; i < nums.Length; i++)
            {
                num = nums[i];
                if (Math.Abs(num) < Math.Abs(result) || (Math.Abs(num) == Math.Abs(result) && num > result))
                    result = num;
            }

            return result;
        }
    }
}
