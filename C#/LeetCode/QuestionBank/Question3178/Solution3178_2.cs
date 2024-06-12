using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3178
{
    public class Solution3178_2 : Interface3178
    {
        /// <summary>
        /// 数学
        /// 将k看作自变量，从1开始递增，那么结果为 1 .. n-1, n-1..0, 1..n-1, n-1..0, ... ...
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumberOfChild(int n, int k)
        {
            int mod = (n - 1) << 1;
            int _n = k % mod;

            return _n < n - 1 ? _n : mod - _n;
        }
    }
}
