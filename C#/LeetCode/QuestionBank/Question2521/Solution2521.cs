using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2521
{
    public class Solution2521 : Interface2521
    {
        /// <summary>
        /// 线性筛
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DistinctPrimeFactors(int[] nums)
        {
            HashSet<int> primes = [.. GetPrimes(1001)];
            int result = 0, len = nums.Length;
            for (int i = 0, num; i < len && primes.Count > 0; i++)
            {
                num = nums[i];
                foreach (int prime in primes) if (num % prime == 0) { result++; primes.Remove(prime); }
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
