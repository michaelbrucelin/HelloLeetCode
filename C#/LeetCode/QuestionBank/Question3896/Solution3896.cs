using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3896
{
    public class Solution3896 : Interface3896
    {
        static Solution3896()
        {
            List<int> _primes = GetPrimes(100004);  // 100003是质数
            primes = [.. _primes];
            map = new int[100004];
            for (int i = 0, j = 0, p = 0; i < 100004; i++) if (i == _primes[j])
                {
                    while (p <= i) map[p++] = i;
                    j++;
                }
        }

        private static HashSet<int> primes;
        private static int[] map;

        /// <summary>
        /// 线性筛
        /// 使用线性筛找出需要的质数，然后构造每一个合数对应的下一个质数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if ((i & 1) == 0)
                {
                    if (!primes.Contains(num)) result += map[num] - num;
                }
                else
                {
                    if (primes.Contains(num)) result += (num != 2 ? 1 : 2);
                }
            }

            return result;
        }

        private static List<int> GetPrimes(int n)
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
