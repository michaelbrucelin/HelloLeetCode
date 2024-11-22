using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3233
{
    public class Solution3233 : Interface3233
    {
        /// <summary>
        /// 数学, 线性筛 + 二分法
        /// 题目的定义的“特殊数字”的充要条件是数字是质数的平方，所以只要找出来[l, r]之间有多少个质数的平方即可
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public int NonSpecialCount(int l, int r)
        {
            List<int> primes = GetPrimes((int)Math.Sqrt(r));
            int low = 0, high = primes.Count - 1, mid, id = primes.Count, L = (int)Math.Ceiling(Math.Sqrt(l));
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (primes[mid] >= L) { id = mid; high = mid - 1; } else { low = mid + 1; }
            }

            return r - l + 1 - (primes.Count - id);

            List<int> GetPrimes(int n)
            {
                List<int> result = new List<int>();
                bool[] mask = new bool[n + 1]; Array.Fill(mask, true);
                for (int i = 2; i <= n; i++)
                {
                    if (mask[i]) result.Add(i);
                    for (int j = 0; j < result.Count && i * result[j] <= n; j++)
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
