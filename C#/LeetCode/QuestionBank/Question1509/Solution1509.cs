using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1509
{
    public class Solution1509 : Interface1509
    {
        /// <summary>
        /// 分类讨论
        /// 也可以不排序，找出数组中最小的4个值与最大的4个值，这里就不写了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinDifference(int[] nums)
        {
            if (nums.Length < 5) return 0;

            Array.Sort(nums);
            int result = nums[^1] - nums[3];
            result = Math.Min(result, nums[^2] - nums[2]);
            result = Math.Min(result, nums[^3] - nums[1]);
            result = Math.Min(result, nums[^4] - nums[0]);

            return result;
        }
    }
}
