using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1920
{
    public class Solution1920_3 : Interface1920
    {
        /// <summary>
        /// 原地
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] BuildArray(int[] nums)
        {
            int len = nums.Length;
            const int mul = 10000;
            for (int i = 0; i < len; i++) nums[i] += (nums[nums[i]] % mul) * mul;
            for (int i = 0; i < len; i++) nums[i] /= mul;

            return nums;
        }
    }
}
