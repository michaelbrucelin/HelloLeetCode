using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1018
{
    public class Solution1018 : Interface1018
    {
        private static readonly int[] bits = [2, 4, 8, 6];

        /// <summary>
        /// 数学
        /// 1. 能被5整除的数字，十进制的末位只有0与1两种可能
        /// 2. 二进制从低位到高位，每一位对应十进制的末位是有规律的
        ///     1    2    4    8   16   32   64  128  256  512 1024 2048 4096 8192
        ///     1    2    4    8    6    2    4    8    6    2    4    8    6    2
        /// 提交会超时
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5(int[] nums)
        {
            int len = nums.Length;
            bool[] result = new bool[len];
            for (int i = 0, add; i < len; i++)
            {
                add = nums[i];  // add记录对应十进制末位的和，题意的限制可以保证int不溢出
                for (int j = 1; j <= i; j++) if (nums[i - j] != 0) add += bits[(j - 1) % 4];
                result[i] = add % 5 == 0;
            }

            return result;
        }
    }
}
