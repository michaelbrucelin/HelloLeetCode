using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0922
{
    public class Solution0922_2 : Interface0922
    {
        /// <summary>
        /// 原地交换
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortArrayByParityII(int[] nums)
        {
            int len = nums.Length, even = 0, odd = 1, t;
            while (true)
            {
                while (even < len && ((nums[even] & 1) != 1)) even += 2;
                if (even >= len) break;
                while (odd < len && ((nums[odd] & 1) != 0)) odd += 2;
                if (odd >= len) break;

                t = nums[odd]; nums[odd] = nums[even]; nums[even] = t;
            }

            return nums;
        }
    }
}
