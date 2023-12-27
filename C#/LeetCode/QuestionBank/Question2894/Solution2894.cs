using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2894
{
    public class Solution2894 : Interface2894
    {
        /// <summary>
        /// 数学
        /// 不能整除 - 能整除 = ALL - 能整除 * 2
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int DifferenceOfSums(int n, int m)
        {
            int k = n / m;
            return (n * (n + 1) >> 1) - m * k * (k + 1);
        }
    }
}
