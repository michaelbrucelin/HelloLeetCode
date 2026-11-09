using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2579
{
    public class Solution2579 : Interface2579
    {
        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long ColoredCells(int n)
        {
            long last = (0L + n - 1) << 2;
            return ((0 + last) * n >> 1) + 1;
        }
    }
}
