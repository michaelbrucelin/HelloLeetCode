using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0692
{
    public class Solution0692 : Interface0692
    {
        /// <summary>
        /// 字典 + 堆
        /// </summary>
        /// <param name="words"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            foreach (string word in words) if (map.TryGetValue(word, out int cnt)) map[word] = ++cnt; else map.Add(word, 1);
            Comparer<(string, int)> comparer = Comparer<(string s, int i)>.Create((x, y) => x.i != y.i ? x.i - y.i : string.CompareOrdinal(y.s, x.s));
            PriorityQueue<(string, int), (string, int)> pq = new PriorityQueue<(string, int), (string, int)>(comparer);
            foreach (var kv in map)
            {
                pq.Enqueue((kv.Key, kv.Value), (kv.Key, kv.Value));
                if (pq.Count > k) pq.Dequeue();
            }

            string[] result = new string[k];
            while (k > 0) result[--k] = pq.Dequeue().Item1;  // 题目限定一个有k个值
            return result;
        }
    }
}
