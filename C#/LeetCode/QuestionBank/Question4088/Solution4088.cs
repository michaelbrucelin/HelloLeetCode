using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4088
{
    public class Solution4088 : Interface4088
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PeakValleyDifference(int[] nums)
        {
            int result = 0, len = nums.Length - 1;
            for (int i = 1; i < len; i++)
            {
                if (nums[i] > nums[i - 1] && nums[i] > nums[i + 1]) result += nums[i];
                else if (nums[i] < nums[i - 1] && nums[i] < nums[i + 1]) result -= nums[i];
            }

            return result;
        }
    }
}
