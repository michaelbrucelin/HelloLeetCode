using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0952
{
    public class Solution0952 : Interface0952
    {
        /// <summary>
        /// 并查集 + 线性筛
        /// 不能两两union数组中的元素，会TLE，需要用数组中的元素和自身的质因数"union"
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LargestComponentSize(int[] nums)
        {
            int max = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, nums[i]);
            List<int> primes = GetPrimes(max + 1);
            int[] uf = new int[max + 1];
            int[] rank = new int[max + 1];
            for (int i = 1; i <= max; i++) uf[i] = i;
            for (int i = 0, num, cnt = primes.Count; i < len; i++)
            {
                num = nums[i];
                for (int j = 0; j < cnt && num >= primes[j]; j++) if (num % primes[j] == 0)
                    {
                        union(nums[i], primes[j]);
                        while (num % primes[j] == 0) num /= primes[j];
                    }
            }

            int[] cnts = new int[max + 1];
            for (int i = 0; i < len; i++) cnts[find(nums[i])]++;

            int result = 0;
            for (int i = 0; i <= max; i++) result = Math.Max(result, cnts[i]);
            return result;

            int find(int x)
            {
                if (uf[x] != x) uf[x] = find(uf[x]);
                return uf[x];
            }

            void union(int x, int y)
            {
                x = find(x); y = find(y);
                if (x == y) return;
                switch (rank[x] - rank[y])
                {
                    case > 0: uf[y] = x; break;
                    case < 0: uf[x] = y; break;
                    default: uf[y] = x; rank[x]++; break;
                }
            }

            static List<int> GetPrimes(int n)
            {
                List<int> result = [];
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
