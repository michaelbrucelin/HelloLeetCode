using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3377
{
    public class Solution3377 : Interface3377
    {
        /// <summary>
        /// DFS + 记忆化搜索 + 线性筛
        /// 
        /// 没写完，以后再写
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int MinOperations(int n, int m)
        {
            int up = 10;
            while (up <= m) up *= 10;
            HashSet<int> primes = [.. GetPrimes(up)];
            if (primes.Contains(m)) return -1;
            if (n == m) return n;

            int result = int.MaxValue;
            Dictionary<int, int> memory = new Dictionary<int, int>();
            return dfs(n, m, primes, memory);

            static int dfs(int x, int y, HashSet<int> set, Dictionary<int, int> memory)
            {
                if (x == y) return x;
                if (memory.TryGetValue(x, out int value)) return value;

                int result = int.MaxValue, _x, d, M1 = 10, M2 = 1;
                while (x >= M2)
                {
                    d = x % M1 / M2;
                    if (d != 9 && !set.Contains(_x = x + M2)) result = Math.Min(result, dfs(_x, y, set, memory));
                    if (d != 0 && !set.Contains(_x = x - M2)) result = Math.Min(result, dfs(_x, y, set, memory));
                    M1 *= 10; M2 *= 10;
                }

                if (result != int.MaxValue) result += x; else result = -1;
                memory.Add(x, result);
                return result;
            }

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
