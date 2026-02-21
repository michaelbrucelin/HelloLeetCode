using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3708
{
    public class Solution3708 : Interface3708
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestSubarray(int[] nums)
        {
            if (nums.Length < 3) return nums.Length;

            int result = 2, _result = 2, len = nums.Length;
            for (int i = 2; i < len; i++)
            {
                if (nums[i] == nums[i - 1] + nums[i - 2])
                {
                    _result++;
                }
                else
                {
                    result = Math.Max(result, _result);
                    _result = 2;
                }
            }
            result = Math.Max(result, _result);

            return result;
        }
    }
}
