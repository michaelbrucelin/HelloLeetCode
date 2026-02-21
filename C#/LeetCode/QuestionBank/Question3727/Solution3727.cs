using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3727
{
    public class Solution3727 : Interface3727
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxAlternatingSum(int[] nums)
        {
            int len = nums.Length;
            long[] _nums = new long[len];
            for (int i = 0; i < len; i++) _nums[i] = 1L * nums[i] * nums[i];
            Array.Sort(_nums);

            long result = 0; int boundary = len >> 1;
            for (int i = 0; i < boundary; i++) result -= _nums[i];
            for (int i = boundary; i < len; i++) result += _nums[i];

            return result;
        }
    }
}
