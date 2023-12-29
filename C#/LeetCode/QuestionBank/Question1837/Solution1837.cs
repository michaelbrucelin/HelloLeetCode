using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1837
{
    public class Solution1837 : Interface1837
    {
        /// <summary>
        /// 进制转换
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SumBase(int n, int k)
        {
            int result = 0;
            (int Quotient, int Remainder) info;
            while (n > 0)
            {
                info = Math.DivRem(n, k);
                result += info.Remainder;
                n = info.Quotient;
            }

            return result;
        }
    }
}
