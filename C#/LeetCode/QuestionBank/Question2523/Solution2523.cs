using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2523
{
    public class Solution2523 : Interface2523
    {
        /// <summary>
        /// 线性筛
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int[] ClosestPrimes(int left, int right)
        {
            List<int> primes = GetPrimes(right + 1);
            if (primes.Count < 2 || primes[^2] < left) return [-1, -1];
            int[] result = [primes[^2], primes[^1]];
            int min_diff = primes[^1] - primes[^2];
            for (int i = primes.Count - 2; i > 0 && primes[i - 1] >= left; i--)
            {
                if (primes[i] - primes[i - 1] > min_diff) continue;
                result[0] = primes[i - 1];
                result[1] = primes[i];
                min_diff = primes[i] - primes[i - 1];
            }

            return result;

            static List<int> GetPrimes(int n)
            {
                List<int> result = new List<int>();
                bool[] mask = new bool[n]; Array.Fill(mask, true);
                for (int i = 2; i < n; i++)
                {
                    if (mask[i]) result.Add(i);
                    for (int j = 0; j < result.Count && i * result[j] < n; j++)
                    {
                        mask[i * result[j]] = false;
                        if (i % result[j] == 0) break;
                    }
                }

                return result;
            }
        }
    }
}
