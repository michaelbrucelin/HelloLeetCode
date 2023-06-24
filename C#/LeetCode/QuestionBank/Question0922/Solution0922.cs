using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0922
{
    public class Solution0922 : Interface0922
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortArrayByParityII(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            for (int i = 0, num, even = 0, odd = 1; i < len; i++)
            {
                num = nums[i];
                if ((num & 1) != 0)
                {
                    result[odd] = num; odd += 2;
                }
                else
                {
                    result[even] = num; even += 2;
                }
            }

            return result;
        }
    }
}
