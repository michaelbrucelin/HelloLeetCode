using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2341
{
    public class Solution2341 : Interface2341
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NumberOfPairs(int[] nums)
        {
            int ptr1 = 0, ptr2, len = nums.Length;
            int[] result = new int[] { 0, len };
            while (ptr1 < len)
            {
                ptr2 = ptr1 + 1;
                while (ptr2 < len && nums[ptr2] != nums[ptr1]) ptr2++;
                if (ptr2 < len)
                {
                    len -= 2;
                    for (int i = ptr1; i < ptr2 - 1; i++) nums[i] = nums[i + 1];
                    for (int i = ptr2 - 1; i < len; i++) nums[i] = nums[i + 2];
                    result[0]++; result[1] -= 2;
                }
                else
                {
                    ptr1++;
                }
            }

            return result;
        }
    }
}
