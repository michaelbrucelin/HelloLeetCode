using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3010
{
    public class Solution3010 : Interface3010
    {
        /// <summary>
        /// 取第一项及后面所有项中的两个最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumCost(int[] nums)
        {
            int first = nums[0], second = int.MaxValue, third = int.MaxValue, len = nums.Length;
            for (int i = 1, num; i < len; i++)
            {
                num = nums[i];
                if (num < second)
                {
                    third = second; second = num;
                }
                else if (num < third)
                {
                    third = num;
                }
            }

            return first + second + third;
        }
    }
}
