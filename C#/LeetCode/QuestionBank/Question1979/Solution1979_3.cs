using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1979
{
    public class Solution1979_3
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
        /// 结合使用辗转相除法与更相减损术的优势，在更相减损术基础上通过移位运算来加速
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int GetGCD(int x, int y)
        {
            if (x == y) return x;

            if ((x & 1) == 0 && (y & 1) == 0)
                return GetGCD(x >> 1, y >> 1) << 1;
            else if ((x & 1) == 0 && (y & 1) == 1)
                return GetGCD(x >> 1, y);
            else if ((x & 1) == 1 && (y & 1) == 0)
                return GetGCD(x, y >> 1);
            else
            {
                if (x > y)
                    return GetGCD(x - y, y);
                else
                    return GetGCD(x, y - x);
            }
        }
    }
}
