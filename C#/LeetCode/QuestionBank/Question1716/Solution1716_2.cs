using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1716
{
    public class Solution1716_2 : Interface1716
    {
        /// <summary>
        /// 数学
        /// 假设n = 26，则
        /// 1 2 3 4 5 6 7    28
        /// 2 3 4 5 6 7 8    35
        /// 3 4 5 6 7 8 9    42    3个整周期，公差为7的等差数列，3 = 26/7
        /// 4 5 6 7 8              5个零头，  公差为1的等差数列，5 = 26%7，4 = 26/7+1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TotalMoney(int n)
        {
            var info = Math.DivRem(n, 7);
            return (((56 + (info.Quotient - 1) * 7) * info.Quotient) >> 1) +
                   (((((info.Quotient + 1) << 1) + info.Remainder - 1) * info.Remainder) >> 1);
        }
    }
}
