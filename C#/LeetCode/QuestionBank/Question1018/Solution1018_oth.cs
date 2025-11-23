using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1018
{
    public class Solution1018_oth : Interface1018
    {
        private static readonly int[,] states = new int[,] { { 0, 1 }, { 2, 3 }, { 4, 0 }, { 1, 2 }, { 3, 4 } };

        /// <summary>
        /// 有限状态机
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5(int[] nums)
        {
            int len = nums.Length;
            bool[] result = new bool[len];
            for (int i = 0, m = 0; i < len; i++)
            {
                m = states[m, nums[i]];
                result[i] = m == 0;
            }

            return result;
        }
    }
}
