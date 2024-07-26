using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2740
{
    public class Solution2740 : Interface2740
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindValueOfPartition(int[] nums)
        {
            Array.Sort(nums);
            int result = nums[1] - nums[0];
            for (int i = 2, len = nums.Length; i < len; i++) result = Math.Min(result, nums[i] - nums[i - 1]);

            return result;
        }
    }
}
