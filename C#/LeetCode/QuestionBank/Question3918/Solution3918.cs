using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3918
{
    public class Solution3918 : Interface3918
    {
        static Solution3918()
        {
            primes = Primes(1001);
        }

        private static List<int> primes;

        /// <summary>
        /// 线性筛
        /// 
        /// 简单题加点花活，静态构造函数预处理
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SumOfPrimesInRange(int n)
        {
            int min = n, max = 0;
            while (n > 0) { max = max * 10 + n % 10; n /= 10; }
            (min, max) = (Math.Min(min, max), Math.Max(min, max));

            int result = 0, id = 0, cnt = primes.Count;
            while (id < cnt && primes[id] < min) id++;                     // 这里可以使用二分 + 前缀和优化，数据量太小没必要了
            while (id < cnt && primes[id] <= max) result += primes[id++];

            return result;
        }

        private static List<int> Primes(int n)
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
