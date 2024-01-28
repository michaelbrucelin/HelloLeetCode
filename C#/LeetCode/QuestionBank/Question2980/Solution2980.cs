using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2980
{
    public class Solution2980 : Interface2980
    {
        /// <summary>
        /// 遍历
        /// 二进制尾随0，即是偶数，所以只有数组中偶数小于2个时，结果才为false
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool HasTrailingZeros(int[] nums)
        {
            int cnt = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                cnt += 1 - (nums[i] & 1);
                if (cnt >= 2) return true;
            }

            return false;
        }
    }
}
