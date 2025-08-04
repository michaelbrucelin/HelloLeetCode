using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2561
{
    public class Solution2561_2 : Interface2561
    {

        /// <summary>
        /// 贪心，计数统计
        /// 逻辑与Solution2561一样，Solution2561用SortedDictionary模拟了整个交换过程，比较慢，这里不模拟，只记录需要交换的成本
        /// </summary>
        /// <param name="basket1"></param>
        /// <param name="basket2"></param>
        /// <returns></returns>
        public long MinCost(int[] basket1, int[] basket2)
        {
            SortedDictionary<long, int> minpq = new SortedDictionary<long, int>();
            foreach (int x in basket1) if (minpq.ContainsKey(x)) minpq[x]++; else minpq.Add(x, 1);
            foreach (int x in basket2) if (minpq.ContainsKey(x)) minpq[x]--; else minpq.Add(x, -1);
            long total = 0;  // 总的交换次数
            foreach (int x in minpq.Values) if (x > 0)
                {
                    if ((x & 1) != 0) return -1; else total += x;
                }
            total >>= 1;

            long result = 0, min = minpq.First().Key << 1, cnt;
            foreach (long x in minpq.Keys) if (total > 0 && minpq[x] != 0)
                {
                    cnt = Math.Abs(minpq[x]) >> 1;
                    if (cnt <= total) total -= cnt; else { cnt = total; total = 0; }
                    result += Math.Min(x, min) * cnt;
                }

            return result;
        }
    }
}
