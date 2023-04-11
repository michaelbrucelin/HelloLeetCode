using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0485
{
    public class Solution0485 : Interface0485
    {
        /// <summary>
        /// 遍历一次，统计1
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int result = 0, cnt = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                switch (nums[i])
                {
                    case 1:
                        cnt++;
                        break;
                    default:  // case 0:
                        result = Math.Max(result, cnt); cnt = 0;
                        break;
                }
            }

            return Math.Max(result, cnt);
        }

        /// <summary>
        /// 遍历一次，统计0
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxConsecutiveOnes2(int[] nums)
        {
            int result = 0, id = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    result = Math.Max(result, i - id - 1);
                    id = i;
                }
            }

            return Math.Max(result, nums.Length - id - 1);
        }
    }
}
