using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0258
{
    public class Solution0258 : Interface0258
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int AddDigits(int num)
        {
            while (num >= 10)
            {
                int t = 0;
                while (num > 0)
                {
                    var info = Math.DivRem(num, 10);
                    t += info.Remainder;
                    num = info.Quotient;
                }
                num = t;
            }

            return num;
        }
    }
}
