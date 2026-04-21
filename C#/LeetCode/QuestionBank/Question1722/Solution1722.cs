using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1722
{
    public class Solution1722 : Interface1722
    {
        /// <summary>
        /// 并查集
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="allowedSwaps"></param>
        /// <returns></returns>
        public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
        {
            int n = source.Length;
            int[] uf = new int[n], rank = new int[n];
            for (int i = 0; i < n; i++) uf[i] = i;
            foreach (int[] swap in allowedSwaps) union(swap[0], swap[1]);

            Dictionary<int, Dictionary<int, int>> filter = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0, key; i < n; i++)
            {
                key = find(i);
                filter.TryAdd(key, new Dictionary<int, int>());
                filter[key].TryAdd(source[i], 0); filter[key][source[i]]++;
                filter[key].TryAdd(target[i], 0); filter[key][target[i]]--;
            }

            int result = 0;
            foreach (var map in filter.Values) foreach (int cnt in map.Values) if (cnt > 0) result += cnt;
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
        }
    }
}
