using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0371
{
    public class Solution0371 : Interface0371
    {
        /// <summary>
        /// 位运算
        /// 参考官解
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int GetSum(int a, int b)
        {
            int carry;
            while (b != 0)
            {
                carry = (a & b) << 1;
                a ^= b;
                b = carry;
            }

            return a;
        }

        public int GetSum2(int a, int b)
        {
            while (b != 0) (a, b) = (a ^ b, (a & b) << 1);

            return a;
        }
    }
}
