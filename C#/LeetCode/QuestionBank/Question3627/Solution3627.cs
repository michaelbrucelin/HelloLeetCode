using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3627
{
    public class Solution3627 : Interface3627
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumMedianSum(int[] nums)
        {
            long result = 0;
            Array.Sort(nums);
            for (int i = nums.Length - 2, lo = nums.Length / 3; i >= lo; i -= 2) result += nums[i];

            return result;
        }
    }
}
