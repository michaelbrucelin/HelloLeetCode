using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1979
{
    public class Solution1979 : Interface1979
    {
        public int FindGCD(int[] nums)
        {
            int min = nums[0], max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < min) min = nums[i]; else if (nums[i] > max) max = nums[i];
            }

            return GetGCD(min, max);
        }

        /// <summary>
        /// 计算两个整数的最大公约数
        /// 使用辗转相除法，弊端：当两个整数较大时，取模（求余）运算的性能比较差
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int GetGCD(int x, int y)
        {
            int big = x > y ? x : y;
            int small = x > y ? y : x;

            if (big % small == 0)
                return small;

            return GetGCD(big % small, small);
        }
    }
}
