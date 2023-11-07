using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1175
{
    public class Solution1175_2 : Interface1175
    {
        private const int MOD = 1000000007;
        private List<int> cnts = new List<int>() { 0 };

        /// <summary>
        /// 与Solution1175逻辑一样，只是加了一层动态缓存
        /// 原则上可以打表的，这里就不搞了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumPrimeArrangements(int n)
        {
            if (cnts.Count - 1 < n)
            {
                for (int i = cnts.Count; i <= n; i++)
                    cnts.Add(IsPrime(i) ? cnts[^1] + 1 : cnts[^1]);
            }

            long cnt1 = cnts[n], cnt2 = n - cnt1, r1 = 1, r2 = 1;
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
