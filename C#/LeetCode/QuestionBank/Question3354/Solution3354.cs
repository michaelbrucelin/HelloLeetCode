using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3354
{
    public class Solution3354 : Interface3354
    {
        /// <summary>
        /// 脑筋急转弯
        /// 0左右的数值和的差不能超过1即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountValidSelections(int[] nums)
        {
            int result = 0, sum = 0, len = nums.Length;
            for (int i = 0; i < len; i++) sum += nums[i];
            if (sum == 0) return len << 1;
            if (sum == 1) return len - 1;

            int left = 0, right = sum - nums[0];
            for (int i = 1; i < len; i++)
            {
                left += nums[i - 1]; right -= nums[i];
                if (nums[i] == 0)
                {
                    if (left == right)
                    {
                        result += 2;
                    }
                    else if (left - right == 1 || right - left == 1)
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
