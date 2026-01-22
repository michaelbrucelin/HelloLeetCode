using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1877
{
    public class Solution1887 : Interface1877
    {
        /// <summary>
        /// 贪心
        /// 排序，最大+最小，一定是最优解
        /// a1 < a2 <a3 <a4，如果不是a1 + a4，a2 + a3，反证法即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinPairSum(int[] nums)
        {
            Array.Sort(nums);
            int result = nums[0] + nums[^1];
            for (int i = 1, j = nums.Length - 2; i < j; i++, j--) result = Math.Max(result, nums[i] + nums[j]);

            return result;
        }
    }
}
