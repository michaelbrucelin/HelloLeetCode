using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0692
{
    public class Solution0692_2 : Interface0692
    {
        /// <summary>
        /// 快速选择
        /// </summary>
        /// <param name="words"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            foreach (string word in words) if (map.TryGetValue(word, out int cnt)) map[word] = ++cnt; else map.Add(word, 1);
            (string, int)[] items = new (string, int)[map.Count];
            int idx = 0;
            foreach (var kv in map) items[idx++] = (kv.Key, kv.Value);

            Comparer<(string, int)> comparer = Comparer<(string s, int i)>.Create((x, y) => x.i != y.i ? y.i - x.i : string.CompareOrdinal(x.s, y.s));
            int lo = 0, hi = items.Length - 1, p, len = items.Length;
            while ((p = partition(lo, hi)) != k - 1) if (p < k - 1) lo = p + 1; else hi = p - 1;
            Array.Sort(items, 0, p + 1, comparer);

            string[] result = new string[k];
            while (--k >= 0) result[k] = items[k].Item1;
            return result;

            int partition(int lo, int hi)
            {
                if (lo == hi) return lo;

                (string, int) v = items[lo], t;
                int i = lo, j = hi + 1;
                while (i < j)
                {
                    while (comparer.Compare(items[++i], v) < 0) if (i == hi) break;
                    while (comparer.Compare(items[--j], v) > 0) ;  // if (j == lo) break;
                    if (i >= j) break;
                    t = items[i]; items[i] = items[j]; items[j] = t;
                }
                items[lo] = items[j]; items[j] = v;

                return j;
            }
        }
    }
}
