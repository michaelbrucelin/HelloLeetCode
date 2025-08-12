using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0326
{
    public class Solution0326_3 : Interface0326
    {
        /// <summary>
        /// 数学
        /// 3^n分解质因数全部是3，所以3^n的约数是3的幂，反过来亦成立。
        /// 这种解法可以拓展为k的幂，k为质数。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfThree(int n)
        {
            if (n <= 0) return false;

            const int max3pow = 1162261467;
            return (max3pow % n) == 0;
        }

        /// <summary>
        /// 表达式主体
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfThree2(int n) => n > 0 && (1162261467 % n) == 0;
    }
}
