using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1175
{
    public class Solution1175 : Interface1175
    {
        private const int MOD = 1000000007;

        /// <summary>
        /// 排列组合
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumPrimeArrangements(int n)
        {
            long cnt1 = 0, cnt2;
            for (int i = 1; i <= n; i++) if (IsPrime(i)) cnt1++;
            cnt2 = n - cnt1;

            long r1 = 1, r2 = 1;
            for (long i = cnt1; i > 1; i--) r1 = r1 * i % MOD;
            for (long i = cnt2; i > 1; i--) r2 = r2 * i % MOD;

            return (int)(r1 * r2 % MOD);
        }

        private bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if ((n & 1) != 1) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(n));

            for (int i = 3; i <= boundary; i += 2)
                if (n % i == 0) return false;

            return true;
        }
    }
}
