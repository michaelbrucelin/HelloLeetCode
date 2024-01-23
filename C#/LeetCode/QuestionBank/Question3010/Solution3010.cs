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
            int result = nums[0], first = int.MaxValue, second = int.MaxValue;
            for (int i = 1, num; i < nums.Length; i++)
            {
                num = nums[i];
                if (num < first)
                {
                    second = first; first = num;
                }
                else if (num < second)
                {
                    second = num;
                }
            }

            return result + first + second;
        }
    }
}
