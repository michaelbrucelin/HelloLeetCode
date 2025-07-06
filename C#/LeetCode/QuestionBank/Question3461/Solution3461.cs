using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3461
{
    public class Solution3461 : Interface3461
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool HasSameDigits(string s)
        {
            int len = s.Length;
            int[] nums = new int[len];
            for (int i = 0; i < len; i++) nums[i] = s[i] & 15;
            // for (int i = len - 1; i > 1; i--) for (int j = 0; j < i; j++) nums[j] += nums[j + 1];
            for (int i = len - 1; i > 1; i--) for (int j = 0; j < i; j++) nums[j] = (nums[j] + nums[j + 1]) % 10;

            return nums[0] % 10 == nums[1] % 10;
        }
    }
}
