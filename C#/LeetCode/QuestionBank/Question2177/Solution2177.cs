using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2177
{
    public class Solution2177 : Interface2177
    {
        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public long[] SumOfThree(long num)
        {
            if (num % 3 != 0) return [];

            long x = num / 3;
            return [x - 1, x, x + 1];
        }
    }
}
