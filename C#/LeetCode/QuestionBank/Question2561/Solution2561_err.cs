using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2561
{
    public class Solution2561_err : Interface2561
    {
        /// <summary>
        /// 贪心
        /// 用最小的换最大的
        /// 用SortedDictionary来模拟双向有序队列（堆）
        /// 
        /// 思路没什么问题，只是考虑的不周全，例如：
        ///     basket1 = [8, 16, 88, 88, 100];
        ///     basket2 = [8, 16, 32, 32, 100];
        /// 按照下面的算法结果是32，但是结果应该是16，可以换2次，8 <--> 32, 8 <--> 88，而不是只换一次 32 <--> 88
        /// </summary>
        /// <param name="basket1"></param>
        /// <param name="basket2"></param>
        /// <returns></returns>
        public long MinCost(int[] basket1, int[] basket2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int x in basket1) if (map.ContainsKey(x)) map[x]++; else map.Add(x, 1);
            foreach (int x in basket2) if (map.ContainsKey(x)) map[x]++; else map.Add(x, 1);
            foreach (int x in map.Values) if ((x & 1) != 0) return -1;

            SortedDictionary<long, int> minpq1 = new SortedDictionary<long, int>(), minpq2 = new SortedDictionary<long, int>();
            foreach (int x in basket1) if (minpq1.ContainsKey(x)) minpq1[x]++; else minpq1.Add(x, 1);
            foreach (int x in basket2) if (minpq2.ContainsKey(x)) minpq2[x]++; else minpq2.Add(x, 1);

            long result = 0, key, keymin, keymax;
            while (minpq1.Count > 0 && minpq2.Count > 0)
            {
                while (minpq1.Count > 0 && minpq2.Count > 0 && (key = minpq1.First().Key) == minpq2.First().Key) switch (minpq1[key] - minpq2[key])
                    {
                        case > 0: minpq1[key] -= minpq2[key]; minpq2.Remove(key); break;
                        case < 0: minpq2[key] -= minpq1[key]; minpq1.Remove(key); break;
                        default: minpq1.Remove(key); minpq2.Remove(key); break;
                    }
                if (minpq1.Count == 0) break;
                while ((key = minpq1.Last().Key) == minpq2.Last().Key) switch (minpq1[key] - minpq2[key])
                    {
                        case > 0: minpq1[key] -= minpq2[key]; minpq2.Remove(key); break;
                        case < 0: minpq2[key] -= minpq1[key]; minpq1.Remove(key); break;
                        default: minpq1.Remove(key); minpq2.Remove(key); break;
                    }

                if (minpq1.First().Key < minpq2.First().Key)
                {
                    keymin = minpq1.First().Key;
                    keymax = minpq2.Last().Key;
                    switch (minpq1.First().Value - minpq2.Last().Value)
                    {
                        case > 0:
                            minpq2[keymax] >>= 1; minpq1.TryAdd(keymax, 0); minpq1[keymax] += minpq2[keymax];
                            minpq1[keymin] -= minpq2[keymax]; minpq2.Add(keymin, minpq2[keymax]);
                            result += keymin * minpq2[keymax];
                            break;
                        case < 0:
                            minpq1[keymin] >>= 1; minpq2.Add(keymin, minpq1[keymin]);
                            minpq2[keymax] -= minpq1[keymin]; minpq1.TryAdd(keymax, 0); minpq1[keymax] += minpq1[keymin];
                            result += keymin * minpq1[keymin];
                            break;
                        default:
                            minpq1[keymin] >>= 1; minpq2.Add(keymin, minpq1[keymin]);
                            minpq2[keymax] >>= 1; minpq1.TryAdd(keymax, 0); minpq1[keymax] += minpq2[keymax];
                            result += keymin * minpq1[keymin];
                            break;
                    }
                }
                else
                {
                    keymin = minpq2.First().Key;
                    keymax = minpq1.Last().Key;
                    switch (minpq2.First().Value - minpq1.Last().Value)
                    {
                        case > 0:
                            minpq1[keymax] >>= 1; minpq2.TryAdd(keymax, 0); minpq2[keymax] += minpq1[keymax];
                            minpq2[keymin] -= minpq1[keymax]; minpq1.Add(keymin, minpq1[keymax]);
                            result += keymin * minpq1[keymax];
                            break;
                        case < 0:
                            minpq2[keymin] >>= 1; minpq1.Add(keymin, minpq2[keymin]);
                            minpq1[keymax] -= minpq2[keymin]; minpq2.TryAdd(keymax, 0); minpq2[keymax] += minpq2[keymin];
                            result += keymin * minpq2[keymin];
                            break;
                        default:
                            minpq2[keymin] >>= 1; minpq1.Add(keymin, minpq2[keymin]);
                            minpq1[keymax] >>= 1; minpq2.TryAdd(keymax, 0); minpq2[keymax] += minpq1[keymax];
                            result += keymin * minpq2[keymin];
                            break;
                    }
                }
            }

            return result;
        }
    }
}
