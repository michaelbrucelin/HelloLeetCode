using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3774
{
    public class Solution3774 : Interface3774
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int AbsDifference(int[] nums, int k)
        {
            int result = 0, len = nums.Length;
            Array.Sort(nums);
            for (int i = 0; i < k; i++) result += nums[len - i - 1] - nums[i];

            return result;
        }
    }
}
