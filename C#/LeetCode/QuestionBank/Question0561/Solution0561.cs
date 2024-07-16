using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0561
{
    public class Solution0561 : Interface0561
    {
        /// <summary>
        /// 排序 + 贪心
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);
            int result = 0;
            for (int i = 0; i < nums.Length; i += 2) result += nums[i];

            return result;
        }
    }
}
