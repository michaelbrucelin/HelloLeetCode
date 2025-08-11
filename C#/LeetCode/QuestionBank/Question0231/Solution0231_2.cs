using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0231
{
    public class Solution0231_2 : Interface0231
    {
        /// <summary>
        /// 数学
        /// 2^n分解质因数全部是2，所以2^n的约数是2的幂，反过来亦成立。
        /// 这种解法可以拓展为k的幂，k为质数。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo(int n)
        {
            if (n <= 0) return false;

            return ((1 << 30) % n) == 0;
        }

        private const int BIG2POW = 1 << 30;
        public bool IsPowerOfTwo2(int n)
        {
            if (n <= 0) return false;

            return (BIG2POW % n) == 0;
        }
    }
}
