using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3487
{
    public class Solution3487 : Interface3487
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSum(int[] nums)
        {
            Array.Sort(nums);
            if (nums[^1] <= 0) return nums[^1];

            int result = nums[^1];
            for (int i = nums.Length - 2; i > -1; i--)
            {
                if (nums[i] <= 0) break;
                if (nums[i] != nums[i + 1]) result += nums[i];
            }

            return result;
        }
    }
}
