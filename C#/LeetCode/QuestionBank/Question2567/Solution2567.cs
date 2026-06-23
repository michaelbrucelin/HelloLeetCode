using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2567
{
    public class Solution2567 : Interface2567
    {
        /// <summary>
        /// 分类讨论
        /// 如果数组长度小于等于3，结果为0
        /// 先将nums排序，分3种情况
        ///     nums[0]  -> nums[1],  nums[^1] -> nums[^2]
        ///     nums[0]  -> nums[2],  nums[1]  -> nums[2]
        ///     nums[^1] -> nums[^3], nums[^2] -> nums[^3]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimizeSum(int[] nums)
        {
            if (nums.Length < 4) return 0;

            Array.Sort(nums);
            int result = nums[^2] - nums[1];
            result = Math.Min(result, nums[^1] - nums[2]);
            result = Math.Min(result, nums[^3] - nums[0]);

            return result;
        }
    }
}
