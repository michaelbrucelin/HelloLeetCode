using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2908
{
    public class Solution2908 : Interface2908
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumSum(int[] nums)
        {
            int result = -1, sum, len = nums.Length;
            for (int i = 0; i < len - 2; i++) for (int j = i + 1; j < len - 1; j++) for (int k = j + 1; k < len; k++)
                    {
                        if (nums[i] < nums[j] && nums[j] > nums[k])
                        {
                            sum = nums[i] + nums[j] + nums[k];
                            result = result == -1 ? sum : Math.Min(result, sum);
                        }
                    }

            return result;
        }
    }
}
