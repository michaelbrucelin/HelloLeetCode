using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1137
{
    public class Solution1137 : Interface1137
    {
        /// <summary>
        /// 递归
        /// n=35时TLE
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Tribonacci(int n)
        {
            switch (n)
            {
                case 0: return 0;
                case 1: return 1;
                case 2: return 1;
                default: return Tribonacci(n - 3) + Tribonacci(n - 2) + Tribonacci(n - 1);
            }
        }
    }
}
