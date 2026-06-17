using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3345
{
    public class Solution3345 : Interface3345
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="n"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int SmallestNumber(int n, int t)
        {
            if (t == 1 || n % 10 == 0) return n;
            while (!check(n, t)) n++;
            return n;

            static bool check(int x, int y)
            {
                int prod = 1;
                while (x > 0)
                {
                    if ((prod *= x % 10) == 0) return true;
                    x /= 10;
                }
                return prod % y == 0;
            }
        }
    }
}
