using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0326
{
    public class Solution0326 : Interface0326
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfThree(int n)
        {
            if (n < 1) return false;

            while (n >= 3)
            {
                var info = Math.DivRem(n, 3);
                if (info.Remainder != 0) return false;
                n = info.Quotient;
            }

            return n == 1;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfThree2(int n)
        {
            if (n == 1) return true;
            if (n < 3) return false;

            var info = Math.DivRem(n, 3);
            if (info.Remainder != 0) return false;
            return IsPowerOfThree2(info.Quotient);
        }
    }
}
