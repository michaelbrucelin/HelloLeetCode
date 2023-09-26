using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2582
{
    public class Solution2582_2 : Interface2582
    {
        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int PassThePillow(int n, int time)
        {
            var t = Math.DivRem(time, n - 1);
            return (t.Quotient & 1) == 0 ? t.Remainder + 1 : n - t.Remainder;
        }
    }
}
