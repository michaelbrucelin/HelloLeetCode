using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0905
{
    public class Solution0905 : Interface0905
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortArrayByParity(int[] nums)
        {
            int len = nums.Length; int ptr_l = 0, ptr_r = len - 1;
            int[] result = new int[len];
            for (int i = 0; i < len; i++)
            {
                if ((nums[i] & 1) != 1)
                    result[ptr_l++] = nums[i];
                else
                    result[ptr_r--] = nums[i];
            }

            return result;
        }
    }
}
