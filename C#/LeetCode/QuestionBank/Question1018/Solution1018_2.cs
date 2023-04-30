using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1018
{
    public class Solution1018_2 : Interface1018
    {
        /// <summary>
        /// 模拟
        /// 模拟二进制转十进制，每次只保留十进制的最后一位即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5(int[] nums)
        {
            int len = nums.Length;
            bool[] result = new bool[len];
            for (int i = 0, add = 0; i < len; i++)
            {
                add = ((add << 1) + nums[i]) % 10;
                result[i] = add == 0 || add == 5;
            }

            return result;
        }

        /// <summary>
        /// PrefixesDivBy5()改进版
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy52(int[] nums)
        {
            int len = nums.Length;
            bool[] result = new bool[len];
            for (int i = 0, add = 0; i < len; i++)
            {
                add = ((add << 1) + nums[i]) % 5;
                result[i] = add == 0;
            }

            return result;
        }
    }
}
