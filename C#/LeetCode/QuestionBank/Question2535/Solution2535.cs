using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2535
{
    public class Solution2535 : Interface2535
    {
        public int DifferenceOfSum(int[] nums)
        {
            int sum_n = 0, sum_d = 0;
            for (int i = 0, num; i < nums.Length; i++)
            {
                sum_n += (num = nums[i]);
                while (num > 0)
                {
                    sum_d += num % 10; num /= 10;
                }
            }

            return Math.Abs(sum_n - sum_d);
        }

        /// <summary>
        /// 数字一定大于数位和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DifferenceOfSum2(int[] nums)
        {
            int sum_n = 0, sum_d = 0;
            for (int i = 0, num; i < nums.Length; i++)
            {
                sum_n += (num = nums[i]);
                while (num > 0)
                {
                    sum_d += num % 10; num /= 10;
                }
            }

            return sum_n - sum_d;
        }
    }
}
