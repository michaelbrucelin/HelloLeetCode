using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3925
{
    public class Solution3925 : Interface3925
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ConcatWithReverse(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len << 1];
            for (int i = 0, j = (len << 1) - 1; i < len; i++, j--) result[i] = result[j] = nums[i];

            return result;
        }
    }
}
