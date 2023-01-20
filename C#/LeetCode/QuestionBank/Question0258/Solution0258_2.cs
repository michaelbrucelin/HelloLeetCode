using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0258
{
    public class Solution0258_2 : Interface0258
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int AddDigits(int num)
        {
            if (num < 10) return num;

            int _num = 0;
            while (num > 0)
            {
                var info = Math.DivRem(num, 10);
                _num += info.Remainder;
                num = info.Quotient;
            }
            return AddDigits(_num);
        }
    }
}
