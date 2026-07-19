using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1979
{
    public class Solution1979_2
    {
        /// <summary>
        /// 更相减损术，出自《九章算术》
        /// 优点：对于两个大整数，减法运算比取模（求余）运算更快
        /// 缺点：如果两个整数相差较大，递归的层数太多，例如GetGCD2(1, 10000)，需要递归9999次
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindGCD(int[] nums)
        {
            int min = nums[0], max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < min) min = nums[i]; else if (nums[i] > max) max = nums[i];
            }

            return GetGCD(min, max);

            static int GetGCD(int x, int y)
            {
                if (x == y) return x;

                int big = x > y ? x : y;
                int small = x > y ? y : x;

                return GetGCD(big - small, small);
            }
        }
    }
}
