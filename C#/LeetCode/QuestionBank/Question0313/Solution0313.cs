using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0313
{
    public class Solution0313 : Interface0313
    {
        /// <summary>
        /// 小顶堆 + Hash
        /// </summary>
        /// <param name="n"></param>
        /// <param name="primes"></param>
        /// <returns></returns>
        public int NthSuperUglyNumber(int n, int[] primes)
        {
            if (n == 1) return 1;
            if (--n == 1) return primes[0];

            long x, y, len = primes.Length;
            PriorityQueue<long, long> minpq = new PriorityQueue<long, long>();
            HashSet<long> set = new HashSet<long>();
            for (int i = 0; i < len; i++) { minpq.Enqueue(primes[i], primes[i]); set.Add(primes[i]); }
            while (--n > 0)
            {
                x = minpq.Dequeue();
                for (int i = 0; i < len; i++) if (set.Add(y = x * primes[i])) minpq.Enqueue(y, y);
            }

            return (int)minpq.Dequeue();
        }
    }
}
